using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WinForms
{
    internal class Output : TextWriter
    {
        RichTextBox output = null;
        public Output(RichTextBox _output)
        {
            output = _output;
            output.ScrollBars = RichTextBoxScrollBars.Both;
            output.WordWrap = true;
        }
        //<summary>
        //Appends text to the textbox and to the logfile
        //</summary>
        //<param name="value">Input-string which is appended to the textbox.</param>
        public override void Write(char value)
        {
            base.Write(value);
            output.AppendText(value.ToString());//Append char to the textbox
        }


        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
