namespace MVC.CRUD.Interface.Models.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("UserRoles")]
public class UserRole
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}
