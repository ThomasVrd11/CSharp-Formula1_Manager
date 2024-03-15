using System;
using System.Collections.Generic;
using formula1;
using System.Threading;


public class Program
{
    static void Main(string[] args)
    {
        Gamesetup setup = new Gamesetup();
        setup.InitializeTeamsAndDrivers();

        System.Console.Clear();
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("For a maximum experience, please play with the terminal as big as possible.");
        System.Console.WriteLine("-------------------------------------------------");
        Thread.Sleep(6000);
        System.Console.Clear();
        System.Console.WriteLine("Welcome to the Formula 1 2024 season!");
        System.Console.WriteLine("Congratulations on winning the Formula 2 championship!");
        System.Console.WriteLine("You are now a Formula 1 driver!");
        System.Console.WriteLine("As a new driver in Formula 1, you will have to choose a team to drive for.");
        System.Console.WriteLine("Here are the teams and their performance ratings:");
        Thread.Sleep(8000);
        System.Console.WriteLine("-------------------------------------------------");
        foreach (var team in setup.AllTeams)
        {
            System.Console.WriteLine($"{team.Name} - {team.PerformanceFactor}");
        }
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("The team you choose will determine your car's performance for the rest of the season.");
        System.Console.WriteLine("Choose wisely!");
        Thread.Sleep(5000);

    }
}