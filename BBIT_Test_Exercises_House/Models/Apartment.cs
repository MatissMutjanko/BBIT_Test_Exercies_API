using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class Apartment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int FloorSpace { get; set; }
    public int LivingSpace { get; set; }
    public int HouseId { get; set; }

    public House House { get; set; }
    
    [JsonIgnore]
    public ICollection<Resident> Residents { get; set; }
    
    public Apartment()
    {
    }

    public Apartment(int number, int floor, int numberOfRooms,int floorSpace,
        int livingSpace,int houseId)
    {
        Number = number;
        Floor = floor;
        NumberOfRooms = numberOfRooms;
        FloorSpace = floorSpace;
        LivingSpace = livingSpace;
        HouseId = houseId;
    }
}