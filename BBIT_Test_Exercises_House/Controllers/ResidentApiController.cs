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
    private readonly ResidentService _residentService;

    public ResidentApiController(IMapper mapper, ResidentService residentService)
    {
        _mapper = mapper;
        _residentService = residentService;
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddResident(Resident resident)
    {
        if (!_residentService.IsResidentUnique(resident))
        {
            return Conflict();
        }

        var residentViewModel = _mapper.Map<ResidentDto>(resident);

        _residentService.Add(resident);
        return Created("", residentViewModel);
    }

    [HttpGet]
    [Route("get/{name}")]
    public IActionResult GetResident(string name)
    {
        var resident = _residentService.GetByName(name);
        if (resident == null)
        {
            return NotFound();
        }

        var residentViewModel = _mapper.Map<ResidentDto>(resident);
        return Ok(residentViewModel);
    }

    [HttpDelete]
    [Route("delete/{name}")]
    public IActionResult DeleteResident(string name)
    {
        var residenToRemove = _residentService.GetByName(name);
        if (residenToRemove == null)
        {
            return NotFound();
        }

        _residentService.Delete(residenToRemove);
        return Ok();
    }

    //given resident name it will change all the other variables as writen in body.
    [HttpPut]
    [Route("edit/{resident}")]
    public IActionResult EditApartment([FromBody] Resident resident)
    {
        var residentToEdit = _residentService.GetByName(resident.Name);
        if (residentToEdit == null)
        {
            return NotFound();
        }

        _residentService.EditResident(residentToEdit);
        var residentViewModel = _mapper.Map<ResidentDto>(residentToEdit);

        return Ok(residentViewModel);
    }
}