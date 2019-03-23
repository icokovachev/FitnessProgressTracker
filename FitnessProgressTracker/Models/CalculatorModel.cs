using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessProgressTracker.Models
{
    public class CalculatorModel
    {
        public double Height{get;set;}
        public double Weight{get;set;}
        public double Waist{get;set;}
        public double Hip {get;set;}
        public double Neck {get;set;}
        public double BodyFatPer { get; set; }
        public double BodyFatMass { get; set; }
        public double LeanMass { get; set; }
    }
}