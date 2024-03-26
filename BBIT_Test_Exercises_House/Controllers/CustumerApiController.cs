using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBIT_Test_Exercises_House.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustumerApiController : ControllerBase
    {
        // GET: api/<CustumerApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustumerApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustumerApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustumerApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustumerApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
