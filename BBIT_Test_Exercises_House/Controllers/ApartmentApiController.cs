using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("apartment-api")]
[ApiController]
public class ApartmentApiController : ControllerBase
{
    private readonly IMapper _mapper;

    public ApartmentApiController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPut]
    [Route("apartment")]
    public IActionResult AddApartment(Apartment apartment)
    {
        if (!ApartmentStorage.IsApartmentUnique(apartment))
        {
            return Conflict();
        }

        var apartmentViewModel = _mapper.Map<ApartmentViewModel>(apartment);
        ApartmentStorage.AddApartment(apartment);
        return Created("", apartmentViewModel);
    }

    [HttpGet]
    [Route("apartment/{number}")]
    public IActionResult GetApartment(int number)
    {
        var apartment = ApartmentStorage.GetApartmentByNumber(number);
        var apartmentViewModel = _mapper.Map<ApartmentViewModel>(apartment);
        if (apartment == null)
        {
            return NotFound();
        }

        return Ok(apartmentViewModel);
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

        ApartmentStorage.EditApartment(number, updatedApartmentData);
        return Ok();
    }
}