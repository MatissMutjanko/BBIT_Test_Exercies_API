using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Resident
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonProperty("id")]
    public int Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("surname")]
    public string Surname { get; set; }
    
    [JsonProperty("personalId")]
    public string PersonalId{ get; set; }

    [JsonProperty("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonProperty("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("apartmentIds")]
    public List<int> ApartmentIds { get; set; } = new List<int>();

    public bool IsOwner { get; set; }

    public Resident(string name, string surname, string personalId, string dateOfBirth, string phoneNumber, string email, bool isOwner)
    {
        Name = name;
        Surname = surname;
        PersonalId = personalId;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        IsOwner = isOwner;
    }
}