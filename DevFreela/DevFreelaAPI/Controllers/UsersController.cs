using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using MediatR;
using DevFreela.Aplication.Querys.GetUser;


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
        public async Task<IActionResult> GetById(int id)
        {   var query = new GetUserQuery(id);
            var user = await _mediator.Send(query);

            if (user == null) {return NotFound();}

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserModel request)
        {
            var id = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetById), new { id = id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LoginUserModel login)
        {
            return NoContent();
        }
    }
}
