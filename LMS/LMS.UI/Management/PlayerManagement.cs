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
    internal class PlayerManagement
    {
        private readonly IGenericService<Player> _service;
        public PlayerManagement()
        {
            _service = new GenericService<Player>();
        }
        public void AddPlayer()
        {
            Player player = new Player();
            Console.Write("Enter player team id: ");
            player.TeamId = int.Parse(Console.ReadLine());
            Console.Write("Enter player jersey number: ");
            player.JerseyNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter player full name: ");
            player.FullName = Console.ReadLine();
            _service.Add(player);
            Console.WriteLine($"\nPlayer added successfully. (id:{player.Id})\n");
        }
        public void RemovePlayer()
        {
            Console.Write("Enter player id: ");
            int id = int.Parse(Console.ReadLine());
            _service.Delete(id);
            Console.WriteLine("\nPlayer deleted successfully.\n");
        }
        public void GetPlayer()
        {
            TeamManagement teamManagement = new TeamManagement();
            Console.Write("Enter player id: ");
            int id = int.Parse(Console.ReadLine());
            var player = _service.Get(id);
            var team = teamManagement.GetTeam(player.TeamId);

            int spaceCount = 25;
            spaceCount -= team.Name.Length;
            string space = new string((char)32, spaceCount);

            int spaceCount2 = 30;
            spaceCount2 -= player.FullName.Length;
            string space2 = new string((char)32, spaceCount2);

            Console.WriteLine("Team Name                Jersey No  Full Name                     GS");
            Console.WriteLine("-----------------------  ---------  --------------------          ---"); 
            Console.WriteLine($"{team.Name}{space}{player.JerseyNumber}          {player.FullName}{space2}{player.Goals}");
        }
        //Don't use in menu
        public Player GetPlayer(int id)
        {
            var player = _service.Get(id);
            return player;
        }
        public void BestGoalers()
        {
            TeamManagement teamManagement = new TeamManagement();
            var players = _service.GetAll();
            var playersSorted = players.OrderByDescending(x => x.Goals);
            int i = 0;
            Console.WriteLine("Team Name                Jersey No  Full Name                     GS");
            Console.WriteLine("-----------------------  ---------  --------------------          ---");
            foreach (var item in playersSorted)
            {
                Team team = teamManagement.GetTeam(item.TeamId);
                int spaceCount = 25;
                spaceCount -= team.Name.Length;
                string space = new string((char)32, spaceCount);

                int spaceCount2 = 30;
                spaceCount2 -= item.FullName.Length;
                string space2 = new string((char)32, spaceCount2);

                Console.WriteLine($"{team.Name}{space}{item.JerseyNumber}          {item.FullName}{space2}{item.Goals}");
                i++;
                if( i == 10)
                {
                    break;
                }
            }
        }
        public void GetTeamPlayers()
        {
            Console.Write("Enter team id: ");
            int id = int.Parse(Console.ReadLine());
            var players = _service.GetAll();
            players = players.OrderBy(x => x.JerseyNumber).ToList();
            Console.WriteLine("Jersey No  Full Name                     GS");
            Console.WriteLine("---------  --------------------          ---");
            foreach (var item in players)
            {
                if (item.TeamId == id)
                {
                    int spaceCount = 30;
                    spaceCount -= item.FullName.Length;
                    string space = new string((char)32, spaceCount);

                    Console.WriteLine($"{item.JerseyNumber}          {item.FullName}{space}{item.Goals}");
                }

            }
        }
        //Don't Add to Menu
        public void UpdatePlayer(Player player)
        {
            _service.Update(player);
        }
    }
}
