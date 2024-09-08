using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using Microsoft.Extensions.Options;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.InputModels;
using MediatR;
using DevFreela.Aplication.Commands.CreateProjectCommand;
using DevFreela.Aplication.Commands.CreateCommentCommand;
using DevFreela.Aplication.Commands.DeleteProjectCommand;
using DevFreela.Aplication.Commands.FinishProjectCommand;
using DevFreela.Aplication.Commands.StartProjectCommand;
using DevFreela.Aplication.Commands.UpdateProjectCommand;
using DevFreela.Aplication.Querys.GetAllProjects;
using DevFreela.Aplication.Querys.GetByIdProject;

namespace DevFreelaAPI.Controllers
{
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        //ctor

        //variavel privada somenteParaLeitura doTipoOpningTimeOption(Modelo/Option) _->pq eh privada
        private readonly OpeningTimeOption _option;
        //IOptions eh uma interface em que o valor recebido pode ser fornecido posteriormente por meio de injecao de dependencia,
        //injencao de dependencio eh feita no builder.Services.Configure<Option>(builder.Configuration.GetSection("sectionNoJson")
        
        
        private readonly IMediator _mediator;
        public ProjectController(IMediator mediator)
        {
            
            _mediator = mediator;
        }
        [HttpGet]
        //api/projects/query?=net core
        public async Task<IActionResult> Get( )
        {
            var query = new GetAllProjectsQuery();
            var projectList = await _mediator.Send(query);
            return Ok(projectList);
        }

        //passando id como parametro, fazendo com que a url mostre o id do usuario
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProjectQuery(id);
            var project = await _mediator.Send(query);
            if (project == null) 
            { 
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            //cadastro objeto
            if (command.Title.Length > 20)
            {
                return BadRequest();
            }
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = command }, command);
        }
        /*[HttpGet]
        public IActionResult GetSpecificProject(string query)
        {
            return NoContent();
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 20)
            {
                //atualizo o objeto
                return BadRequest();
            }
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);
            return Ok();
        }

        //api/projects/id/comments
        [HttpPost("{id}/comments")]

        //posta comentarios
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //api/projects/id/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return Ok();
        }

        //api/projects/id/finish
        [HttpPut("{id}/finish")]
        public async Task<ActionResult> Finish(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
