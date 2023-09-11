using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using PersonApi.Model;
using System;

namespace PersonApi.Controllers
{
  [ApiController]
  [Route("api")]
  public class PersonController : ControllerBase
  {
    [HttpPost("save")]
    public async Task<IActionResult> SaveData([FromBody] Person person)
    {
      if (person != null)
      {
        try
        {
          var data = JsonSerializer.Serialize(person);
          await System.IO.File.WriteAllTextAsync("person.json", data);
        }
        catch (NotSupportedException e)
        {
          return BadRequest(new { Message = "Cannot serilaize JSON", error = e.Message });
        }
        catch (Exception e)
        {
          return BadRequest(new { Message = "File failed to save", error = e.Message});
        }

        return Ok(new { Message = "Data saved successfully"});
      }
      else
      {
        return BadRequest();
      }
    }
  }
}
