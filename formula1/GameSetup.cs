using System.Collections.Generic;
using System;
using formula1;
// * this class will be used to initialize the teams and drivers
// * it will also be used to access all the teams and drivers in the game
// * comments are like that parce que avec BetterComments c'est plus joli et plus clair (uwu)
public class Gamesetup
{
    public List<Team> AllTeams { get; set; } = new List<Team>();
    public List<Driver> AllDrivers { get; set; } = new List<Driver>();
    private readonly int[] pointsForPosition = { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1 };
    public void InitializeTeamsAndDrivers()
    {
        //* Initialize datas for the teams and drivers inside of dictionaries
        //* making it more readable,easily editable and expandable
        //* teams : team names and performance rating
        //* driver : driver name, performance and team name
        var teamsData = new Dictionary<string, double>
        {
            {"Mercedes", 8.5},
            {"Ferrari", 9.2},
            {"Red Bull", 9.5},
            {"McLaren", 8.1},
            {"Alpine", 6.0},
            {"Aston Martin", 7.5},
            {"Alfa Romeo", 5.5},
            {"Haas", 5.0},
            {"Williams", 5.0},
            {"Alpha Tauri", 5.0}
        };

        var driverData = new List<(string Name, double Rating, string TeamName)>
        {
        ("Lewis Hamilton", 9.1, "Mercedes"),
        ("George Russell", 8.0, "Mercedes"),
        ("Carlos Sainz", 8.5, "Ferrari"),
        ("Charles Leclerc", 9.3, "Ferrari"),
        ("Max Verstappen", 9.5, "Red Bull"),
        ("Sergio Perez", 8.0, "Red Bull"),
        ("Daniel Ricciardo", 7.0, "Alpha Tauri"),
        ("Yuki Tsunoda", 7.0, "Alpha Tauri"),
        ("Lando Norris", 8.5, "McLaren"),
        ("Oscar Piastri", 8.0, "McLaren"),
        ("Fernando Alonso", 8.8, "Aston Martin"),
        ("Lance Stroll", 7.0, "Aston Martin"),
        ("Esteban Ocon", 7.5, "Alpine"),
        ("Pierre Gasly", 7.5, "Alpine"),
        ("Valtteri Bottas", 7.0, "Alfa Romeo"),
        ("Theo Pourchaire", 6.5, "Alfa Romeo"),
        ("Kevin Magnussen", 6.0, "Haas"),
        ("Nico Hulkenberg", 6.0, "Haas"),
        ("Alex Albon", 7.5, "Williams"),
        ("Logan Sargeant", 5.5, "Williams")
        };

        //* Dictionary to store the created Team objects, using team names as keys for easy access.
        var teams = new Dictionary<string, Team>();

        //* Create Team objects for each entry in teamsData and add them to the teams dictionary.
        foreach (var team in teamsData)
        {
            teams[team.Key] = new Team(team.Key, team.Value);
        }
        //* Debug line
        Console.WriteLine($"Team: {teams["Ferrari"].Name}, Rating: {teams["Ferrari"].PerformanceFactor}");

        //* Loop through each driver in driverData, create a Driver object, and add it to the correct team.
        foreach (var driver in driverData)
        {
            //* Check if the team exist
            if (teams.ContainsKey(driver.TeamName))
            {
                var newDriver = new Driver(driver.Name, driver.Rating);
                teams[driver.TeamName].Drivers.Add(newDriver);
            }
        }

        //* Add all Team objects from the teams dictionary to the AllTeams list for global access.
        AllTeams.AddRange(teams.Values);

        //* Loop through each team and add all of its drivers to the AllDrivers list for global access.
        foreach (var team in teams.Values)
        {
            foreach (var driver in team.Drivers)
            {
                AllDrivers.Add(driver);
            }
        }
    }
    public void SimulateRace(List<Team> teams)
    {
        Random random = new Random();
        var raceResults = new List<(Driver Driver, double performanceScore)>();

        foreach (var team in teams)
        {
            foreach (var driver in team.Drivers)
            {
                double performanceScore = (team.PerformanceFactor + driver.Rating) * random.NextDouble();
                raceResults.Add((driver, performanceScore));
            }
        }
        //* Sort drievrs by theur perfrmance score
        raceResults.Sort((x, y) => y.performanceScore.CompareTo(x.performanceScore));

        //* Displaying race results
        System.Console.WriteLine("\nRace results:");
        System.Console.WriteLine("-------------------------------------------------");
        for (int i = 0; i < raceResults.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {raceResults[i].Driver.Name} - {raceResults[i].performanceScore}");
            //* Award points to the drivers
            if (i < pointsForPosition.Length)
            {
                raceResults[i].Driver.Points += pointsForPosition[i];
            }
        }
        System.Console.WriteLine("-------------------------------------------------");
    }
    public void RunSeason(List<Team> teams, int racesCount)
    {
        System.Console.WriteLine("\n--- Starting the season ---");
        System.Console.WriteLine("Press any key to start the first race !");
        Console.ReadKey();
        for (int raceNumber = 1; raceNumber <= racesCount; raceNumber++)
        {
            Console.WriteLine($"\n--- Race {raceNumber} ---");
            SimulateRace(teams);
            Console.WriteLine("-------------------------------------------------");
            string choice;
            do
            {
            Console.WriteLine("Choose what you want to do next:");
            Console.WriteLine("1. Open driver standings");
            Console.WriteLine("2. Open team standings");
            Console.WriteLine("3. Continue to the next race");
            choice = Console.ReadLine();
            
                
                switch (choice)
                {
                    case "1":
                        DisplayDriverStandings(teams);
                        break;
                    case "2":
                        DisplayTeamStandings(teams);
                        break;
                    case "3":
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                } 
            } while (choice != "3");
            Console.Clear();
        }
    }
    public void EndOfSeason(List<Team> teams)
    {
        Console.WriteLine("\n--- End of season ---");
        Console.WriteLine("\nFinal driver standings:");
        Console.WriteLine("-------------------------------------------------");
        var allDrivers = teams.SelectMany(t => t.Drivers).ToList();
        allDrivers.Sort((x, y) => y.Points.CompareTo(x.Points));
        int position = 1;
        foreach (var driver in allDrivers)
        {
            Console.WriteLine($"{position}. {driver.Name} - {driver.Points} points");
            position++;
        }
        Console.WriteLine("-------------------------------------------------");

        Console.WriteLine("\nFinal team standings:");
        Console.WriteLine("-------------------------------------------------");
        teams.Sort((x, y) => y.GetTotalPoints().CompareTo(x.GetTotalPoints()));
        position = 1;
        foreach (var team in teams)
        {
            Console.WriteLine($"{position}. {team.Name} - {team.GetTotalPoints()} points");
            position++;
        }
        Console.WriteLine("-------------------------------------------------");
    }
    public void DisplayTeamStandings(List<Team> teams)
    {
        Console.WriteLine("\nCurrent team standings:");
        Console.WriteLine("-------------------------------------------------");
        teams.Sort((x, y) => y.GetTotalPoints().CompareTo(x.GetTotalPoints()));
        int position = 1;
        foreach (var team in teams)
        {
            Console.WriteLine($"{position}. {team.Name} - {team.GetTotalPoints()} points");
            position++;
        }
        Console.WriteLine("-------------------------------------------------");
    }
    public void DisplayDriverStandings(List<Team> teams)
    {
        Console.WriteLine("\nCurrent driver standings:");
        Console.WriteLine("-------------------------------------------------");
        var allDrivers = teams.SelectMany(t => t.Drivers).ToList();
        allDrivers.Sort((x, y) => y.Points.CompareTo(x.Points));
        int position = 1;
        foreach (var driver in allDrivers)
        {
            Console.WriteLine($"{position}. {driver.Name} - {driver.Points} points");
            position++;
        }
        Console.WriteLine("-------------------------------------------------");
    }
    public void FirstMessage()
    {
        System.Console.Clear();
        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("For a better experience, please maximize the console window.");
        System.Console.WriteLine("---------------------------------------------");
        Thread.Sleep(4000);
        System.Console.Clear();
    }
    public void Welcome()
    {
        System.Console.WriteLine("---------------------------------------------");
        System.Console.WriteLine("Welcome to the Formula 1 2024 season!");
        System.Console.WriteLine("Congratulations on winning the Formula 2 championship!");
        System.Console.WriteLine("You are now a Formula 1 driver!");
        System.Console.WriteLine("As a rookie, you will have to prove yourself in the upcoming season");
        System.Console.WriteLine("You will have to compete against the best drivers in the world.");
        System.Console.WriteLine("but first, you have to choose your driver name.");
        System.Console.WriteLine("\nWhat will your driver name be?");
    }
    public string GetName()
    {
        string playerName = "";
        while (playerName == "")
        {
            playerName = Console.ReadLine();
            if (playerName == "")
            {
                System.Console.WriteLine("Invalid name. Please try again.");
            }
        }
        return playerName;
        
    }
    public void DisplayTeams(string playerName)
    {
        System.Console.Clear();
        System.Console.WriteLine($"Welcome to Formula 1, {playerName}!");
        System.Console.WriteLine("As a new driver in Formula 1, you will have to choose a team to drive for.");
        System.Console.WriteLine("Here are the teams and their performance ratings:");
        System.Console.WriteLine("-------------------------------------------------");
        foreach (var team in AllTeams)
        {
            System.Console.WriteLine($"{team.Name} - {team.PerformanceFactor}");
        }
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("-------------- CAREER MODE ----------------------");
        System.Console.WriteLine("-------------------------------------------------");
    }
    public Team GetTeam(string playerName)
    {
        System.Console.WriteLine("The team you choose will determine your car's performance for the rest of the season.");
        System.Console.WriteLine("Choose wisely!");
        Team playerTeam = null;
        while (playerTeam == null)
        {
            System.Console.WriteLine("Choose your team by typing the team name:");
            string chosenTeam = Console.ReadLine();
            playerTeam = AllTeams.Find(team => team.Name.ToLower() == chosenTeam.ToLower());
            if (playerTeam == null)
            {
                System.Console.WriteLine("Invalid team name. Please try again.");
            }
        }
        System.Console.Clear();
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine($"-------- {playerTeam.Name} {playerName} --------");
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine($"You have chosen {playerTeam.Name}.");
        System.Console.WriteLine($"Great choice! You are now part of {playerTeam.Name}.");
        return playerTeam;
        Thread.Sleep(4000);
        System.Console.Clear();
    }
    public int ReplaceDriver(string playerName, Team playerTeam)
    {
        System.Console.WriteLine("Now, you have to choose the driver you will replace in the team.");
        System.Console.WriteLine("Here are the drivers you can choose from:");
        int indexDriver = 3;
        string replacingDriver;
        while (indexDriver == 3)
        {
            int position = 0;
            foreach (var driver in playerTeam.Drivers)
            {
                System.Console.WriteLine($"{position}. {driver.Name} - {driver.Rating}");
                position++;
            }
            System.Console.WriteLine($"Choose the driver you will replace by typing the driver number, you will inherit his rating.");
            System.Console.WriteLine($"You can choose from:\n0. {playerTeam.Drivers[0].Name}\n1. {playerTeam.Drivers[1].Name}");

            replacingDriver = Console.ReadLine();
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
        System.Console.Clear();
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("----------------- CAREER MODE -------------------");
        System.Console.WriteLine("------------ LINE UP FOR THE SEASON -------------");
        System.Console.WriteLine($"            {playerTeam.Name} - {playerTeam.Drivers[0].Name} - {playerTeam.Drivers[0].Rating}");
        System.Console.WriteLine($"            {playerTeam.Name} - {playerTeam.Drivers[1].Name} - {playerTeam.Drivers[1].Rating}");
        System.Console.WriteLine("------------ LINE UP FOR THE SEASON -------------");
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("");

        return indexDriver;
    }
}

