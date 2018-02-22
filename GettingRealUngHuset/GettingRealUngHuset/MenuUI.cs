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

        public static bool CheckForLoan = false; // bruges til metoden til at vise materiale for at bestemme om vi skal låne materiale ud, eller bare vise materiale
        public static string username = "";
        public static string userLastname = "";
        public static string userPhone = "";
        public static string userEmail = ""; // user bruges til at gemme info, specielt i forhold til at vise hvem der har lånt materiale
        public static List<string> ChosenMaterial = new List<string>(); // bruges til at kunne printe hvad der er blevet lånt


        public void mainMenu()
        {
            username = "";
            userLastname = "";
            userEmail = "";
            userPhone = "";
            ChosenMaterial.Clear();
            CheckForLoan = false;

            Console.BackgroundColor = ConsoleColor.Black;
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

                case "1": CheckForLoan = true;
                    LoanMenu();
                    break;

                case "2": ChooseTypeLoaned();
                    break;

                case "3":
                    ChooseTypeHome();
                    break;

                case "4":
                    ReturnItem();
                    break;


                case "0": //afslut
                    Environment.Exit(0);
                    break;

                default: Console.WriteLine("Ugyldigt Input");
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
                default: Console.WriteLine("ugyldigt input");
                    break;
            }
        }

        public void ShowKamaraHome() // Kamara der er HJEMME
        {

            Console.Clear();
            controller.GetKamaralistHome();
            

            if (CheckForLoan == true)
            {
                Console.WriteLine("Instast Kamera nummer der skal lånes:");
                string KamaraID = Console.ReadLine();
                ChosenMaterial.Add(KamaraID);

                controller.InsertKameraIDInMaterial(KamaraID);

            controller.GetIDFromMatriale_Kamera(KamaraID);

            controller.InsertLoanerIDandMatIDInLoaned();
            Console.ReadLine();

            LoanMore();
             }
            else if (CheckForLoan == false)
            {
                Console.WriteLine("0. for at vende tilbage til hovedmenu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        mainMenu();
                        break;
                }

           
                
                
            }


        }

        private void ShowKabelHome() // Kabler der er HJEMME
        {
            Console.Clear();
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
                case "1": ShowKamaraLoaned();
                    break;
                case "2":
                    ShowKabelLoaned();
                    break;
                default: Console.WriteLine("ugyldigt input");
                    break;
            }
        }

        private void ShowKamaraLoaned() 
        {
            Console.Clear();
            controller.ShowKamaraLoaned();
            Console.ReadLine();
        }

        private void ShowKabelLoaned() 
        {
           
        }

        private void LoanMore()
        {
            Console.Clear();
            Console.WriteLine("skal der lånes mere?\n" +
                "1. ja\n" +
                "2. Nej");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChooseTypeHome();
                    break;
                case "2":
                    Confirmation();
                    break;
                default: Console.WriteLine("ugyldigt input");
                    break;
            }
        }

        private void Confirmation() // bekræfter og printer hvilken bruger har lånt og hvad der er lånt
        {
            Console.Clear();
            string PrintResult = "";
            

            if (ChosenMaterial.Count() > 1)
            {
                for (int i = 0; i < ChosenMaterial.Count(); i++)
                {
                    string Result = ChosenMaterial[i].ToString();
                    PrintResult = PrintResult + " - " + Result.TrimEnd('-');
                }
            }
            else if (ChosenMaterial.Count() == 1)
            {
                PrintResult = ChosenMaterial[0];
            }


            Console.WriteLine(username + " " + userLastname + " har lånt " + PrintResult + "\n" +
                "enter for hovedmenu");
            Console.ReadLine();
            mainMenu();
        }

        private void ReturnItem()
        {
            Console.Clear();
            Console.WriteLine("Indtast ID på materiale");
            string input = Console.ReadLine();

            mainMenu();
        }


    }
}
