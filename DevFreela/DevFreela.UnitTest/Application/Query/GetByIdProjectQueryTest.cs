using DevFreela.Aplication.Querys.GetByIdProject;
using DevFreela.Aplication.ViewModel;
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
    public class GetByIdProjectQueryTest
    {
        //Nesse Teste criei propriedades de teste para utilizalas no periodo de teste,
        //as propriedades foram aquelas que nao estao disponiveis no construtor ou sao privadas no project,
        //entao criei elas separadas, adicionei um novo construtor no user para testar, nele tem apenas o fullname,
        //
        //Como GetByid retorna project, tambem transformei projects em project view model para comparar com o resultado esperado

        [Fact]
        public async Task Should_Convert_Projects_To_ProjectDetailsViewModel_In_Test()
        {
            // Arrange: Cria um objeto Projects com as informações necessárias
            var project = new Projects("Projeto Teste", "Descrição do Projeto", 1, 2, 1000m)
            {
                OwnedTest = new Users("Cliente Nome"),
                FreelanceTest = new Users("Freelancer Nome")
            };

            
            var mockProjectRepository = Substitute.For<IProjectRepository>();
            mockProjectRepository.GetDetailsById(Arg.Any<int>()).Returns(project);

            var getByIdProjectQuery = new GetByIdProjectQuery(1);
            var getByIdProjectQueryHandler = new GetByIdProjectQueryHandler(mockProjectRepository);
            //ACT
            var projectResult = await getByIdProjectQueryHandler.Handle(getByIdProjectQuery, new CancellationToken());

            
            var expectedViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.OwnedId,
                project.TotalCost,
                project.CreatedAt,
                project.OwnedTest.FullName,
                project.FreelanceTest.FullName
            );
            //Assert
            Assert.NotNull(projectResult);
             Assert.Equal( projectResult.Title, expectedViewModel.Title);
            
        }



    }
}
