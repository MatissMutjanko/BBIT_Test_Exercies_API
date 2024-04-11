namespace BBIT_Test_Exercises_House.Storage;

public interface IResidentService
{
    bool IsResidentUnique(Resident resident);
    Resident GetByNameSurname(string name, string surname);
    void EditResident(Resident resident);
    Resident GetById(int id);
    void AddApartment(string name, string surname, int apartmentId, bool isOwner);
    void DeleteApartment(string name, string surname, int apartmentId);
    void Add(Resident entity);
    void Delete(Resident entity);
    void Edit(Resident entity);
}