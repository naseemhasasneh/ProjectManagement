using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<InvoicePaymentTerm> InvoicePaymentTerms{ get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProjectStatus> ProjectStatus{ get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectPhase>().HasOne(pp =>pp.Project)
                .WithMany(p => p.ProjectPhase)
                .HasForeignKey(pp=>pp.ProjectId);
            builder.Entity<ProjectPhase>().HasOne(pp =>pp.Phase)
               .WithMany(p => p.ProjectPhase)
               .HasForeignKey(pp => pp.PhaseId);
            builder.Entity<ProjectPhase>()
          .HasIndex(p => new { p.ProjectId, p.PhaseId }).IsUnique();

           builder.Entity<InvoicePaymentTerm>().HasKey(Ip => new {Ip.InvoiceId , Ip.PaymentTermId}); //compsite key
            builder.Entity<InvoicePaymentTerm>()
          .HasIndex(ipt=>ipt.PaymentTermId).IsUnique();
        }
    }
}
