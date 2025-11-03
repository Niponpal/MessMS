using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options):base(Options)
    {
    }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}
