using Engine.Konstrukte.Lagereinheiten;
using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte
{
    public class Lagerhaus
    {
        #region Variables
        public Ort Ort { get; set; }
        public int Index { get; set; }
        public List<Lagereinheit> Lagereinheiten { get; set; }
        #endregion

        #region Konstruktoren
        public Lagerhaus(Ort ort, int index, List<Lagereinheit> lagereinheiten)
        {
            this.Ort = ort;
            this.Index = index;
            this.Lagereinheiten = lagereinheiten;
        }
        public Lagerhaus(Ort ort, int index) : this(ort, index, new List<Lagereinheit>()) { }
        public Lagerhaus(int index) : this (new Ort(), index) { }
        public Lagerhaus() : this(-1) { }
        #endregion
        public List<Lagereinheit> GetFreieLagerplätze()
        {
            return GetLagerplätze(Lagereinheiten, false);
        }
        public List<Lagereinheit> GetFreieLagerplätze(LagerEinheitGröße größe)
        {
            return GetLagerplätze(Lagereinheiten, false, größe);
        }
        public List<Lagereinheit> GetBelegteLagerplätze()
        {
            return GetLagerplätze(Lagereinheiten, true);
        }
        public List<Lagereinheit> GetBelegteLagerplätze(LagerEinheitGröße größe)
        {
            return GetLagerplätze(Lagereinheiten, true, größe);
        }
        public static List<Lagereinheit> GetLagerplätze(List<Lagereinheit> liste, bool belegt)
        {
            List<Lagereinheit> tmp = new List<Lagereinheit>();
            foreach (Lagereinheit l in liste)
            {
                if (belegt == l.belegt)
                {
                    tmp.Add(l);
                }
            }
            return tmp;
        }
        public static List<Lagereinheit> GetLagerplätze(List<Lagereinheit> liste, bool belegt, LagerEinheitGröße lagereinheitgröße)
        {
            List<Lagereinheit> tmp = new List<Lagereinheit>();
            foreach (Lagereinheit l in liste)
            {
                if (belegt == l.belegt && l.größe == lagereinheitgröße)
                {
                    tmp.Add(l);
                }
            }
            return tmp;
        }
        public void LagerAufstocken(Guid katalogItemGuid, LagerEinheitGröße gößeneinheit, int anzahl)
        {
            for (int i = 0; i < anzahl; i++)
            {
                int index = Lagereinheiten.FindIndex(x => (x.größe == gößeneinheit) && x.belegt == false);
                if (index != -1)
                {
                    Lagereinheiten[index].belegt = true;
                    Lagereinheiten[index].KatalogItemGuid = katalogItemGuid;
                }
                else
                {
                    Exception ex = new Exception("Im Lager ist nicht genug Platz für diese Anzahl an KatalogItems. Es wurden " + (i+1) + " von " + anzahl +"Einheiten hinzugefügt");
                    throw ex;
                }
            }
        }
        public void LagerLeeren(Guid katalogItemGuid, int anzahl)
        {
            if (katalogItemGuid != Guid.Empty)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    int index = Lagereinheiten.FindIndex(x => x.KatalogItemGuid == katalogItemGuid);
                    if (index != -1)
                    {
                        Lagereinheiten[index].belegt = false;                        
                    }
                    else
                    {
                        Exception ex = new Exception("Im Lager sind nicht KatalogItems. Es wurden " + (i + 1) + " von " + anzahl + "Einheiten entfernt.");
                        throw ex;
                    }
                }
            }

        }

    }
}
