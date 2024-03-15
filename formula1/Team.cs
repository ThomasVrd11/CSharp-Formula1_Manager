using System.Collections.Generic;
using System;
using formula1;
using System.Linq;
//* THANK U FOR WATCHING MY CODE
// * EVERY 4 DAYS NEW PROJECT I HOPE U LIKED IT 
// * <33333333333 XOXO
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
        public int GetTotalPoints()
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