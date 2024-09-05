using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using Microsoft.Extensions.Options;
using DevFreela.Aplication.Services.Interfaces;
using DevFreela.Aplication.InputModels;

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
        
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        //api/projects/query?=net core
        public IActionResult Get(string query)
        {
           var projectList = _projectService.GetAll(query);
            return Ok(projectList);
        }

        //passando id como parametro, fazendo com que a url mostre o id do usuario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null) 
            { 
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            //cadastro objeto
            if (inputModel.Title.Length > 20)
            {
                return BadRequest();
            }
            var project = _projectService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = project }, inputModel);
        }
        /*[HttpGet]
        public IActionResult GetSpecificProject(string query)
        {
            return NoContent();
        }*/

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProjectUpdateInputModels inputModel)
        {
            if (inputModel.Description.Length > 20)
            {
                //atualizo o objeto
                return BadRequest();
            }
            _projectService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Ok();
        }

        //api/projects/id/comments
        [HttpPost("{id}/comments")]

        //posta comentarios
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModels inputModel)
        {
            _projectService.CreateComment(inputModel);
            return NoContent();
        }

        //api/projects/id/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return Ok();
        }

        //api/projects/id/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }
}
