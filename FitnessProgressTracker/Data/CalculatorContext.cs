using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FitnessProgressTracker.Models
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext (DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        public DbSet<FitnessProgressTracker.Models.CalculatorModel> CalculatorModel { get; set; }
    }
}
