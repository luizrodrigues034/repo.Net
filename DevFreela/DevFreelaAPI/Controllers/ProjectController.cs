using Microsoft.AspNetCore.Mvc;
using DevFreela.API.Models;
using DevFreelaAPI.Models;
using Microsoft.Extensions.Options;

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
        public ProjectController(IOptions<OpeningTimeOption> option, ExempleClass exempleClass)
        {
            exempleClass.Name = "Luiz";
            _option = option.Value;
        }
        [HttpGet]
        //api/projects/query?=net core
        public IActionResult Get(string query)
        {
            return Ok();
        }

        //passando id como parametro, fazendo com que a url mostre o id do usuario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //NotFound
            //buscar o projeto
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProjectModel)
        {
            //cadastro objeto
            if (createProjectModel.Title.Length > 10)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = createProjectModel.Id }, createProjectModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
        {
            if (updateProjectModel.Description.Length > 20)
            {
                //atualizo o objeto
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound();
        }

        //api/projects/id/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        //api/projects/id/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return Ok();
        }

        //api/projects/id/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
