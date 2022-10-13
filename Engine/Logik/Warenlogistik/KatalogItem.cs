using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    internal class KatalogItem
    {
        #region Variables
        internal string Name { get; set; }
        internal double[] Maße
        {
            get => Maße;
            set
            {
                if (value != null)
                {
                    if (value.Length == 3)
                    {
                        Maße = value;
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
        internal LagerEinheitGröße Größenklasse { get; set;}
        internal List<int> LagerhäuserMitItem { get; set; }
        internal Guid GUID { get; set; }
        #endregion

        #region Konstruktoren
        internal KatalogItem()
        {
            Name = "";
            Maße = new double[3] { 0, 0, 0 };
            Größenklasse = LagerEinheitGröße.klein;
            LagerhäuserMitItem = new();
            GUID = Guid.Empty;
        }
        internal KatalogItem(string name, int lagerhausIndex, double[] maße)
        {
            Name = name;
            Maße = maße;
            Größenklasse = getGrößenklasseFromMaße(maße);
            GUID = Guid.NewGuid();
            LagerhäuserMitItem = new List<int> { lagerhausIndex };
        }
        #endregion

        internal bool exists()
        {
            return GUID != Guid.Empty;
        }
        internal static LagerEinheitGröße getGrößenklasseFromMaße(double[] maße)
        {
            //zu implementieren
            return LagerEinheitGröße.klein;
        }
    }
}
