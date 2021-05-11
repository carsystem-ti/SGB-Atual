namespace SGB
{
    partial class conciliaCielo
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conciliaCielo));
            this.barraProgresso = new System.Windows.Forms.ProgressBar();
            this.textArquivoSelecionado = new System.Windows.Forms.TextBox();
            this.cmdSair = new System.Windows.Forms.Button();
            this.cmdCarregar = new System.Windows.Forms.Button();
            this.cmdProcuraArquivo = new System.Windows.Forms.Button();
            this.picCielo = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).BeginInit();
            this.SuspendLayout();
            // 
            // barraProgresso
            // 
            this.barraProgresso.Location = new System.Drawing.Point(105, 415);
            this.barraProgresso.Name = "barraProgresso";
            this.barraProgresso.Size = new System.Drawing.Size(640, 19);
            this.barraProgresso.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(12, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 42;
            label1.Text = "Arquivo";
            // 
            // textArquivoSelecionado
            // 
            this.textArquivoSelecionado.BackColor = System.Drawing.Color.White;
            this.textArquivoSelecionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textArquivoSelecionado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textArquivoSelecionado.Location = new System.Drawing.Point(72, 9);
            this.textArquivoSelecionado.Name = "textArquivoSelecionado";
            this.textArquivoSelecionado.ReadOnly = true;
            this.textArquivoSelecionado.Size = new System.Drawing.Size(673, 21);
            this.textArquivoSelecionado.TabIndex = 41;
            // 
            // cmdSair
            // 
            this.cmdSair.FlatAppearance.BorderSize = 2;
            this.cmdSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSair.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSair.Location = new System.Drawing.Point(751, 415);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(128, 20);
            this.cmdSair.TabIndex = 38;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            // 
            // cmdCarregar
            // 
            this.cmdCarregar.FlatAppearance.BorderSize = 2;
            this.cmdCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCarregar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarregar.Location = new System.Drawing.Point(12, 413);
            this.cmdCarregar.Name = "cmdCarregar";
            this.cmdCarregar.Size = new System.Drawing.Size(77, 21);
            this.cmdCarregar.TabIndex = 39;
            this.cmdCarregar.Text = "Carregar";
            this.cmdCarregar.UseVisualStyleBackColor = true;
            // 
            // cmdProcuraArquivo
            // 
            this.cmdProcuraArquivo.FlatAppearance.BorderSize = 2;
            this.cmdProcuraArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdProcuraArquivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcuraArquivo.Location = new System.Drawing.Point(751, 9);
            this.cmdProcuraArquivo.Name = "cmdProcuraArquivo";
            this.cmdProcuraArquivo.Size = new System.Drawing.Size(128, 21);
            this.cmdProcuraArquivo.TabIndex = 40;
            this.cmdProcuraArquivo.Text = "Procurar Arquivo";
            this.cmdProcuraArquivo.UseVisualStyleBackColor = true;
            // 
            // picCielo
            // 
            this.picCielo.Image = ((System.Drawing.Image)(resources.GetObject("picCielo.Image")));
            this.picCielo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCielo.InitialImage")));
            this.picCielo.Location = new System.Drawing.Point(900, 69);
            this.picCielo.Name = "picCielo";
            this.picCielo.Size = new System.Drawing.Size(64, 64);
            this.picCielo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCielo.TabIndex = 44;
            this.picCielo.TabStop = false;
            // 
            // conciliaCielo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 445);
            this.Controls.Add(this.barraProgresso);
            this.Controls.Add(label1);
            this.Controls.Add(this.picCielo);
            this.Controls.Add(this.textArquivoSelecionado);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdCarregar);
            this.Controls.Add(this.cmdProcuraArquivo);
            this.Name = "conciliaCielo";
            this.Text = "conciliaCielo";
            this.Load += new System.EventHandler(this.conciliaCielo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar barraProgresso;
        private System.Windows.Forms.PictureBox picCielo;
        private System.Windows.Forms.TextBox textArquivoSelecionado;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.Button cmdCarregar;
        private System.Windows.Forms.Button cmdProcuraArquivo;
    }
}