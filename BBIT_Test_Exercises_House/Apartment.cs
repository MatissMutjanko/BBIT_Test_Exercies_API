using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Apartment
{
    [Key]
    [JsonProperty("Id")]
    public int Id { get; set; }
    
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
    
    [JsonProperty("houseId")]
    public int HouseId { get; set; }
    
    [ForeignKey("HouseId")]
    [JsonIgnore]
    public House House { get; set; }

    public Apartment() { }

    // Constructor with parameters
    public Apartment(int id, int number, int floor, int numberOfRooms, int numberOfResidents, int floorSpace, int livingSpace, int houseId)
    {
        Id = id;
        Number = number;
        Floor = floor;
        NumberOfRooms = numberOfRooms;
        NumberOfResidents = numberOfResidents;
        FloorSpace = floorSpace;
        LivingSpace = livingSpace;
        HouseId = houseId;
    }
}