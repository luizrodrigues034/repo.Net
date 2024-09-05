using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillsConfigurations : IEntityTypeConfiguration<UserSkills>
    {
        public void Configure(EntityTypeBuilder<UserSkills> builder)
        {

            builder
                .HasKey(p => p.Id);

        }
    }
}
