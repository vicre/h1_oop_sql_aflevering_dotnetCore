using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace h1_oop_sql_aflevering_dotnetCore
{
    class Bestillinger
    {
        // Default constukter
        public Bestillinger( int kundeId, string bestillingsTid, string film, int antalPladser, string betaltEllerReserveret )
        {
            KundeId                 = kundeId;
            BestillingsTid          = bestillingsTid;
            Film                    = film;
            AntalPladser            = antalPladser;
            BetaltEllerReserveret   = betaltEllerReserveret;
        }

        public int KundeId { get; set; }
        public string BestillingsTid { get; set; }
        public string Film { get; set; }
        public int AntalPladser { get; set; }
        public string BetaltEllerReserveret { get; set; }

        public void InsertIntoDB()
        {
            string sql = $"INSERT INTO Bestilling ( KundeID, BestillingsTid, Film, AntalPladser, BetaltEllerReserveret ) VALUES ({KundeId}, '{BestillingsTid}', '{Film}', {AntalPladser}, '{BetaltEllerReserveret}')";
            // string sql = "INSERT INTO Bestilling ( KundeID, BestillingsTid, Film, AntalPladser, BetaltEllerReserveret ) VALUES (1, '2020-01-01 00:00', 'Terminator 232', 2, 'betalt')";
            
            try
            {
                Sql.insert(sql);
                Console.WriteLine($"Bestilling med kunde id {KundeId} oprettet på tabellen");
            }
            catch (Exception)
            {
                Console.WriteLine($"Der opstod en fejl i oprettelsen, kunden {KundeId} IKKE oprettet");
            }
            
        }


        public override string ToString()
        {
            // return base.ToString();
            return $"Bestillings instans: {KundeId}, {BestillingsTid}, {Film}, {AntalPladser}, {BetaltEllerReserveret},";
        }

        // public static List<Bestillinger> DanBestillingerListe()
        // {
        //     string sql = "Select * from Bestillinger";
        //     DataTable bestillingDataTable = Sql.ReadTable(sql);

        //     List<Bestillinger> listBestillinger = new List<Bestillinger>();

        //     foreach (DataRow bestillingData in bestillingDataTable.Rows)
        //     {
        //         listBestillinger.Add(new Bestillinger()
        //         {
        //             // // BestillingerId = Convert.ToInt32(kundeData["BestillingerId"]),
        //             // Navn    = kundeData["Navn"].ToString(),
        //             // Telefon = kundeData["Telefon"].ToString(),
        //             // Email   = kundeData["Email"].ToString(),
        //             // BestillingerType = kundeData["KundeType"].ToString()
        //         });
        //     }

        //     // //En specifik rækker, her den første ellers kan [0] udskiftes med tal eller tæller
        //     // string denførsterække = kundeDataTable.Rows[0]["Navn"].ToString();
        //     // Console.WriteLine("Den første række " + denførsterække + kundeDataTable.Rows.Count);

        //     return listKunde;
        // }
    }
}