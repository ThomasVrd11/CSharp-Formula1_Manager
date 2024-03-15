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
}

