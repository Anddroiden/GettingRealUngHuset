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

        public void InsertUser(String LoanerName, String LoanerLastname, String LoanerPhone, String LoanerEmail)
        {
            sql.InsertUser(LoanerName, LoanerLastname, LoanerPhone, LoanerEmail);
        }

    }
}
