using LabsDB.Entity;
using Microsoft.EntityFrameworkCore;

namespace MainApp;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        // Database.Migrate();
    }

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<House> Houses { get; set; } = null!;
    public DbSet<Indication> Indications { get; set; } = null!;

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<House>().HasMany<Indication>().WithOne(r => r.House);
    //     var testHouses = new List<House>();
    //     var e = new Employee ("Test", "Test"){Id = 1};
    //     var house1 = new House {Id = 1};
    //     var ind0 = new Indication {Id = 1, EmployeeId = 1, HouseId = 1, Value = 100, Title = "Свет"};
    //     var ind1 = new Indication {Id = 2, EmployeeId = 1, HouseId = 1, Value = 200, Title = "Вода"};
    //     var house2 = new House {Id = 2};
    //     var ind3 = new Indication {Id = 4, EmployeeId = 1, HouseId = 2, Value = 200, Title = "Свет"};
    //     var ind4 = new Indication {Id = 3, EmployeeId = 1, HouseId = 2, Value = 400, Title = "Вода"};
    //     var l = new List<Indication>(new []{ind0, ind1, ind3, ind4});
    //     testHouses.Add(house1);
    //     testHouses.Add(house2);
    //     modelBuilder.Entity<Employee>().HasData(e);
    //     modelBuilder.Entity<House>().HasData(testHouses);
    //     modelBuilder.Entity<Indication>().HasData(l);
    //
    //
    //     base.OnModelCreating(modelBuilder);
    // }
}