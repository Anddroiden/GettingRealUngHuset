using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingRealUngHuset
{
    class Database
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database =DB2017_B08; User ID =USER_B08; Password=SesamLukOp_08";

        public void InsertUser(String LoanerName, String LoanerLastname, String LoanerPhone, String LoanerEmail)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("INSERTUSER", con);
                    cmd1.CommandType = CommandType.StoredProcedure;


                    cmd1.Parameters.Add(new SqlParameter("@LoanerName", LoanerName));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerLastname", LoanerLastname));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerPhone", LoanerPhone));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerEmail", LoanerEmail));



                    cmd1.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }

        }
    }
}
