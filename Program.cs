using System;

namespace h1_oop_sql_aflevering_dotnetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // klader metod
            Console.WriteLine(SqlConn.SqlConnectionOK());

            Kunde k1 = new Kunde("Mads Hansen", "12345678", "mads.hansen@gmail.com", "standard");
            System.Console.WriteLine(k1.ToString());

            k1.InsertIntoDB();
        }
    }
}
