using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using MediatR;
using DevFreela.Aplication.Querys.GetUser;
using DevFreela.Aplication.Commands.CreateUser;
using DevFreela.Aplication.Commands.LoginUserCommand;
using Microsoft.AspNetCore.Authorization;


namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {   var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);

            if (user == null) {return NotFound();}

            return Ok(user);

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViwerModel =  await _mediator.Send(command);
            if (loginUserViwerModel == null) {return BadRequest();}
            return Ok(loginUserViwerModel);
        }
        
    }
}
