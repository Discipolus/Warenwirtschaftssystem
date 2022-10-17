using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte
{
    public class Ort
    {
        //ggf Lagerplatz hinzufügen in eigener Klasse. Mit Platz (Regale, Stellflächen, wieviel qm ist platz etc.
        internal string Land { get; set; }
        internal DeutscheBundesländer Bundesland { get; set; }
        internal string Ortsname { get; set; }
        internal string PLZ { get; set; }
        internal string Strassenname { get; set; }
        internal int Hausnummer { get; set; }
        internal string Hausnummerzusatz { get; set; }
        internal string Adresszusatz { get; set; }
        internal Ort(string land, DeutscheBundesländer bundesland, string ortsname, string plz, string strassenname, int hausnummer, string hausnummerzusatz, string adresszusatz)
        {
            Land = land;
            Bundesland = bundesland;
            Ortsname = ortsname;
            PLZ = plz;
            Strassenname = strassenname;
            Hausnummer = hausnummer;
            Hausnummerzusatz = hausnummerzusatz;
            Adresszusatz = adresszusatz;
        }
        internal Ort()
        {
            Bundesland = DeutscheBundesländer.Niedersachsen;
            Land = "";            
            Ortsname = "";
            PLZ = "";
            Strassenname = "";
            Hausnummer = -1;
            Hausnummerzusatz = "";
            Adresszusatz = "";
        }
        internal bool equals(Ort ort)
        {
            if (
            Bundesland == ort.Bundesland 
            && Land == ort.Land 
            && Ortsname == ort.Ortsname 
            && PLZ == ort.PLZ 
            && Strassenname == ort.Strassenname 
            && Hausnummer == ort.Hausnummer 
            && Hausnummerzusatz == ort.Hausnummerzusatz
            && Adresszusatz == ort.Adresszusatz
                )
            {
                return true;
            }
            return false;
        }
        
    }
}
