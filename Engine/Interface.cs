using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
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
                wl.Katalog.Add(item);
            }
        }
        public void ProduktAusKatalogEntfernen()
        {

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
