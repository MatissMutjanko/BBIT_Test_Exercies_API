using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("apartment-api")]
[ApiController]
public class ApartmentApiController : ControllerBase
{
    
    [HttpPut]
    [Route("apartment")]
    public IActionResult AddApartment(Apartment apartment)
    {
        ApartmentStorage.AddApartment(apartment);
        return Created("",apartment);
    }
    
    [HttpGet]
    [Route("apartment/{number}")]
    public IActionResult GetApartment(int number)
    {
        var apartment = ApartmentStorage.GetApartmentByNumber(number);
        if (apartment == null)
        {
            return NotFound();
        }

        return Ok(apartment);
    }
    
    [HttpDelete]
    [Route("apartment/{number}")]
    public IActionResult DeleteApartment(int number)
    {
        var apartmentToDelete = ApartmentStorage.GetApartmentByNumber(number);
        if (apartmentToDelete == null)
        {
            return NotFound();
        }
        ApartmentStorage.DeleteApartment(apartmentToDelete);
        return Ok();
    }
//given appartment number it will change all the other variables as writen in body.
    [HttpPost]
    [Route("apartment/{number}")]
    public IActionResult EditApartment(int number, [FromBody] Apartment updatedApartmentData)
    {
        var apartmentToEdit = ApartmentStorage.GetApartmentByNumber(number);
        if (apartmentToEdit == null)
        {
            return NotFound();
        }
        ApartmentStorage.EditApartment(number,updatedApartmentData);
        return Ok();
    }

}