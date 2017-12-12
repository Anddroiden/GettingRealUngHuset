using System;
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

                case "1": LoanMenu();
                    break;

                case "2":  //udlånt
                    ChooseType();
                    break;

                case "3": //hjemme

                    break;

                case "4": //retuner

                    break;

                case "9":
                    CreateAndDeleteMenu();
                    break;

                case "0": //afslut
                    Environment.Exit(0);
                    break;
            }



        }
        private static void LoanMenu()  //udlåningsmenuen - Intast bruger Info
        {
            
            Controller controller = new Controller();

            Console.Clear();
            Console.WriteLine("Indtast fornavn:");
            string username = Console.ReadLine();
            Console.WriteLine("Indtast efternavn:");
            string userLastname = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer:");
            string userPhone = Console.ReadLine();
            Console.WriteLine("Indtast Email:");
            string userEmail = Console.ReadLine();

            controller.InsertUser(username, userLastname, userPhone, userEmail);

           

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


        private static void ChooseType() // her vælger man type af materiale, kan genanvendes flere gange
        {



            Console.Clear();

            Console.WriteLine("vælg type af materiale \n" +
                "1. Kamera \n" +
                "2. Kabler \n" +
                "3. lokaler");
            string input = Console.ReadLine();
            string output = "";

            switch (input)
            {
                case "1":
                    output = "Kamera";
                    break;
                case "2":
                    output = "Kabler";
                    break;

            }

            ChooseMaterial(output);

        }
        private static void ShowType()
        {
            Console.Clear();

        }

        private static void ChooseMaterial(string Input)
        {
            Console.Clear();
            Console.WriteLine(Input);
            Console.WriteLine("1. Kamera med ID K1\n" +
                "osv");
            string input = Console.ReadLine();

            LoanMore();
        }
        private static void CheckHome()
           
        {

        }

        private static void LoanMore()
        {
            Console.Clear();
            Console.WriteLine("skal der lånes mere?\n" +
                "1. ja\n" +
                "2.nej");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": ChooseType();
                    break;
                case "2": Confirmation(); // skal nok være en bekræfelse inden slutningen
                    break;
            }
        }






        private static void Confirmation()
        {
            Console.Clear();
            Console.WriteLine("Bruger har lånt materiale 1,2,3\n" +
                "enter for hovedmenu");
            Console.ReadLine();
            mainMenu();
        }

    }
}
