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
    public Driver MyDriver { get; set; }
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
                
                double performanceScore = team.PerformanceFactor + driver.Rating;
                if (driver == MyDriver)
                {
                    performanceScore += MyDriver.TemporaryBoost;
                }
                performanceScore *= random.NextDouble();
                raceResults.Add((driver, performanceScore));
            }
        }
        raceResults.Sort((x, y) => y.performanceScore.CompareTo(x.performanceScore));
        System.Console.WriteLine("\nRace results:");
        System.Console.WriteLine("-------------------------------------------------");
        for (int i = 0; i < raceResults.Count; i++)
        {
            System.Console.WriteLine($"{i + 1}. {raceResults[i].Driver.Name} - {raceResults[i].performanceScore}");
            if (i < pointsForPosition.Length)
            {
                raceResults[i].Driver.Points += pointsForPosition[i];
            }
        }
        System.Console.WriteLine("-------------------------------------------------");
    }
    public void RunSeason(List<Team> teams, int racesCount)
    {
        System.Console.Clear();
        System.Console.WriteLine("\n--- Starting the season ---");
        System.Console.WriteLine("Press any key to start the first race !");
        Console.ReadKey();
        for (int raceNumber = 1; raceNumber <= racesCount; raceNumber++)
        {
            Console.WriteLine($"\n--- Race {raceNumber} ---");
            SimulateRace(teams);
            ResetTemporaryBoost();
            Console.WriteLine("-------------------------------------------------");
            string choice;
            do
            {
                Console.WriteLine("Choose what you want to do next:");
                Console.WriteLine("1. Open driver standings");
                Console.WriteLine("2. Open team standings");
                Console.WriteLine("3. Play a mini game to increase your driver's performance for next race");
                Console.WriteLine("4. Continue to the next race");
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
                        PlayGameForMyDriver();
                        break;
                    case "4":
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != "4");
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
                    MyDriver = playerTeam.Drivers[0];
                    break;
                case 1:
                    playerTeam.Drivers[1].Name = playerName;
                    MyDriver = playerTeam.Drivers[1];
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
    //* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //* ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // * MINI GAMES

    private bool miniGame1()
    {
        System.Console.WriteLine("F1 Quizz: Who won the 2021 Formula 1 World Championship?");
        System.Console.WriteLine("A. Lewis Hamilton\nB. Max Verstappen\nC. Valtteri Bottas\nD. Sebastian Vettel");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: Max Verstappen, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame2()
    {
        System.Console.WriteLine("F1 Quizz: What is the name of the current Formula 1 CEO?");
        System.Console.WriteLine("A. Stefano Domenicali\nB. Toto Wolff\nC. Christian Horner\nD. Ross Brawn");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Stefano Domenicali, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame3()
    {
        System.Console.WriteLine("F1 Quizz: Which driver holds the record for the most Grand Prix wins in F1 history?");
        System.Console.WriteLine("A. Lewis Hamilton\nB. Michael Schumacher\nC. Ayrton Senna\nD. Sebastian Vettel");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Lewis Hamilton, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame4()
    {
        System.Console.WriteLine("F1 Quizz: What is the name of the current Formula 1 World Champion team?");
        System.Console.WriteLine("A. Mercedes\nB. Red Bull\nC. Ferrari\nD. McLaren");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: Red Bull, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame5()
    {
        System.Console.WriteLine("F1 Quizz: what does DRS stand for?");
        System.Console.WriteLine("A. Drag Reduction System\nB. Drag Reduction Setup\nC. Drag Reduction Speed\nD. Drag Reduction Sensation");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Drag Reduction System, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame6()
    {
        System.Console.WriteLine("F1 Quizz: What is the name of the current Formula 1 tyre supplier?");
        System.Console.WriteLine("A. Michelin\nB. Pirelli\nC. Bridgestone\nD. Goodyear");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: Pirelli, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame7()
    {
        System.Console.WriteLine("F1 Quizz: Which Formula 1 team has the most Constructors' Championships?");
        System.Console.WriteLine("A. Ferrari\nB. Mercedes\nC. McLaren\nD. Williams");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Ferrari, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame8()
    {
        System.Console.WriteLine("F1 Quizz: Who became the youngest Formula 1 World Champion in history?");
        System.Console.WriteLine("A. Fernando Alonso\nB. Lewis Hamilton\nC. Max Verstappen\nD. Sebastian Vettel");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "D")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was D: Sebastian Vettel, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame9()
    {
        System.Console.WriteLine("F1 Quizz: Where is the headquarters of the Red Bull Racing Formula 1 team?");
        System.Console.WriteLine("A. Milton Keynes, UK\nB. Maranello, Italy\nC. Brackley, UK\nD. Enstone, UK");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Milton Keynes, UK, you lost the mini game!");
            return false;
        }
    }
    private bool miniGame10()
    {
        System.Console.WriteLine("F1 Quiz: Which Formula 1 circuit features the famous corner named 'Parabolica'?");
        System.Console.WriteLine("A. Silverstone\nB. Monza\nC. Spa-Francorchamps\nD. Suzuka");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: Monza, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame11()
    {
        System.Console.WriteLine("F1 Quiz: What is the fuel weight limit for a Formula 1 car at the start of the race, as of recent regulations?");
        System.Console.WriteLine("A. 100 kg\nB. 105 kg\nC. 110 kg\nD. 95 kg");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: 105 kg, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame12()
    {
        System.Console.WriteLine("F1 Quiz: In which year did the first Formula 1 night race take place, and where?");
        System.Console.WriteLine("A. 2008, Singapore\nB. 2006, Bahrain\nC. 2010, Abu Dhabi\nD. 2012, Qatar");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: 2008, Singapore, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame13()
    {
        System.Console.WriteLine("F1 Quiz: What part of a Formula 1 car is referred to as the 'halo'?");
        System.Console.WriteLine("A. The front wing\nB. The cockpit protection system\nC. The rear diffuser\nD. The steering wheel");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: The cockpit protection system, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame14()
    {
        System.Console.WriteLine("F1 Quiz: Who made the famous radio comment 'Leave me alone, I know what I'm doing' during a race?");
        System.Console.WriteLine("A. Fernando Alonso\nB. Kimi Räikkönen\nC. Sebastian Vettel\nD. Lewis Hamilton");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: Kimi Räikkönen, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame15()
    {
        System.Console.WriteLine("F1 Quiz: Which Formula 1 team is based in Brackley, UK?");
        System.Console.WriteLine("A. Red Bull Racing\nB. McLaren\nC. Mercedes-AMG Petronas\nD. Aston Martin");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "C")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was C: Mercedes-AMG Petronas, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame16()
    {
        System.Console.WriteLine("F1 Quiz: Which circuit is known as 'The Cathedral of Speed'?");
        System.Console.WriteLine("A. Monza\nB. Silverstone\nC. Spa-Francorchamps\nD. Suzuka");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: Monza, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame17()
    {
        System.Console.WriteLine("F1 Quizz: What does the term undercut refer to in Formula 1?");
        System.Console.WriteLine("A. A pit stop strategy\nB. A type of tyre compound\nC. A type of aerodynamic device\nD. A type of engine mode");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "A")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was A: A pit stop strategy, you lost the mini-game!");
            return false;
        }
    }
    private bool miniGame18()
    {
        System.Console.WriteLine("F1 Quizz: In what year did the first Formula 1 World Championship take place?");
        System.Console.WriteLine("A. 1948\nB. 1950\nC. 1952\nD. 1954");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer == "B")
        {
            System.Console.WriteLine("Correct! You won the mini-game!");
            return true;
        }
        else
        {
            System.Console.WriteLine("Wrong answer! It was B: 1950, you lost the mini-game!");
            return false;
        }
    }







    public void PlayGameForMyDriver()
    {
        List<Func<bool>> miniGames = new List<Func<bool>>()
        {
            miniGame1,
            miniGame2,
            miniGame3,
            miniGame4,
            miniGame5,
            miniGame6,
            miniGame7,
            miniGame8,
            miniGame9,
            miniGame10,
            miniGame11,
            miniGame12,
            miniGame13,
            miniGame14,
            miniGame15,
            miniGame16,
            miniGame17,
            miniGame18
        };
        Random random = new Random();
        int randomIndex = random.Next(miniGames.Count);
        Func<bool> randomGame = miniGames[randomIndex];
        System.Console.Clear();
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine($"You will play a mini game to increase your driver's performance for the next race!");
        System.Console.WriteLine("--- Mini game ---");
        bool won = randomGame();
        if (won)
        {
            System.Console.WriteLine("You won the mini game! Your driver's performance has increased!");
            MyDriver.TemporaryBoost = random.NextDouble() * 4 + 2;
        }
        else
        {
            System.Console.WriteLine("You lost the mini game! Your driver's performance won't be increased for this race...");
            MyDriver.TemporaryBoost = 0;
        }
        Thread.Sleep(3000);
        System.Console.Clear();

    }
    public void ResetTemporaryBoost()
    {
        MyDriver.TemporaryBoost = 0;
    }
    

}
