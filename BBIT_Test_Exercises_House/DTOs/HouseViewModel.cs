namespace BBIT_Test_Exercises_House.DTOs;

public class HouseViewModel
{
    public int Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalIndex { get; set; }
    public List<int> ApartmentIds { get; set; }
}