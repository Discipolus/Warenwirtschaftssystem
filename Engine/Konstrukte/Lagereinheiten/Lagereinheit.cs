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
        internal bool belegt
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
        internal LagerEinheitGröße größe { get; set; }
        internal Guid KatalogItemGuid { get; set; }
        #endregion

        #region Konstruktoren
        internal Lagereinheit(bool belegt, LagerEinheitGröße größe, Guid katalogItemGuid)
        {
            this.belegt = belegt;
            this.größe = größe;
            KatalogItemGuid = katalogItemGuid;
        }

        internal Lagereinheit(LagerEinheitGröße größe) : this(false, größe, Guid.Empty) { }
        internal Lagereinheit() : this(false, LagerEinheitGröße.klein, Guid.Empty) { }

        #endregion
    }
}
