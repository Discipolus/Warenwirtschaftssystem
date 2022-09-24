using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_WinForms
{
    public partial class UC_TextboxMitLabel : UserControl
    {
        public UC_TextboxMitLabel(string name)
        {
            InitializeComponent();
            label1.Name = "lbl_" + name;
            label1.Text = name + ":";
            textBox1.Name = "tb_" + name;
        }
        private void uC_TextboxMitLabel_Resize(object sender, EventArgs e)
        {
            textBox1.Size = new Size(this.Size.Height, this.Size.Width / 2);
        }
    }
}
