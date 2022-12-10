using Engine.Logik.Warenlogistik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WPF.EventArgs
{
    public class KatalogItemHinzufuegenEventArgs : System.EventArgs
    {
        public KatalogItem Item { get; set; }
        public KatalogItemHinzufuegenEventArgs(KatalogItem item)
        {
            this.Item = item;
        }
    }
}
