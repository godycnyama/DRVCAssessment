using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.BetsAPI;
[Route("api/[controller]")]
[ApiController]
public class BetsController : ControllerBase
{
    // GET: api/<BetsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<BetsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<BetsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BetsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BetsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
