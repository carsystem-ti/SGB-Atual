namespace BaixaTitulos
{
    partial class QuitaParcelas
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
            System.Windows.Forms.Label lblTituloNN;
            System.Windows.Forms.Label lblTitulo;
            System.Windows.Forms.Label lblFundo;
            System.Windows.Forms.Label lblTituloB;
            System.Windows.Forms.Label lblTituloE;
            System.Windows.Forms.Label lblTituloA;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuitaParcelas));
            this.lblNossoNumero = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.gridParcelas = new System.Windows.Forms.DataGridView();
            this.cmdQuitar = new System.Windows.Forms.Button();
            lblTituloNN = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            lblFundo = new System.Windows.Forms.Label();
            lblTituloB = new System.Windows.Forms.Label();
            lblTituloE = new System.Windows.Forms.Label();
            lblTituloA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloNN
            // 
            lblTituloNN.AutoSize = true;
            lblTituloNN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblTituloNN.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTituloNN.Location = new System.Drawing.Point(41, 156);
            lblTituloNN.Name = "lblTituloNN";
            lblTituloNN.Size = new System.Drawing.Size(101, 13);
            lblTituloNN.TabIndex = 1;
            lblTituloNN.Text = "Nosso Número";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitulo.Location = new System.Drawing.Point(61, 200);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(61, 13);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Valor R$";
            // 
            // lblFundo
            // 
            lblFundo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblFundo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblFundo.Location = new System.Drawing.Point(5, -1);
            lblFundo.Name = "lblFundo";
            lblFundo.Size = new System.Drawing.Size(631, 286);
            lblFundo.TabIndex = 2;
            lblFundo.Click += new System.EventHandler(this.lblFundo_Click);
            // 
            // lblTituloB
            // 
            lblTituloB.AutoSize = true;
            lblTituloB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblTituloB.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTituloB.Location = new System.Drawing.Point(68, 68);
            lblTituloB.Name = "lblTituloB";
            lblTituloB.Size = new System.Drawing.Size(46, 13);
            lblTituloB.TabIndex = 4;
            lblTituloB.Text = "Banco";
            // 
            // lblTituloE
            // 
            lblTituloE.AutoSize = true;
            lblTituloE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblTituloE.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTituloE.Location = new System.Drawing.Point(59, 112);
            lblTituloE.Name = "lblTituloE";
            lblTituloE.Size = new System.Drawing.Size(64, 13);
            lblTituloE.TabIndex = 4;
            lblTituloE.Text = "Empresa";
            // 
            // lblTituloA
            // 
            lblTituloA.AutoSize = true;
            lblTituloA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            lblTituloA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTituloA.Location = new System.Drawing.Point(292, 14);
            lblTituloA.Name = "lblTituloA";
            lblTituloA.Size = new System.Drawing.Size(58, 13);
            lblTituloA.TabIndex = 4;
            lblTituloA.Text = "Arquivo";
            // 
            // lblNossoNumero
            // 
            this.lblNossoNumero.BackColor = System.Drawing.Color.White;
            this.lblNossoNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNossoNumero.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNossoNumero.Location = new System.Drawing.Point(18, 174);
            this.lblNossoNumero.Name = "lblNossoNumero";
            this.lblNossoNumero.Size = new System.Drawing.Size(147, 21);
            this.lblNossoNumero.TabIndex = 0;
            this.lblNossoNumero.Text = "123456789012345";
            this.lblNossoNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValor
            // 
            this.lblValor.BackColor = System.Drawing.Color.White;
            this.lblValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValor.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(18, 218);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(147, 21);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "R$ 0000,00";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBanco
            // 
            this.lblBanco.BackColor = System.Drawing.Color.White;
            this.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBanco.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(18, 86);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(147, 21);
            this.lblBanco.TabIndex = 3;
            this.lblBanco.Text = "R$ 0000,00";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.BackColor = System.Drawing.Color.White;
            this.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpresa.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(18, 130);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(147, 21);
            this.lblEmpresa.TabIndex = 3;
            this.lblEmpresa.Text = "R$ 0000,00";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpresa.Click += new System.EventHandler(this.lblEmpresa_Click);
            // 
            // lblArquivo
            // 
            this.lblArquivo.BackColor = System.Drawing.Color.White;
            this.lblArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArquivo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivo.Location = new System.Drawing.Point(18, 31);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(606, 21);
            this.lblArquivo.TabIndex = 3;
            this.lblArquivo.Text = "R$ 0000,00";
            this.lblArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridParcelas
            // 
            this.gridParcelas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParcelas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridParcelas.Location = new System.Drawing.Point(180, 68);
            this.gridParcelas.Name = "gridParcelas";
            this.gridParcelas.Size = new System.Drawing.Size(444, 205);
            this.gridParcelas.TabIndex = 5;
            this.gridParcelas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellDoubleClick);
            this.gridParcelas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellContentClick);
            // 
            // cmdQuitar
            // 
            this.cmdQuitar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitar.Location = new System.Drawing.Point(18, 250);
            this.cmdQuitar.Name = "cmdQuitar";
            this.cmdQuitar.Size = new System.Drawing.Size(147, 23);
            this.cmdQuitar.TabIndex = 6;
            this.cmdQuitar.Text = "&Quitar";
            this.cmdQuitar.UseVisualStyleBackColor = true;
            this.cmdQuitar.Click += new System.EventHandler(this.cmdQuitar_Click);
            // 
            // QuitaParcelas
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(641, 291);
            this.Controls.Add(this.cmdQuitar);
            this.Controls.Add(this.gridParcelas);
            this.Controls.Add(lblTituloA);
            this.Controls.Add(lblTituloE);
            this.Controls.Add(lblTituloB);
            this.Controls.Add(this.lblArquivo);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblBanco);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblTituloNN);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblNossoNumero);
            this.Controls.Add(lblFundo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QuitaParcelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.QuitaParcelas_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuitaParcelas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNossoNumero;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.DataGridView gridParcelas;
        private System.Windows.Forms.Button cmdQuitar;
    }
}