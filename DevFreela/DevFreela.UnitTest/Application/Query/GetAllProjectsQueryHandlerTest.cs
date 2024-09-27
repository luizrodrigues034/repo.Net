using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using DevFreela.Core.Repositories;
using DevFreela.Core.DTOs;
using DevFreela.Aplication.Querys.GetAllProjects;

namespace DevFreela.UnitTest.Application.Query
{
    public class GetAllProjectsQueryHandlerTest
    {
        [Fact]
        public async Task ThreeProjectReturnExecutedReturnThreeProjects()
        {
            //Arrange
            var project = new List<Projects>
            {
                new Projects("Titulo", "Descricao do Projeto", 1, 2, 10000),
                new Projects("Titulo", "Descricao do Projeto", 1, 2, 10000),
                new Projects("Titulo", "Descricao do Projeto", 1, 2, 10000)
            };
            var projectDto = project.Select(x => new ProjectDTO
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.GetAllAsync().Returns(projectDto);

            var getAllProjectQuery = new GetAllProjectsQuery();
            var getAllProjecQueryHandler = new GetAllProjectsQueryHandler(mockProjectRepository);

            //Act
            var projectViewModelList = await getAllProjecQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projectViewModelList.Count, project.Count);
        }
    }
}
