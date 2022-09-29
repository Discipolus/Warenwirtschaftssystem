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
            List<UC_TextboxMitLabel> list = new List<UC_TextboxMitLabel>();
            string[] Felder = new string[] {"Name", "Anzahl", "Ort", "ID" };
            int maxLaenge = 0;
            
            for (int i = Felder.Length-1; i >= 0; i--)
            {
                UC_TextboxMitLabel UC = new UC_TextboxMitLabel(Felder[i]);
                UC.Location = new Point(0, this.panel_ProduktHinzufügen_Logo.Location.Y + (i+1)*this.panel_ProduktHinzufügen_Logo.Height);
                UC.Dock = DockStyle.Top;
                UC.Font = new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point);
                UC.Margin = new Padding(5, 4, 5, 4);
                UC.Name = "uC_TextboxMitLabel" + i.ToString();
                UC.Size = new Size(571, 28);
                UC.TabIndex = 3+i;
                foreach (Control l in UC.Controls)
                {
                    if (l is Label)
                    {
                        if (maxLaenge < l.Size.Width)
                        {
                            maxLaenge = l.Size.Width;
                        }
                    }
                }
                list.Add(UC);
            }
            foreach (UC_TextboxMitLabel uc in list)
            {
                uc.ResizeUc(maxLaenge);
                panel_Elemente.Controls.Add(uc);                
            }
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {

        }        
    }
}
