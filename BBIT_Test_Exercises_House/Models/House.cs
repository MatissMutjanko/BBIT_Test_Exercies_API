using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class House
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalIndex { get; set; }
    public List<int> ApartmentIds { get; set; } = new List<int>();

    public House()
    {
    }

    public House(int id, int number, string street, string city, string country, string postalIndex,
        IEnumerable<int> apartmentIds)
    {
        Id = id;
        Number = number;
        Street = street;
        City = city;
        Country = country;
        PostalIndex = postalIndex;
        ApartmentIds.AddRange(apartmentIds);
    }
}