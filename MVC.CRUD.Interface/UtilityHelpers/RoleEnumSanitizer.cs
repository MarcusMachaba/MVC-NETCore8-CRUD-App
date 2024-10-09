using MVC.CRUD.Interface.Models.Enums;

namespace MVC.CRUD.Interface.UtilityHelpers;

public static class RoleEnumSanitizer
{
    public static string SuperAdmin => Roles.SuperAdmin.ToString();
    public static string Admin => Roles.Admin.ToString();
    public static string Moderator => Roles.Moderator.ToString();
    public static string Basic => Roles.Basic.ToString();
}
