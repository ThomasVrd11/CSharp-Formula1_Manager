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
        // * Thread.Sleep(3000);
        System.Console.Clear();
        System.Console.WriteLine("Welcome to the Formula 1 2024 season!");
        System.Console.WriteLine("Congratulations on winning the Formula 2 championship!");
        System.Console.WriteLine("You are now a Formula 1 driver!");
        System.Console.WriteLine("As a rookie, you will have to prove yourself in the upcoming season");
        System.Console.WriteLine("You will have to compete against the best drivers in the world.");
        System.Console.WriteLine("but first, you have to choose your driver name.");
        System.Console.WriteLine("What will your driver name be?");
        string playerName = "";
        while (playerName == "")
        {
            playerName = Console.ReadLine();
            if (playerName == "")
            {
                System.Console.WriteLine("Invalid name. Please try again.");
            }
        }

        // * System.Console.clear();
        System.Console.WriteLine($"Welcome to Formula 1, {playerName}!");
        System.Console.WriteLine("As a new driver in Formula 1, you will have to choose a team to drive for.");
        System.Console.WriteLine("Here are the teams and their performance ratings:");
        System.Console.WriteLine("-------------------------------------------------");
        foreach (var team in setup.AllTeams)
        {
            System.Console.WriteLine($"{team.Name} - {team.PerformanceFactor}");
        }
        System.Console.WriteLine("-------------------------------------------------");


        System.Console.WriteLine("The team you choose will determine your car's performance for the rest of the season.");
        System.Console.WriteLine("Choose wisely!");
        Team playerTeam = null;
        while (playerTeam == null)
        {
            System.Console.WriteLine("Choose your team by typing the team name:");
            string chosenTeam = Console.ReadLine();
            playerTeam = setup.AllTeams.Find(team => team.Name.ToLower() == chosenTeam.ToLower());
            if (playerTeam == null)
            {
                System.Console.WriteLine("Invalid team name. Please try again.");
            }
        }   
        System.Console.WriteLine($"You have chosen {playerTeam.Name}.");
        System.Console.WriteLine($"Great choice! You are now part of {playerTeam.Name}.");
        System.Console.WriteLine("-------------------------------------------------");
        // * Thread.Sleep(3000);
        // * System.Console.Clear();
        System.Console.WriteLine("Now, you have to choose the driver you will replace in the team.");
        System.Console.WriteLine("Here are the drivers you can choose from:");
        int indexDriver = 3;
        while (indexDriver == 3)
        {
            foreach (var driver in playerTeam.Drivers)
            {
                System.Console.WriteLine($"{driver.Name} - {driver.Rating}");
            }
            System.Console.WriteLine($"Choose the driver you will replace by typing the driver number:");
            System.Console.WriteLine($"You can choose from 0. {playerTeam.Drivers[0].Name} and 1. {playerTeam.Drivers[1].Name}");

            string replacingDriver = Console.ReadLine();
            indexDriver = Convert.ToInt32(replacingDriver);
            switch (indexDriver)
            {
                case 0:
                    playerTeam.Drivers[0].Name = playerName;
                    break;
                case 1:
                    playerTeam.Drivers[1].Name = playerName;
                    break;
                default:
                    System.Console.WriteLine("Invalid driver name. Please try again.");
                    indexDriver = 3;
                    break;
            }
        }
        System.Console.WriteLine($"You are now part of {playerTeam.Name} and your teammate is {playerTeam.Drivers[1 - indexDriver].Name}.");
        System.Console.WriteLine($"{playerTeam.Name} drivers for the season: {playerTeam.Drivers[0].Name}, {playerTeam.Drivers[1].Name}");
        System.Console.WriteLine($" drivers rating: {playerTeam.Drivers[0].Rating}, {playerTeam.Drivers[1].Rating}");  
    }
}