using System.Security.Claims;

namespace MVC.CRUD.Interface.Extensions;

public static class ViewExtension
{
    private const string DefaultDisplayName = "UserName - EndUser";
    private const string DefaultMembershipDate = "2024";
    public static string GetDisplayName(ClaimsPrincipal user)
    {
        if (user == null)
            return DefaultDisplayName;
        var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
        if (claim == null)
            claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        return claim?.Value ?? DefaultDisplayName;
    }

    public static string GetMembershipDate(ClaimsPrincipal user)
    {
        if (user == null)
            return DefaultMembershipDate;
        var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth);
        if (claim == null)
            claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth);

        return claim?.Value ?? DefaultMembershipDate;
    }

    public static string GetUserId(ClaimsPrincipal user)
    {
        if (user == null)
            return null;//I doubt this will ever be null cz by the time u get here youre already signedIn/authenticated
        var claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
        if (claim == null)
            claim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);

        return claim?.Value ?? null;
    }
}
