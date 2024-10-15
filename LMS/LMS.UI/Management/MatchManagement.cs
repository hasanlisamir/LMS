using LMS.BL.Services.Interfaces;
using LMS.BL.Services;
using LMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Management
{
    internal class MatchManagement
    {
        private readonly IGenericService<Match> _service;
        private PlayerManagement playerManagement;
        private TeamManagement teamManagement;
        public MatchManagement()
        {
            _service = new GenericService<Match>();
            playerManagement = new PlayerManagement();
            teamManagement = new TeamManagement();
        }
        public void AddMatch()
        {
            Match match = new Match();

            Console.Write("Enter match week number: ");
            match.WeekNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter home team id: ");
            match.HomeTeamId = int.Parse(Console.ReadLine());
            var HomeTeam = teamManagement.GetTeam(match.HomeTeamId);

            Console.Write("Enter away team id: ");
            match.AwayTeamId = int.Parse(Console.ReadLine());
            var AwayTeam = teamManagement.GetTeam(match.AwayTeamId);

            Console.Write("Enter home team goals: ");
            match.HomeTeamGoals = int.Parse(Console.ReadLine());
            if (match.HomeTeamGoals > 0)
            {
                match.HomeTeamScoredPlayers = "";
                char doContinue = 'y';
                do
                {
                    Console.Write("Enter the id of the player who scored: ");
                    int playerId = int.Parse(Console.ReadLine());
                    var player = playerManagement.GetPlayer(playerId);
                    Console.Write("How many goals he scored: ");
                    int playerGoals = int.Parse(Console.ReadLine());
                    player.Goals += playerGoals;
                    playerManagement.UpdatePlayer(player);
                    string temp = $"ID {player.Id} scored {playerGoals}";
                    match.HomeTeamScoredPlayers += temp + " ";
                    Console.Write("Is there any other player from this team who scored? (y,Y/n,N): ");
                    doContinue = char.Parse(Console.ReadLine());
                } while (char.ToLower(doContinue) == 'y');
            }

            Console.Write("Enter away team goals: ");
            match.AwayTeamGoals = int.Parse(Console.ReadLine());
            if (match.AwayTeamGoals > 0)
            {
                match.AwayTeamScoredPlayers = "";
                char doContinue = 'y';
                do
                {
                    Console.Write("Enter the id of the player who scored: ");
                    int playerId = int.Parse(Console.ReadLine());
                    var player = playerManagement.GetPlayer(playerId);
                    Console.Write("How many goals he scored: ");
                    int playerGoals = int.Parse(Console.ReadLine());
                    player.Goals += playerGoals;
                    playerManagement.UpdatePlayer(player);
                    string temp = $"ID {player.Id} scored {playerGoals}";
                    match.AwayTeamScoredPlayers += temp + " ";
                    Console.Write("Is there any other player from this team who scored? (y,Y/n,N): ");
                    doContinue = char.Parse(Console.ReadLine());
                } while (char.ToLower(doContinue) == 'y');
            }

            HomeTeam.Played += 1;
            AwayTeam.Played += 1;

            HomeTeam.GoalsFor += match.HomeTeamGoals;
            HomeTeam.GoalsAgainst += match.AwayTeamGoals;

            AwayTeam.GoalsFor += match.AwayTeamGoals;
            AwayTeam.GoalsAgainst += match.HomeTeamGoals;

            if (match.HomeTeamGoals > match.AwayTeamGoals)
            {
                HomeTeam.Won += 1;
                AwayTeam.Lost += 1;
                HomeTeam.Points += 3;
            }
            else if (match.HomeTeamGoals < match.AwayTeamGoals)
            {
                HomeTeam.Lost += 1;
                AwayTeam.Won += 1;
                AwayTeam.Points += 3;
            }
            else
            {
                HomeTeam.Drawn += 1;
                AwayTeam.Drawn += 1;
                HomeTeam.Points += 1;
                AwayTeam.Points += 1;
            }

            teamManagement.UpdateTeam(HomeTeam);
            teamManagement.UpdateTeam(AwayTeam);
            _service.Add(match);
            Console.WriteLine($"\nMatch added successfully. (id:{match.Id}) \n");
        }

        public void RemoveMatch()
        {
            Console.Write("Enter match id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("\nMatch deleted successfully.\n");
        }
        public void GetAllMatches()
        {
           var matches = _service.GetAll();
            Console.WriteLine("Id Week HT AT HTGoals ATGoals HTScoredPlayers      ATScoredPlayers");
            Console.WriteLine("-- ---- -- -- ------- ------- -------------------- -----------------------");
            foreach ( var match in matches )
            {
                Console.WriteLine($"{match.Id}  {match.WeekNumber}    {match.HomeTeamId} {match.AwayTeamId}  {match.HomeTeamGoals}        {match.AwayTeamGoals}       {match.HomeTeamScoredPlayers}      ||      {match.AwayTeamScoredPlayers}");
            }
        }
        public void GetMatchesByWeek()
        {
            Console.Write("Enter week number: ");
            int weekNumber = int.Parse(Console.ReadLine());
            var matches = _service.GetAll();
            Console.WriteLine("Id WeekNumber HomeTeam AwayTeam HTGoals ATGoals HTScoredPlayers      ATScoredPlayers");
            Console.WriteLine("-- ---------- -------- -------- ------- ------- -------------------- -----------------------");
            foreach (var match in matches)
            {
                if (match.WeekNumber == weekNumber)
                {
                    Console.WriteLine($"{match.Id} {match.WeekNumber} {match.HomeTeamId} {match.AwayTeamId} {match.HomeTeamGoals} {match.AwayTeamGoals} {match.HomeTeamScoredPlayers} {match.AwayTeamScoredPlayers}");
                }
            }
        }
        public void GetMatch()
        {
            Console.Write("Enter match id: ");
            int id = int.Parse(Console.ReadLine());
            var match = _service.Get(id);
            Console.WriteLine("Id WeekNumber HomeTeam AwayTeam HTGoals ATGoals HTScoredPlayers      ATScoredPlayers");
            Console.WriteLine("-- ---------- -------- -------- ------- ------- -------------------- -----------------------");
            Console.WriteLine($"{match.Id} {match.WeekNumber} {match.HomeTeamId} {match.AwayTeamId} {match.HomeTeamGoals} {match.AwayTeamGoals} {match.HomeTeamScoredPlayers} {match.AwayTeamScoredPlayers}");
        }
    }
}
