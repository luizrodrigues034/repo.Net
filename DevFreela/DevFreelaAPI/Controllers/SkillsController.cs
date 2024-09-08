using DevFreela.Aplication.Querys.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;



namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class SkillsController: ControllerBase
    {

        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSkillsQuery();
            var skillList = await _mediator.Send(query);
            return Ok(skillList);
        }
        
    }
}
