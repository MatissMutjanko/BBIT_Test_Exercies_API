using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Apartment
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public List<int> ResidentsIds { get; set; } = new List<int>();
    public int FloorSpace { get; set; }
    public int LivingSpace { get; set; }
    public int HouseId { get; set; }
    public House House { get; set; }

    public Apartment()
    {
    }

    public Apartment(int id, int number, int floor, int numberOfRooms, IEnumerable<int> residentIds, int floorSpace,
        int livingSpace, int houseId)
    {
        Id = id;
        Number = number;
        Floor = floor;
        NumberOfRooms = numberOfRooms;
        ResidentsIds.AddRange(residentIds);
        FloorSpace = floorSpace;
        LivingSpace = livingSpace;
        HouseId = houseId;
    }
}