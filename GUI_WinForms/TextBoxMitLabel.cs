using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_WinForms
{
    public class TextBoxMitLabel : UserControl
    {
        private Panel panel_Text;
        private Panel panel_Eingabe;
        private Size textgröße;        
        public TextBoxMitLabel(string text, Size größe_des_Containers, Font font)
        {
            text += ": ";
            Font = font;
            textgröße = TextRenderer.MeasureText(text, Font);
            this.Size = new Size(größe_des_Containers.Width, textgröße.Height);

            InitialiseComponent(text);
        }
        private void InitialiseComponent(string text)
        {
            panel_Text = getTextPanel(text);
            panel_Eingabe = getEingabePanel();

            this.Controls.Add(panel_Text);
            this.Controls.Add(panel_Eingabe);

        }
        private Panel getTextPanel(string text)
        {
            Panel panel = new Panel();

            Label label = new Label();
            label.Text = text;
            label.Size = textgröße;
            label.TextAlign = ContentAlignment.MiddleLeft;

            panel.Size = label.Size;
            panel.Controls.Add(label);
            panel.Dock = DockStyle.Left;

            return panel;
        }
        private Panel getEingabePanel()
        {
            Panel panel = new Panel();
            panel = new Panel();
            panel.Dock = DockStyle.Right;

            TextBox textbox = new TextBox();
            textbox.Font = Font;
            textbox.Dock = DockStyle.Fill;
            panel.Controls.Add(textbox);

            return panel;
        }
        public void ResizeControl(Size maximale_schriftgröße)
        {
            Size s = new Size(maximale_schriftgröße.Width, this.Height);
            panel_Text.Controls[0].Size = s;
            panel_Text.Size = s;
        }
    }
}
