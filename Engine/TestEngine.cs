using Engine.Konstrukte;
using Engine.Konstrukte.Lagereinheiten;
using Engine.Logik.Warenlogistik;

namespace Engine
{
    public class TestEngine
    {        
        internal Warenlogik wl = new Warenlogik();
        public TestEngine()
        {
            wl.LagerhausHinzufuegen(generiereLagerhaus());
            generiereKatalog();
            
            wl.LagerAufstocken(wl.Katalog[0].GUID, 0, 9);
            SpeichernLaden.LagerhäuserSpeichern(wl.Lagerhäuser); ;
            SpeichernLaden.KatalogSpeichern(wl.Katalog);
        }
        #region testmethoden
        private Lagerhaus generiereLagerhaus()
        {
            Lagerhaus l = new Lagerhaus(wl.Lagerhäuser.Count);
            for (int i = 0; i < 10; i++)
            {
                Lagereinheit einheit = new Lagereinheit(LagerEinheitGröße.klein);
                l.Lagereinheiten.Add(einheit);
            }
            for (int i = 0; i < 10; i++)
            {
                Lagereinheit einheit = new Lagereinheit(LagerEinheitGröße.mittel);
                l.Lagereinheiten.Add(einheit);
            }
            for (int i = 0; i < 10; i++)
            {
                Lagereinheit einheit = new Lagereinheit(LagerEinheitGröße.groß);
                l.Lagereinheiten.Add(einheit);
            }
            return l;
        }
        private List<KatalogItem> generiereKatalog()
        {
            List<KatalogItem> Katalog = new List<KatalogItem>();
            for (int i = 0; i < 5; i++)
            {
                KatalogItem ki = new KatalogItem("Produkt " + i, new MaßeTemplate( 2, 2, 2 ));
                wl.KatalogItemHinzufuegen(ki);
            }

            return Katalog;
        }
        #endregion
    }
}