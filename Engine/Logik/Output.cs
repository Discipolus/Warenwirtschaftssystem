using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logik
{
    internal class Output : TextWriter
    {
        //nicht funktionsfähig. Versuch den Consolenoutput in einen String umzuleiten.


        public override void Write(bool value)
        {
            base.Write(value);

        }
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
