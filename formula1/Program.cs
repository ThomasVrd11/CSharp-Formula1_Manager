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

        setup.FirstMessage();
        setup.Welcome();
        string playerName = setup.GetName();
        setup.DisplayTeams(playerName);



        

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






        int racesCount = 10;
    setup.RunSeason(setup.AllTeams, racesCount);
    setup.EndOfSeason(setup.AllTeams);
    }
}