namespace BBIT_Test_Exercises_House;

public class Apartment
{
    public int number;
    public int floor;
    public int numberOfRooms;
    public int numberOfResidents;
    public int floorSpace;
    public int livingSpace;
    public House house;

    public Apartment(int number, int floor, int numberOfRooms, int numberOfResidents, int floorSpace, int livingSpace, House house)
    {
        number = number;
        floor = floor;
        numberOfRooms = numberOfRooms;
        numberOfResidents = numberOfResidents;
        floorSpace = floorSpace;
        livingSpace = livingSpace;
        house = house;
    }
}