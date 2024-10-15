using LMS.DAL.Models;
using LMS.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL.Services;

namespace LMS.UI.Management
{
    internal class TeamManagement
    {
        private readonly IGenericService<Team> _service;
        public TeamManagement()
        {
            _service = new GenericService<Team>();
        }
        public void AddTeam()
        {
            Team team = new Team();
            Console.Write("Enter team name: ");
            team.Name = Console.ReadLine();
            _service.Add(team);
            Console.WriteLine("\nTeam added successfully.\n");
        }
        public void RemoveTeam()
        {
            Console.Write("Enter team id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("\nTeam deleted successfully.\n");
        }
        public void GetStandings()
        {
            var teams = _service.GetAll();
            Console.WriteLine("Team                         ID P  W  T  L  GF  GA  GD P");
            Console.WriteLine("-------------------------    -- -- -- -- -- --  --  -- --");
            var teamsSorted = teams.OrderByDescending(o => o.Points).ToList();
            int i = 1;
            foreach (var team in teamsSorted) 
            {
                int spaceCount = 25;
                spaceCount -= team.Name.Length;
                if(team.Id < 10)
                {
                    spaceCount++;
                }
                string space = new string((char)32,spaceCount);
                Console.WriteLine($"{i}. {team.Name}{space}{team.Id}  {team.Played}  {team.Won}  {team.Drawn}  {team.Lost}  {team.GoalsFor}   {team.GoalsAgainst}   {team.GoalsFor - team.GoalsAgainst}   {team.Points}");
                i++;
            }
        }
        public void GetTeamInfo()
        {
            Console.Write("Enter team id: ");
            int id = int.Parse(Console.ReadLine());
            var team = _service.Get(id);
            int spaceCount = 25;
            spaceCount -= team.Name.Length;
            if (team.Id < 10)
            {
                spaceCount++;
            }
            string space = new string((char)32, spaceCount);
            Console.WriteLine("Team                      ID P  W  T  L  GF  GA  GD P");
            Console.WriteLine("----------------------    -- -- -- -- -- --  --  -- --");

            Console.WriteLine($"{team.Name}{space}{team.Id}  {team.Played}  {team.Won}  {team.Drawn}  {team.Lost}  {team.GoalsFor}   {team.GoalsAgainst}   {team.GoalsFor - team.GoalsAgainst}  {team.Points}");

        }
        public void GetFirstAndLastTeam()
        {
            var teams = _service.GetAll();
            Console.WriteLine("Team                     GF  GA");
            Console.WriteLine("----------------------   --  --");

            var teamsSorted = teams.OrderByDescending(o => o.GoalsFor).ToList();
            int i = teamsSorted[0].Id;

            int spaceCount = 25;
            spaceCount -= teamsSorted[0].Name.Length;
            string space = new string((char)32, spaceCount);

            Console.WriteLine($"{teamsSorted[0].Name}{space}{teamsSorted[0].GoalsFor}   {teamsSorted[0].GoalsAgainst}");

            var teamsSorted2 = teams.OrderByDescending(o => o.GoalsAgainst).ToList();
            Team team = teamsSorted2[0];
            if (teamsSorted2[0].Id == i)
            {
                team = teamsSorted2[1];
            }

            spaceCount = 25;
            spaceCount -= team.Name.Length;
            space = new string((char)32, spaceCount);

            Console.WriteLine($"{team.Name}{space}{team.GoalsFor}   {team.GoalsAgainst}");
        }
        //Don't Use in menu
        public Team GetTeam(int id)
        {
            var team = _service.Get(id);
            return team;
        }
        //Don't Use in menu
        public void UpdateTeam(Team team)
        {
            _service.Update(team);
        }
    }
}
