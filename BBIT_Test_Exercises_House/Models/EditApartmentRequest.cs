using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House;

public class EditApartmentRequest
{
    [FromRoute(Name = "id")]
    public int id { get; set; }

    [FromBody]
    public Apartment ApartmentData { get; set; }
}