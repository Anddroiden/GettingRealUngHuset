using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class MenuUI
    {
        Controller controller = new Controller(); // new master again

        MenuUI menu = new MenuUI();


        public static bool CheckForLoan = false; // bruges til metoden til at vise materiale for at bestemme om vi skal låne materiale ud, eller bare vise materiale
        public static string username = "";
        public static string userLastname = "";
        public static string userPhone = "";
        public static string userEmail = ""; // user bruges til at gemme info, specielt i forhold til at vise hvem der har lånt materiale
        public static List<string> ValgtMateriale = new List<string>(); // bruges til at kunne printe hvad der er blevet lånt


        public void mainMenu()
        {
            username = "";
            userLastname = "";
            userPhone = "";
            userEmail = "";
            ValgtMateriale.Clear();

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

                case "2":
                    ChooseTypeHome();
                    break;

                case "3":
                    ChooseTypeHome();
                    break;

                case "4": //retuner

                    break;


                case "0": //afslut
                    Environment.Exit(0);
                    break;
            }



        }
        private void LoanMenu()  //udlåningsmenuen - Intast bruger Info
        {
            
            Console.Clear();
            Console.WriteLine("Indtast fornavn:");
            username = Console.ReadLine();
            Console.WriteLine("Indtast efternavn:");
            userLastname = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer:");
            userPhone = Console.ReadLine();
            Console.WriteLine("Indtast Email:");
            userEmail = Console.ReadLine();

            controller.InsertUser(username, userLastname, userPhone, userEmail);
            
            controller.GetIDFromLoaner(username, userLastname, userPhone, userEmail);

            
            ChooseTypeHome();
            
        }

        private void ChooseTypeHome() // her vælger man type af materiale, kan genanvendes flere gange -- Case 3 HJEMME
        {
            
            Console.Clear();
            Console.WriteLine("vælg type af materiale \n" +
                "1. Kamera \n" +
                "2. Kabler \n" +
                "3. lokaler");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1": ShowKamaraHome();
                    break;
                case "2": ShowKabelHome();
                    break;
            }
        }

        public void ShowKamaraHome() // Kamara der er HJEMME
        {
            

            Console.Clear();
            controller.GetKamaralistHome();
            Console.WriteLine("Instast Kamera nummer der skal lånes:");
            string KamaraID = Console.ReadLine();

            controller.InsertKameraIDInMaterial(KamaraID);
            
            controller.GetIDFromMatriale_Kamera(KamaraID);

            controller.InsertLoanerIDandMatIDInLoaned();
            Console.ReadLine();

            LoanMore();

        }

        private static void ShowKabelHome() // Kabler der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKabellistHome();
        }

        private void ChooseTypeLoaned() //  Case 2 Udlånt
        {

            Console.Clear();

            Console.WriteLine("vælg type af materiale \n" +
                "1. Kamera \n" +
                "2. Kabler \n" +
                "3. lokaler");
            string input = Console.ReadLine();


            switch (input)
            {
                case "1":
                    ShowKamaraLoaned();
                    break;
                case "2":
                    ShowKabelLoaned();
                    break;
            }
        }

        private void ShowKamaraLoaned() // Kamara der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKamaralistHome();


        }

        private void ShowKabelLoaned() // Kabler der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKabellistHome();
        }

        private void LoanMore()
        {
            Console.Clear();
            Console.WriteLine("skal der lånes mere?\n" +
                "1. ja\n" +
                "2.nej");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChooseTypeHome();
                    break;
                case "2":
                    Confirmation();
                    break;
            }
        }

        private void Confirmation() // bekræfter og printer hvilken bruger har lånt og hvad der er lånt
        {
            Console.Clear();
            string PrintResult = "";
            Controller controller = new Controller();

            if (ValgtMateriale.Count() > 1)
            {
                for (int i = 0; i < ValgtMateriale.Count(); i++)
                {
                    string Result = ValgtMateriale[i].ToString();
                    PrintResult = PrintResult + " og " + Result;
                }
            }
            else if (ValgtMateriale.Count() == 1)
            {
                PrintResult = ValgtMateriale[0];
            }


            Console.WriteLine(username + " " + userLastname + " har lånt " + PrintResult + "\n" +
                "enter for hovedmenu");
            Console.ReadLine();
            menu.mainMenu();
        }


    }
}
