using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("house")]
[ApiController]
public class HouseApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IHouseService _houseService;

    public HouseApiController(IMapper mapper,IHouseService houseService)
    {
        _mapper = mapper;
        _houseService = houseService;
    }

    [HttpPost]
    [Route("add")]
    public IActionResult AddHouse(House house)
    {
        if (_houseService.GetById(house.Id) != null)
        {
            return Conflict();
        }
        _houseService.Add(house);

        var hosueViewModel = _mapper.Map<HouseDto>(house);
        return Created("", hosueViewModel);
    }

    [HttpGet]
    [Route("get/{number}")]
    public IActionResult GetHouse(int number)
    {
        var house = _houseService.GetById(number);
        if (house == null)
        {
            return NotFound();
        }

        var hosueViewModel = _mapper.Map<HouseDto>(house);

        return Ok(hosueViewModel);
    }

    [HttpDelete]
    [Route("house/{id}")]
    public IActionResult DeleteHouse(int id)
    {
        var houseToDelete = _houseService.GetById(id);
        if (houseToDelete == null)
        {
            return NotFound();
        }

        _houseService.Delete(houseToDelete);
        return Ok();
    }

    //given hosue id it will change all the other variables as writen in body.
    [HttpPut]
    [Route("house/{house}")]
    public IActionResult EditApartment([FromBody] House house)
    {
        var houseToEdit = _houseService.GetById(house.Id);
        if (houseToEdit == null)
        {
            return NotFound();
        }

        _houseService.EditHouse(houseToEdit.Id, house);
        var residentViewModel = _mapper.Map<ResidentDto>(house);

        return Ok(residentViewModel);
    }
}