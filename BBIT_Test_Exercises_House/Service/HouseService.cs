using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class HouseService : EntityService<House>
{
    private readonly AppDbContext _dbContext;

    public HouseService(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public void EditHouse(int id, House house)
    {
        var existingHouse = _dbContext.Houses.FirstOrDefault(h => h.Id == id);
        if (existingHouse != null)
        {
            existingHouse.Number = house.Number;
            existingHouse.City = house.City;
            existingHouse.Country = house.Country;
            existingHouse.Street = house.Street;
            existingHouse.Apartments = house.Apartments;
            existingHouse.PostalIndex = house.PostalIndex;
            _dbContext.SaveChanges();
        }
    }
}