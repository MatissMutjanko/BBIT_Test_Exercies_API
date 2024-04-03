using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("resident-api")]
[ApiController]
public class ResidentApiController : ControllerBase
{
    private readonly IMapper _mapper;

    public ResidentApiController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPut]
    [Route("resident")]
    public IActionResult AddResident(Resident resident)
    {
        if (!ResidentStorage.IsResidentUnique(resident))
        {
            return Conflict();
        }

        var residentViewModel = _mapper.Map<ResidentViewModel>(resident);

        ResidentStorage.AddResident(resident);
        return Created("", residentViewModel);
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

        var residentViewModel = _mapper.Map<ResidentViewModel>(resident);
        return Ok(residentViewModel);
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

    //given resident name it will change all the other variables as writen in body.
    [HttpPost]
    [Route("resident/{resident}")]
    public IActionResult EditApartment([FromBody] Resident resident)
    {
        var residentToEdit = ResidentStorage.GetByName(resident.Name);
        if (residentToEdit == null)
        {
            return NotFound();
        }

        ResidentStorage.EditResident(residentToEdit);
        var residentViewModel = _mapper.Map<ResidentViewModel>(residentToEdit);

        return Ok(residentViewModel);
    }
}