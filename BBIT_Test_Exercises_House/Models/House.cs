using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using NuGet.Packaging;

namespace BBIT_Test_Exercises_House;

public class House
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostalIndex { get; set; }
    
    [ForeignKey("Apartment")]
    public int? ApartmentId { get; set; }
    
    [JsonIgnore]
    public ICollection<Apartment> Apartments { get; set; }
    public House()
    {
        Apartments = new List<Apartment>();
    }

    public House(int number, string street, string city, string country, string postalIndex,
        List<Apartment> apartments)
    {
        Number = number;
        Street = street;
        City = city;
        Country = country;
        PostalIndex = postalIndex;
        Apartments = apartments;
    }
}