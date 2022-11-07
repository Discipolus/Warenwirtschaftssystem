using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Konstrukte.Lagereinheiten
{
    public class Lagereinheit
    {
        #region Variables
        private bool _belegt;
        public bool belegt
        {
            get
            {
                return _belegt;
            }
            set
            {
                if (value == false)
                {
                    KatalogItemGuid = Guid.Empty;                    
                }
                _belegt = value;
            }
        }
        public LagerEinheitGröße größe { get; set; }
        public Guid KatalogItemGuid { get; set; }
        #endregion

        #region Konstruktoren
        public Lagereinheit(bool belegt, LagerEinheitGröße größe, Guid katalogItemGuid)
        {
            this.belegt = belegt;
            this.größe = größe;
            KatalogItemGuid = katalogItemGuid;
        }

        public Lagereinheit(LagerEinheitGröße größe) : this(false, größe, Guid.Empty) { }
        public Lagereinheit() : this(false, LagerEinheitGröße.klein, Guid.Empty) { }

        #endregion
    }
}
