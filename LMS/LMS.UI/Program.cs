using static System.Net.Mime.MediaTypeNames;
using System.Numerics;
using LMS.UI.Management;

namespace LMS.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchManagement match = new();
            MenuManagement menu = new();
            PlayerManagement player = new();
            TeamManagement team = new();
            bool doContinue = true;
            do
            {
                int selection = menu.MainMenu();
                switch (selection)
                {
                    case 1:
                        selection = menu.TeamMenu();
                        switch(selection)
                        {
                            case 1:
                                team.AddTeam();
                                break;
                            case 2:
                                team.RemoveTeam();
                                break;
                            case 3:
                                team.GetFirstAndLastTeam();
                                break;
                            case 4:
                                team.GetStandings();
                                break;
                            case 5:
                                team.GetTeamInfo();
                                break;
                            case 6:
                                break;
                        }
                        break;
                    case 2:
                        selection = menu.PlayerMenu();
                        switch (selection)
                        {
                            case 1:
                                player.AddPlayer();
                                break;
                            case 2:
                                player.RemovePlayer();
                                break;
                            case 3:
                                player.GetTeamPlayers();
                                break;
                            case 4:
                                player.GetPlayer();
                                break;
                            case 5:
                                player.BestGoalers();
                                break;
                            case 6:
                                break;
                        }
                        break;
                    case 3:
                        selection = menu.MatchMenu();
                        switch(selection)
                        {
                            case 1:
                                match.AddMatch();
                                break;
                            case 2:
                                match.RemoveMatch();
                                break;
                            case 3:
                                match.GetAllMatches();
                                break;
                            case 4:
                                match.GetMatchesByWeek();
                                break;
                            case 5:
                                match.GetMatch();
                                break;
                            case 6:
                                break;
                        }    
                        break;
                    case 4:
                        doContinue = false;
                        Console.WriteLine("Quitting...");
                        Thread.Sleep(700);
                        break;
                }
            } while (doContinue);
        }
    }
}
