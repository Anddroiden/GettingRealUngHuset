using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealUngHuset
{
    class Loaner
    {

        public static void RegisterLoaner(string LoanerName, string LoanerLastname, string LoanerPhone, string LoanerEmail)
        {
            Controller controller = new Controller();
            controller.InsertUser(LoanerName, LoanerLastname, LoanerPhone, LoanerEmail);
        }

    }
}
