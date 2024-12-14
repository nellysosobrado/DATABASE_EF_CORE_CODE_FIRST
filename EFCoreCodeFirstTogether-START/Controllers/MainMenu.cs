using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START.Controllers
{
    public class MainMenu
    {
        public int DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Create" +
                "\n2.Read" +
                "\n3.Update" +
                "\n4.Delete" +
                "\n5.Exit");

                string choise = Console.ReadLine() ?? string.Empty;

                int userMainMenuChoise = Convert.ToInt32(choise);

    
            return userMainMenuChoise;


            }

        }
    }
}
