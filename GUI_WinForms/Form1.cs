namespace GUI_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            versteckeSubMenues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TextWriter writer = new Output(richTextBox1);
            //Console.SetOut(writer);
            //Engine.TestEngine te = new Engine.TestEngine();
            //te.Main();
        }
        private int setzePanelGroeße(Panel p)
        {
            int groeße = 0;
            if (p.Visible)
            {
                foreach (Control c in p.Controls)
                {
                    if (c is Panel)
                    {
                        if (c.Visible)
                        {
                            groeße += setzePanelGroeße((Panel)c);
                        }
                    }
                    else
                    {
                        groeße += c.Size.Height;
                    }
                }
                p.Size = new Size(p.Size.Width, groeße);
            }            
            return groeße;
        }

        #region Sichtbarkeiten
        private void versteckeSubMenues()
        {
            panel_Warenlogistik.Visible = false;
            panel_Warenlogistik_Katalog.Visible = false;
            panel_Verkauf.Visible = false;
            panel_Einkauf.Visible = false;
        }
        private void triggerSichtbarkeitSubMenue(Panel subMenue)
        {            
            subMenue.Visible = !subMenue.Visible;
            setzePanelGroeße(panel_Menueelemente);
            //subMenue.Size = new Size(subMenue.Size.Width, setzePanelGroeße(subMenue));
            panel_Menueelemente.Refresh();
        }
        private void oeffneView(UserControl uc)
        {
            foreach(Control c in panel_Views.Controls)
            {
                if (c.GetType() != uc.GetType())
                {
                    panel_Views.Controls.Remove(c);
                    c.Dispose();
                }
            }
            uc.BorderStyle = BorderStyle.None;
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(0, 0);
            panel_Views.Tag = uc;
            panel_Views.Controls.Add(uc);
            panel_Views.BringToFront();            
            uc.Show();
        }

        #region Hauptmenü
        private void btn_Warenlogistik_Click(object sender, EventArgs e)
        {
            triggerSichtbarkeitSubMenue(panel_Warenlogistik);
        }
        private void btn_Warenlogistik_Katalog_Click(object sender, EventArgs e)
        {
            triggerSichtbarkeitSubMenue(panel_Warenlogistik_Katalog);
        }
        private void btn_Einkauf_Click(object sender, EventArgs e)
        {
            triggerSichtbarkeitSubMenue(panel_Einkauf);
        }
        private void btn_Verkauf_Click(object sender, EventArgs e)
        {
            triggerSichtbarkeitSubMenue(panel_Verkauf);
        }
        #endregion

        #region Warenlogistik Menü
        private void btn_Warenlogistik_Katalog_Hinzufuegen_Click(object sender, EventArgs e)
        {
           oeffneView(new ProduktHinzufügen());
           
        }

        #endregion

        #endregion

        private void btn_Warenlogistik_Katalog_Entfernen_Click(object sender, EventArgs e)
        {
            oeffneView(new OrtHinzufügen());
        }
    }
}