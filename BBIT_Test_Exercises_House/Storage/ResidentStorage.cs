using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class ResidentStorage
{
    private static AppDbContext _dbContext;

    public ResidentStorage(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static void AddResident(Resident resident)
    {
        _dbContext.Residents.Add(resident);
        _dbContext.SaveChanges();
    }

    public static bool IsResidentUnique(Resident resident)
    {
        if (_dbContext.Residents.Any(a => a.Name == resident.Name))
        {
            return false;
        }

        return true;
    }

    public static Resident GetByName(string name)
    {
        return _dbContext.Residents.FirstOrDefault(r => r.Name == name);
    }

    public static void RemoveResident(Resident resident)
    {
        var residentToRemove = _dbContext.Residents.FirstOrDefault(r => r.Name == resident.Name);
        if (residentToRemove != null)
        {
            _dbContext.Residents.Remove(residentToRemove);
            _dbContext.SaveChanges();
        }
    }

    public static void EditResident(Resident resident)
    {
        var residentToEdit = _dbContext.Residents.FirstOrDefault(r => r.Name == resident.Name);
        if (residentToEdit != null)
        {
            residentToEdit.Name = resident.Name;
            residentToEdit.Id = resident.Id;
            residentToEdit.Email = resident.Email;
            residentToEdit.PhoneNumber = resident.PhoneNumber;
            residentToEdit.Surname = resident.Surname;
            residentToEdit.DateOfBirth = resident.DateOfBirth;
            _dbContext.SaveChanges();
        }
    }
}