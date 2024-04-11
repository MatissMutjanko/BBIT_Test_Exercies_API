using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace BBIT_Test_Exercises_House.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Resident> Residents { get; set; }
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        // this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);

        modelBuilder.Entity<Apartment>().HasOne(e => e.House)
            .WithMany(e => e.Apartments)
            .HasForeignKey(e => e.HouseId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Resident>().HasMany<Apartment>(e => e.Apartments);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AppDbContextConnection"));
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var apartments = new List<Apartment>
        {
            new Apartment
            {
                Id = 2,
                Number = 101,
                Floor = 1,
                NumberOfRooms = 2,
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1,
            },
            new Apartment
            {
                Id = 3,
                Number = 404,
                Floor = 1,
                NumberOfRooms = 2,
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1,
            },
            new Apartment
            {
                Id = 4,
                Number = 500,
                Floor = 1,
                NumberOfRooms = 2,
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 1,
            }
        };
        modelBuilder.Entity<Apartment>().HasData(apartments);

        var houses = new List<House>
        {
            new House
            {
                Id = 1,
                Number = 2,
                Street = "Cesu",
                City = "Riga",
                Country = "Latvija",
                PostalIndex = "1234",
            },
            new House
            {
                Id = 2,
                Number = 5,
                Street = "Brivibas",
                City = "Riga",
                Country = "Latvija",
                PostalIndex = "4311",
            },
            new House
            {
                Id = 3,
                Number = 60,
                Street = "Dzelzavas",
                City = "Riga",
                Country = "Latvija",
                PostalIndex = "5424",
            }
        };

        modelBuilder.Entity<House>().HasData(houses);

        var residents = new List<Resident>
        {
            new Resident
            {
                Id = 8,
                Name = "Austris",
                Surname = "Paradnieks",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentId = 1,
                IsOwner = true,
                ApartmentIds = new List<int> {  },
                OwnedApartmentIds = new List<int> { 1 }
            },
            new Resident
            {
                Id = 9,
                Name = "Verners",
                Surname = "Calis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentId = 2,
                IsOwner = true,
                ApartmentIds = new List<int> {  },
                OwnedApartmentIds = new List<int> { 2 }
            },
            new Resident
            {
                Id = 10,
                Name = "Latvietis",
                Surname = "uzvards",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentId = 3,
                IsOwner = false,
                ApartmentIds = new List<int> { 3 },
                OwnedApartmentIds = new List<int> { }
            },
            new Resident
            {
                Id = 11,
                Name = "Pauls",
                Surname = "Janis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv",
                ApartmentId = 3,
                IsOwner = true,
                ApartmentIds = new List<int> {  },
                OwnedApartmentIds = new List<int> { 3 }
            }
        };

        modelBuilder.Entity<Resident>().HasData(residents);
    }
}