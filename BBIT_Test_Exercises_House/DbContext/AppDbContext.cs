using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


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
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        SeedData(modelBuilder);
        
        modelBuilder.Entity<House>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<House>()
            .HasMany<Apartment>(a => a.Apartments);
        
        modelBuilder.Entity<Apartment>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Apartment>()
            .HasMany<Resident>(r => r.Residents)
            .WithMany(a => a.Apartments);
        
        modelBuilder.Entity<Resident>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Resident>()
            .HasMany<Apartment>(a => a.Apartments)
            .WithMany(r => r.Residents);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("AppDbContextConnection"));
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var apartments = new List<Apartment>
        {
            new Apartment
            {
                Id = 1,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 5
            },
            new Apartment
            {
                Id = 2,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
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
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 5
            },
            new Apartment
            {
                Id = 4,
                Number = 1,
                Floor = 1,
                NumberOfRooms = 2,
                FloorSpace = 400,
                LivingSpace = 250,
                HouseId = 5
            }
        };

        modelBuilder.Entity<Apartment>().HasData(apartments);

        var houses = new List<House>
        {
            new House
            {
                Id = 5,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
            },
            new House
            {
                Id = 6,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
            },
            new House
            {
                Id = 7,
                Number = 2,
                Street = "street",
                City = "city",
                Country = "country",
                PostalIndex = "1234",
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
                Email = "epasts@Inbox.lv"
            },
            new Resident
            {
                Id = 9,
                Name = "Verners",
                Surname = "Calis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv"
            },
            new Resident
            {
                Id = 10,
                Name = "Latvietis",
                Surname = "uzvards",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv"
            },
            new Resident
            {
                Id = 11,
                Name = "Pauls",
                Surname = "Janis",
                PersonalId = "999999-99999",
                DateOfBirth = "09-05-1999",
                PhoneNumber = "22222222",
                Email = "epasts@Inbox.lv"
            }
        };

        modelBuilder.Entity<Resident>().HasData(residents);
    }
}