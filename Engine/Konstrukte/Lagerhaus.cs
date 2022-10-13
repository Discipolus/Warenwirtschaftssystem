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
    internal class Lagerhaus
    {
        #region Variables
        Ort _ort;
        internal int Index { get; set; }
        internal List<Lagereinheit> Lagerplatz { get; set; }
        #endregion

        #region Konstruktoren
        internal Lagerhaus()
        {
            _ort = new Ort();
            Lagerplatz = new List<Lagereinheit>();
        }

        internal Lagerhaus(Ort ort)
        {
            this._ort = ort;
            Lagerplatz = new List<Lagereinheit>();
        }
        #endregion
        internal List<Lagereinheit> GetFreieLagerplätze()
        {
            return GetLagerplätze(Lagerplatz, false);
        }
        internal List<Lagereinheit> GetFreieLagerplätze(LagerEinheitGröße größe)
        {
            return GetLagerplätze(Lagerplatz, false, größe);
        }
        internal List<Lagereinheit> GetBelegteLagerplätze()
        {
            return GetLagerplätze(Lagerplatz, true);
        }
        internal List<Lagereinheit> GetBelegteLagerplätze(LagerEinheitGröße größe)
        {
            return GetLagerplätze(Lagerplatz, true, größe);
        }
        internal static List<Lagereinheit> GetLagerplätze(List<Lagereinheit> liste, bool belegt)
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
        internal static List<Lagereinheit> GetLagerplätze(List<Lagereinheit> liste, bool belegt, LagerEinheitGröße lagereinheitgröße)
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
        internal void LagerAufstocken(Guid katalogItemGuid, LagerEinheitGröße gößeneinheit, int anzahl)
        {
            for (int i = 0; i < anzahl; i++)
            {
                int index = Lagerplatz.FindIndex(x => (x.größe == gößeneinheit) && x.belegt == false);
                if (index != -1)
                {
                    Lagerplatz[index].belegt = true;
                    Lagerplatz[index].KatalogItemGuid = katalogItemGuid;
                }
                else
                {
                    Exception ex = new Exception("Im Lager ist nicht genug Platz für diese Anzahl an KatalogItems. Es wurden " + (i+1) + " von " + anzahl +"Einheiten hinzugefügt");
                    throw ex;
                }
            }
        }
        internal void LagerLeeren(Guid katalogItemGuid, int anzahl)
        {
            if (katalogItemGuid != Guid.Empty)
            {
                for (int i = 0; i < anzahl; i++)
                {
                    int index = Lagerplatz.FindIndex(x => x.KatalogItemGuid == katalogItemGuid);
                    if (index != -1)
                    {
                        Lagerplatz[index].belegt = false;                        
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
