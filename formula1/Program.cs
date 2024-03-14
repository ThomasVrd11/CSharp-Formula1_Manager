using System;
using System.Collections.Generic;
using formula1;


public class Program
{
    static void Main(string[] args)
    {
        Gamesetup setup = new Gamesetup();
        setup.InitializeTeamsAndDrivers();

        System.Console.WriteLine("Initialization complete. Teams count: " + setup.AllTeams.Count);
        foreach (var team in setup.AllTeams)
        {
            System.Console.WriteLine($"Team: {team.Name}, Drivers count: {team.Drivers.Count}");
            System.Console.WriteLine($"Team's rating: {team.PerformanceFactor}");
            foreach (var driver in team.Drivers)
            {
                System.Console.WriteLine($"Driver: {driver.Name}");
                System.Console.WriteLine($"Driver's rating: {driver.Rating}");
            }
        }
    }
}