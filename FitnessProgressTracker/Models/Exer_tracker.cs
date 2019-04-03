using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FitnessProgressTracker.Models
{
    public class Exer_tracker
    {
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
