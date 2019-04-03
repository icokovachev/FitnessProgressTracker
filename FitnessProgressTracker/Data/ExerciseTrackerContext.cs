using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitnessProgressTracker.Models
{
    public class ExerciseTrackerContext : DbContext
    {
        public ExerciseTrackerContext (DbContextOptions<ExerciseTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessProgressTracker.Models.Exer_tracker> Exer_tracker { get; set; }
    }
}
