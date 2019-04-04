using Microsoft.EntityFrameworkCore;

namespace FitnessProgressTracker.Models
{
    /// <summary>
    /// The class is responsible for the creation of the ExeciseTrackerContext
    /// </summary>
    public class ExerciseTrackerContext : DbContext
    {
        /// <summary>
        /// This is the actual context
        /// </summary>
        /// <param name="options"></param>
        public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DB seting of the Exer_tracker model;
        /// </summary>
        public DbSet<FitnessProgressTracker.Models.Exer_tracker> Exer_tracker { get; set; }
    }
}
