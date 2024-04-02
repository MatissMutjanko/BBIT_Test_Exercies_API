namespace BBIT_Test_Exercises_House.Storage;

public class ResidentStorage
{
    public static List<Resident> _residents = new List<Resident>();

    public static void AddResident(Resident resident)
    {
        _residents.Add(resident);
    }

    public static Resident GetByName(string name)
    {
        return _residents.FirstOrDefault(r => r.Name == name);
    }

    public static void RemoveResident(Resident resident)
    {
        var residentToRemove = _residents.FirstOrDefault(r => r.Name == resident.Name);
        if (residentToRemove != null)
        {
            _residents.Remove(residentToRemove);
        }
    }

    public static void EditResident(Resident resident)
    {
        var residentToEdit = _residents.FirstOrDefault(r => r.Name == resident.Name);
        if (residentToEdit != null)
        {
            residentToEdit.Name = resident.Name;
            residentToEdit.Id = resident.Id;
            residentToEdit.Email = resident.Email;
            residentToEdit.PhoneNumber = resident.PhoneNumber;
            residentToEdit.Surname = resident.Surname;
            residentToEdit.DateOfBirth = resident.DateOfBirth;
        }
    }
}