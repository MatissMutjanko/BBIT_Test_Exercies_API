namespace BBIT_Test_Exercises_House;

public class Resident
{
    public string name;
    public string surname;
    public string id;
    public DateTime dateOfBirth;
    public string phoneNumber;
    public string email;
    public Apartment apartment;

    public Resident(string name, string surname, string id, DateTime dateOfBirth, string phoneNumber, string email, Apartment apartment)
    {
        name = name;
        surname = surname;
        id = id;
        dateOfBirth = dateOfBirth;
        phoneNumber = phoneNumber;
        email = email;
        apartment = apartment;
    }
}