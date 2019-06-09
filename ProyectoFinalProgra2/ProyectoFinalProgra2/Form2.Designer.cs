namespace ProyectoFinalProgra2
{
    partial class Consola
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtConsola = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtConsola
            // 
            this.txtConsola.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtConsola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsola.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsola.ForeColor = System.Drawing.Color.Lime;
            this.txtConsola.Location = new System.Drawing.Point(0, 0);
            this.txtConsola.Multiline = true;
            this.txtConsola.Name = "txtConsola";
            this.txtConsola.Size = new System.Drawing.Size(284, 261);
            this.txtConsola.TabIndex = 0;
            this.txtConsola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsola_KeyDown);
            this.txtConsola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsola_KeyPress);
            // 
            // Consola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtConsola);
            this.Name = "Consola";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consola LNS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsola;
    }
}