using DevFreela.Aplication.Querys.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTest.Application.Query
{
    public  class GetAllSkillsQueryHandlerTest
    {
        [Fact]
        public async Task ThreeSkillsUserReturnExecutedReturnedThreeSkillsUser()
        {
            //Assert
            var skills = new List<Skills>
            {
                new Skills(1, "c#"),
                new Skills(2, ".net"),
                new Skills(3, "asp.net")
            };
            var skillsDto = skills.Select(x => new SkillsDTO
            {
                Id = x.Id,
                Description = x.Description
            }).ToList();
            var mockSkillsRepositoty = Substitute.For<ISkillsRepository>();
            mockSkillsRepositoty.GetSkillsAsync().Returns(skillsDto);

            var getAllSkillsQuery = new GetAllSkillsQuery();
            var getAllSkillsQueryHandler = new GetAllSkillsQueryHandler(mockSkillsRepositoty);

            //Act
            var skillsViewModel = await getAllSkillsQueryHandler.Handle(getAllSkillsQuery, new CancellationToken());
            
            //Assert
            Assert.NotNull(skillsViewModel);
            Assert.Equal(skillsViewModel.Count, skillsDto.Count);
            Assert.NotEmpty(skillsDto);

            mockSkillsRepositoty.Received(1).GetSkillsAsync();



        }
    }
}
