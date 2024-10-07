using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using MVC.CRUD.Interface.DAL;
using MVC.CRUD.Interface.Models;
using MVC.CRUD.Interface.Models.Entities;
using MVC.CRUD.Interface.UtilityHelpers;
using System.Security.Claims;


namespace MVC.CRUD.Interface.ServiceHelpers;

public interface IAuthenticationService
{
    Task<WebResponse<User>> AutenticateUser(string username, string password, bool rememberMe, string returnUrl);
    Task<(string error, bool successful)> CreateUser(User model, long userId);
}

public class AuthenticationService : IAuthenticationService
{
    private readonly IRepository<User> _userRepository;
    private ILogger<AuthenticationService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    protected INotyfService _notyf;
    public AuthenticationService(IRepository<User> userRepository,
                                ILogger<AuthenticationService> logger,
                                UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                INotyfService notyf)
    {
        _userRepository = userRepository;
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _notyf = notyf;
    }


    private (string token, DateTime exipry) GenerateJwtToken(User user)
    {
        return MVC.CRUD.Interface.UtilityHelpers.Utility.GenerateJwtToken(user.UserName, "User");
    }

    public async Task<WebResponse<User>> AutenticateUser(string username, string password, bool rememberMe, string returnUrl)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(username);
            //if (user == null || !ApplicationPasswordEncryption.PasswordIsMatch(password, user.PasswordHash))
            //    return new WebResponse<ClientPortalUser>
            //    {
            //        Successful = false,
            //        ErrorMessage = "Invalid Login Credentials"
            //    };
            if (user == null)
            {
                _notyf.Error("Email / Username Not Found.");
                return new WebResponse<User>
                {
                    Successful = false,
                    ErrorMessage = "Invalid Login Credentials"
                };
            }


            //This blocks login for users with uncomfirmed/non-activated email accounts
            var userMailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            if (string.IsNullOrEmpty(user.Id.ToString()) || !userMailConfirmed || user == null)
            {
                _notyf.Error("Email Not Confirmed.");
                return new WebResponse<User>
                {
                    Successful = false,
                    ErrorMessage = "Invalid login attempt"
                };
            }
            else
            {
                // This doen't count login failures towards lockout only two factor authentication
                // To enable password failures to trigger lockout, change to shouldLockout: true
                //var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);

                var result = await _signInManager.CanSignInAsync(user);
                if (result)//result.Succeeded
                {
                    //_logger.LogInformation("User {Email} logged in at {Time} via Identity-PasswordSignInAsync.",user.Email, DateTime.UtcNow);
                    _logger.LogInformation("User {Email} can signIn, Checked at {Time} via Identity-CanSignInAsync.", user.Email, DateTime.UtcNow);
                    //return RedirectToLocal(returnUrl);

                    var claims = new[]
                    {
                            //new Claim(ClaimTypes.Role, user.),
                            new Claim(ClaimTypes.Name, user.FirstName),
                            new Claim(ClaimTypes.GivenName, $"{user.FirstName}, {user.Surname}"),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Sid, user.Id.ToString()),
                        };
                    var identity = new ClaimsIdentity(claims);//, CookieAuthenticationDefaults.AuthenticationScheme

                    await _signInManager.SignInWithClaimsAsync(user, true, claims);

                    var isSignedIn = _signInManager.IsSignedIn(new ClaimsPrincipal(identity));//for some odd reason always returns false even when signin was a success above
                    _logger.LogInformation("User {Email} logged in at {Time} via _signInManager.SignInWithClaimsAsync ++ claims with custom user data.", user.Email, DateTime.UtcNow);
                    return new WebResponse<User>
                    {
                        Data = user,
                        Successful = true
                    };
                }
                var twoFactorEnabled = await _userManager.GetTwoFactorEnabledAsync(user);
                if (twoFactorEnabled)//result.RequiresTwoFactor
                {
                    _logger.LogInformation("Login requires two-factor auth.");
                    //RedirectToAction("LoginWith2fa", "Account", new { returnUrl, rememberMe });

                }
                if (await _userManager.IsLockedOutAsync(user))//result.IsLockedOut
                {
                    //var rc = new RequestContext(context, new RouteData());
                    //var urlHelper = new UrlHelper(rc);
                    //context.Response.Redirect(urlHelper.Action(actionName), false);
                    _notyf.Warning("User account locked out.");
                    _logger.LogWarning("User account is locked out.");
                    //RedirectToAction("Lockout", "Account");
                }
                return new WebResponse<User>
                {
                    Successful = false,
                    ErrorMessage = "Invalid login attempt"//Should be, user is not allowed to login/does not support signIn func
                };
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }
    public async Task<(string error, bool successful)> CreateUser(User model, long userId)
    {
        if (model == null)
            return ("Invalid Data", false);

        try
        {
            var stringPassword = model.PasswordHash;
            model.PasswordHash = ApplicationPasswordEncryption.EncryptPassword(model.PasswordHash);
            await _userRepository.InsertAsync(model);
            //model.Application.ClientUserId = addedClient.Id;
            //var addedApplication = await _repository.AddAsync(model.Application);
            var addedUser = _userRepository.Search(x=>x.Id == model.Id).ToList();
            if (!string.IsNullOrEmpty(addedUser.FirstOrDefault()?.FirstName))
            {
                //var mailSent = await _mailMessagingService.SendAccountCreatedMailMessage(addedClient, stringPassword, addedApplication);
                //await _cacheRepository.CacheItem(GenerateUserCacheKey(addedUser.ClientSystemId), addedUser);

                //var applications = (await _cacheRepository.GetCachedItemsList<ClientApiApplication>(nameof(ClientApiApplication))).ToList();
                //applications.Add(addedApplication);
                //await _cacheRepository.CacheItemList(nameof(ClientApiApplication), applications);

                //return ($"Client Application Successfully Created, {(mailSent ? "Credentials Have been mailed" : "Credential mail sending failed, Password is " + stringPassword)}", true);
                return ($"User Successfully Created", true);
            }
            return ("There was an error adding the data to the database", false);
        }
        catch (Exception e)
        {
            return ("Error Creating/Registering User (persistence).", false);
            throw;
        }
    }

}
