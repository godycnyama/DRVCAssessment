
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.PayoutsAPI;
[Route("api/[controller]")]
[ApiController]
public class PayoutsController : ControllerBase
{
    // GET: api/<PayoutsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<PayoutsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<PayoutsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<PayoutsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PayoutsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
