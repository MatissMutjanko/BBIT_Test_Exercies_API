namespace BBIT_Test_Exercises_House.Storage;

public interface IApartmentService
{
    bool IsThereADuplicateApartment(Apartment apartment);
    void EditApartment(int number, Apartment apartment);
    Apartment GetById(int id);
    void Add(Apartment entity);
    void Delete(Apartment entity);
    void Edit(Apartment entity);
}