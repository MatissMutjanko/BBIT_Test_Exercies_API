using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class ApartmentStorage
{
    private static AppDbContext _dbContext;

    public ApartmentStorage(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static Apartment GetApartmentByNumber(int number)
    {
        return _dbContext.Apartments.FirstOrDefault(apartment => apartment.Number == number);
    }

    public static bool IsApartmentUnique(Apartment apartment)
    {
        if (_dbContext.Apartments.Any(a => a.Number == apartment.Number))
        {
            return false;
        }

        return true;
    }

    public static void AddApartment(Apartment apartment)
    {
        _dbContext.Apartments.Add(apartment);
        _dbContext.SaveChanges();
    }

    public static void DeleteApartment(Apartment apartmentToDelete)
    {
        _dbContext.Apartments.Remove(apartmentToDelete);
        _dbContext.SaveChanges();
    }

    public static void EditApartment(int number, Apartment apartment)
    {
        var existingApartment = _dbContext.Apartments.FirstOrDefault(apartment => apartment.Number == number);
        if (existingApartment != null)
        {
            existingApartment.Floor = apartment.Floor;
            existingApartment.NumberOfRooms = apartment.NumberOfRooms;
            existingApartment.FloorSpace = apartment.FloorSpace;
            existingApartment.LivingSpace = apartment.LivingSpace;
            existingApartment.House = apartment.House;
            _dbContext.SaveChanges();
        }
    }
}