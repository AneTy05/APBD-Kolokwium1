using Kolokwium_s28508.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s28508.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WashProgram> WashPrograms { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>(){
            new Customer { CustomerId = 1, FirstName = "Anna", LastName = "Nowak", PhoneNumber = "1111111111" },
            new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Kowalski", PhoneNumber = "2222222222" },
        });
        
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>(){
            new WashingMachine { WashingMachineId = 1, SerialNumber = "abc111", MaxWeight = 7.00f },
            new WashingMachine { WashingMachineId = 2, SerialNumber = "def222", MaxWeight = 6.00f },
        });
        
        modelBuilder.Entity<WashProgram>().HasData(new List<WashProgram>(){
            new WashProgram { ProgramId = 1, Name = "Standard", DurationMinutes = 120, TemperatureCelsius = 30 },
            new WashProgram { ProgramId = 2, Name = "Delicate", DurationMinutes = 60, TemperatureCelsius = 30 },
            new WashProgram { ProgramId = 3, Name = "Wool", DurationMinutes = 40, TemperatureCelsius = 20 }
        });
        
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>(){
            new AvailableProgram { AvailableProgramId = 1, WashinMachineId = 1, ProgramId = 1, Price = 10.99f },
            new AvailableProgram { AvailableProgramId = 2, WashinMachineId = 1, ProgramId = 2, Price = 15.99f },
            new AvailableProgram { AvailableProgramId = 3, WashinMachineId = 2, ProgramId = 3, Price = 100.00f }
        });
        
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>(){
            new PurchaseHistory { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-06-02"), Rating = 4},
            new PurchaseHistory { AvailableProgramId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-06-05"), Rating = 2 },
            new PurchaseHistory { AvailableProgramId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-06-05") }
        });
        
    }
}