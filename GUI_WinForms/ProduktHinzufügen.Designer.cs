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
            this.panel_ProduktHinzufügen_Logo.SuspendLayout();
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
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // ProduktHinzufügen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_ProduktHinzufügen_Logo);
            this.Name = "ProduktHinzufügen";
            this.Size = new System.Drawing.Size(571, 295);
            this.panel_ProduktHinzufügen_Logo.ResumeLayout(false);
            this.panel_ProduktHinzufügen_Logo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel_ProduktHinzufügen_Logo;
        private Label label2;
    }
}
