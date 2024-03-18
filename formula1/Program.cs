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
        Team playerTeam = setup.GetTeam(playerName);
        int replacedDriver = setup.ReplaceDriver(playerName, playerTeam);









        int racesCount = 10;
        setup.RunSeason(setup.AllTeams, racesCount);
        setup.EndOfSeason(setup.AllTeams);
    }
}