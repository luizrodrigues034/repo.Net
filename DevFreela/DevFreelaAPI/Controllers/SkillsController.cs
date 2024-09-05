using DevFreela.Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;



namespace DevFreelaAPI.Controllers
{
    [Route("api/users")]
    public class SkillsController: ControllerBase
    {

        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService) 
        {
            _skillsService = skillsService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var skillList = _skillsService.GetSkills();
            return Ok(skillList);
        }
        
    }
}
