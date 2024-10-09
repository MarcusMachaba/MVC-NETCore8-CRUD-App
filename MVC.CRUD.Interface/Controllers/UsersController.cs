using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.CRUD.Interface.DAL;
using MVC.CRUD.Interface.Models.Entities;
using MVC.CRUD.Interface.Models.Enums;

namespace MVC.CRUD.Interface.Controllers;

[Authorize(Roles = nameof(Roles.SuperAdmin))]
public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly IRepository<User> _usersRepository;


    public UsersController(ILogger<UsersController> logger, IRepository<User> usersRepository)
    {
        _logger = logger;
        _usersRepository = usersRepository;
    }



    //Create GET
    public ActionResult Create()
    {
        return View();
    }

    //Create POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    //ReadAll GET
    public IActionResult Index()
    {
        return View();
    }

    //ReadOne GET
    public IActionResult Details(int id)
    {
        return View();
    }

    //UpdateOne GET
    public ActionResult Edit(int id)
    {
        return View();
    }

    //UpdateOne POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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

    //DeleteOne GET
    public ActionResult Delete(int id)
    {
        return View();
    }

    //DeleteOne POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
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
}
