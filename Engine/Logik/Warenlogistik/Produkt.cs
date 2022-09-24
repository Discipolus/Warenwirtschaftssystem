using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    public class Produkt
    {
        public Produkt(string name, List<KeyValuePair<Ort, int>> ortUndAnzahl)
        {
            Name = name;
            GUID = Guid.NewGuid();
            OrtUndAnzahl = ortUndAnzahl;            
        }
        public string Name { get; set; }
        public double[] Volumen = new double[3] { 4.1, 4.6, 1 };
        //public Ort AktuellerOrt { get; set; }
        public Guid GUID { get; set; }
        public List<KeyValuePair<Ort, int>> OrtUndAnzahl { get; set; }
        private bool OrtRegistriert(Ort ort)
        {
            foreach (KeyValuePair<Ort, int> kv in OrtUndAnzahl)
            {
                if (kv.Key.Id == ort.Id)
                return true;
            }
            return false;
        }
        public void OrtUndAnzahlHinzufuegen(KeyValuePair<Ort, int> ortUndAnzahl)
        {
            if (OrtRegistriert(ortUndAnzahl.Key))
            {
                foreach (KeyValuePair<Ort, int> kv in OrtUndAnzahl)
                {
                    if (kv.Key.Id == ortUndAnzahl.Key.Id)
                    {
                        KeyValuePair<Ort, int> tmp = new KeyValuePair<Ort, int>(kv.Key, kv.Value + ortUndAnzahl.Value);
                        OrtUndAnzahl.Remove(kv);
                        OrtUndAnzahl.Add(tmp);
                        return;                        
                    }
                }
            }
            else
            {
                OrtUndAnzahl.Add(ortUndAnzahl);
            }
        }
        public bool OrtUndAnzahlEntfernen(KeyValuePair<Ort, int> ortUndAnzahl)
        {
            if (OrtRegistriert(ortUndAnzahl.Key))
            {

            }
            return false;
        }
    }
}
