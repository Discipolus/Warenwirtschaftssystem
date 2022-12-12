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
        public MaßeTemplate Maße { get; set; }
        public LagerEinheitGröße Größenklasse { get; set;}
        public List<int> LagerhäuserMitItem { get; set; }
        public string LagerhäuserMitItemString
        { 
            get
            {
                string s = "";
                foreach (int i in LagerhäuserMitItem)
                {
                    s += i + "; ";
                }
                return s;
            }
        }
        public Guid GUID { get; set; }
        #endregion

        #region Konstruktoren
        public KatalogItem(string name, MaßeTemplate maße, List<int> lagerhäuser, Guid guid)
        {
            Name = name;
            Maße = maße;
            LagerhäuserMitItem = lagerhäuser;
            Größenklasse = getGrößenklasseFromMaße(Maße);
            GUID = guid;
        }
        public KatalogItem(string name, MaßeTemplate maße, int lagerhausIndex) : this(name, maße, new List<int> { lagerhausIndex }, Guid.NewGuid()) {}
        public KatalogItem(string name, MaßeTemplate maße, List<int> lagerhausIndex) : this(name, maße, lagerhausIndex , Guid.NewGuid()) { }
        public KatalogItem(string name, MaßeTemplate maße) : this(name, maße, new List<int>(), Guid.NewGuid()) {}
        public KatalogItem() : this("", new MaßeTemplate()) {}

        #endregion

        public bool exists()
        {
            return GUID != Guid.Empty;
        }
        public static LagerEinheitGröße getGrößenklasseFromMaße(MaßeTemplate maße)
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
        public string ToSqlValue()
        {
            //(Name, MaßeX, MaßeY, MaßeZ, Guid, Lagerhäuser)
            return "('" + Name + "', " + Maße.X + ", " + Maße.Y + ", " + Maße.Z + ", '" + GUID.ToString() + "', '" + LagerhäuserMitItemString + "')";
        }
    }
}
