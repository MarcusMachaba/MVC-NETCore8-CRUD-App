namespace MVC.CRUD.Interface.Models;

public class WebResponse<T> where T : class
{
    public T Data { get; set; }
    public bool Successful { get; set; }
    public string ErrorMessage { get; set; }
}
