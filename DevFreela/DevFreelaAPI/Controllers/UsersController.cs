using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.InputModels;


namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _userService.GetUser(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserInputModel inputModel)
        {
            var user = _userService.AddUser(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = user }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginUserModel login)
        {
            return NoContent();
        }
    }
}
