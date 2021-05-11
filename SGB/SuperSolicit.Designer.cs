namespace SGB
{
    partial class SuperSolicit
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
            this.gridSolicitacoes = new System.Windows.Forms.DataGridView();
            this.listaUsuario = new System.Windows.Forms.ListBox();
            this.listaDepartamento = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lbl_produto = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textContrato = new System.Windows.Forms.TextBox();
            this.botaoFiltrar = new System.Windows.Forms.Button();
            this.botaoLimpar = new System.Windows.Forms.Button();
            this.botaoOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitacoes)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSolicitacoes
            // 
            this.gridSolicitacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridSolicitacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSolicitacoes.Location = new System.Drawing.Point(12, 83);
            this.gridSolicitacoes.Name = "gridSolicitacoes";
            this.gridSolicitacoes.Size = new System.Drawing.Size(877, 441);
            this.gridSolicitacoes.TabIndex = 0;
            this.gridSolicitacoes.DataSourceChanged += new System.EventHandler(this.gridSolicitacoes_DataSourceChanged);
            // 
            // listaUsuario
            // 
            this.listaUsuario.FormattingEnabled = true;
            this.listaUsuario.Location = new System.Drawing.Point(298, 24);
            this.listaUsuario.Name = "listaUsuario";
            this.listaUsuario.Size = new System.Drawing.Size(278, 56);
            this.listaUsuario.TabIndex = 72;
            // 
            // listaDepartamento
            // 
            this.listaDepartamento.FormattingEnabled = true;
            this.listaDepartamento.Location = new System.Drawing.Point(12, 24);
            this.listaDepartamento.Name = "listaDepartamento";
            this.listaDepartamento.Size = new System.Drawing.Size(278, 56);
            this.listaDepartamento.TabIndex = 71;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(295, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(281, 18);
            this.Label1.TabIndex = 69;
            this.Label1.Text = "Usuário";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_produto
            // 
            this.lbl_produto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_produto.Location = new System.Drawing.Point(6, 3);
            this.lbl_produto.Name = "lbl_produto";
            this.lbl_produto.Size = new System.Drawing.Size(281, 18);
            this.lbl_produto.TabIndex = 68;
            this.lbl_produto.Text = "Departamento";
            this.lbl_produto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(583, 24);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(107, 21);
            this.dtpInicio.TabIndex = 76;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFim.Location = new System.Drawing.Point(696, 24);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(107, 21);
            this.dtpFim.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(580, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 69;
            this.label2.Text = "Início";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(693, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 69;
            this.label3.Text = "Fim";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(582, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "Contrato:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textContrato
            // 
            this.textContrato.Location = new System.Drawing.Point(656, 56);
            this.textContrato.Name = "textContrato";
            this.textContrato.Size = new System.Drawing.Size(106, 21);
            this.textContrato.TabIndex = 77;
            // 
            // botaoFiltrar
            // 
            this.botaoFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoFiltrar.Location = new System.Drawing.Point(809, 25);
            this.botaoFiltrar.Name = "botaoFiltrar";
            this.botaoFiltrar.Size = new System.Drawing.Size(80, 23);
            this.botaoFiltrar.TabIndex = 78;
            this.botaoFiltrar.Text = "Filtrar";
            this.botaoFiltrar.UseVisualStyleBackColor = true;
            // 
            // botaoLimpar
            // 
            this.botaoLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoLimpar.Location = new System.Drawing.Point(809, 54);
            this.botaoLimpar.Name = "botaoLimpar";
            this.botaoLimpar.Size = new System.Drawing.Size(80, 23);
            this.botaoLimpar.TabIndex = 78;
            this.botaoLimpar.Text = "Limpar";
            this.botaoLimpar.UseVisualStyleBackColor = true;
            // 
            // botaoOK
            // 
            this.botaoOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoOK.Location = new System.Drawing.Point(768, 54);
            this.botaoOK.Name = "botaoOK";
            this.botaoOK.Size = new System.Drawing.Size(35, 23);
            this.botaoOK.TabIndex = 78;
            this.botaoOK.Text = "Ok";
            this.botaoOK.UseVisualStyleBackColor = true;
            this.botaoOK.Click += new System.EventHandler(this.botaoOK_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(813, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 79;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SuperSolicit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 563);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botaoLimpar);
            this.Controls.Add(this.botaoOK);
            this.Controls.Add(this.botaoFiltrar);
            this.Controls.Add(this.textContrato);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.listaUsuario);
            this.Controls.Add(this.listaDepartamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lbl_produto);
            this.Controls.Add(this.gridSolicitacoes);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SuperSolicit";
            this.Text = "SuperSolicit";
            this.Load += new System.EventHandler(this.SuperSolicit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSolicitacoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridSolicitacoes;
        internal System.Windows.Forms.ListBox listaUsuario;
        internal System.Windows.Forms.ListBox listaDepartamento;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lbl_produto;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFim;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textContrato;
        private System.Windows.Forms.Button botaoFiltrar;
        private System.Windows.Forms.Button botaoLimpar;
        private System.Windows.Forms.Button botaoOK;
        private System.Windows.Forms.Button button1;
    }
}