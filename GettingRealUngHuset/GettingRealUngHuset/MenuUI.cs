using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class MenuUI
    {
        Controller controller = new Controller();

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
            string username = Console.ReadLine();
            Console.WriteLine("Indtast efternavn:");
            string userLastname = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer:");
            string userPhone = Console.ReadLine();
            Console.WriteLine("Indtast Email:");
            string userEmail = Console.ReadLine();

            controller.InsertUser(username, userLastname, userPhone, userEmail);
            
            controller.GetIDFromLoaner(username, userLastname, userPhone, userEmail);

            
            ChooseTypeHome();
            
        }

        private void ChooseTypeHome() // her vælger man type af materiale, kan genanvendes flere gange -- Case 3 HJEMME
        {

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
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

        public void ShowKamaraHome() // Kamera der er HJEMME
        {
            

            Console.Clear();
            controller.GetKamaralistHome();
            Console.WriteLine("Instast Kamera nummer der skal lånes:");
            string KamaraID = Console.ReadLine();

            controller.InsertKameraIDInMaterial(KamaraID);
            
            controller.GetIDFromMatriale_Kamera(KamaraID);

            controller.InsertLoanerIDandMatIDInLoaned();
            Console.ReadLine();

        }

        private void ShowKabelHome() // Kabler der er HJEMME
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

        //private static void ShowType()
        //{



        //}

        //private static void ChooseMaterial(string Input)
        //{

        //}
        //private static void CheckHome()

        //{

        //}

        //private static void LoanMore()
        //{
        //    Console.Clear();
        //    Console.WriteLine("skal der lånes mere?\n" +
        //        "1. ja\n" +
        //        "2.nej");
        //    string input = Console.ReadLine();
        //    switch (input)
        //    {
        //        case "1": ChooseType();
        //            break;
        //        case "2": Confirmation(); // skal nok være en bekræfelse inden slutningen
        //            break;
        //    }
        //}

        //private static void Confirmation()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Bruger har lånt materiale 1,2,3\n" +
        //        "enter for hovedmenu");
        //    Console.ReadLine();
        //    mainMenu();
        //}

    }
}
