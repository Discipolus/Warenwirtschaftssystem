using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    public class KatalogItem : IEditableObject
    {
        #region Variables

        public string Name { get; set; }
        public MaßeTemplate Maße { get; set; }
        public LagerEinheitGröße Größenklasse { get; set; }
        public Guid GUID { get; set; }
        public List<int> LagerhäuserMitItem { get; set; }
        public string LagerhäuserMitItemString
        {
            get
            {
                string s = "";
                if (LagerhäuserMitItem.Count > 0)
                {
                    s += LagerhäuserMitItem[0].ToString();
                    for (int i = 1; i < LagerhäuserMitItem.Count; i++)
                    {
                        s += "; " + LagerhäuserMitItem[i].ToString();
                    }
                }
                return s;
            }
        }

        private KatalogItem? backupData;
        private bool inBearbeitung = false;
        private List<KatalogItem> parent;

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
        public KatalogItem(string name, MaßeTemplate maße, int lagerhausIndex) : this(name, maße, new List<int> { lagerhausIndex }, Guid.NewGuid()) { }
        public KatalogItem(string name, MaßeTemplate maße, List<int> lagerhausIndex) : this(name, maße, lagerhausIndex, Guid.NewGuid()) { }
        public KatalogItem(string name, MaßeTemplate maße) : this(name, maße, new List<int>(), Guid.NewGuid()) { }
        public KatalogItem() : this("", new MaßeTemplate()) { }

        #endregion

        public bool exists()
        {
            return GUID != Guid.Empty;
        }
        public static LagerEinheitGröße getGrößenklasseFromMaße(MaßeTemplate maße)
        {
            //zu implementieren
            double maxLänge = maße.ToArray().Max();
            if (maxLänge < 10)
            {
                return LagerEinheitGröße.klein;
            }
            else if (maxLänge < 20)
            {
                return LagerEinheitGröße.mittel;
            }
            else
            {
                return LagerEinheitGröße.groß;
            }
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
        public void BeginEdit()
        {
            if (!inBearbeitung)
            {
                inBearbeitung = true;
                this.backupData = new KatalogItem(this.Name, this.Maße, this.LagerhäuserMitItem, this.GUID);
            }
        }
        public void CancelEdit()
        {
            if (inBearbeitung)
            {
                this.Name = this.backupData.Name;
                this.Maße = this.backupData.Maße;
                this.LagerhäuserMitItem = this.backupData.LagerhäuserMitItem;
                this.GUID = this.backupData.GUID;
                inBearbeitung = false;
            }
        }
        public void EndEdit()
        {
            if (inBearbeitung)
            {
                this.backupData = null;
                inBearbeitung = false;
            }
        }        
    }
}
