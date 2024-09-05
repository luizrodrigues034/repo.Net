using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
       

    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) :base(options)
        {
            

    }
        //criar uma propiedade de lista proejto chamada projectsds, user user, skill skills
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<ProjectsComment> ProjectsComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
