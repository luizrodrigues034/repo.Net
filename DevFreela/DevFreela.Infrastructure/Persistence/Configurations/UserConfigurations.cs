using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasMany(p => p.Skills)
                .WithOne()
                .HasForeignKey(p => p.SkillsId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
