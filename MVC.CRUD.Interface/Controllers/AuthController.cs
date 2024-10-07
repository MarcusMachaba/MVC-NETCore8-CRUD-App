using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.CRUD.Interface.Models.Entities;
using MVC.CRUD.Interface.Models.ViewModels;
using System;
using System.Net.Mail;

namespace MVC.CRUD.Interface.Controllers;

public class AuthController : Controller
{
    private readonly MVC.CRUD.Interface.ServiceHelpers.IAuthenticationService _authenticationService;
    protected INotyfService _notyf;
    private readonly ILogger<AuthController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public AuthController(MVC.CRUD.Interface.ServiceHelpers.IAuthenticationService authenticationService,
                          INotyfService notyf,
                          ILogger<AuthController> logger,
                          UserManager<User> userManager,
                          SignInManager<User> signInManager)
    {
        _authenticationService = authenticationService;
        _notyf = notyf;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    //Register GET
    public IActionResult Signup()
    {
        return View();
    }

    //Register POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Signup(User newUser)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    //Login GET
    public IActionResult Signin(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    //Login POST
    [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
    public async Task<IActionResult> Signin(SigninViewModel model, string returnUrl = null)
    {
        try
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userName = model.Email;
            if (IsValidEmail(model.Email))
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    userName = user.UserName;
                }
            }
            var authResult = await _authenticationService.AutenticateUser(model.Email, model.Password, model.RememberMe, returnUrl);//AutenticateAdmin
            if (authResult == null)
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            else
            if (!authResult.Successful)
            {
                ModelState.AddModelError("", authResult.ErrorMessage);
                return View(model);
            }
            else if (authResult.Successful)
            {
                _notyf.Success($"Logged in as {authResult.Data.Email}.");
                return returnUrl.Equals(Url.Content("~/")) ? RedirectToAction("Index", "CLients") : LocalRedirect(returnUrl);
            }
            //something blewup above.. Idk...error
            return View(model);
        }
        catch (Exception ex)
        {
            throw;
        }

    }
    public bool IsValidEmail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    //Logout POST
    public async Task<IActionResult> Signout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return RedirectToAction("Signin", "Auth");
        }
    }

}
