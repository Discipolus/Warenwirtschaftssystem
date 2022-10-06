using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WinForms
{
    public partial class ProduktHinzufügen : UserControl
    {
        public ProduktHinzufügen(Size zielgröße)
        {
            this.Size = zielgröße;
            InitializeComponent();
        }
        public void InitializeComponent()
        {
            Panel panel_logo = generierePanelMitLogo();
            Panel panel_buttons = generierePanelMitButtons();
            Panel panel_textboxen = generierePanelMitTextboxen(new Size(this.Width, this.Height-(panel_logo.Height+panel_buttons.Height)), new Point(0, panel_logo.Size.Height), new string[] { "Name", "Anzahl", "Ort", "ID" });

            this.Controls.Add(panel_textboxen);
            this.Controls.Add(panel_logo);
            this.Controls.Add(panel_buttons);

            panel_textboxen.Dock = DockStyle.Top;
            panel_logo.Dock = DockStyle.Top;
            panel_buttons.Dock = DockStyle.Bottom;

            this.Refresh();
        }
        private Panel generierePanelMitLogo()
        {
            //Panel mit Logo
            Panel panel_logo = new Panel();
            panel_logo.Location = new Point(0, 0);
            panel_logo.Dock = DockStyle.Top;
            
            Label schriftzug = new Label();
            schriftzug.AutoSize = false;
            schriftzug.Text = "Produkt Hinzufügen";
            schriftzug.TextAlign = ContentAlignment.MiddleCenter;
            schriftzug.Font = new Font("Arial", 30, FontStyle.Bold);
            schriftzug.Size = TextRenderer.MeasureText(schriftzug.Text, schriftzug.Font);

            panel_logo.Controls.Add(schriftzug);

            schriftzug.Refresh();
            schriftzug.Show();           

            panel_logo.Size = new Size(this.Width, schriftzug.Height+(1/5)*schriftzug.Height);
            

            return panel_logo;
        }
        private Panel generierePanelMitTextboxen(Size size, Point location, string[] listeAnWerten)
        {
            //Panel mit Textboxen etc.
            Panel panel_Textboxen = new Panel();
            panel_Textboxen.Size = size;
            panel_Textboxen.Location = location;
            //panel_Textboxen.Dock = DockStyle.Fill;

            //List<TextBoxMitLabel> list = new List<TextBoxMitLabel>();
            Font f = new Font("Arial", 18, FontStyle.Italic); //new Font("Snap ITC", 12F, FontStyle.Regular, GraphicsUnit.Point);
            string[] Felder = listeAnWerten;
            Size maxSize = new Size();

            foreach (string s in listeAnWerten)
            {
                Size newSize = TextRenderer.MeasureText(s, f);
                if (maxSize.Width < newSize.Width)
                {
                    maxSize = newSize;
                }
            }


            for (int i = Felder.Length - 1; i >= 0; i--)
            {                
                TextBoxMitLabel UC = new TextBoxMitLabel(Felder[i], this.Size, f);
                UC.Location = new Point(0, UC.Size.Height * (i + 1));
                UC.Dock = DockStyle.Top;
                
                UC.Name = "uC_TextboxMitLabel" + i.ToString();
                
                UC.TabIndex = 3 + i;
                panel_Textboxen.Controls.Add(UC);
                //list.Add(UC);
            }

            //foreach (TextBoxMitLabel uc in list)
            //{
            //    panel_Textboxen.Controls.Add(uc);
            //}
            return panel_Textboxen;
        }
        private Panel generierePanelMitButtons()
        {
            //Panel mit Buttons
            Panel panel_buttons = new Panel();
            Button default_button = getDefaultButtonStyle("");
            panel_buttons.Size = new Size(this.Width, default_button.Size.Height);
            panel_buttons.Location = new Point(0, this.Size.Height - default_button.Size.Height);
            //panel_buttons.Dock = DockStyle.Bottom;


            Button btn_uebernehmen = getDefaultButtonStyle("Übernehmen");
            btn_uebernehmen.Location = new Point(panel_buttons.Size.Width - btn_uebernehmen.Size.Width, 0);
            panel_buttons.Controls.Add(btn_uebernehmen);

            Button btn_abbrechen = getDefaultButtonStyle("Abbrechen");
            btn_abbrechen.Location = new Point(panel_buttons.Size.Width - (btn_uebernehmen.Size.Width + btn_abbrechen.Size.Width + 20), 0);
            panel_buttons.Controls.Add(btn_abbrechen);

            return panel_buttons;
        }

        private Button getDefaultButtonStyle(string text)
        {
            Button button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.Size = new Size(155, 35);
            button.Anchor = AnchorStyles.Right;
            button.Text = text;
            return button;
        }
    }

}
