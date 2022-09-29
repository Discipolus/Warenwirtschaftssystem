namespace GUI_WinForms
{
    partial class UC_TextboxMitLabel
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
            this.lbl_Bezeichnung = new System.Windows.Forms.Label();
            this.tb_Wert = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Bezeichnung
            // 
            this.lbl_Bezeichnung.AutoSize = true;
            this.lbl_Bezeichnung.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Bezeichnung.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Bezeichnung.Location = new System.Drawing.Point(0, 0);
            this.lbl_Bezeichnung.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_Bezeichnung.Name = "lbl_Bezeichnung";
            this.lbl_Bezeichnung.Size = new System.Drawing.Size(202, 25);
            this.lbl_Bezeichnung.TabIndex = 0;
            this.lbl_Bezeichnung.Text = "Label123456677";
            // 
            // tb_Wert
            // 
            this.tb_Wert.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_Wert.Location = new System.Drawing.Point(300, 0);
            this.tb_Wert.Name = "tb_Wert";
            this.tb_Wert.Size = new System.Drawing.Size(300, 28);
            this.tb_Wert.TabIndex = 1;
            // 
            // UC_TextboxMitLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tb_Wert);
            this.Controls.Add(this.lbl_Bezeichnung);
            this.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(10000, 28);
            this.MinimumSize = new System.Drawing.Size(300, 28);
            this.Name = "UC_TextboxMitLabel";
            this.Size = new System.Drawing.Size(600, 28);
            this.Resize += new System.EventHandler(this.uC_TextboxMitLabel_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_Bezeichnung;
        private TextBox tb_Wert;
    }
}
