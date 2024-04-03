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
            new House
            {
                Id = 1,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
                ApartmentIds = { 1, 2 }
            },
            new House
            {
                Id = 2,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
                ApartmentIds = { 1, 2 }
            },
            new House
            {
                Id = 3,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
                ApartmentIds = { 1, 2 }
            }
        );
        modelBuilder.Entity<Apartment>().HasData(
            new Apartment
            {
                Id = 1,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                ResidentsIds = new List<int> { 1, 2 },
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1
            },
            new Apartment
            {
                Id = 2,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                ResidentsIds = new List<int> { 1, 2 },
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1
            },
            new Apartment
            {
                Id = 3,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                ResidentsIds = new List<int> { 1, 2 },
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1
            },
            new Apartment
            {
                Id = 4,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                ResidentsIds = new List<int> { 1, 2 },
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1
            }
        );
        modelBuilder.Entity<Resident>().HasData(
            new Resident
            {
                Id = 1,
                Name = "Austris",
                Surname = "Paradnieks",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentIds = new List<int> { 1, 2, 3 },
                IsOwner = false
            },
            new Resident
            {
                Id = 2,
                Name = "Verners",
                Surname = "Calis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentIds = new List<int> { 1, 2, 3 },
                IsOwner = false
            }, 
            new Resident
            {
                Id = 3,
                Name = "Latvietis",
                Surname = "uzvards",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentIds = new List<int> { 1, 2, 3 },
                IsOwner = false
            }, 
            new Resident
            {
                Id = 4,
                Name = "Pauls",
                Surname = "Janis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentIds = new List<int> { 1, 2, 3 },
                IsOwner = false
            }
        );
    }
}