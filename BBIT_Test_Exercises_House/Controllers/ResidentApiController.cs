using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("resident")]
[ApiController]
public class ResidentApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IResidentService _residentService;
    private readonly IApartmentService _apartmentService;

    public ResidentApiController(IMapper mapper, IResidentService residentService, IApartmentService apartmentService)
    {
        _mapper = mapper;
        _residentService = residentService;
        _apartmentService = apartmentService;
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddResident(Resident resident)
    {
        if (!_residentService.IsResidentUnique(resident))
        {
            return Conflict();
        }

        _residentService.Add(resident);
        var residentViewModel = _mapper.Map<ResidentDto>(resident);

        return Created("", residentViewModel);
    }

    [HttpGet]
    [Route("get/{name}/{surname}")]
    public IActionResult GetResident(string name, string surname)
    {
        var resident = _residentService.GetByNameSurname(name, surname);
        if (resident == null)
        {
            return NotFound();
        }

        var residentViewModel = _mapper.Map<ResidentDto>(resident);
        return Ok(residentViewModel);
    }

    [HttpDelete]
    [Route("delete/{name}/{surname}")]
    public IActionResult DeleteResident(string name, string surname)
    {
        var residenToRemove = _residentService.GetByNameSurname(name, surname);
        if (residenToRemove == null)
        {
            return NotFound();
        }

        _residentService.Delete(residenToRemove);
        return Ok();
    }

    [HttpPut]
    [Route("addApartment/{name}/{surname}/{apartmentId}/{isOwner}")]
    public IActionResult AddApartment(string name, string surname, int apartmentId, bool isOwner)
    {
        var resident = _residentService.GetByNameSurname(name, surname);
        var apartment = _apartmentService.GetById(apartmentId);
        if (resident == null || apartment == null)
        {
            return NotFound();
        }

        _residentService.AddApartment(name, surname, apartmentId, isOwner);
        
        var residentViewModel = _mapper.Map<ResidentDto>(resident);

        return Ok(residentViewModel);
    }
    
    [HttpDelete]
    [Route("deleteApartment/{name}/{surname}/{apartmentId}")]
    public IActionResult DeleteApartment(string name, string surname, int apartmentId)
    {
        var resident = _residentService.GetByNameSurname(name, surname);
        var apartment = _apartmentService.GetById(apartmentId);
        if (resident == null || apartment == null)
        {
            return NotFound();
        }
        _residentService.DeleteApartment(name, surname, apartmentId);
        
        var residentViewModel = _mapper.Map<ResidentDto>(resident);

        return Ok(residentViewModel);
    }
}