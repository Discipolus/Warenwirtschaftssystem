using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.EventArgs
{
    public class KatalogItemEntfernenEventArgs : System.EventArgs
    {
        public Guid GUID { get; set; }
        public KatalogItemEntfernenEventArgs(Guid guid)
        {
            GUID = guid;
        }
    }
}
