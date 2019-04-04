using Microsoft.EntityFrameworkCore;

namespace FitnessProgressTracker.Models
{
    /// <summary>
    /// This class is responsible for the creation of the Calculator context
    /// </summary>
    public class CalculatorContext : DbContext
    {
        /// <summary>
        /// This is the actual Calculator context
        /// </summary>
        /// <param name="options"></param>
        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///  DB seting of the Model
        /// </summary>
        public DbSet<FitnessProgressTracker.Models.CalculatorModel> CalculatorModel { get; set; }
    }
}
