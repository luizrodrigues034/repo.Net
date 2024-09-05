using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectsCommentConfiguration : IEntityTypeConfiguration<ProjectsComment>
    {
        public void Configure(EntityTypeBuilder<ProjectsComment> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Projects)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Users)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
