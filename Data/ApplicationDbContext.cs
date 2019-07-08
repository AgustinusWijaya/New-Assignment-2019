using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewAssignment2019.Models;
using System.Linq;

namespace NewAssignment2019.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ProjectSprint>()
            //    .HasOne(p => p.ProjectId)
            //    .WithMany()
            //    .HasForeignKey(p => p.ProjectId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(true);

            //modelBuilder.Entity<ProjectSprint>()
            //    .HasOne<Project>()
            //    .WithMany()
            //    .HasForeignKey(p => p.ProjectId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .IsRequired(true);

            modelBuilder.Entity<ProjectSprint>().HasAlternateKey(c => c.Code).HasName("IX_UniqueCode");
            modelBuilder.Entity<ProjectSprint>().HasAlternateKey(c => c.Name).HasName("IX_UniqueName");
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectFeature> ProjectFeature { get; set; }
        public DbSet<ProjectSprint> ProjectSprint { get; set; }
        public DbSet<ProjectBacklog> ProjectBacklog { get; set; }
    }
}
