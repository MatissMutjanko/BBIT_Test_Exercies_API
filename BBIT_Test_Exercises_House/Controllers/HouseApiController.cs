using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;
using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("admin-api")]
[ApiController]
public class HouseApiController : ControllerBase
{
    private readonly IMapper _mapper;

    public HouseApiController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPut]
    [Route("house")]
    public IActionResult AddHouse(House house)
    {
        if (HouseStorage.GetHouseByNumber(house.Number) != null)
        {
            return Conflict();
        }

        var hosueViewModel = _mapper.Map<HouseViewModel>(house);

        HouseStorage.AddHouse(house);
        return Created("", hosueViewModel);
    }

    [HttpGet]
    [Route("house/{number}")]
    public IActionResult GetHouse(int number)
    {
        var house = HouseStorage.GetHouseByNumber(number);
        if (house == null)
        {
            return NotFound();
        }

        var hosueViewModel = _mapper.Map<HouseViewModel>(house);

        return Ok(hosueViewModel);
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
}