using System;
using System.Data.SqlClient;

namespace h1_oop_sql_aflevering_dotnetCore
{
    static public class SqlInput
    {
        // metode
        public static void InsertIntoDB(string input)
        {
            try
            {
                SqlConn.insert(input);
                Console.WriteLine($"sql kommandoen lykkedes");
            }
            catch (Exception)
            {
                Console.WriteLine($"sql kommandoen lykkedes ikke");
            }
            
        }
    }
}
