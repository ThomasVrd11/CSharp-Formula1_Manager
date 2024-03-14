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
        // * creating teams
        Team mercedes = new Team("Mercedes", 8.5);
        Team ferrari = new Team("Ferrari", 9.2);
        Team redBull = new Team("Red Bull", 9.5);
        Team mclaren = new Team("McLaren", 8.1);
        Team alpine = new Team("Alpine", 6.0);
        Team astonMartin = new Team("Aston Martin", 7.5);
        Team alfaRomeo = new Team("Alfa Romeo", 5.5);
        Team haas = new Team("Haas", 5.0);
        Team williams = new Team("Williams", 5.0);
        Team alphaTauri = new Team("Alpha Tauri", 5.0);
        // * creating drivers
        Driver lewisHamilton = new Driver("Lewis Hamilton", 9.1);
        Driver georgeRussell = new Driver("George Russell", 8.0);
        Driver carlosSainz = new Driver("Carlos Sainz", 8.5);
        Driver charlesLeclerc = new Driver("Charles Leclerc", 9.3);
        Driver maxVerstappen = new Driver("Max Verstappen", 9.5);
        Driver sergioPerez = new Driver("Sergio Perez", 8.0);
        Driver danielRicciardo = new Driver("Daniel Ricciardo", 7.0);
        Driver yukiTsunoda = new Driver("Yuki Tsunoda", 7.0);
        Driver landoNorris = new Driver("Lando Norris", 8.5);
        Driver oscarPiastri = new Driver("Oscar Piastri", 8.0);
        Driver fernandoAlonso = new Driver("Fernando Alonso", 8.8);
        Driver lanceStroll = new Driver("Lance Stroll", 7.0);
        Driver estebanOcon = new Driver("Esteban Ocon", 7.5);
        Driver pierreGasly = new Driver("Pierre Gasly", 7.5);
        Driver valtteriBottas = new Driver("Valtteri Bottas", 7.0);
        Driver theoPourchaire = new Driver("Theo Pourchaire", 6.5);
        Driver kevinMagnussen = new Driver("Kevin Magnussen", 6.0);
        Driver nicoHulkenberg = new Driver("Nico Hulkenberg", 6.0);
        Driver alexAlbon = new Driver("Alex Albon", 7.5);
        Driver loganSargeant = new Driver("Logan Sargeant", 5.5);
        // * adding drivers to teams
        mercedes.Drivers.Add(lewisHamilton);
        mercedes.Drivers.Add(georgeRussell);
        ferrari.Drivers.Add(carlosSainz);
        ferrari.Drivers.Add(charlesLeclerc);
        redBull.Drivers.Add(maxVerstappen);
        redBull.Drivers.Add(sergioPerez);
        mclaren.Drivers.Add(landoNorris);
        mclaren.Drivers.Add(oscarPiastri);
        alpine.Drivers.Add(pierreGasly);
        alpine.Drivers.Add(estebanOcon);
        astonMartin.Drivers.Add(fernandoAlonso);
        astonMartin.Drivers.Add(lanceStroll);
        alfaRomeo.Drivers.Add(valtteriBottas);
        alfaRomeo.Drivers.Add(theoPourchaire);
        haas.Drivers.Add(kevinMagnussen);
        haas.Drivers.Add(nicoHulkenberg);
        williams.Drivers.Add(alexAlbon);
        williams.Drivers.Add(loganSargeant);
        alphaTauri.Drivers.Add(danielRicciardo);
        alphaTauri.Drivers.Add(yukiTsunoda);
        // * adding teams to the AllTeams list
        AllTeams.Add(mercedes);
        AllTeams.Add(ferrari);
        AllTeams.Add(redBull);
        AllTeams.Add(mclaren);
        AllTeams.Add(alpine);
        AllTeams.Add(astonMartin);
        AllTeams.Add(alfaRomeo);
        AllTeams.Add(haas);
        AllTeams.Add(williams);
        AllTeams.Add(alphaTauri);
        // * adding drivers to the AllDrivers list
        AllDrivers.Add(lewisHamilton);
        AllDrivers.Add(georgeRussell);
        AllDrivers.Add(carlosSainz);
        AllDrivers.Add(charlesLeclerc);
        AllDrivers.Add(maxVerstappen);
        AllDrivers.Add(sergioPerez);
        AllDrivers.Add(danielRicciardo);
        AllDrivers.Add(yukiTsunoda);
        AllDrivers.Add(landoNorris);
        AllDrivers.Add(oscarPiastri);
        AllDrivers.Add(fernandoAlonso);
        AllDrivers.Add(lanceStroll);
        AllDrivers.Add(estebanOcon);
        AllDrivers.Add(pierreGasly);
        AllDrivers.Add(valtteriBottas);
        AllDrivers.Add(theoPourchaire);
        AllDrivers.Add(kevinMagnussen);
        AllDrivers.Add(nicoHulkenberg);
        AllDrivers.Add(alexAlbon);
        AllDrivers.Add(loganSargeant);

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