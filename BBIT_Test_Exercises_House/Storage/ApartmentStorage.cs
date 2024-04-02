namespace BBIT_Test_Exercises_House.Storage;

public class ApartmentStorage
{
    private static List<Apartment> _apartments = new List<Apartment>();
    private static int number;

    public static Apartment GetApartmentByNumber(int number)
    {
        return _apartments.FirstOrDefault(apartment => apartment.Number == number);
    }

    public static void AddApartment(Apartment apartment)
    {
        _apartments.Add(apartment);
    }

    public static void DeleteApartment(Apartment apartmentToDelete)
    {
        _apartments.Remove(apartmentToDelete);
    }

    public static void EditApartment(int number, Apartment apartment)
    {
        var existingApartment = _apartments.FirstOrDefault(apartment => apartment.Number == number);
        if (existingApartment != null)
        {
            existingApartment.Floor = apartment.Floor;
            existingApartment.NumberOfRooms = apartment.NumberOfRooms;
            existingApartment.NumberOfResidents = apartment.NumberOfResidents;
            existingApartment.FloorSpace = apartment.FloorSpace;
            existingApartment.LivingSpace = apartment.LivingSpace;
            existingApartment.House = apartment.House;
        }
    }
}