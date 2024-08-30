using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;

namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public UsersController(ExempleClass exempleClass)
        {
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginUserModel login)
        {
            return NoContent();
        }
    }
}
