﻿using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
        internal List<KatalogItem> Katalog { get; private set; }
        internal List<Lagerhaus> Lagerhäuser { get; private set; }
        internal Warenlogik()
        {
            ladeWarenkatalog();
            ladeLagerhäuser();

        }
        internal void ladeWarenkatalog()
        {
            List<KatalogItem>? tmp = KatalogSpeichernLaden.KatalogLaden();
            if (tmp != null)
            {
                Katalog = tmp;
            }
            else
            {
                Katalog = new();
            }
        }
        internal void ladeLagerhäuser()
        {
            List<Lagerhaus>? tmp = KatalogSpeichernLaden.LagerhäuserLaden();

            if (tmp != null)
            {
                Lagerhäuser = tmp;
            }
            else
            {
                Lagerhäuser = new();
            }
        }
        internal void KatalogItemDemKatalogHinzufuegen(string name, MaßeTemplate maße, int lagerhausindex, int anzahl)
        {
            KatalogItem katalogItem;
            if (Lagerhäuser.Find(x => x.Index == lagerhausindex) != null)
            {
                katalogItem = new KatalogItem(name, maße, lagerhausindex);
                Lagerhäuser.Find(x => x.Index == lagerhausindex).LagerAufstocken(katalogItem.GUID, katalogItem.Größenklasse, anzahl);
            }
            else            
            {
                katalogItem = new KatalogItem(name, maße);
                Console.WriteLine("Lagerhausindex nicht gefunden. Produkt wird nur dem Katalog hinzugefügt.");                
                katalogItem.LagerhäuserMitItem.Remove(lagerhausindex);
            }
            Katalog.Add(katalogItem);
        }
        internal void KatalogItemDemKatalogHinzufuegen(KatalogItem ki)
        {
            if (ki.LagerhäuserMitItem == null || ki.LagerhäuserMitItem.Count == 0)
            {
                KatalogItemDemKatalogHinzufuegen(ki.Name, ki.Maße);
            }
            else
            {
                //ToDo
                //KatalogItemDemKatalogHinzufuegen(ki.Name, ki.Maße, ki.)
            }
        }
        public void KatalogItemDemKatalogHinzufuegen(string name, MaßeTemplate maße)
        {
            Katalog.Add(new KatalogItem(name, maße));
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
