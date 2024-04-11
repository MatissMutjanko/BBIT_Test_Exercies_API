using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class ApartmentService : EntityService<Apartment>
{
    
    public ApartmentService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool IsThereADuplicateApartment(Apartment apartment)
    {
        if (_dbContext.Apartments.Any(a => a.Id == apartment.Id && a.Id == apartment.Id))
        {
            return true;
        }

        return false;
    }

    public void EditApartment(int number, Apartment apartment)
    {
        var existingApartment = _dbContext.Apartments.FirstOrDefault(apartment => apartment.Number == number);
        if (existingApartment != null)
        {
            existingApartment.Floor = apartment.Floor;
            existingApartment.NumberOfRooms = apartment.NumberOfRooms;
            existingApartment.FloorSpace = apartment.FloorSpace;
            existingApartment.LivingSpace = apartment.LivingSpace;
            existingApartment.House = apartment.House;
            Edit(existingApartment);
        }
    }
}