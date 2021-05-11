namespace geracaoRemessa.Formulario
{
    partial class CriacaoRemessa
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
            this.Label5 = new System.Windows.Forms.Label();
            this.cbBanco = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.nud_Parcelas = new System.Windows.Forms.NumericUpDown();
            this.cmdIniciar = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblTituloRemessa = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtFimVencimentos = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtInicioVencimento = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(236, 108);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(46, 13);
            this.Label5.TabIndex = 24;
            this.Label5.Text = "Banco";
            // 
            // cbBanco
            // 
            this.cbBanco.DisplayMember = "ds_empresa";
            this.cbBanco.FormattingEnabled = true;
            this.cbBanco.Items.AddRange(new object[] {
            "Santander",
            "Bradesco",
            "Safra"});
            this.cbBanco.Location = new System.Drawing.Point(236, 124);
            this.cbBanco.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbBanco.Name = "cbBanco";
            this.cbBanco.Size = new System.Drawing.Size(141, 21);
            this.cbBanco.TabIndex = 23;
            this.cbBanco.ValueMember = "cd_empresa";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(296, 48);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(76, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Parcelas";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_Parcelas
            // 
            this.nud_Parcelas.Location = new System.Drawing.Point(294, 67);
            this.nud_Parcelas.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nud_Parcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Parcelas.Name = "nud_Parcelas";
            this.nud_Parcelas.Size = new System.Drawing.Size(83, 20);
            this.nud_Parcelas.TabIndex = 21;
            this.nud_Parcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Parcelas.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // cmdIniciar
            // 
            this.cmdIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdIniciar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIniciar.Location = new System.Drawing.Point(113, 170);
            this.cmdIniciar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdIniciar.Name = "cmdIniciar";
            this.cmdIniciar.Size = new System.Drawing.Size(165, 32);
            this.cmdIniciar.TabIndex = 20;
            this.cmdIniciar.Text = "&Criar";
            this.cmdIniciar.UseVisualStyleBackColor = true;
            this.cmdIniciar.Click += new System.EventHandler(this.cmdIniciar_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(13, 108);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 13);
            this.Label4.TabIndex = 19;
            this.Label4.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DisplayMember = "ds_empresa";
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Items.AddRange(new object[] {
            "CarSystem",
            "SatNet"});
            this.cbEmpresa.Location = new System.Drawing.Point(13, 124);
            this.cbEmpresa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(215, 21);
            this.cbEmpresa.TabIndex = 18;
            this.cbEmpresa.ValueMember = "cd_empresa";
            // 
            // lblTituloRemessa
            // 
            this.lblTituloRemessa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRemessa.Location = new System.Drawing.Point(13, 9);
            this.lblTituloRemessa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloRemessa.Name = "lblTituloRemessa";
            this.lblTituloRemessa.Size = new System.Drawing.Size(367, 28);
            this.lblTituloRemessa.TabIndex = 17;
            this.lblTituloRemessa.Text = "Título Remessa";
            this.lblTituloRemessa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(160, 48);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(118, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Fim Vencimentos";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtFimVencimentos
            // 
            this.dtFimVencimentos.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFimVencimentos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFimVencimentos.Location = new System.Drawing.Point(160, 67);
            this.dtFimVencimentos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtFimVencimentos.Name = "dtFimVencimentos";
            this.dtFimVencimentos.Size = new System.Drawing.Size(118, 23);
            this.dtFimVencimentos.TabIndex = 15;
            this.dtFimVencimentos.Value = new System.DateTime(2007, 6, 1, 0, 0, 0, 0);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 48);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(131, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Início Vencimentos";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtInicioVencimento
            // 
            this.dtInicioVencimento.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInicioVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicioVencimento.Location = new System.Drawing.Point(13, 67);
            this.dtInicioVencimento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtInicioVencimento.Name = "dtInicioVencimento";
            this.dtInicioVencimento.Size = new System.Drawing.Size(130, 23);
            this.dtInicioVencimento.TabIndex = 13;
            this.dtInicioVencimento.Value = new System.DateTime(2007, 6, 1, 0, 0, 0, 0);
            // 
            // CriacaoRemessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(394, 216);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cbBanco);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.nud_Parcelas);
            this.Controls.Add(this.cmdIniciar);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.lblTituloRemessa);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.dtFimVencimentos);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.dtInicioVencimento);
            this.Name = "CriacaoRemessa";
            this.Text = "Criação da Remessa";
            this.Load += new System.EventHandler(this.CriacaoRemessa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cbBanco;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.NumericUpDown nud_Parcelas;
        internal System.Windows.Forms.Button cmdIniciar;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cbEmpresa;
        internal System.Windows.Forms.Label lblTituloRemessa;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker dtFimVencimentos;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtInicioVencimento;
    }
}

