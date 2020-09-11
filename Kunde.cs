using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace h1_oop_sql_aflevering_dotnetCore
{
    // lav en klasse som skaber instanser:
    // Navn, Telefon, Email, Kundetype
    class Kunde
    {
        // Default constukter
        public Kunde(string navn, string telefon, string email, string kundeType)
        {
            Navn        = navn;
            Telefon     = telefon;
            Email       = email;
            KundeType   = kundeType;
        }

        public Kunde()
        {
        }

        private string navn;        public string Navn      { get { return navn;      } set { navn = value; } }
        private string telefon;     public string Telefon   { get { return telefon;   } set { telefon = value; } }
        private string email;       public string Email     { get { return email;     } set { email = value; } }
        private string kundeType;   public string KundeType { get { return kundeType; } set { kundeType = value; } }


        public void InsertIntoDB()
        {
            string sql = $"INSERT INTO Kunde ( Navn, Telefon, Email, Kundetype ) VALUES ('{navn}','{telefon}', '{email}', '{kundeType}')";
            try
            {
                Sql.insert(sql);
                Console.WriteLine($"Kunden {Navn} oprettet på tabellen");
            }
            catch (Exception)
            {

                Console.WriteLine("Der opstod en fejl i oprettelsen, kunden IKKE oprettet");
            }
            
        }

        public override string ToString()
        {
            // return base.ToString();
            return $"Kunde instans: {Navn}, {Telefon}, {Email}, {KundeType}";
        }

        public static List<Kunde> DanKundeListe()
        {
            string sql = "Select * from Kunde";
            DataTable kundeDataTable = Sql.ReadTable(sql);

            List<Kunde> listKunde = new List<Kunde>();

            foreach (DataRow kundeData in kundeDataTable.Rows)
            {
                listKunde.Add(new Kunde()
                {
                    // KundeId = Convert.ToInt32(kundeData["KundeId"]),
                    Navn    = kundeData["Navn"].ToString(),
                    Telefon = kundeData["Telefon"].ToString(),
                    Email   = kundeData["Email"].ToString(),
                    KundeType = kundeData["KundeType"].ToString()
                });
            }

            // //En specifik rækker, her den første ellers kan [0] udskiftes med tal eller tæller
            // string denførsterække = kundeDataTable.Rows[0]["Navn"].ToString();
            // Console.WriteLine("Den første række " + denførsterække + kundeDataTable.Rows.Count);

            return listKunde;
        }
    }
}
