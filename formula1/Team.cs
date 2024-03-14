using System.Collections.Generic;
using System;
using formula1;
using System.Linq;

namespace formula1
{
    public class Team
    {
        public string Name { get; set; }
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public double PerformanceFactor { get; set; }
        public Team(string name, double performanceFactor)
        {
            Name = name;
            PerformanceFactor = performanceFactor;
        }
        public int TotalPoints()
        {
            int TotalPoints = 0;
            foreach (var driver in Drivers)
            {
                TotalPoints += driver.Points;
            }
            return TotalPoints;
        }
    }
}