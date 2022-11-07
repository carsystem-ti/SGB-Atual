
namespace SGB
{
    partial class loading
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
            this.lblprocessando = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblprocessando
            // 
            this.lblprocessando.AutoSize = true;
            this.lblprocessando.BackColor = System.Drawing.Color.Transparent;
            this.lblprocessando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprocessando.ForeColor = System.Drawing.Color.Green;
            this.lblprocessando.Location = new System.Drawing.Point(19, 9);
            this.lblprocessando.Name = "lblprocessando";
            this.lblprocessando.Size = new System.Drawing.Size(257, 20);
            this.lblprocessando.TabIndex = 0;
            this.lblprocessando.Text = "Processando dados aguarde..";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(218, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(319, 75);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblprocessando);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "loading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblprocessando;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}