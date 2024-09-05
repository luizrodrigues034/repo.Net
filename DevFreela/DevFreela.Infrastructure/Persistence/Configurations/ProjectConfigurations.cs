using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {


            builder
            //Definicao de chave primaria
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Freelance)              // Relaciona a entidade Freelancer
                .WithMany(p => p.FreelanceProjects)
                .HasForeignKey(p => p.FreelanceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Owned)
                .WithMany(p => p.OwnedProjects)
                .HasForeignKey(p => p.OwnedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.TotalCost)
                .HasPrecision(14, 2);
        
    }
    }
}
