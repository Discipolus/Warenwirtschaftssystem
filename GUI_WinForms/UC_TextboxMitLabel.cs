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
            lbl_Bezeichnung.Name = "lbl_" + name;
            lbl_Bezeichnung.Text = name + ":";
            lbl_Bezeichnung.Dock = DockStyle.Left;
            tb_Wert.Name = "tb_" + name;
            
            ResizeUc(lbl_Bezeichnung.Size.Width);
        }
        private void uC_TextboxMitLabel_Resize(object sender, EventArgs e)
        {
            ResizeUc(lbl_Bezeichnung.Size.Width);
        }
        public void ResizeUc(int maxWithLabel)
        {            
            int diff = 10;
            tb_Wert.Size = new Size(this.Size.Width - maxWithLabel - diff, this.Size.Height);
            tb_Wert.Location = new Point(maxWithLabel + diff, 0);            
            this.Refresh();
        }
    }
}
