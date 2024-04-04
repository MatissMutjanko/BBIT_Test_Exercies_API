using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class HouseStorage
{
    private static AppDbContext _dbContext;

    public HouseStorage(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static House GetHouseByNumber(int number)
    {
        return _dbContext.Houses.FirstOrDefault(house => house.Number == number);
        _dbContext.SaveChanges();
    }

    public static void AddHouse(House house)
    {
        _dbContext.Houses.Add(house);
        _dbContext.SaveChanges();
    }

    public static void DeleteHouse(House house)
    {
        _dbContext.Houses.Remove(house);
        _dbContext.SaveChanges();
    }
}