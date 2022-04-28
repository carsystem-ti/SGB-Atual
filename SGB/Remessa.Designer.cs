
namespace SGB
{
    partial class Remessa
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
            System.Windows.Forms.Label Label14;
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_selecionados = new System.Windows.Forms.Label();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            Label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label14
            // 
            Label14.BackColor = System.Drawing.Color.Red;
            Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label14.ForeColor = System.Drawing.Color.White;
            Label14.Location = new System.Drawing.Point(-34, 45);
            Label14.Name = "Label14";
            Label14.Size = new System.Drawing.Size(539, 18);
            Label14.TabIndex = 48;
            Label14.Text = "Quantidade de boletos processados";
            Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_titulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_titulo.Font = new System.Drawing.Font("Verdana", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(2, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(503, 36);
            this.lbl_titulo.TabIndex = 47;
            this.lbl_titulo.Text = "Remessa Daycoval";
            this.lbl_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_selecionados
            // 
            this.lbl_selecionados.BackColor = System.Drawing.Color.White;
            this.lbl_selecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_selecionados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecionados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_selecionados.Location = new System.Drawing.Point(-34, 63);
            this.lbl_selecionados.Name = "lbl_selecionados";
            this.lbl_selecionados.Size = new System.Drawing.Size(540, 32);
            this.lbl_selecionados.TabIndex = 49;
            this.lbl_selecionados.Text = "0000000";
            this.lbl_selecionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Location = new System.Drawing.Point(160, 100);
            this.cmdPesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(181, 73);
            this.cmdPesquisar.TabIndex = 60;
            this.cmdPesquisar.Text = "GERAR ARQUIVO";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // Remessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 185);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(Label14);
            this.Controls.Add(this.lbl_selecionados);
            this.Controls.Add(this.lbl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Remessa";
            this.Text = "Remessa";
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label lbl_titulo;
        internal System.Windows.Forms.Label lbl_selecionados;
        private System.Windows.Forms.Button cmdPesquisar;
    }
}