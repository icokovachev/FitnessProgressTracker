using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessProgressTracker.Models
{
    /// <summary>
    /// This is the model for the Exer_tracker functionality
    /// </summary>
    public class Exer_tracker
    {
        /// <summary>
        /// Initializing all variables for the exercise tracker model
        /// </summary>
        public int ID { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Display(Name = "Exercise")]
        public string exercise { get; set; }
        [Display(Name = "Repeats")]
        public int repeats { get; set; }
        [Display(Name = "With what load (in Kg)")]
        public int load { get; set; }
        [Display(Name = "Rest between repeats (in minutes)")]
        public int time_between { get; set; }
    }
}
