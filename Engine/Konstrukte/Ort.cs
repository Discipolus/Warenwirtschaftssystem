using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte
{
    internal class Ort
    {
        public string Land { get; set; }
        public DeutscheBundesländer Bundesland { get; set; }
        public string Ortsname { get; set; }
        public string PLZ { get; set; }
        public string Strassenname { get; set; }
        public int Hausnummer { get; set; }
        public string Hausnummerzusatz { get; set; }
        public string Adresszusatz { get; set; }
        public Ort(string land, DeutscheBundesländer bundesland, string ortsname, string plz, string strassenname, int hausnummer, string hausnummerzusatz, string adresszusatz)
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
    }
}
