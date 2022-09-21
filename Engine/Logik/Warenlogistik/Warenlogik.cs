using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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
        SortedList<Guid, Produkt> katalog = new();
        public Warenlogik()
        {
            SortedList<Guid, Produkt>? tmp = KatalogSpeichernLaden.KatalogLaden();
            if (tmp != null)
            {
                katalog = tmp;
            }
        }
        public void ProduktDemKatalogHinzufuegen(Produkt produkt)
        {
            if (katalog.ContainsKey(produkt.GUID) && produkt.GUID != Guid.Empty)
            {
                foreach (KeyValuePair<Ort, int> kv in produkt.OrtUndAnzahl)
                {
                    ProduktAufstocken(produkt.GUID, kv);
                }
            }
            else if (produkt.GUID != Guid.Empty)
            {
                katalog.Add(produkt.GUID, produkt);
            }
            else
            {
                produkt.GUID = Guid.NewGuid();
                katalog.Add(produkt.GUID, produkt);
            }
        }
        public void ProduktAusDemKatalogEntfernen(Produkt produkt)
        {
            if (produkt != null)
            {
                try
                {
                    katalog.Remove(produkt.GUID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("zu entfernendes Produkt ist null.");
            }
        }
        public void ProduktAufstocken(Guid produktId, KeyValuePair<Ort, int> Anzahl)
        {
            if (katalog.ContainsKey(produktId))
            {
                katalog[produktId].OrtUndAnzahlHinzufuegen(Anzahl);
            }
        }
        public SortedList<Guid, Produkt> GetKatalog()
        {
            return katalog;
        }

    }
}
