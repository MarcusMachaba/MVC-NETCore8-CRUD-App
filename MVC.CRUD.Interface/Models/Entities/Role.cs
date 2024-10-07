using MVC.CRUD.Interface.Models.CommonModelBase;

namespace MVC.CRUD.Interface.Models.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("Roles")]
public class Role : HasGIdRecord
{
    public Role()
    {
    }
    public Role(string roleName)
    {
        Name = roleName;
    }

    public string Name { get; set; }
    public string NormalizedName { get; set; }


   

    public virtual ICollection<UserRole> UserRoles { get; set; }
}
