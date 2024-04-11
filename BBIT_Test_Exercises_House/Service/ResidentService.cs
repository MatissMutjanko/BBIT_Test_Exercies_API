using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class ResidentService : EntityService<Resident>
{

    public ResidentService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool IsResidentUnique(Resident resident)
    {
        if (_dbContext.Residents.Any(r => r.Name == resident.Name && r.Surname == resident.Surname))
        {
            return false;
        }

        return true;
    }

    public Resident GetByName(string name)
    {
        return _dbContext.Residents.FirstOrDefault(r => r.Name == name);
    }

    public void EditResident(Resident resident)
    {
        var residentToEdit =
            _dbContext.Residents.FirstOrDefault(r => r.Name == resident.Name && r.Surname == resident.Surname);
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