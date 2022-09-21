using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;

namespace Engine
{
    public class TestEngine
    {
        Warenlogik wl = new Warenlogik();
        public void Main()
        {
            Produkt p = new Produkt();
            p.GUID = Guid.NewGuid();
            p.Name = "test1";
            wl.ProduktHinzufuegen(p);
            p.Name = "test2";
            wl.ProduktHinzufuegen(p, (uint)5);
            wl.ProduktEntfernen((uint)3);
            wl.ProduktEntfernen(p);

            SortedList<uint, Produkt> produktliste = wl.GetProduktliste();
            foreach (KeyValuePair<uint, Produkt> kv in produktliste)
            {
                Console.WriteLine("Produkt mit Namen " + kv.Value.Name + " mit der ID " + kv.Key + " ist in der Liste vorhanden.");
            }
        }
        

    }
}