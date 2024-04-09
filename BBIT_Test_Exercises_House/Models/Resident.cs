using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using NuGet.Packaging;

namespace BBIT_Test_Exercises_House;

public class Resident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PersonalId { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    [JsonIgnore]
    public List<Apartment> Apartments { get; set; }

    public Resident()
    {
    }

    public Resident(string name, string surname, string personalId, string dateOfBirth, string phoneNumber,
        string email)
    {
        Name = name;
        Surname = surname;
        PersonalId = personalId;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}