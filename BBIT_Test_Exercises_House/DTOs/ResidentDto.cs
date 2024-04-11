namespace BBIT_Test_Exercises_House.DTOs;

public class ResidentDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PersonalId { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<int> ApartmentIds { get; set; }
    public List<int> OwnedApartmentIds { get; set; }
    public bool IsOwner { get; set; }
}