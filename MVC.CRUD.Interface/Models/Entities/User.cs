using Microsoft.AspNetCore.Identity;
using MVC.CRUD.Interface.Models.CommonModelBase;
using System.ComponentModel.DataAnnotations;

namespace MVC.CRUD.Interface.Models.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("Users")]
public class User: IdentityUser
{

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string Surname { get; set; }

    [Range(0, 120)]
    public int? Age { get; set; }

    public string? Sex { get; set; }

    [Phone]
    public string? Mobile { get; set; }

    public bool Active { get; set; }

    public string? ProfilePicture { get; set; }
   
}
