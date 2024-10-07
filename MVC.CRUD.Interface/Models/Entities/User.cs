using Microsoft.AspNetCore.Identity;
using MVC.CRUD.Interface.Models.CommonModelBase;
using System.ComponentModel.DataAnnotations;

namespace MVC.CRUD.Interface.Models.Entities;

public class User: IdentityUser
{
    //public int Id { get; set; }

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

    //public string Username { get; set; }
    //public string Password { get; set; }
    public string? ProfilePicture { get; set; }
   
}
