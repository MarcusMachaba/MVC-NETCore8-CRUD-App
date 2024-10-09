using MVC.CRUD.Interface.Models.CommonModelBase;

namespace MVC.CRUD.Interface.Models.Entities;

[System.ComponentModel.DataAnnotations.Schema.Table("Clients")]
public class Client: HasGIdRecord
{
    public string Name { get; set; }
    public string Platform { get; set; }
    public string Region { get; set; }
    public string Package { get; set; }
    public bool Active { get; set; }
}
