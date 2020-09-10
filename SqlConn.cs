using System;
using System.Data.SqlClient;

namespace h1_oop_sql_aflevering_dotnetCore
{
    static class SqlConn
    {
        private static string ConnectionString = "Data Source=\"BYG-A101-VICRE\\SQLEXPRESS\";Initial Catalog=biograf; Integrated Security=SSPI;Connect Timeout=5;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static bool SqlConnectionOK()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
                //1) Create, Data der skal creates i en tabel (det hedder insert på sql'sk)
        public static void insert(string sql) 
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
