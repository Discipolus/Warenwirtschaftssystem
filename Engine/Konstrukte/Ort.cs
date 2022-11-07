using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte
{
    public class Ort
    {
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
        internal Ort() : this("", DeutscheBundesländer.Niedersachsen, "", "", "", -1, "", "") {}
        internal static bool equals(Ort ort1, Ort ort2)
        {
            if (
            ort2.Bundesland == ort1.Bundesland 
            && ort2.Land == ort1.Land 
            && ort2.Ortsname == ort1.Ortsname 
            && ort2.PLZ == ort1.PLZ 
            && ort2.Strassenname == ort1.Strassenname 
            && ort2.Hausnummer == ort1.Hausnummer 
            && ort2.Hausnummerzusatz == ort1.Hausnummerzusatz
            && ort2.Adresszusatz == ort1.Adresszusatz
                )
            {
                return true;
            }
            return false;
        }
        internal bool equals(Ort ort)
        {
            return equals(this, ort);
        }
        
    }
}
