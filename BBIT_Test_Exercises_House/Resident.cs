using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Resident
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("surname")]
    public string Surname { get; set; }
    
    [Key]
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("personalId")]
    public string PersonalId{ get; set; }

    [JsonProperty("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [ForeignKey("ApartmentId")]
    [JsonProperty("apartment")]
    public Apartment Apartment { get; set; }
    
    [JsonProperty("ApartmentId")]
    public int ApartmentId { get; set; }

    public bool isOwner { get; set; }

    public Resident(int id, string name, string surname, string personalId, string dateOfBirth, string phoneNumber, string email, int apartmentId)
    {
        Name = name;
        Surname = surname;
        Id = id;
        PersonalId = personalId;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        ApartmentId = apartmentId;
    }
}