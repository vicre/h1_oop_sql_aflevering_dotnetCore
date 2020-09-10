using System;

namespace h1_oop_sql_aflevering_dotnetCore
{
    // Note:  hvis den ikke statisk kan du kun kalde metoden fra et objekt
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Debugging start - i mens du tester så sletter du tabellerne
            //

            // Chekker om der er forbindelse til serveren
            Console.WriteLine(SqlConn.SqlConnectionOK());

            SqlInput.InsertIntoDB("drop table Bestilling");
            SqlInput.InsertIntoDB("drop table Kunde");

            SqlInput.InsertIntoDB(
            @"
                create table Kunde(
                    KundeId int identity(1,1) primary key,
                    Navn nvarchar(50),
                    Telefon nvarchar(50),
                    Email nvarchar(50),
                    Kundetype nvarchar(50) /* Der skal stå enten 'standard' eller 'premium' */
                )
            ");

            SqlInput.InsertIntoDB(
            @"
                create table Bestilling(
                    BestillingId int identity(1,1) primary key,
                    KundeId int,
                    BestillingsTid nvarchar(50),
                    Film nvarchar(50),
                    AntalPladser int,
                    BetaltEllerReserveret nvarchar(50) /* Der skal enten stå 'betalt' eller 'reserveret' */
                ) 
            ");

            SqlInput.InsertIntoDB(
            @"
                ALTER TABLE Bestilling
                ADD FOREIGN KEY (KundeId) REFERENCES Kunde(KundeId);
            "); 

            // laver kunde instans og indsætter i db
            Kunde k1 = new Kunde("Susanne Espersen", "12345678", "mads.hansen@gmail.com", "betalt");    k1.InsertIntoDB(); // System.Console.WriteLine(k1.ToString());
            Kunde k2 = new Kunde("Mads Hansen", "25456589", "mads.hansen@gmail.com", "standard");       k2.InsertIntoDB(); // System.Console.WriteLine(k2.ToString());
            //
            // Debugging slut
            //

            // program variabler
            string currentTime;

            
            //
            // Opgave Create ~ Insert into start
            //

            // laver bestillings instans og indsætter i database
            currentTime = DateTime.Now.ToString("yyyy-mm-ss HH:ss:ffff");            
            Bestillinger b1 = new Bestillinger(1, currentTime, "terminator b1", 1, "Betalt");
            b1.InsertIntoDB();

            currentTime = DateTime.Now.ToString("yyyy-mm-ss HH:ss:ffff");
            Bestillinger b2 = new Bestillinger(1, currentTime, "terminator b2", 1, "Betalt");
            b2.InsertIntoDB();

            currentTime = DateTime.Now.ToString("yyyy-mm-ss HH:ss:ffff");
            Bestillinger b3 = new Bestillinger(1, currentTime, "terminator b3", 1, "Betalt");
            b3.InsertIntoDB();

            //
            // Opgave Create ~ Insert into slut
            //

            //
            // Opgave Create ~ Select from start
            //

            

            //
            // Opgave Create ~ Select from slut
            //
        }
    }
}
