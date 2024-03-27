using BBIT_Test_Exercises_House.Storage;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers;

[Route("admin-api")]
[ApiController]
public class HouseApiController : ControllerBase
{
    [HttpPut]
    [Route("house")]
    public IActionResult AddHouse(House house)
    {
        if (HouseStorage.GetHouseByNumber(house.Number) != null)
        {
            return Conflict();
        }
        HouseStorage.AddHouse(house);
        return Created("", house);
    }

    [HttpGet]
    [Route("house/{number}")]
    public IActionResult GetHouse(int number)
    {
        var id = 1;
        var house = HouseStorage.GetHouseByNumber(number);
        if (house == null)
        {
            var houseNew = new House(id,1, "mellenu", "riga", "Latvija", "1234");
            id++;
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
}