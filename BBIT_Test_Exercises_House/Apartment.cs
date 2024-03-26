using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Apartment
{
    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("floor")]
    public int Floor { get; set; }

    [JsonProperty("numberOfRooms")]
    public int NumberOfRooms { get; set; }

    [JsonProperty("numberOfResidents")]
    public int NumberOfResidents { get; set; }

    [JsonProperty("floorSpace")]
    public int FloorSpace { get; set; }

    [JsonProperty("livingSpace")]
    public int LivingSpace { get; set; }

    [JsonProperty("house")]
    public House House { get; set; }

    public Apartment(int number, int floor, int numberOfRooms, int numberOfResidents, int floorSpace, int livingSpace, House house)
    {
        Number = number;
        Floor = floor;
        NumberOfRooms = numberOfRooms;
        NumberOfResidents = numberOfResidents;
        FloorSpace = floorSpace;
        LivingSpace = livingSpace;
        House = house;
    }
}