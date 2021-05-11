namespace SGB
{
    partial class adInad
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
            this.gbAdInad = new System.Windows.Forms.GroupBox();
            this.cmdAlterar = new System.Windows.Forms.Button();
            this.textContrato = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAdInad.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAdInad
            // 
            this.gbAdInad.Controls.Add(this.label1);
            this.gbAdInad.Controls.Add(this.textContrato);
            this.gbAdInad.Controls.Add(this.cmdAlterar);
            this.gbAdInad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbAdInad.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAdInad.Location = new System.Drawing.Point(12, 23);
            this.gbAdInad.Name = "gbAdInad";
            this.gbAdInad.Size = new System.Drawing.Size(208, 135);
            this.gbAdInad.TabIndex = 0;
            this.gbAdInad.TabStop = false;
            this.gbAdInad.Text = "AD/INAD";
            // 
            // cmdAlterar
            // 
            this.cmdAlterar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAlterar.Location = new System.Drawing.Point(25, 85);
            this.cmdAlterar.Name = "cmdAlterar";
            this.cmdAlterar.Size = new System.Drawing.Size(159, 31);
            this.cmdAlterar.TabIndex = 0;
            this.cmdAlterar.Text = "Alterar";
            this.cmdAlterar.UseVisualStyleBackColor = true;
            this.cmdAlterar.Click += new System.EventHandler(this.cmdAlterar_Click);
            // 
            // textContrato
            // 
            this.textContrato.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContrato.Location = new System.Drawing.Point(6, 52);
            this.textContrato.Name = "textContrato";
            this.textContrato.Size = new System.Drawing.Size(194, 26);
            this.textContrato.TabIndex = 1;
            this.textContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contrato";
            // 
            // adInad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 167);
            this.Controls.Add(this.gbAdInad);
            this.Name = "adInad";
            this.Text = "adInad";
            this.gbAdInad.ResumeLayout(false);
            this.gbAdInad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAdInad;
        private System.Windows.Forms.Button cmdAlterar;
        private System.Windows.Forms.TextBox textContrato;
        private System.Windows.Forms.Label label1;

    }
}