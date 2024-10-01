using Microsoft.EntityFrameworkCore;
using MVC.CRUD.Interface.Models.Entities;

namespace MVC.CRUD.Interface.DAL;

public class CRUDContext : DbContext
{
    public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }
    public CRUDContext() { }

    public DbSet<User> Users { get; set; }
}

