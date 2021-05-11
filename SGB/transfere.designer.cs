namespace geraBoletos
{
    partial class OperBoletos
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
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblTitulo;
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmdEmail = new System.Windows.Forms.Button();
            this.dgParcelas = new System.Windows.Forms.DataGridView();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdProcessar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_Parcelas = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dtInicioVencimento = new System.Windows.Forms.DateTimePicker();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optTodas = new System.Windows.Forms.RadioButton();
            this.optVencidas = new System.Windows.Forms.RadioButton();
            this.optVencer = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_Revisao = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Revisao)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(422, 116);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 13);
            label6.TabIndex = 72;
            label6.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(10, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 64;
            label3.Text = "Pedido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(123, 19);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 63;
            label2.Text = "Placa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(422, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 62;
            label1.Text = "Produto";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitulo.Location = new System.Drawing.Point(422, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(44, 13);
            lblTitulo.TabIndex = 58;
            lblTitulo.Text = "Nome";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(425, 133);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(390, 20);
            this.txtEmail.TabIndex = 71;
            this.txtEmail.TabStop = false;
            // 
            // cmdEmail
            // 
            this.cmdEmail.Enabled = false;
            this.cmdEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmail.Location = new System.Drawing.Point(622, 175);
            this.cmdEmail.Name = "cmdEmail";
            this.cmdEmail.Size = new System.Drawing.Size(193, 30);
            this.cmdEmail.TabIndex = 70;
            this.cmdEmail.Text = "e&Mail";
            this.cmdEmail.UseVisualStyleBackColor = true;
            this.cmdEmail.Click += new System.EventHandler(this.cmdEmail_Click);
            // 
            // dgParcelas
            // 
            this.dgParcelas.AllowUserToAddRows = false;
            this.dgParcelas.AllowUserToDeleteRows = false;
            this.dgParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParcelas.Location = new System.Drawing.Point(10, 218);
            this.dgParcelas.Name = "dgParcelas";
            this.dgParcelas.Size = new System.Drawing.Size(805, 284);
            this.dgParcelas.TabIndex = 69;
            this.dgParcelas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgParcelas_CellValueChanged);
            this.dgParcelas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgParcelas_CellBeginEdit);
            this.dgParcelas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgParcelas_DataError);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Enabled = false;
            this.cmdImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Location = new System.Drawing.Point(427, 175);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(189, 30);
            this.cmdImprimir.TabIndex = 60;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdProcessar
            // 
            this.cmdProcessar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcessar.Location = new System.Drawing.Point(86, 130);
            this.cmdProcessar.Name = "cmdProcessar";
            this.cmdProcessar.Size = new System.Drawing.Size(245, 30);
            this.cmdProcessar.TabIndex = 61;
            this.cmdProcessar.Text = "&Processar";
            this.cmdProcessar.UseVisualStyleBackColor = true;
            this.cmdProcessar.Click += new System.EventHandler(this.cmdProcessar_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Parcelas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_Parcelas
            // 
            this.nud_Parcelas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Parcelas.Location = new System.Drawing.Point(173, 94);
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
            this.nud_Parcelas.Size = new System.Drawing.Size(97, 23);
            this.nud_Parcelas.TabIndex = 67;
            this.nud_Parcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Parcelas.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "1º Vencimento";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtInicioVencimento
            // 
            this.dtInicioVencimento.Enabled = false;
            this.dtInicioVencimento.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInicioVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicioVencimento.Location = new System.Drawing.Point(36, 94);
            this.dtInicioVencimento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtInicioVencimento.Name = "dtInicioVencimento";
            this.dtInicioVencimento.Size = new System.Drawing.Size(130, 23);
            this.dtInicioVencimento.TabIndex = 65;
            this.dtInicioVencimento.Value = new System.DateTime(2007, 6, 1, 0, 0, 0, 0);
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Location = new System.Drawing.Point(217, 29);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(184, 30);
            this.cmdPesquisar.TabIndex = 59;
            this.cmdPesquisar.Text = "p&Esquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(13, 35);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(107, 20);
            this.txtPedido.TabIndex = 55;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(126, 35);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(85, 20);
            this.txtPlaca.TabIndex = 57;
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(425, 85);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(390, 20);
            this.txtProduto.TabIndex = 54;
            this.txtProduto.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(425, 34);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(390, 20);
            this.txtNome.TabIndex = 56;
            this.txtNome.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optTodas);
            this.groupBox1.Controls.Add(this.optVencidas);
            this.groupBox1.Controls.Add(this.optVencer);
            this.groupBox1.Location = new System.Drawing.Point(12, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 42);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // optTodas
            // 
            this.optTodas.AutoSize = true;
            this.optTodas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTodas.Location = new System.Drawing.Point(260, 15);
            this.optTodas.Name = "optTodas";
            this.optTodas.Size = new System.Drawing.Size(64, 20);
            this.optTodas.TabIndex = 3;
            this.optTodas.Text = "Todas";
            this.optTodas.UseVisualStyleBackColor = true;
            this.optTodas.CheckedChanged += new System.EventHandler(this.optTodas_CheckedChanged);
            // 
            // optVencidas
            // 
            this.optVencidas.AutoSize = true;
            this.optVencidas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVencidas.Location = new System.Drawing.Point(170, 15);
            this.optVencidas.Name = "optVencidas";
            this.optVencidas.Size = new System.Drawing.Size(84, 20);
            this.optVencidas.TabIndex = 2;
            this.optVencidas.Text = "Vencidas";
            this.optVencidas.UseVisualStyleBackColor = true;
            this.optVencidas.CheckedChanged += new System.EventHandler(this.optVencidas_CheckedChanged);
            // 
            // optVencer
            // 
            this.optVencer.AutoSize = true;
            this.optVencer.Checked = true;
            this.optVencer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVencer.Location = new System.Drawing.Point(79, 15);
            this.optVencer.Name = "optVencer";
            this.optVencer.Size = new System.Drawing.Size(84, 20);
            this.optVencer.TabIndex = 1;
            this.optVencer.TabStop = true;
            this.optVencer.Text = "À Vencer";
            this.optVencer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optVencer.UseVisualStyleBackColor = true;
            this.optVencer.CheckedChanged += new System.EventHandler(this.optVencer_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(278, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Revisão";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_Revisao
            // 
            this.nud_Revisao.Enabled = false;
            this.nud_Revisao.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Revisao.Location = new System.Drawing.Point(276, 94);
            this.nud_Revisao.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nud_Revisao.Name = "nud_Revisao";
            this.nud_Revisao.Size = new System.Drawing.Size(97, 23);
            this.nud_Revisao.TabIndex = 74;
            this.nud_Revisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Boletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(827, 519);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_Revisao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmdEmail);
            this.Controls.Add(this.dgParcelas);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdProcessar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_Parcelas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtInicioVencimento);
            this.Controls.Add(this.cmdPesquisar);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(lblTitulo);
            this.Controls.Add(this.txtNome);
            this.Name = "Boletos";
            this.Text = "Boletos 3.0";
            this.Load += new System.EventHandler(this.Boletos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Revisao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button cmdEmail;
        private System.Windows.Forms.DataGridView dgParcelas;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdProcessar;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown nud_Parcelas;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker dtInicioVencimento;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optVencidas;
        private System.Windows.Forms.RadioButton optVencer;
        private System.Windows.Forms.RadioButton optTodas;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.NumericUpDown nud_Revisao;
    }
}

