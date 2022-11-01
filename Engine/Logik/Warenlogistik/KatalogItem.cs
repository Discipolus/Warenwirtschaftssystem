using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    public class KatalogItem
    {
        #region Variables
        public string Name { get; set; }
        private double[] _Maße;
        public double[] Maße
        {
            get => _Maße;
            set
            {
                if (value != null)
                {
                    if (value.Length == 3)
                    {
                        _Maße = value;
                    }
                    else
                    {
                        Console.WriteLine("KatalogItem (" + Name + ")..setVolume: value has not a length of 3.");
                    }
                }
                else
                {
                    Console.WriteLine("KatalogItem (" + Name + ")..setVolume: value is null.");
                }
            }

        }
        public LagerEinheitGröße Größenklasse { get; set;}
        public List<int> LagerhäuserMitItem { get; set; }
        public Guid GUID { get; set; }
        #endregion

        #region Konstruktoren
        public KatalogItem(string name, double[] maße, int lagerhausIndex) : this(name, maße)
        {
            LagerhäuserMitItem = new List<int> { lagerhausIndex };
        }
        public KatalogItem(string name, double[] maße)
        {
            LagerhäuserMitItem = new List<int>();
            Name = name;
            Maße = maße;
            Größenklasse = getGrößenklasseFromMaße(maße);
            GUID = Guid.NewGuid();
        }

        public KatalogItem() : this("", new double[3] {0,0,0})
        {  
            GUID = Guid.Empty;
        }

        #endregion

        public bool exists()
        {
            return GUID != Guid.Empty;
        }
        public static LagerEinheitGröße getGrößenklasseFromMaße(double[] maße)
        {
            //zu implementieren
            return LagerEinheitGröße.klein;
        }
        public override string ToString()
        {
            return ToString(';');
        }
        public string ToString(char seperator)
        {
            string value;
            value = GUID.ToString() + seperator + " " + Name;
            switch (Größenklasse)
            {
                case LagerEinheitGröße.klein:
                    value += seperator + " klein";
                    break;
                case LagerEinheitGröße.mittel:
                    value += seperator + " mittel";
                    break;
                case LagerEinheitGröße.groß:
                    value += seperator + " groß";
                    break;
                default:
                    break;
            }
            value += seperator + " " + String.Join("|", Maße);
            value += seperator + " " + String.Join(",", LagerhäuserMitItem);
            return value;
        }
    }
}
