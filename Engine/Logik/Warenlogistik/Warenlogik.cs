using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    /* Katalog mit fester ID für die Produkte.
     * Produkte mit Anzahl
     * sinnvollere produktliste (Struktur)
     * https://stackoverflow.com/questions/1866794/naming-classes-how-to-avoid-calling-everything-a-whatevermanager
     * x => x.ID (linq) 
    */


    internal class Warenlogik
    {
        SortedList<uint, Produkt> produktliste = new();
        List<Produkt> produktliste2 = new();
        public void ProduktHinzufuegen(Produkt produkt)
        {            
            if (!produktliste.ContainsKey(produkt.Id) && produkt.Id != 0)
            {
                produktliste.Add(produkt.Id, produkt);
                Console.WriteLine("Produkt \"" + produkt.Name + "\" wurde erfolgreich hinzugefügt.");
            }
            else
            {
                for (uint i = 1; i <= produktliste.Count+1; i++)
                {
                    if (!produktliste.ContainsKey(i))
                    {
                        produkt.Id = i;
                        produktliste.Add(i, produkt);
                        Console.WriteLine("Produkt \""+ produkt.Name + "\" hatte eine bereits vergebene ID. Es wurde die neue ID: \" "+ produkt.Id + "\" vergeben und das Produkt wurde erfolgreich hinzugefügt.");
                        break;
                    }
                }
            }
        }
        public void ProduktHinzufuegen2(Produkt produkt)
        {
            produktliste2.Add(produkt);            
        }
        public void ProduktHinzufuegen(Produkt produkt, uint anzahl)
        {
            uint maximaleDurchläufe = (uint)produktliste.Count + anzahl;
            for (uint i = 1; i <= maximaleDurchläufe; i ++)
            {
                if (!produktliste.ContainsKey(i))
                {
                    produkt.Id = i;
                    produktliste.Add(i, produkt);
                    anzahl--;
                    Console.WriteLine("Produkt \"" + produkt.Name + "\" wurde mit der ID: \" " + produkt.Id + "\" erfolgreich hinzugefügt.");
                    if (anzahl <= 1)
                    {
                        break;
                    }
                }
            }
        }
        public void ProduktEntfernen2(Produkt produkt)
        {
            Produkt p = produktliste2.First(x => x.GUID == produkt.GUID);
            if (p != null)
            {
                produktliste2.Remove(p);
            }
        }
        public void ProduktEntfernen(Produkt produkt)
        {
            if (produkt.Id == 0)
            {
                Console.WriteLine("Zum entfernen angegebenes Produkt hat keine ID. Versuche passendes Produkt zu finden: ");
                if (produktliste.ContainsValue(produkt)) //ggf durch eigene Abfrage austauschen. Es muss ja nur der Name und ggf Ort übereinstimmen, nicht das komplette Objekt.
                {
                    Produkt p = produktliste.ElementAt(produktliste.IndexOfValue(produkt)).Value;
                    Console.WriteLine("Produkt \"" + produkt.Name + "\"mit der id: \"" + produkt.Id + "\" wurde nicht gefunden und konnte dementsprechend auch nicht entfernt werden. Es wurde allerdings gefunden mit Namen: " + p.Name + " und ID: " + p.Id);
                    produktliste.Remove(p.Id);
                }
                else
                {
                    Console.WriteLine("Produkt \"" + produkt.Name + "\"mit der id: \"" + produkt.Id + "\" wurde nicht gefunden und konnte dementsprechend auch nicht entfernt werden.");
                }
            }
            else
            {
                if (produktliste.ContainsKey(produkt.Id))
                {
                    produktliste.Remove(produkt.Id);
                    Console.WriteLine("Produkt \"" + produkt.Name + "\"mit der id: \"" + produkt.Id + "\" wurde gefunden und entfernt.");
                }
                else
                {
                    Console.WriteLine("Produkt \"" + produkt.Name + "\"mit der id: \"" + produkt.Id + "\" wurde nicht gefunden und konnte dementsprechend auch nicht entfernt werden.");
                }
            }
        }
        public void ProduktEntfernen(uint id)
        {
            if (produktliste.ContainsKey(id))
            {                
                produktliste.Remove(id);
                Console.WriteLine("Produkt mit der id: \"" + id + "\" wurde gefunden und entfernt.");
            }
            else
            {
                Console.WriteLine("Produkt mit der id: \"" + id + "\" wurde nicht gefunden und konnte dementsprechend auch nicht entfernt werden.");
            }
        }
        public SortedList<uint, Produkt> GetProduktliste()
        {
            return produktliste;
        }
    }
}
