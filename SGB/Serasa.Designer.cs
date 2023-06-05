
namespace SGB
{
    partial class Serasa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.dg_Filtrados = new System.Windows.Forms.DataGridView();
            this.Label4 = new System.Windows.Forms.Label();
            this.listaRemessa = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArquivoAdimplencia = new System.Windows.Forms.Button();
            this.btnarquivoRetornoAd = new System.Windows.Forms.Button();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.btnretornoInad = new System.Windows.Forms.Button();
            this.pnlInadimplente = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAdimplente = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textFiltro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBanco = new System.Windows.Forms.GroupBox();
            this.chkInseriManual = new System.Windows.Forms.CheckBox();
            this.cmdPesquisar = new System.Windows.Forms.Button();
            this.grupoAcoes = new System.Windows.Forms.GroupBox();
            this.lblnome = new System.Windows.Forms.Label();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.btnListaNegra = new System.Windows.Forms.Button();
            this.txtcontrole = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkErro = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsequencia = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.txtQuantidadeRemessa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemessa = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            Label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Filtrados)).BeginInit();
            this.pnlInadimplente.SuspendLayout();
            this.pnlAdimplente.SuspendLayout();
            this.groupBanco.SuspendLayout();
            this.grupoAcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label14
            // 
            Label14.Location = new System.Drawing.Point(0, 0);
            Label14.Name = "Label14";
            Label14.Size = new System.Drawing.Size(100, 23);
            Label14.TabIndex = 64;
            // 
            // btnArquivo
            // 
            this.btnArquivo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArquivo.ForeColor = System.Drawing.Color.Red;
            this.btnArquivo.Location = new System.Drawing.Point(42, 24);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(297, 37);
            this.btnArquivo.TabIndex = 76;
            this.btnArquivo.Text = "Gerar arquivo";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // dg_Filtrados
            // 
            this.dg_Filtrados.AllowUserToAddRows = false;
            this.dg_Filtrados.AllowUserToDeleteRows = false;
            this.dg_Filtrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_Filtrados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Filtrados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_Filtrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_Filtrados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_Filtrados.Location = new System.Drawing.Point(16, 274);
            this.dg_Filtrados.Name = "dg_Filtrados";
            this.dg_Filtrados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_Filtrados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_Filtrados.RowHeadersWidth = 60;
            this.dg_Filtrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_Filtrados.Size = new System.Drawing.Size(1024, 190);
            this.dg_Filtrados.TabIndex = 78;
            this.dg_Filtrados.Click += new System.EventHandler(this.dg_Filtrados_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(13, 12);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(205, 13);
            this.Label4.TabIndex = 84;
            this.Label4.Text = "LISTA DE REMESSAS EMITIDAS";
            // 
            // listaRemessa
            // 
            this.listaRemessa.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaRemessa.ForeColor = System.Drawing.Color.Black;
            this.listaRemessa.FormattingEnabled = true;
            this.listaRemessa.ItemHeight = 18;
            this.listaRemessa.Location = new System.Drawing.Point(12, 28);
            this.listaRemessa.Name = "listaRemessa";
            this.listaRemessa.Size = new System.Drawing.Size(729, 112);
            this.listaRemessa.TabIndex = 85;
            this.listaRemessa.SelectedIndexChanged += new System.EventHandler(this.listaRemessa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 244);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 23);
            this.label1.TabIndex = 86;
            this.label1.Text = "LISTA DE CPF/CNPJ";
            // 
            // btnArquivoAdimplencia
            // 
            this.btnArquivoAdimplencia.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArquivoAdimplencia.ForeColor = System.Drawing.Color.Green;
            this.btnArquivoAdimplencia.Location = new System.Drawing.Point(33, 24);
            this.btnArquivoAdimplencia.Name = "btnArquivoAdimplencia";
            this.btnArquivoAdimplencia.Size = new System.Drawing.Size(309, 37);
            this.btnArquivoAdimplencia.TabIndex = 89;
            this.btnArquivoAdimplencia.Text = "Gerar Arquivo Adimplência";
            this.btnArquivoAdimplencia.UseVisualStyleBackColor = true;
            this.btnArquivoAdimplencia.Click += new System.EventHandler(this.btnArquivoAdimplencia_Click);
            // 
            // btnarquivoRetornoAd
            // 
            this.btnarquivoRetornoAd.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btnarquivoRetornoAd.ForeColor = System.Drawing.Color.Green;
            this.btnarquivoRetornoAd.Location = new System.Drawing.Point(33, 67);
            this.btnarquivoRetornoAd.Name = "btnarquivoRetornoAd";
            this.btnarquivoRetornoAd.Size = new System.Drawing.Size(309, 37);
            this.btnarquivoRetornoAd.TabIndex = 90;
            this.btnarquivoRetornoAd.Text = "Processar arquivo retorno Inadimplencia";
            this.btnarquivoRetornoAd.UseVisualStyleBackColor = true;
            this.btnarquivoRetornoAd.Click += new System.EventHandler(this.btnarquivoRetornoAd_Click);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "ofd1";
            // 
            // btnretornoInad
            // 
            this.btnretornoInad.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.btnretornoInad.ForeColor = System.Drawing.Color.Red;
            this.btnretornoInad.Location = new System.Drawing.Point(42, 67);
            this.btnretornoInad.Name = "btnretornoInad";
            this.btnretornoInad.Size = new System.Drawing.Size(297, 37);
            this.btnretornoInad.TabIndex = 91;
            this.btnretornoInad.Text = "Processar arquivo retorno Inadimplencia";
            this.btnretornoInad.UseVisualStyleBackColor = true;
            this.btnretornoInad.Click += new System.EventHandler(this.btnretornoInad_Click);
            // 
            // pnlInadimplente
            // 
            this.pnlInadimplente.Controls.Add(this.label2);
            this.pnlInadimplente.Controls.Add(this.btnArquivo);
            this.pnlInadimplente.Controls.Add(this.btnretornoInad);
            this.pnlInadimplente.Enabled = false;
            this.pnlInadimplente.Location = new System.Drawing.Point(27, 470);
            this.pnlInadimplente.Name = "pnlInadimplente";
            this.pnlInadimplente.Size = new System.Drawing.Size(397, 118);
            this.pnlInadimplente.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(84, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Processos de Inadimplência";
            // 
            // pnlAdimplente
            // 
            this.pnlAdimplente.Controls.Add(this.label3);
            this.pnlAdimplente.Controls.Add(this.btnArquivoAdimplencia);
            this.pnlAdimplente.Controls.Add(this.btnarquivoRetornoAd);
            this.pnlAdimplente.Enabled = false;
            this.pnlAdimplente.Location = new System.Drawing.Point(572, 470);
            this.pnlAdimplente.Name = "pnlAdimplente";
            this.pnlAdimplente.Size = new System.Drawing.Size(397, 118);
            this.pnlAdimplente.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(96, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Processos de Adimplência";
            // 
            // textFiltro
            // 
            this.textFiltro.Location = new System.Drawing.Point(9, 35);
            this.textFiltro.Name = "textFiltro";
            this.textFiltro.Size = new System.Drawing.Size(167, 20);
            this.textFiltro.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 16);
            this.label5.TabIndex = 94;
            this.label5.Text = "CONTRATO / CNPJ_CPF";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBanco
            // 
            this.groupBanco.Controls.Add(this.chkInseriManual);
            this.groupBanco.Controls.Add(this.cmdPesquisar);
            this.groupBanco.Controls.Add(this.textFiltro);
            this.groupBanco.Controls.Add(this.label5);
            this.groupBanco.Location = new System.Drawing.Point(747, 28);
            this.groupBanco.Name = "groupBanco";
            this.groupBanco.Size = new System.Drawing.Size(293, 112);
            this.groupBanco.TabIndex = 96;
            this.groupBanco.TabStop = false;
            this.groupBanco.Text = "Filtro";
            // 
            // chkInseriManual
            // 
            this.chkInseriManual.AutoSize = true;
            this.chkInseriManual.Location = new System.Drawing.Point(9, 61);
            this.chkInseriManual.Name = "chkInseriManual";
            this.chkInseriManual.Size = new System.Drawing.Size(138, 17);
            this.chkInseriManual.TabIndex = 100;
            this.chkInseriManual.Text = "Inserir BlackList Manual";
            this.chkInseriManual.UseVisualStyleBackColor = true;
            this.chkInseriManual.Click += new System.EventHandler(this.chkInseriManual_Click);
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Location = new System.Drawing.Point(183, 29);
            this.cmdPesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(103, 30);
            this.cmdPesquisar.TabIndex = 97;
            this.cmdPesquisar.Text = "P&esquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // grupoAcoes
            // 
            this.grupoAcoes.Controls.Add(this.lblnome);
            this.grupoAcoes.Controls.Add(this.txtnome);
            this.grupoAcoes.Controls.Add(this.btnListaNegra);
            this.grupoAcoes.Controls.Add(this.txtcontrole);
            this.grupoAcoes.Controls.Add(this.label6);
            this.grupoAcoes.Enabled = false;
            this.grupoAcoes.Location = new System.Drawing.Point(396, 146);
            this.grupoAcoes.Name = "grupoAcoes";
            this.grupoAcoes.Size = new System.Drawing.Size(644, 70);
            this.grupoAcoes.TabIndex = 97;
            this.grupoAcoes.TabStop = false;
            this.grupoAcoes.Text = "Ações";
            // 
            // lblnome
            // 
            this.lblnome.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnome.Location = new System.Drawing.Point(69, 16);
            this.lblnome.Name = "lblnome";
            this.lblnome.Size = new System.Drawing.Size(170, 16);
            this.lblnome.TabIndex = 98;
            this.lblnome.Text = "Cliente";
            this.lblnome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtnome
            // 
            this.txtnome.Enabled = false;
            this.txtnome.Location = new System.Drawing.Point(72, 35);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(273, 20);
            this.txtnome.TabIndex = 98;
            // 
            // btnListaNegra
            // 
            this.btnListaNegra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaNegra.ForeColor = System.Drawing.Color.Red;
            this.btnListaNegra.Location = new System.Drawing.Point(351, 29);
            this.btnListaNegra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnListaNegra.Name = "btnListaNegra";
            this.btnListaNegra.Size = new System.Drawing.Size(154, 30);
            this.btnListaNegra.TabIndex = 97;
            this.btnListaNegra.Text = "Incluir Lista Negra";
            this.btnListaNegra.UseVisualStyleBackColor = true;
            this.btnListaNegra.Click += new System.EventHandler(this.btnListaNegra_Click);
            // 
            // txtcontrole
            // 
            this.txtcontrole.Enabled = false;
            this.txtcontrole.Location = new System.Drawing.Point(9, 35);
            this.txtcontrole.Name = "txtcontrole";
            this.txtcontrole.Size = new System.Drawing.Size(57, 20);
            this.txtcontrole.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 94;
            this.label6.Text = "Controle";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkErro
            // 
            this.chkErro.AutoSize = true;
            this.chkErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkErro.Location = new System.Drawing.Point(903, 248);
            this.chkErro.Name = "chkErro";
            this.chkErro.Size = new System.Drawing.Size(137, 17);
            this.chkErro.TabIndex = 98;
            this.chkErro.Text = "CPF-CNPJ com erro";
            this.chkErro.UseVisualStyleBackColor = true;
            this.chkErro.Visible = false;
            this.chkErro.CheckedChanged += new System.EventHandler(this.chkErro_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 99;
            this.label7.Text = "Sequência";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtsequencia
            // 
            this.txtsequencia.Location = new System.Drawing.Point(16, 181);
            this.txtsequencia.MaxLength = 6;
            this.txtsequencia.Name = "txtsequencia";
            this.txtsequencia.Size = new System.Drawing.Size(106, 20);
            this.txtsequencia.TabIndex = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 101;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRetirar
            // 
            this.btnRetirar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirar.ForeColor = System.Drawing.Color.Red;
            this.btnRetirar.Location = new System.Drawing.Point(747, 231);
            this.btnRetirar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(143, 38);
            this.btnRetirar.TabIndex = 102;
            this.btnRetirar.Text = "RETIRAR CPF/CNPJ";
            this.btnRetirar.UseVisualStyleBackColor = true;
            this.btnRetirar.Visible = false;
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // txtQuantidadeRemessa
            // 
            this.txtQuantidadeRemessa.Enabled = false;
            this.txtQuantidadeRemessa.ForeColor = System.Drawing.Color.Red;
            this.txtQuantidadeRemessa.Location = new System.Drawing.Point(20, 249);
            this.txtQuantidadeRemessa.MaxLength = 6;
            this.txtQuantidadeRemessa.Name = "txtQuantidadeRemessa";
            this.txtQuantidadeRemessa.Size = new System.Drawing.Size(43, 20);
            this.txtQuantidadeRemessa.TabIndex = 104;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 103;
            this.label8.Text = "Qtd";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemessa
            // 
            this.txtRemessa.Enabled = false;
            this.txtRemessa.Location = new System.Drawing.Point(69, 249);
            this.txtRemessa.MaxLength = 6;
            this.txtRemessa.Name = "txtRemessa";
            this.txtRemessa.Size = new System.Drawing.Size(106, 20);
            this.txtRemessa.TabIndex = 106;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(66, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 105;
            this.label9.Text = "Remessa";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Serasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 600);
            this.Controls.Add(this.txtRemessa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQuantidadeRemessa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRetirar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtsequencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkErro);
            this.Controls.Add(this.grupoAcoes);
            this.Controls.Add(this.groupBanco);
            this.Controls.Add(this.pnlAdimplente);
            this.Controls.Add(this.pnlInadimplente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaRemessa);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.dg_Filtrados);
            this.Controls.Add(Label14);
            this.Name = "Serasa";
            this.Text = "Serasa";
            ((System.ComponentModel.ISupportInitialize)(this.dg_Filtrados)).EndInit();
            this.pnlInadimplente.ResumeLayout(false);
            this.pnlInadimplente.PerformLayout();
            this.pnlAdimplente.ResumeLayout(false);
            this.pnlAdimplente.PerformLayout();
            this.groupBanco.ResumeLayout(false);
            this.groupBanco.PerformLayout();
            this.grupoAcoes.ResumeLayout(false);
            this.grupoAcoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnArquivo;
        internal System.Windows.Forms.DataGridView dg_Filtrados;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ListBox listaRemessa;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArquivoAdimplencia;
        private System.Windows.Forms.Button btnarquivoRetornoAd;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button btnretornoInad;
        private System.Windows.Forms.Panel pnlInadimplente;
        private System.Windows.Forms.Panel pnlAdimplente;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFiltro;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBanco;
        private System.Windows.Forms.Button cmdPesquisar;
        private System.Windows.Forms.GroupBox grupoAcoes;
        private System.Windows.Forms.Button btnListaNegra;
        private System.Windows.Forms.TextBox txtcontrole;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblnome;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.CheckBox chkInseriManual;
        private System.Windows.Forms.CheckBox chkErro;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsequencia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.TextBox txtQuantidadeRemessa;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemessa;
        internal System.Windows.Forms.Label label9;
    }
}