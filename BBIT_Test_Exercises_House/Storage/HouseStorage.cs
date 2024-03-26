namespace BBIT_Test_Exercises_House.Storage;

public class HouseStorage
{
    private static List<House> _houses = new List<House>();
    private static int _number;

    public static House GetHouseByNumber(int number)
    {
        return _houses.FirstOrDefault(house => house.Number == number);
    }

    public static void AddHouse(House house)
    {
        _houses.Add(house);
    }

    public static void DeleteHouse(House house)
    {
        _houses.Remove(house);
    }
}