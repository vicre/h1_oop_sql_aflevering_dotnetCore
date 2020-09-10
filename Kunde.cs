using System;
using System.Data.SqlClient;


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


        private string navn;        public string Navn      { get { return navn;      } set { navn = value; } }
        private string telefon;     public string Telefon   { get { return telefon;   } set { telefon = value; } }
        private string email;       public string Email     { get { return email;     } set { email = value; } }
        private string kundeType;   public string KundeType { get { return kundeType; } set { kundeType = value; } }


        public void InsertIntoDB()
        {
            string sql = "INSERT INTO Kunde ( Navn, Telefon, Email, Kundetype ) VALUES ('c sharp','26129604', 'victor@reipur.dk', 'standard')";
            try
            {
                SqlConn.insert(sql);
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
    }
}
