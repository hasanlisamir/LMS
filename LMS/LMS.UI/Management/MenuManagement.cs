using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.UI.Management
{
    internal class MenuManagement
    {
        public int MainMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Team Menu");
                Console.WriteLine("2. Player Menu");
                Console.WriteLine("3. Match Menu");
                Console.WriteLine("4. Quit");
                Console.Write("Your selection: ");
                selection = int.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (selection < 1 || selection > 4);
            return selection;
        }
        public int TeamMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Team");
                Console.WriteLine("2. Remove Team");
                Console.WriteLine("3. Get Best and Worst Team");
                Console.WriteLine("4. Get Standings");
                Console.WriteLine("5. Get Team Info");
                Console.WriteLine("6. Quit");
                Console.Write("Your selection: ");
                selection = int.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (selection < 1 || selection > 7);
            return selection;
        }
        public int PlayerMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Remove Player");
                Console.WriteLine("3. Get Players of a Team");
                Console.WriteLine("4. Get Player");
                Console.WriteLine("5. Best Goalers");
                Console.WriteLine("6. Quit");
                Console.Write("Your selection: ");
                selection = int.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (selection < 1 || selection > 7);
            return selection;
        }
        public int MatchMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Match");
                Console.WriteLine("2. Remove Match");
                Console.WriteLine("3. Get All Matches");
                Console.WriteLine("4. Get Matches by Week Number");
                Console.WriteLine("5. Get Match by Id");
                Console.WriteLine("6. Quit");
                Console.Write("Your selection: ");
                selection = int.Parse(Console.ReadLine());
                Console.WriteLine();
            } while (selection < 1 || selection > 6);
            return selection;
        }
    }
}
