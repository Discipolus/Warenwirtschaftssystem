using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Interface
    {
        
        Warenlogik wl = new Warenlogik();
        public Interface()
        {

        }
        public void Testrun()
        {
            TestEngine engine = new TestEngine();
            wl = engine.wl;
        }
        public void ProduktDemKatalogHinzufuegen(KatalogItem item)
        {
            if (wl.Katalog.Any(x => x.GUID == item.GUID))
            {
                string message = "item mit der GUID ist bereits im Katalog vorhanden. (" + item.GUID + ")";
                Console.WriteLine(message);                
            }
            else
            {
                wl.KatalogItemHinzufuegen(item);
            }
        }
        public void ProduktAusKatalogEntfernen(Guid GUID)
        {
            KatalogItem? item = wl.Katalog.Find(x => x.GUID == GUID);
            if (item != null)
            {
                wl.KatalogItemEntfernen(item);
            }
            else
            {
                string message = "Item mit der Guid: " + GUID.ToString() + " konnte nicht im Katalog gefunden, also auch nicht entfernt werden.";
                Console.WriteLine(message);                
            }
        }
        public List<string[]> GetKatalog()
        {
            List<string[]> list = new List<string[]>();
            list.Add(new string[5] { "ID","Name","Größenklasse","Maße (x|y|z) [m]","gelagert in"});
            foreach (KatalogItem item in wl.Katalog)
            {
                string[] s = item.ToString().Split(';');
                list.Add(s);
            }

            return list;
        }
        public List<KatalogItem> GetSpecificKatalog()
        {
            return wl.Katalog;
        }
        public void GetLagerhäuser()
        {

        }
        public void ProduktEinlagern()
        {

        }
        public void ProduktAuslagern()
        {

        }

    }
}
