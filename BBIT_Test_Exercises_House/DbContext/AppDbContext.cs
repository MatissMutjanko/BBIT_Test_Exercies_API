using Microsoft.EntityFrameworkCore;

namespace BBIT_Test_Exercises_House.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Resident> Residents { get; set; }


    public AppDbContext()
    {
        this.Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=HousesDbContext.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call SeedData method to seed initial data
        SeedData(modelBuilder);
    }

    public void SeedData(ModelBuilder modelBuilder)
    {
        // Add initial data using Entity Framework Core APIs
        modelBuilder.Entity<House>().HasData(
            new House(1, "Brivibas", "Riga", "Latvia", "1446"),
            new House(2, "Stirnu", "Riga", "Latvia", "2456")
        );
        modelBuilder.Entity<Apartment>().HasData(
            new Apartment (1,  1,  2, 2, 400, 250,  1 ),
            new Apartment (2,  2,  2, 2, 400, 250,  1 ),
            new Apartment (1,  1,  2, 2, 400, 250,  2 ),
            new Apartment (2,  2,  2, 2, 400, 250,  2 )
        );
        modelBuilder.Entity<Resident>().HasData(
            new Resident("Austris", "Labinieks", "888888-88888", "05-09-1999", "2222222", "epasts@inbox.com",false),
            new Resident("Janis", "Paradnieks", "888888-88888", "05-09-1999", "2222222", "epasts@inbox.com", false),
            new Resident("Ivars", "Ozols", "888888-88888", "05-09-1999", "2222222", "epasts@inbox.com", false),
            new Resident("Grikis", "Risins", "888888-88888", "05-09-1999", "2222222", "epasts@inbox.com", true)
        );
    }
}