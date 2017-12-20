using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class MenuUI
    {
        public static bool CheckForLoan = false;
        public static string username = "";
        public static string userLastname = "";
        public static string userPhone = "";
        public static string userEmail = "";



        public static void mainMenu()
        {
            CheckForLoan = false;
            username = "";
        userLastname = "";
        userPhone = "";
        userEmail = "";

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
                    CheckForLoan = true;
                    LoanMenu();
                    
                    break;

                case "2":
                    ChooseTypeHome();
                    break;

                case "3":
                    ChooseTypeHome(); // 2 og 3 er de samme pt.
                    break;

                case "4": //retuner

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
            username = Console.ReadLine();
            Console.WriteLine("Indtast efternavn:");
            userLastname = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer:");
            userPhone = Console.ReadLine();
            Console.WriteLine("Indtast Email:");
            userEmail = Console.ReadLine();

            controller.InsertUser(username, userLastname, userPhone, userEmail);
            Console.Clear();
            controller.GetIDFromLoaner(username, userLastname, userPhone, userEmail);

            
            ChooseTypeHome();
            
        }

        private static void ChooseTypeHome() // her vælger man type af materiale, kan genanvendes flere gange -- Case 3 HJEMME
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

        public static void ShowKamaraHome() // Kamara der er HJEMME
        {
            Controller controller = new Controller();

            Console.Clear();
            controller.GetKamaralistHome();

            if (CheckForLoan == true)
            {
                Console.WriteLine("Instast Kamera nummer der skal lånes:");
                string KamaraID = Console.ReadLine();

                controller.InsertKameraIDInMaterial(KamaraID);

                controller.GetIDFromMatriale_Kamera(KamaraID); // retunere ikke 
                Console.ReadLine();
            }
            else if (CheckForLoan == false)
            {
                Console.WriteLine("\n" + "0. Tilbage til Hovedmenu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        mainMenu();
                        break;
                    default:
                        Console.WriteLine("ugyldigt input");
                        break;
                }
            }
            

        }

        private static void ShowKabelHome() // Kabler der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKabellistHome();
        }

        private static void ChooseTypeLoaned() //  Case 2 Udlånt
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

        private static void ShowKamaraLoaned() // Kamara der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKamaralistHome();
        }

        private static void ShowKabelLoaned() // Kabler der er HJEMME
        {
            Console.Clear();
            Controller controller = new Controller();
            controller.GetKabellistHome();
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
                case "1":
                    ChooseTypeHome();
                    break;
                case "2":
                    Confirmation(); // skal nok være en bekræfelse inden slutningen
                    break;
            }
        }

        private static void Confirmation()
        {
            Console.Clear();
            Controller controller = new Controller();

            Console.WriteLine("Bruger har lånt materiale 1,2,3\n" +
                "enter for hovedmenu");
            Console.ReadLine();
            mainMenu();
        }

    }
}
