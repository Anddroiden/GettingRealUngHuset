using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ungdomshuset udlåningssystem";
            MenuUI menu = new MenuUI();
            menu.mainMenu();
        }
    }
}
