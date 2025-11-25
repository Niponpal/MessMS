using Mess_Manager.Auth_IdentityModel;
using Mess_Manager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace Mess_Manager.Data;

public class ApplicationDbContext : IdentityDbContext<
    IdentityModel.User,
    IdentityModel.Role,
    long,
    IdentityModel.UserClaim,
    IdentityModel.UserRole,
    IdentityModel.UserLogin,
    IdentityModel.RoleClaim,
    IdentityModel.UserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
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



    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        // Configure Attendance-Staff relationship with cascade delete
        modelBuilder.Entity<Attendance>()
        .HasOne(a => a.Staff)
        .WithMany(s => s.Attendances)
        .HasForeignKey(a => a.StaffId)
        .OnDelete(DeleteBehavior.Cascade);

        // Configure Purchase-Inventory relationship with cascade delete
        modelBuilder.Entity<Purchase>()
        .HasOne(p => p.Inventory)
        .WithMany(i => i.Purchases)
        .HasForeignKey(p => p.InventoryId)
        .OnDelete(DeleteBehavior.Cascade);
        // Configure Meal-Member relationship with cascade delete
         modelBuilder.Entity<Meal>()
        .HasOne(m => m.Member)
        .WithMany(mem => mem.Meals)
        .HasForeignKey(m => m.MemberId)
        .OnDelete(DeleteBehavior.Cascade);
        // Configure Meal-Member relationship with cascade delete
         modelBuilder.Entity<Meal>()
        .HasOne(m => m.Member)
        .WithMany(mem => mem.Meals)
        .HasForeignKey(m => m.MemberId)
        .OnDelete(DeleteBehavior.Cascade);

        // Configure Payment-Member relationship with cascade delete
         modelBuilder.Entity<Payment>()
        .HasOne(p => p.Member)
        .WithMany(m => m.Payments)
        .HasForeignKey(p => p.MemberId)
        .OnDelete(DeleteBehavior.Cascade);


        // Purchase → Supplier (many-to-one)
          modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Supplier)
            .WithMany(s => s.Purchases)
            .HasForeignKey(p => p.SupplierId)
            .OnDelete(DeleteBehavior.Cascade);

        // Purchase → Inventory (many-to-one)
             modelBuilder.Entity<Purchase>()
            .HasOne(p => p.Inventory)
            .WithMany(i => i.Purchases)
            .HasForeignKey(p => p.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
        // Configure Attendance-Staff relationship with cascade delete
          modelBuilder.Entity<Attendance>()
        .HasOne(a => a.Staff)
        .WithMany(s => s.Attendances)
        .HasForeignKey(a => a.StaffId)
        .OnDelete(DeleteBehavior.Cascade);

        // Configure Purchase-Supplier relationship with cascade delete
         modelBuilder.Entity<Purchase>()
        .HasOne(p => p.Supplier)
        .WithMany(s => s.Purchases)
        .HasForeignKey(p => p.SupplierId)
        .OnDelete(DeleteBehavior.Cascade);



        base.OnModelCreating(modelBuilder);
        // Automatically apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        optionsBuilder.LogTo(Console.WriteLine);
        optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() }));
    }


 
}
