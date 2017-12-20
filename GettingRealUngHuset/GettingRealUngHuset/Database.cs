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

        public void InsertUser(string LoanerName, string LoanerLastname, string LoanerPhone, string LoanerEmail)
        {

            using (SqlConnection con = new SqlConnection(connectionString)) // SP INSERTUSER
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



                    cmd1.ExecuteNonQuery(); // Retunere ikke data
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }
        }
         
        public void GetKamaraListHome()
        {
            using (SqlConnection con = new SqlConnection(connectionString)) // SP GetKamaraList
            {
               
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("GetKamaraList", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                   SqlDataReader list = cmd1.ExecuteReader();

                        while(list.Read())
                        {

                        for (int i = 0; i < list.FieldCount; i++)
                        {

                            Console.WriteLine(list.GetValue(i));
                        }
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }
        }

        public void GetKabelListHome()
        {
            using (SqlConnection con = new SqlConnection(connectionString)) // SP GetkabelList
            {

                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("GetKabelList", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    SqlDataReader list = cmd1.ExecuteReader();

                    while (list.Read())
                    {

                        for (int i = 0; i < list.FieldCount; i++)
                        {
                            Console.WriteLine(list.GetValue(i)); // Mangler lidt forklaring i loop
                        }

                    }

                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }
        }

        public void GetIDFromLoaner(string LoanerName, string LoanerLastname, string LoanerPhone, string LoanerEmail)
        {
            Controller controller = new Controller();

            using (SqlConnection con = new SqlConnection(connectionString)) // SP GetIDFromLoaner
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("GetIDFromLoaner", con);
                    cmd1.CommandType = CommandType.StoredProcedure;


                    cmd1.Parameters.Add(new SqlParameter("@LoanerName", LoanerName));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerLastname", LoanerLastname));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerPhone", LoanerPhone));
                    cmd1.Parameters.Add(new SqlParameter("@LoanerEmail", LoanerEmail));

                    SqlDataReader LoanerID = cmd1.ExecuteReader();
                    string ID = LoanerID.ToString();

                    Console.ReadLine();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }
        }

        public void InsertKameraIDInMaterial(string KamaraID)
        {

            using (SqlConnection con = new SqlConnection(connectionString)) // SP InsertKameraIDInMaterial
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertKameraIDInMaterial", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@KamaraID", KamaraID));

                    cmd1.ExecuteNonQuery(); // Retunere ikke data
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                };
            }
        }

        public void GetIDFromMatriale_Kamera(string KamaraID)
        {

            using (SqlConnection con = new SqlConnection(connectionString)) // SP GetIDFromMat =to Kamera
            {
                Controller controller = new Controller();
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("GetIDFromMatriale_Kamera", con);

                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@KamaraID", KamaraID));
                    

                    SqlDataReader MatID = cmd1.ExecuteReader();
                    string ID = MatID.ToString();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                }
            }
        }


        public void InsertLoanerIDandMatIDInLoaned(string LoanerID, string matrialeID)
        {

            using (SqlConnection con = new SqlConnection(connectionString)) // SP InsertKameraIDInMaterial
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertLoanerIDandMatIDInLoaned", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@LoanerID", LoanerID));

                    cmd1.ExecuteNonQuery(); // Retunere ikke data
                }
                catch (SqlException e)
                {
                    Console.WriteLine("HOW!" + e.Message);
                };
            }
        }

        public void ReturnItem (string materialeID) //retuner materiale
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("ReturnProcedure", con);

                    cmd1.Parameters.Add(new SqlParameter("@kamaraID", materialeID));

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

