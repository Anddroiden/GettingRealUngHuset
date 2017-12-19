using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class Controller
    {
        Database sql = new Database();

        public void InsertUser(string LoanerName, string LoanerLastname, string LoanerPhone, string LoanerEmail)
        {
            sql.InsertUser(LoanerName, LoanerLastname, LoanerPhone, LoanerEmail);
        }

        public void GetIDFromLoaner(string LoanerName, string LoanerLastname, string LoanerPhone, string LoanerEmail)
        {
            sql.GetIDFromLoaner(LoanerName, LoanerLastname, LoanerPhone, LoanerEmail);
        }

        public void GetIDFromMatriale_Kamera(string KamaraID) // FÅ MATRIALE ID
        {
            sql.GetIDFromMatriale_Kamera(KamaraID);
        }
        public void GetKamaralistHome() // KAMERA HJEMME
        {
            sql.GetKamaraListHome();
        }

        public void GetKabellistHome() // KABLE HJEMME
        {
            sql.GetKabelListHome();
        }

        public void InsertKameraIDInMaterial(string ItemNumber)
        {
            sql.InsertKameraIDInMaterial(ItemNumber);
        }

        
        public void InsertLoanerIDandMatIDInLoaned(string id)
        {

        }


        //public void GetKamaralistHome() // KAMERA LÅNT
        //{
        //    sql.GetKamaraListHome();
        //}

        //public void GetKabellistHome() // KABLE LÅNT
        //{
        //    sql.GetKabelListHome();
        //}
    }
}
