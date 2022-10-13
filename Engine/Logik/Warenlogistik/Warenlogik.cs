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
        //public SortedList<Guid, KatalogItem> katalog { get; set; }
        internal List<KatalogItem> Katalog { get; set; }
        internal List<Lagerhaus> Lagerhäuser { get; set; }
        internal Warenlogik()
        {
            List<KatalogItem>? tmp = KatalogSpeichernLaden.KatalogLaden();
            List<Lagerhaus>? tmp2 = KatalogSpeichernLaden.LagerhäuserLaden();
            if (tmp != null)
            {
                Katalog = tmp;
            }
            else
            {
                Katalog = new();
            }
            if (tmp2 != null)
            {
                Lagerhäuser = tmp2;
            }
            else
            {
                Lagerhäuser = new();
            }
        }
        internal void LagerAufstocken(Guid katalogItemGuid, int lagerhausIndex, int anzahl)
        {
            KatalogItem? ki = Katalog.Find(x => x.GUID == katalogItemGuid);
            Lagerhaus? l = Lagerhäuser.Find(x => x.Index == lagerhausIndex);
            if (l != null && ki != null)
            {
                if (!ki.LagerhäuserMitItem.Contains(lagerhausIndex))
                {
                    ki.LagerhäuserMitItem.Add(lagerhausIndex);
                }
                l.LagerAufstocken(katalogItemGuid,ki.Größenklasse, anzahl);
            }
        }
        internal void LagerLeeren(Guid katalogItemGuid, int lagerhausIndex, int anzahl)
        {
            KatalogItem? ki = Katalog.Find(x => x.GUID == katalogItemGuid);
            Lagerhaus? l = Lagerhäuser.Find(x => x.Index == lagerhausIndex);
            if (l != null && ki != null)
            {
                if (ki.LagerhäuserMitItem.Contains(lagerhausIndex))
                {
                    ki.LagerhäuserMitItem.Add(lagerhausIndex);
                }
                l.LagerLeeren(katalogItemGuid, anzahl);
            }
        }
    }
}
