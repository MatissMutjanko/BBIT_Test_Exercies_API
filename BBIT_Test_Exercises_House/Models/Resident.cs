using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using NuGet.Packaging;

namespace BBIT_Test_Exercises_House;

public class Resident
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PersonalId { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<int> ApartmentIds { get; set; } = new List<int>();
    public bool IsOwner { get; set; }

    public Resident()
    {
    }

    public Resident(int id, string name, string surname, string personalId, string dateOfBirth, string phoneNumber,
        string email, IEnumerable<int> apartmentIds, bool isOwner)
    {
        Id = id;
        Name = name;
        Surname = surname;
        PersonalId = personalId;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        ApartmentIds.AddRange(apartmentIds);
        IsOwner = isOwner;
    }
}