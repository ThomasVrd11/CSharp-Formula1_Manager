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
        //Initialize datas for the teams and drivers inside of dictionaries
        //making it more readable,easily editable and expandable
        // teams : team names and performance rating
        // driver : driver name, performance and team name
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

        //Dictionary to store the created Team objects, using team names as keys for easy access.
        var teams = new Dictionary<string, Team>();

        //Create Team objects for each entry in teamsData and add them to the teams dictionary.
        foreach (var team in teamsData)
        {
            teams[team.Key] = new Team(team.Key, team.Value);
        }
        //Debug line
        Console.WriteLine($"Team: {teams["Ferrari"].Name}, Rating: {teams["Ferrari"].PerformanceFactor}");

        //Loop through each driver in driverData, create a Driver object, and add it to the correct team.
        foreach (var driver in driverData)
        {
            //Check if the team exist
            if (teams.ContainsKey(driver.TeamName))
            {
                var newDriver = new Driver(driver.Name, driver.Rating);
                teams[driver.TeamName].Drivers.Add(newDriver);
            }
        }

        //Add all Team objects from the teams dictionary to the AllTeams list for global access.
        AllTeams.AddRange(teams.Values);

        //Loop through each team and add all of its drivers to the AllDrivers list for global access.
        foreach (var team in teams.Values)
        {
            foreach (var driver in team.Drivers)
            {
                AllDrivers.Add(driver);
            }
        }

        // * creating teams
        // Team mercedes = new Team("Mercedes", 8.5);
        // Team ferrari = new Team("Ferrari", 9.2);
        // Team redBull = new Team("Red Bull", 9.5);
        // Team mclaren = new Team("McLaren", 8.1);
        // Team alpine = new Team("Alpine", 6.0);
        // Team astonMartin = new Team("Aston Martin", 7.5);
        // Team alfaRomeo = new Team("Alfa Romeo", 5.5);
        // Team haas = new Team("Haas", 5.0);
        // Team williams = new Team("Williams", 5.0);
        // Team alphaTauri = new Team("Alpha Tauri", 5.0);

        // * creating drivers
        // Driver lewisHamilton = new Driver("Lewis Hamilton", 9.1);
        // Driver georgeRussell = new Driver("George Russell", 8.0);
        // Driver carlosSainz = new Driver("Carlos Sainz", 8.5);
        // Driver charlesLeclerc = new Driver("Charles Leclerc", 9.3);
        // Driver maxVerstappen = new Driver("Max Verstappen", 9.5);
        // Driver sergioPerez = new Driver("Sergio Perez", 8.0);
        // Driver danielRicciardo = new Driver("Daniel Ricciardo", 7.0);
        // Driver yukiTsunoda = new Driver("Yuki Tsunoda", 7.0);
        // Driver landoNorris = new Driver("Lando Norris", 8.5);
        // Driver oscarPiastri = new Driver("Oscar Piastri", 8.0);
        // Driver fernandoAlonso = new Driver("Fernando Alonso", 8.8);
        // Driver lanceStroll = new Driver("Lance Stroll", 7.0);
        // Driver estebanOcon = new Driver("Esteban Ocon", 7.5);
        // Driver pierreGasly = new Driver("Pierre Gasly", 7.5);
        // Driver valtteriBottas = new Driver("Valtteri Bottas", 7.0);
        // Driver theoPourchaire = new Driver("Theo Pourchaire", 6.5);
        // Driver kevinMagnussen = new Driver("Kevin Magnussen", 6.0);
        // Driver nicoHulkenberg = new Driver("Nico Hulkenberg", 6.0);
        // Driver alexAlbon = new Driver("Alex Albon", 7.5);
        // Driver loganSargeant = new Driver("Logan Sargeant", 5.5);
        // // * adding drivers to teams
        // mercedes.Drivers.Add(lewisHamilton);
        // mercedes.Drivers.Add(georgeRussell);
        // ferrari.Drivers.Add(carlosSainz);
        // ferrari.Drivers.Add(charlesLeclerc);
        // redBull.Drivers.Add(maxVerstappen);
        // redBull.Drivers.Add(sergioPerez);
        // mclaren.Drivers.Add(landoNorris);
        // mclaren.Drivers.Add(oscarPiastri);
        // alpine.Drivers.Add(pierreGasly);
        // alpine.Drivers.Add(estebanOcon);
        // astonMartin.Drivers.Add(fernandoAlonso);
        // astonMartin.Drivers.Add(lanceStroll);
        // alfaRomeo.Drivers.Add(valtteriBottas);
        // alfaRomeo.Drivers.Add(theoPourchaire);
        // haas.Drivers.Add(kevinMagnussen);
        // haas.Drivers.Add(nicoHulkenberg);
        // williams.Drivers.Add(alexAlbon);
        // williams.Drivers.Add(loganSargeant);
        // alphaTauri.Drivers.Add(danielRicciardo);
        // alphaTauri.Drivers.Add(yukiTsunoda);
        // * adding teams to the AllTeams list
        // AllTeams.Add(mercedes);
        // AllTeams.Add(ferrari);
        // AllTeams.Add(redBull);
        // AllTeams.Add(mclaren);
        // AllTeams.Add(alpine);
        // AllTeams.Add(astonMartin);
        // AllTeams.Add(alfaRomeo);
        // AllTeams.Add(haas);
        // AllTeams.Add(williams);
        // AllTeams.Add(alphaTauri);
        // // * adding drivers to the AllDrivers list
        // AllDrivers.Add(lewisHamilton);
        // AllDrivers.Add(georgeRussell);
        // AllDrivers.Add(carlosSainz);
        // AllDrivers.Add(charlesLeclerc);
        // AllDrivers.Add(maxVerstappen);
        // AllDrivers.Add(sergioPerez);
        // AllDrivers.Add(danielRicciardo);
        // AllDrivers.Add(yukiTsunoda);
        // AllDrivers.Add(landoNorris);
        // AllDrivers.Add(oscarPiastri);
        // AllDrivers.Add(fernandoAlonso);
        // AllDrivers.Add(lanceStroll);
        // AllDrivers.Add(estebanOcon);
        // AllDrivers.Add(pierreGasly);
        // AllDrivers.Add(valtteriBottas);
        // AllDrivers.Add(theoPourchaire);
        // AllDrivers.Add(kevinMagnussen);
        // AllDrivers.Add(nicoHulkenberg);
        // AllDrivers.Add(alexAlbon);
        // AllDrivers.Add(loganSargeant);

    }
}

// * heres an explanation of the code above
// * Individual team objects are being created.
// * Team mercedes = new Team("Mercedes", 8.5);

// * Individual driver objects are being created.
// * Driver lewisHamilton = new Driver("Lewis Hamilton", 9.1);

// * Drivers are being added to teams.
// * mercedes.Drivers.Add(lewisHamilton);

// * At this point, each Team object has its own Drivers list that contains the drivers on that team. However, there's no single list that contains all the teams or all the drivers.

// * the AllTeams and AllDrivers lists are being populated with the Team and Driver objects, respectively.

// * with this list i will be able to access all the teams and drivers in the game
// * Iterate over all drivers or teams with a single loop.
// * Filter teams or drivers based on certain criteria, like points or ratings.
// * Sort the teams or drivers according to their points.
// * Perform other collective operations, like saving all team or driver data.

// ... other teams