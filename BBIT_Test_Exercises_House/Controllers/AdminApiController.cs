using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("admin-api")]
[ApiController]
public class AdminApiController : ControllerBase
{
    [HttpPut]
    [Route("house")]
    public IActionResult AddHouse(House house)
    {
        HouseStorage.AddHouse(house);
        return Created();
    }

    [HttpGet]
    [Route("house/{number}")]
    public IActionResult GetHouse(int number)
    {
        var house = HouseStorage.GetHouseByNumber(number);
        if (house == null)
        {
            var houseNew = new House(1, "mellenu", "riga", "Latvija", "1234");
            return Ok(houseNew);
        }

        return Ok(house);
    }

    [HttpDelete]
    [Route("house/{number}")]
    public IActionResult DeleteHouse(int number)
    {
        var houseToDelete = HouseStorage.GetHouseByNumber(number);
        if (houseToDelete == null)
        {
            return NotFound();
        }

        HouseStorage.DeleteHouse(houseToDelete);
        return Ok();
    }
    
    [HttpPut]
    [Route("apartment")]
    public IActionResult AddApartment(Apartment apartment)
    {
        ApartmentStorage.AddApartment(apartment);
        return Created();
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
    
    [HttpPut]
    [Route("resident")]
    public IActionResult AddResident(Resident resident)
    {
        ResidentStorage.AddResident(resident);
        return Created();
    }
    
    [HttpGet]
    [Route("resident/{name}")]
    public IActionResult GetResident(string name)
    {
        var resident = ResidentStorage.GetByName(name);
        if (resident == null)
        {
            return NotFound();
        }

        return Ok(resident);
    }
    
    [HttpDelete]
    [Route("resident/{name}")]
    public IActionResult DeleteResident(string name)
    {
        var residenToRemove = ResidentStorage.GetByName(name);
        if (residenToRemove == null)
        {
            return NotFound();
        }
        ResidentStorage.RemoveResident(residenToRemove);
        return Ok();
    }
    
    [HttpPost]
    [Route("resident/{resident}")]
    public IActionResult EditApartment([FromBody] Resident resident)
    {
        var residentToEdit = ResidentStorage.GetByName(resident.name);
        if (residentToEdit == null)
        {
            return NotFound();
        }
        ResidentStorage.EditResident(residentToEdit);
        return Ok();
    }
}