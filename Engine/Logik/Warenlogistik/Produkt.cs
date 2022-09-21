using Engine.Konstrukte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik.Warenlogistik
{
    internal class Produkt
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public Ort AktuellerOrt { get; set; }
        public Guid GUID { get; set; }

    }
}
