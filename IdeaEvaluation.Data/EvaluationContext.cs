using IdeaEvaluations.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdeaEvaluation.Data
{
    public class EvaluationContext:DbContext
    {
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IdeaEvaluationMapping> IdeaEvaluationMapping { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=IdeaEvaluations;Trusted_Connection=True;");
        }
    }
}
