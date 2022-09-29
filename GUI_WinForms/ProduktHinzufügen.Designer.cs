namespace GUI_WinForms
{
    partial class ProduktHinzufügen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_ProduktHinzufügen_Logo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Elemente = new System.Windows.Forms.Panel();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.btn_bestaetigen = new System.Windows.Forms.Button();
            this.btn_Abbrechen = new System.Windows.Forms.Button();
            this.panel_ProduktHinzufügen_Logo.SuspendLayout();
            this.panel_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_ProduktHinzufügen_Logo
            // 
            this.panel_ProduktHinzufügen_Logo.BackColor = System.Drawing.Color.Black;
            this.panel_ProduktHinzufügen_Logo.Controls.Add(this.label2);
            this.panel_ProduktHinzufügen_Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ProduktHinzufügen_Logo.Location = new System.Drawing.Point(0, 0);
            this.panel_ProduktHinzufügen_Logo.Name = "panel_ProduktHinzufügen_Logo";
            this.panel_ProduktHinzufügen_Logo.Size = new System.Drawing.Size(571, 46);
            this.panel_ProduktHinzufügen_Logo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(75, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 45);
            this.label2.TabIndex = 0;
            this.label2.Text = "Produkt hinzufügen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_Elemente
            // 
            this.panel_Elemente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Elemente.Location = new System.Drawing.Point(0, 46);
            this.panel_Elemente.Name = "panel_Elemente";
            this.panel_Elemente.Size = new System.Drawing.Size(571, 249);
            this.panel_Elemente.TabIndex = 3;
            // 
            // panel_Buttons
            // 
            this.panel_Buttons.Controls.Add(this.btn_Abbrechen);
            this.panel_Buttons.Controls.Add(this.btn_bestaetigen);
            this.panel_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttons.Location = new System.Drawing.Point(0, 255);
            this.panel_Buttons.MaximumSize = new System.Drawing.Size(0, 40);
            this.panel_Buttons.MinimumSize = new System.Drawing.Size(0, 40);
            this.panel_Buttons.Name = "panel_Buttons";
            this.panel_Buttons.Size = new System.Drawing.Size(571, 40);
            this.panel_Buttons.TabIndex = 4;
            // 
            // btn_bestaetigen
            // 
            this.btn_bestaetigen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bestaetigen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_bestaetigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_bestaetigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bestaetigen.Location = new System.Drawing.Point(496, 5);
            this.btn_bestaetigen.Name = "btn_bestaetigen";
            this.btn_bestaetigen.Size = new System.Drawing.Size(75, 35);
            this.btn_bestaetigen.TabIndex = 0;
            this.btn_bestaetigen.Text = "Bestätigen";
            this.btn_bestaetigen.UseVisualStyleBackColor = true;
            // 
            // btn_Abbrechen
            // 
            this.btn_Abbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Abbrechen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_Abbrechen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Abbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Abbrechen.Location = new System.Drawing.Point(415, 5);
            this.btn_Abbrechen.Name = "btn_Abbrechen";
            this.btn_Abbrechen.Size = new System.Drawing.Size(75, 35);
            this.btn_Abbrechen.TabIndex = 1;
            this.btn_Abbrechen.Text = "Abbrechen";
            this.btn_Abbrechen.UseVisualStyleBackColor = true;
            // 
            // ProduktHinzufügen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Buttons);
            this.Controls.Add(this.panel_Elemente);
            this.Controls.Add(this.panel_ProduktHinzufügen_Logo);
            this.Name = "ProduktHinzufügen";
            this.Size = new System.Drawing.Size(571, 295);
            this.panel_ProduktHinzufügen_Logo.ResumeLayout(false);
            this.panel_ProduktHinzufügen_Logo.PerformLayout();
            this.panel_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel_ProduktHinzufügen_Logo;
        private Label label2;
        private Panel panel_Elemente;
        private Panel panel_Buttons;
        private Button btn_Abbrechen;
        private Button btn_bestaetigen;
    }
}
