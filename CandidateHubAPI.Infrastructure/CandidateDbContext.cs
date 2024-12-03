using CandidateHubAPI.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CandidateHubAPI.Infrastructure
{
    public class CandidateDbContext : DbContext
    {
        // Add a parameterless constructor
        public CandidateDbContext() { }
        public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidate { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique(); // Ensure email is unique

            base.OnModelCreating(modelBuilder);
        }
    }
}
