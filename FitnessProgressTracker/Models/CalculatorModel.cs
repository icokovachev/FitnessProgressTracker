﻿using System.ComponentModel.DataAnnotations;

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
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public double Neck { get; set; }
        [Display(Name = "BMI")]
        public double BodyFatPer { get; set; }
        [Display(Name = "Body fat mass")]
        public double BodyFatMass { get; set; }
        [Display(Name = "Lean mass")]
        public double LeanMass { get; set; }
    }
}