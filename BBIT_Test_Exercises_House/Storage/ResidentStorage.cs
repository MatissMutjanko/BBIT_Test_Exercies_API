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
        return _residents.FirstOrDefault(r => r.name == name);
    }

    public static void RemoveResident(Resident resident)
    {
        var residentToRemove = _residents.FirstOrDefault(r => r.name == resident.name);
        if (residentToRemove != null)
        {
            _residents.Remove(residentToRemove);
        }
    }

    public static void EditResident(Resident resident)
    {
        var residentToEdit = _residents.FirstOrDefault(r => r.name == resident.name);
        if (residentToEdit != null)
        {
            residentToEdit.name = resident.name;
            residentToEdit.apartment = resident.apartment;
            residentToEdit.id = resident.id;
            residentToEdit.email = resident.email;
            residentToEdit.phoneNumber = resident.phoneNumber;
            residentToEdit.surname = resident.surname;
            residentToEdit.dateOfBirth = resident.dateOfBirth;
        }
    }
}