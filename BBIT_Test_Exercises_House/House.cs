using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BBIT_Test_Exercises_House;

public class House
{
    [Key]
    [JsonProperty("Id")]
    public int Id { get; set; }
    
    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("postalIndex")]
    public string PostalIndex { get; set; }

    public House(int id,int number, string street, string city, string country, string postalIndex)
    {
        Id = id;
        Number = number;
        Street = street;
        City = city;
        Country = country;
        PostalIndex = postalIndex;
    }
}