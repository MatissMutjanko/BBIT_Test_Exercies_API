using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Resident
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("surname")]
    public string Surname { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("apartment")]
    public Apartment Apartment { get; set; }

    public Resident(string name, string surname, string id, string dateOfBirth, string phoneNumber, string email, Apartment apartment)
    {
        Name = name;
        Surname = surname;
        Id = id;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        Apartment = apartment;
    }
}