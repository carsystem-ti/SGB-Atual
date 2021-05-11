namespace SGB
{
    partial class analiseRetorno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(analiseRetorno));
            this.treeRetorno = new System.Windows.Forms.TreeView();
            this.textArquivoSelecionado = new System.Windows.Forms.TextBox();
            this.cmdProcuraArquivo = new System.Windows.Forms.Button();
            this.cmdSair = new System.Windows.Forms.Button();
            this.barraProgresso = new System.Windows.Forms.ProgressBar();
            this.cmdCarregar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picItau = new System.Windows.Forms.PictureBox();
            this.checkItau = new System.Windows.Forms.RadioButton();
            this.checkSantander = new System.Windows.Forms.RadioButton();
            this.checkCielo = new System.Windows.Forms.RadioButton();
            this.picSantander = new System.Windows.Forms.PictureBox();
            this.picCielo = new System.Windows.Forms.PictureBox();
            this.picBradesco = new System.Windows.Forms.PictureBox();
            this.picHSBC = new System.Windows.Forms.PictureBox();
            this.checkBradesco = new System.Windows.Forms.RadioButton();
            this.checkHSBC = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSantander)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBradesco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSBC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(9, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 6;
            label1.Text = "Arquivo";
            // 
            // treeRetorno
            // 
            this.treeRetorno.Location = new System.Drawing.Point(102, 33);
            this.treeRetorno.Name = "treeRetorno";
            this.treeRetorno.Size = new System.Drawing.Size(774, 461);
            this.treeRetorno.TabIndex = 0;
            this.treeRetorno.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRetorno_AfterSelect);
            // 
            // textArquivoSelecionado
            // 
            this.textArquivoSelecionado.BackColor = System.Drawing.Color.White;
            this.textArquivoSelecionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textArquivoSelecionado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textArquivoSelecionado.Location = new System.Drawing.Point(69, 6);
            this.textArquivoSelecionado.Name = "textArquivoSelecionado";
            this.textArquivoSelecionado.ReadOnly = true;
            this.textArquivoSelecionado.Size = new System.Drawing.Size(673, 21);
            this.textArquivoSelecionado.TabIndex = 5;
            // 
            // cmdProcuraArquivo
            // 
            this.cmdProcuraArquivo.FlatAppearance.BorderSize = 2;
            this.cmdProcuraArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdProcuraArquivo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcuraArquivo.Location = new System.Drawing.Point(748, 6);
            this.cmdProcuraArquivo.Name = "cmdProcuraArquivo";
            this.cmdProcuraArquivo.Size = new System.Drawing.Size(128, 21);
            this.cmdProcuraArquivo.TabIndex = 4;
            this.cmdProcuraArquivo.Text = "Procurar Arquivo";
            this.cmdProcuraArquivo.UseVisualStyleBackColor = true;
            this.cmdProcuraArquivo.Click += new System.EventHandler(this.cmdProcuraArquivo_Click);
            // 
            // cmdSair
            // 
            this.cmdSair.FlatAppearance.BorderSize = 2;
            this.cmdSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdSair.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSair.Location = new System.Drawing.Point(748, 500);
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(128, 20);
            this.cmdSair.TabIndex = 4;
            this.cmdSair.Text = "Sair";
            this.cmdSair.UseVisualStyleBackColor = true;
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // barraProgresso
            // 
            this.barraProgresso.Location = new System.Drawing.Point(102, 500);
            this.barraProgresso.Name = "barraProgresso";
            this.barraProgresso.Size = new System.Drawing.Size(640, 19);
            this.barraProgresso.TabIndex = 7;
            // 
            // cmdCarregar
            // 
            this.cmdCarregar.FlatAppearance.BorderSize = 2;
            this.cmdCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCarregar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarregar.Location = new System.Drawing.Point(9, 498);
            this.cmdCarregar.Name = "cmdCarregar";
            this.cmdCarregar.Size = new System.Drawing.Size(87, 21);
            this.cmdCarregar.TabIndex = 4;
            this.cmdCarregar.Text = "Carregar";
            this.cmdCarregar.UseVisualStyleBackColor = true;
            this.cmdCarregar.Click += new System.EventHandler(this.cmdCarregar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.picItau);
            this.panel2.Controls.Add(this.checkItau);
            this.panel2.Controls.Add(this.checkSantander);
            this.panel2.Controls.Add(this.checkCielo);
            this.panel2.Controls.Add(this.picSantander);
            this.panel2.Controls.Add(this.picCielo);
            this.panel2.Controls.Add(this.picBradesco);
            this.panel2.Controls.Add(this.picHSBC);
            this.panel2.Controls.Add(this.checkBradesco);
            this.panel2.Controls.Add(this.checkHSBC);
            this.panel2.Location = new System.Drawing.Point(9, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(87, 459);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // picItau
            // 
            this.picItau.Image = ((System.Drawing.Image)(resources.GetObject("picItau.Image")));
            this.picItau.InitialImage = ((System.Drawing.Image)(resources.GetObject("picItau.InitialImage")));
            this.picItau.Location = new System.Drawing.Point(12, 367);
            this.picItau.Name = "picItau";
            this.picItau.Size = new System.Drawing.Size(64, 64);
            this.picItau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picItau.TabIndex = 41;
            this.picItau.TabStop = false;
            this.picItau.Click += new System.EventHandler(this.picItau_Click);
            // 
            // checkItau
            // 
            this.checkItau.AutoSize = true;
            this.checkItau.Location = new System.Drawing.Point(36, 437);
            this.checkItau.Name = "checkItau";
            this.checkItau.Size = new System.Drawing.Size(14, 13);
            this.checkItau.TabIndex = 42;
            this.checkItau.UseVisualStyleBackColor = true;
            //this.checkItau.CheckedChanged += new System.EventHandler(this.checkItau_CheckedChanged);
            // 
            // checkSantander
            // 
            this.checkSantander.AutoSize = true;
            this.checkSantander.Location = new System.Drawing.Point(37, 348);
            this.checkSantander.Name = "checkSantander";
            this.checkSantander.Size = new System.Drawing.Size(14, 13);
            this.checkSantander.TabIndex = 40;
            this.checkSantander.UseVisualStyleBackColor = true;
            // 
            // checkCielo
            // 
            this.checkCielo.AutoSize = true;
            this.checkCielo.Location = new System.Drawing.Point(37, 259);
            this.checkCielo.Name = "checkCielo";
            this.checkCielo.Size = new System.Drawing.Size(14, 13);
            this.checkCielo.TabIndex = 39;
            this.checkCielo.UseVisualStyleBackColor = true;
            // 
            // picSantander
            // 
            this.picSantander.Enabled = false;
            this.picSantander.Image = ((System.Drawing.Image)(resources.GetObject("picSantander.Image")));
            this.picSantander.InitialImage = ((System.Drawing.Image)(resources.GetObject("picSantander.InitialImage")));
            this.picSantander.Location = new System.Drawing.Point(12, 278);
            this.picSantander.Name = "picSantander";
            this.picSantander.Size = new System.Drawing.Size(64, 64);
            this.picSantander.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSantander.TabIndex = 38;
            this.picSantander.TabStop = false;
            this.picSantander.Click += new System.EventHandler(this.picSantander_Click);
            // 
            // picCielo
            // 
            this.picCielo.Image = ((System.Drawing.Image)(resources.GetObject("picCielo.Image")));
            this.picCielo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCielo.InitialImage")));
            this.picCielo.Location = new System.Drawing.Point(12, 189);
            this.picCielo.Name = "picCielo";
            this.picCielo.Size = new System.Drawing.Size(64, 64);
            this.picCielo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCielo.TabIndex = 37;
            this.picCielo.TabStop = false;
            this.picCielo.Click += new System.EventHandler(this.picCielo_Click);
            // 
            // picBradesco
            // 
            this.picBradesco.Image = ((System.Drawing.Image)(resources.GetObject("picBradesco.Image")));
            this.picBradesco.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBradesco.InitialImage")));
            this.picBradesco.Location = new System.Drawing.Point(12, 11);
            this.picBradesco.Name = "picBradesco";
            this.picBradesco.Size = new System.Drawing.Size(64, 64);
            this.picBradesco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBradesco.TabIndex = 34;
            this.picBradesco.TabStop = false;
            // 
            // picHSBC
            // 
            this.picHSBC.Image = ((System.Drawing.Image)(resources.GetObject("picHSBC.Image")));
            this.picHSBC.InitialImage = ((System.Drawing.Image)(resources.GetObject("picHSBC.InitialImage")));
            this.picHSBC.Location = new System.Drawing.Point(12, 100);
            this.picHSBC.Name = "picHSBC";
            this.picHSBC.Size = new System.Drawing.Size(64, 64);
            this.picHSBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHSBC.TabIndex = 34;
            this.picHSBC.TabStop = false;
            this.picHSBC.Click += new System.EventHandler(this.picHSBC_Click);
            // 
            // checkBradesco
            // 
            this.checkBradesco.AutoSize = true;
            this.checkBradesco.Checked = true;
            this.checkBradesco.Location = new System.Drawing.Point(37, 81);
            this.checkBradesco.Name = "checkBradesco";
            this.checkBradesco.Size = new System.Drawing.Size(14, 13);
            this.checkBradesco.TabIndex = 36;
            this.checkBradesco.TabStop = true;
            this.checkBradesco.UseVisualStyleBackColor = true;
            // 
            // checkHSBC
            // 
            this.checkHSBC.AutoSize = true;
            this.checkHSBC.Location = new System.Drawing.Point(37, 170);
            this.checkHSBC.Name = "checkHSBC";
            this.checkHSBC.Size = new System.Drawing.Size(14, 13);
            this.checkHSBC.TabIndex = 36;
            this.checkHSBC.UseVisualStyleBackColor = true;
            this.checkHSBC.CheckedChanged += new System.EventHandler(this.checkHSBC_CheckedChanged);
            // 
            // analiseRetorno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 528);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.barraProgresso);
            this.Controls.Add(label1);
            this.Controls.Add(this.textArquivoSelecionado);
            this.Controls.Add(this.cmdSair);
            this.Controls.Add(this.cmdCarregar);
            this.Controls.Add(this.cmdProcuraArquivo);
            this.Controls.Add(this.treeRetorno);
            this.Name = "analiseRetorno";
            this.Text = "retornoBradesco";
            this.Load += new System.EventHandler(this.retornoBradesco_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSantander)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBradesco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSBC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeRetorno;
        private System.Windows.Forms.TextBox textArquivoSelecionado;
        private System.Windows.Forms.Button cmdProcuraArquivo;
        private System.Windows.Forms.Button cmdSair;
        private System.Windows.Forms.ProgressBar barraProgresso;
        private System.Windows.Forms.Button cmdCarregar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picBradesco;
        private System.Windows.Forms.PictureBox picHSBC;
        private System.Windows.Forms.RadioButton checkBradesco;
        private System.Windows.Forms.RadioButton checkHSBC;
        private System.Windows.Forms.PictureBox picCielo;
        private System.Windows.Forms.PictureBox picSantander;
        private System.Windows.Forms.RadioButton checkCielo;
        private System.Windows.Forms.RadioButton checkSantander;
        private System.Windows.Forms.PictureBox picItau;
        private System.Windows.Forms.RadioButton checkItau;
    }
}