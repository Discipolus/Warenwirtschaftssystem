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
    public partial class ProduktHinzufügen : UserControl
    {
        public ProduktHinzufügen()
        {
            InitializeComponent();
            string[] Felder = new string[] {"Name", "Berufung", "Ort" };
            for (int i = 0; i < Felder.Length; i++)
            {
                UC_TextboxMitLabel UC = new UC_TextboxMitLabel(Felder[i]);
                UC.Dock = System.Windows.Forms.DockStyle.Top;
                UC.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                UC.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
                UC.Name = "uC_TextboxMitLabel1";
                UC.Size = new System.Drawing.Size(571, 28);
                UC.TabIndex = 3+i;
                this.Controls.Add(UC);
            }
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {

        }        
    }
}
