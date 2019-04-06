using System.ComponentModel.DataAnnotations;

namespace FitnessProgressTracker.Models
{
    /// <summary>
    /// This is the model for the Calculator
    /// </summary>
    public class CalculatorModel
    {
        /// <summary>
        /// initializing the variables for the calculator model
        /// </summary>
        public int ID { get; set; }
        [Display(Name = "Height (in cm)")]
        public double Height { get; set; }
        [Display(Name = "Weight (in kg)")]
        public double Weight { get; set; }
        [Display(Name = "Waist (in cm)")]
        public double Waist { get; set; }
        [Display(Name = "Hip (in cm)")]
        public double Hip { get; set; }
        [Display(Name = "Neck (in cm)")]
        public double Neck { get; set; }
        [Display(Name = "BMI")]
        public double BodyFatPer { get; set; }
        [Display(Name = "Body fat mass (in kg)")]
        public double BodyFatMass { get; set; }
        [Display(Name = "Lean mass (in kg)")]
        public double LeanMass { get; set; }
    }
}