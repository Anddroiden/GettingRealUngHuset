﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class MenuUI
    {

        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("udlåningssystem\n" +
                "1. udlån\n" +
                "2. Udlånt\n" +
                "3. Hjemme\n" +
                "4. Aflever\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "9. Andet\n" +
                "0. Afslut");
            string input = Console.ReadLine();

            switch (input)
            {

                case "1":
                    LoanMenu();
                    break;

                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "9":
                    CreateAndDeleteMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }



        }
        private static void LoanMenu()  //udlåningsmenuen
        {
            Console.Clear();
            Console.WriteLine("indtast ID på materiale");
            string MaterialID = Console.ReadLine();


        }

        private static void CreateAndDeleteMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "1. Opret ny type materiale\n" +
                "2. tilføj til eksisterende materialen \n" +
                "\n" +
                "\n" +
                "5. Fjern type af materiale (f.eks alle kamerarer)\n" +
                "6. Fjern materiale\n" +
                "\n" +
                "\n" +
                "\n" +
                "0. Tilbage");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    break;
                case "2":

                    break;

                case "5":

                    break;

                case "6":

                    break;

                case "0":
                    mainMenu();
                    break;



            }


        }
    }
}