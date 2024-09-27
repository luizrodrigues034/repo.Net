using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTest.Core.Entities
{
    
    public class ProjectsTest
    {
        [Fact]
        public void TestStartProjectWorks() 
        {
            var project = new Projects("Titulo do teste", "Descricao do projeto", 7, 3, 1000);
            Assert.NotEmpty(project.Title);
            Assert.NotEmpty(project.Description);
            Assert.NotNull(project);
            
            Assert.Equal(ProjectsStatusEnum.Created, project.Status);

            project.Starting();
            Assert.Equal(ProjectsStatusEnum.InProgress, project.Status);
        }
    }
}
