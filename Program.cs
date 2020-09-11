using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine(Sql.SqlConnectionOK());

            Sql.InsertIntoDB("drop table Bestilling");
            Sql.InsertIntoDB("drop table Kunde");

            Sql.InsertIntoDB(
            @"
                create table Kunde(
                    KundeId int identity(1,1) primary key,
                    Navn nvarchar(50),
                    Telefon nvarchar(50),
                    Email nvarchar(50),
                    Kundetype nvarchar(50) /* Der skal stå enten 'standard' eller 'premium' */
                )
            ");

            Sql.InsertIntoDB(
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

            Sql.InsertIntoDB(
            @"
                ALTER TABLE Bestilling
                ADD FOREIGN KEY (KundeId) REFERENCES Kunde(KundeId);
            ");

            // laver kunde instans og indsætter i db
            Kunde k1 = new Kunde("Susanne Espersen", "12345678", "mads.hansen@gmail.com", "betalt"); k1.InsertIntoDB(); // System.Console.WriteLine(k1.ToString());
            Kunde k2 = new Kunde("Mads Hansen", "25456589", "mads.hansen@gmail.com", "standard"); k2.InsertIntoDB(); // System.Console.WriteLine(k2.ToString());
            Kunde k3 = new Kunde("Puol Fisker", "25456589", "mads.hansen@gmail.com", "standard"); k3.InsertIntoDB(); // 
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
            // List<Kunde> listKunde = new List<Kunde>();

            // minimumskrav - liste alle kunder i tabellen
            List<Kunde> listsKunde = Kunde.DanKundeListe();
            Console.WriteLine("Liste med kunder: ");
            foreach (var item in listsKunde)
            {
                Console.WriteLine($"Navn: {item.Navn}, Telefon: {item.Telefon}, Email: {item.Email}, Kundetype: {item.KundeType}");
            }

            // man skal kunne oprette, rette eller slette en kunde (hvad med eventuelle bestillinger?)
            Sql.InsertIntoDB(
            @"
                UPDATE Kunde
                SET Telefon = '9999999'
                WHERE KundeId = 1;
            ");
            List<Kunde> listsKunde2 = Kunde.DanKundeListe();
            Console.WriteLine("opdateret liste med kunder: ");
            foreach (var item in listsKunde2)
            {
                Console.WriteLine($"Navn: {item.Navn}, Telefon: {item.Telefon}, Email: {item.Email}, Kundetype: {item.KundeType}");
            }

            // Man skal kunne vælge få listen sorteret efter efternavn
            List<Kunde> listsKunde3 = Kunde.DanKundeListe();
            List<Kunde> SortedList = listsKunde3.OrderBy(o=>o.Navn).ToList();
            Console.WriteLine("sorteret liste med kunder: ");
            foreach (var item in SortedList)
            {
                //System.Console.WriteLine(item.ToString());
                Console.WriteLine($"Navn: {item.Navn}, Telefon: {item.Telefon}, Email: {item.Email}, Kundetype: {item.KundeType}");
            }

            //For en specifik kunde skal man kunne se alle bestillinger(på liste-form).
            List<Kunde> listsKunde4 = Kunde.DanKundeListe();

            //List<Bestillinger> listsBestillinger = Bestillinger.DanBestillingerListe();



            //
            // Opgave Create ~ Select from slut
            //
        }
    }
}
