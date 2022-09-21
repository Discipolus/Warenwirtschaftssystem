using Engine.Konstrukte;
using Engine.Logik.Warenlogistik;

namespace Engine
{
    public class TestEngine
    {
        Warenlogik wl = new Warenlogik();
        public void Main()
        {
            Produkt p = new Produkt("test5", new List<KeyValuePair<Ort, int>>());
            p.GUID = Guid.NewGuid();
            p.Name = "test5";
            wl.ProduktDemKatalogHinzufuegen(p);
            KatalogSpeichernLaden.KatalogSpeichern(wl.GetKatalog());

            //SortedList<uint, Produkt> produktliste = wl.GetProduktliste();
            //foreach (KeyValuePair<uint, Produkt> kv in produktliste)
            //{
            //    Console.WriteLine("Produkt mit Namen " + kv.Value.Name + " mit der ID " + kv.Key + " ist in der Liste vorhanden.");
            //}
        }
        

    }
}