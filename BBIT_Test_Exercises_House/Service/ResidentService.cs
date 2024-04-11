using BBIT_Test_Exercises_House.DbContext;

namespace BBIT_Test_Exercises_House.Storage;

public class ResidentService : EntityService<Resident>, IResidentService
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

    public Resident GetByNameSurname(string name, string surname)
    {
        return _dbContext.Residents.FirstOrDefault(r => r.Name == name && r.Surname == surname);
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

    public void AddApartment(string name, string surname, int apartmentId, bool isOwner)
    {
        var resident =
            _dbContext.Residents.FirstOrDefault(r => r.Name == name && r.Surname == surname);
        if (resident != null)
        {
            if (isOwner)
            {
                resident.OwnedApartmentIds.Add(apartmentId);
            }
            else
            {
                resident.ApartmentIds.Add(apartmentId);
            }
        }

        _dbContext.SaveChanges();
    }

    public void DeleteApartment(string name, string surname, int apartmentId)
    {
        var resident =
            _dbContext.Residents.FirstOrDefault(r => r.Name == name && r.Surname == surname);

        if (resident.ApartmentIds.Any(id => id == apartmentId))
        {
            resident.ApartmentIds.Remove(apartmentId);
        }

        if (resident.OwnedApartmentIds.Any(id => id == apartmentId))
        {
            resident.OwnedApartmentIds.Remove(apartmentId);
        }

        _dbContext.SaveChanges();
    }
}