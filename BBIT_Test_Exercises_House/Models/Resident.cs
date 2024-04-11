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
    public int ApartmentId { get; set; }
    public List<int> ApartmentIds { get; set; } = new List<int>();
    public List<int> OwnedApartmentIds { get; set; } = new List<int>();
    public bool IsOwner { get; set; }

    [JsonIgnore]
    public ICollection<Apartment>? Apartments { get; set; }

    public Resident()
    {
    }

    public Resident(string name, string surname, string personalId, string dateOfBirth, string phoneNumber,
        string email, int apartmentId, bool isOwner)
    {
        Name = name;
        Surname = surname;
        PersonalId = personalId;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        ApartmentId = apartmentId;
        IsOwner = isOwner;
        if (isOwner)
        {
            OwnedApartmentIds = new List<int> { apartmentId };
        }
        else
        {
            ApartmentIds = new List<int> { apartmentId };
        }
    }
}