namespace BBIT_Test_Exercises_House.Storage;

public interface IHouseService
{
    void EditHouse(int id, House house);
    House GetById(int id);
    void Add(House entity);
    void Delete(House entity);
    void Edit(House entity);
}