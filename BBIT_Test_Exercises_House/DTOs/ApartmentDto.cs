namespace BBIT_Test_Exercises_House.DTOs;

public class ApartmentDto
{
    public int Number { get; set; }
    public int Floor { get; set; }
    public int NumberOfRooms { get; set; }
    public int FloorSpace { get; set; }
    public int LivingSpace { get; set; }
    public List<int> ResidentsIds { get; set; }
}