namespace SGB
{
    partial class DebitoAutomatico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebitoAutomatico));
            this.cmdIGMP = new System.Windows.Forms.Button();
            this.mcInicio = new System.Windows.Forms.MonthCalendar();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdFolder = new System.Windows.Forms.Button();
            this.txtDataInicial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataFinal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdFechar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optCancelarCadastro = new System.Windows.Forms.RadioButton();
            this.optCadastrarContrato = new System.Windows.Forms.RadioButton();
            this.optEnviarNovamente = new System.Windows.Forms.RadioButton();
            this.optCancelarDebito = new System.Windows.Forms.RadioButton();
            this.optAlterarVencimento = new System.Windows.Forms.RadioButton();
            this.cmdLiberarDA = new System.Windows.Forms.Button();
            this.textContrato = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picBradesco = new System.Windows.Forms.PictureBox();
            this.picItau = new System.Windows.Forms.PictureBox();
            this.picSantander = new System.Windows.Forms.PictureBox();
            this.checkItau = new System.Windows.Forms.RadioButton();
            this.picCielo = new System.Windows.Forms.PictureBox();
            this.checkSantander = new System.Windows.Forms.RadioButton();
            this.picHSBC = new System.Windows.Forms.PictureBox();
            this.checkCielo = new System.Windows.Forms.RadioButton();
            this.checkBradesco = new System.Windows.Forms.RadioButton();
            this.checkHSBC = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBradesco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSantander)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSBC)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdIGMP
            // 
            this.cmdIGMP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIGMP.Location = new System.Drawing.Point(18, 453);
            this.cmdIGMP.Name = "cmdIGMP";
            this.cmdIGMP.Size = new System.Drawing.Size(228, 35);
            this.cmdIGMP.TabIndex = 0;
            this.cmdIGMP.Text = "Processar";
            this.cmdIGMP.UseVisualStyleBackColor = true;
            this.cmdIGMP.Click += new System.EventHandler(this.cmdGeraArquivo_Click);
            // 
            // mcInicio
            // 
            this.mcInicio.Location = new System.Drawing.Point(18, 135);
            this.mcInicio.MaxSelectionCount = 1;
            this.mcInicio.Name = "mcInicio";
            this.mcInicio.ShowToday = false;
            this.mcInicio.TabIndex = 2;
            this.mcInicio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcInicio_DateChanged);
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.BackColor = System.Drawing.Color.White;
            this.txtDiretorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiretorio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiretorio.Location = new System.Drawing.Point(18, 316);
            this.txtDiretorio.MaxLength = 8;
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.ReadOnly = true;
            this.txtDiretorio.Size = new System.Drawing.Size(372, 26);
            this.txtDiretorio.TabIndex = 1;
            this.txtDiretorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiretorio.TextChanged += new System.EventHandler(this.txtDiretorio_TextChanged);
            this.txtDiretorio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrato_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gravar em:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Início Cobrança";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contrato ou Pedido";
            // 
            // txtArquivo
            // 
            this.txtArquivo.BackColor = System.Drawing.Color.White;
            this.txtArquivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArquivo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivo.Location = new System.Drawing.Point(19, 365);
            this.txtArquivo.MaxLength = 8;
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.ReadOnly = true;
            this.txtArquivo.Size = new System.Drawing.Size(472, 26);
            this.txtArquivo.TabIndex = 1;
            this.txtArquivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtArquivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrato_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Arquivo Gerado";
            // 
            // cmdFolder
            // 
            this.cmdFolder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFolder.Location = new System.Drawing.Point(396, 316);
            this.cmdFolder.Name = "cmdFolder";
            this.cmdFolder.Size = new System.Drawing.Size(94, 27);
            this.cmdFolder.TabIndex = 0;
            this.cmdFolder.Text = "Alterar";
            this.cmdFolder.UseVisualStyleBackColor = true;
            this.cmdFolder.Click += new System.EventHandler(this.cmdFolder_Click);
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.BackColor = System.Drawing.Color.White;
            this.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInicial.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicial.Location = new System.Drawing.Point(18, 414);
            this.txtDataInicial.MaxLength = 8;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.ReadOnly = true;
            this.txtDataInicial.Size = new System.Drawing.Size(228, 26);
            this.txtDataInicial.TabIndex = 1;
            this.txtDataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrato_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Data Inicial";
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.BackColor = System.Drawing.Color.White;
            this.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFinal.Location = new System.Drawing.Point(263, 414);
            this.txtDataFinal.MaxLength = 8;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.ReadOnly = true;
            this.txtDataFinal.Size = new System.Drawing.Size(228, 26);
            this.txtDataFinal.TabIndex = 1;
            this.txtDataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textContrato_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(260, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Data Final";
            // 
            // cmdFechar
            // 
            this.cmdFechar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFechar.Location = new System.Drawing.Point(262, 453);
            this.cmdFechar.Name = "cmdFechar";
            this.cmdFechar.Size = new System.Drawing.Size(228, 35);
            this.cmdFechar.TabIndex = 0;
            this.cmdFechar.Text = "Fechar";
            this.cmdFechar.UseVisualStyleBackColor = true;
            this.cmdFechar.Click += new System.EventHandler(this.cmdFechar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmdLiberarDA);
            this.panel1.Controls.Add(this.textContrato);
            this.panel1.Location = new System.Drawing.Point(257, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 151);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optCancelarCadastro);
            this.groupBox1.Controls.Add(this.optCadastrarContrato);
            this.groupBox1.Controls.Add(this.optEnviarNovamente);
            this.groupBox1.Controls.Add(this.optCancelarDebito);
            this.groupBox1.Controls.Add(this.optAlterarVencimento);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 82);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // optCancelarCadastro
            // 
            this.optCancelarCadastro.AutoSize = true;
            this.optCancelarCadastro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCancelarCadastro.Location = new System.Drawing.Point(4, 56);
            this.optCancelarCadastro.Name = "optCancelarCadastro";
            this.optCancelarCadastro.Size = new System.Drawing.Size(114, 17);
            this.optCancelarCadastro.TabIndex = 34;
            this.optCancelarCadastro.Text = "Canc. Cadastro";
            this.optCancelarCadastro.UseVisualStyleBackColor = true;
            // 
            // optCadastrarContrato
            // 
            this.optCadastrarContrato.AutoSize = true;
            this.optCadastrarContrato.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCadastrarContrato.Location = new System.Drawing.Point(125, 33);
            this.optCadastrarContrato.Name = "optCadastrarContrato";
            this.optCadastrarContrato.Size = new System.Drawing.Size(82, 17);
            this.optCadastrarContrato.TabIndex = 34;
            this.optCadastrarContrato.Text = "Cadastrar";
            this.optCadastrarContrato.UseVisualStyleBackColor = true;
            // 
            // optEnviarNovamente
            // 
            this.optEnviarNovamente.AutoSize = true;
            this.optEnviarNovamente.Checked = true;
            this.optEnviarNovamente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optEnviarNovamente.Location = new System.Drawing.Point(125, 10);
            this.optEnviarNovamente.Name = "optEnviarNovamente";
            this.optEnviarNovamente.Size = new System.Drawing.Size(61, 17);
            this.optEnviarNovamente.TabIndex = 3;
            this.optEnviarNovamente.TabStop = true;
            this.optEnviarNovamente.Text = "Enviar";
            this.optEnviarNovamente.UseVisualStyleBackColor = true;
            // 
            // optCancelarDebito
            // 
            this.optCancelarDebito.AutoSize = true;
            this.optCancelarDebito.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCancelarDebito.Location = new System.Drawing.Point(4, 33);
            this.optCancelarDebito.Name = "optCancelarDebito";
            this.optCancelarDebito.Size = new System.Drawing.Size(105, 17);
            this.optCancelarDebito.TabIndex = 2;
            this.optCancelarDebito.Text = "Canc. Débitos";
            this.optCancelarDebito.UseVisualStyleBackColor = true;
            // 
            // optAlterarVencimento
            // 
            this.optAlterarVencimento.AutoSize = true;
            this.optAlterarVencimento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAlterarVencimento.Location = new System.Drawing.Point(4, 10);
            this.optAlterarVencimento.Name = "optAlterarVencimento";
            this.optAlterarVencimento.Size = new System.Drawing.Size(114, 17);
            this.optAlterarVencimento.TabIndex = 1;
            this.optAlterarVencimento.Text = "Alt. Vencimento";
            this.optAlterarVencimento.UseVisualStyleBackColor = true;
            this.optAlterarVencimento.CheckedChanged += new System.EventHandler(this.optAlterarVencimento_CheckedChanged);
            // 
            // cmdLiberarDA
            // 
            this.cmdLiberarDA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLiberarDA.Location = new System.Drawing.Point(4, 121);
            this.cmdLiberarDA.Name = "cmdLiberarDA";
            this.cmdLiberarDA.Size = new System.Drawing.Size(224, 23);
            this.cmdLiberarDA.TabIndex = 1;
            this.cmdLiberarDA.Text = "Gerar";
            this.cmdLiberarDA.UseVisualStyleBackColor = true;
            this.cmdLiberarDA.Click += new System.EventHandler(this.envioContrato);
            // 
            // textContrato
            // 
            this.textContrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textContrato.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContrato.Location = new System.Drawing.Point(124, 92);
            this.textContrato.Name = "textContrato";
            this.textContrato.Size = new System.Drawing.Size(104, 23);
            this.textContrato.TabIndex = 0;
            this.textContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textContrato.TextChanged += new System.EventHandler(this.textContrato_TextChanged_1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.picBradesco);
            this.panel2.Controls.Add(this.picItau);
            this.panel2.Controls.Add(this.picSantander);
            this.panel2.Controls.Add(this.checkItau);
            this.panel2.Controls.Add(this.picCielo);
            this.panel2.Controls.Add(this.checkSantander);
            this.panel2.Controls.Add(this.picHSBC);
            this.panel2.Controls.Add(this.checkCielo);
            this.panel2.Controls.Add(this.checkBradesco);
            this.panel2.Controls.Add(this.checkHSBC);
            this.panel2.Location = new System.Drawing.Point(19, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 110);
            this.panel2.TabIndex = 5;
            // 
            // picBradesco
            // 
            this.picBradesco.Image = ((System.Drawing.Image)(resources.GetObject("picBradesco.Image")));
            this.picBradesco.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBradesco.InitialImage")));
            this.picBradesco.Location = new System.Drawing.Point(41, 17);
            this.picBradesco.Name = "picBradesco";
            this.picBradesco.Size = new System.Drawing.Size(64, 64);
            this.picBradesco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBradesco.TabIndex = 34;
            this.picBradesco.TabStop = false;
            this.picBradesco.Click += new System.EventHandler(this.picBradesco_Click);
            // 
            // picItau
            // 
            this.picItau.Image = ((System.Drawing.Image)(resources.GetObject("picItau.Image")));
            this.picItau.InitialImage = ((System.Drawing.Image)(resources.GetObject("picItau.InitialImage")));
            this.picItau.Location = new System.Drawing.Point(371, 17);
            this.picItau.Name = "picItau";
            this.picItau.Size = new System.Drawing.Size(64, 64);
            this.picItau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picItau.TabIndex = 34;
            this.picItau.TabStop = false;
            this.picItau.Click += new System.EventHandler(this.picItau_Click);
            // 
            // picSantander
            // 
            this.picSantander.Image = ((System.Drawing.Image)(resources.GetObject("picSantander.Image")));
            this.picSantander.InitialImage = ((System.Drawing.Image)(resources.GetObject("picSantander.InitialImage")));
            this.picSantander.Location = new System.Drawing.Point(290, 17);
            this.picSantander.Name = "picSantander";
            this.picSantander.Size = new System.Drawing.Size(64, 64);
            this.picSantander.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSantander.TabIndex = 34;
            this.picSantander.TabStop = false;
            this.picSantander.Click += new System.EventHandler(this.picSantander_Click);
            // 
            // checkItau
            // 
            this.checkItau.AutoSize = true;
            this.checkItau.Location = new System.Drawing.Point(395, 87);
            this.checkItau.Name = "checkItau";
            this.checkItau.Size = new System.Drawing.Size(14, 13);
            this.checkItau.TabIndex = 36;
            this.checkItau.UseVisualStyleBackColor = true;
            this.checkItau.CheckedChanged += new System.EventHandler(this.checkItau_CheckedChanged);
            // 
            // picCielo
            // 
            this.picCielo.Image = ((System.Drawing.Image)(resources.GetObject("picCielo.Image")));
            this.picCielo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCielo.InitialImage")));
            this.picCielo.Location = new System.Drawing.Point(206, 17);
            this.picCielo.Name = "picCielo";
            this.picCielo.Size = new System.Drawing.Size(64, 64);
            this.picCielo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCielo.TabIndex = 34;
            this.picCielo.TabStop = false;
            this.picCielo.Click += new System.EventHandler(this.picCielo_Click);
            // 
            // checkSantander
            // 
            this.checkSantander.AutoSize = true;
            this.checkSantander.Location = new System.Drawing.Point(314, 87);
            this.checkSantander.Name = "checkSantander";
            this.checkSantander.Size = new System.Drawing.Size(14, 13);
            this.checkSantander.TabIndex = 36;
            this.checkSantander.UseVisualStyleBackColor = true;
            this.checkSantander.CheckedChanged += new System.EventHandler(this.checkSantander_CheckedChanged);
            // 
            // picHSBC
            // 
            this.picHSBC.Image = ((System.Drawing.Image)(resources.GetObject("picHSBC.Image")));
            this.picHSBC.InitialImage = ((System.Drawing.Image)(resources.GetObject("picHSBC.InitialImage")));
            this.picHSBC.Location = new System.Drawing.Point(123, 17);
            this.picHSBC.Name = "picHSBC";
            this.picHSBC.Size = new System.Drawing.Size(64, 64);
            this.picHSBC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picHSBC.TabIndex = 34;
            this.picHSBC.TabStop = false;
            this.picHSBC.Click += new System.EventHandler(this.picHSBC_Click);
            // 
            // checkCielo
            // 
            this.checkCielo.AutoSize = true;
            this.checkCielo.Location = new System.Drawing.Point(236, 87);
            this.checkCielo.Name = "checkCielo";
            this.checkCielo.Size = new System.Drawing.Size(14, 13);
            this.checkCielo.TabIndex = 36;
            this.checkCielo.UseVisualStyleBackColor = true;
            // 
            // checkBradesco
            // 
            this.checkBradesco.AutoSize = true;
            this.checkBradesco.Checked = true;
            this.checkBradesco.Location = new System.Drawing.Point(62, 87);
            this.checkBradesco.Name = "checkBradesco";
            this.checkBradesco.Size = new System.Drawing.Size(14, 13);
            this.checkBradesco.TabIndex = 36;
            this.checkBradesco.TabStop = true;
            this.checkBradesco.UseVisualStyleBackColor = true;
            // 
            // checkHSBC
            // 
            this.checkHSBC.AutoSize = true;
            this.checkHSBC.Location = new System.Drawing.Point(148, 87);
            this.checkHSBC.Name = "checkHSBC";
            this.checkHSBC.Size = new System.Drawing.Size(14, 13);
            this.checkHSBC.TabIndex = 36;
            this.checkHSBC.UseVisualStyleBackColor = true;
            // 
            // DebitoAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcInicio);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.txtDataInicial);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.txtDiretorio);
            this.Controls.Add(this.cmdFolder);
            this.Controls.Add(this.cmdFechar);
            this.Controls.Add(this.cmdIGMP);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DebitoAutomatico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Débito Automático";
            this.Load += new System.EventHandler(this.igpm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBradesco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSantander)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCielo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSBC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdIGMP;
        private System.Windows.Forms.MonthCalendar mcInicio;
        private System.Windows.Forms.TextBox txtDiretorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdFolder;
        private System.Windows.Forms.TextBox txtDataInicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataFinal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdFechar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textContrato;
        private System.Windows.Forms.Button cmdLiberarDA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optEnviarNovamente;
        private System.Windows.Forms.RadioButton optCancelarDebito;
        private System.Windows.Forms.RadioButton optAlterarVencimento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picHSBC;
        private System.Windows.Forms.PictureBox picBradesco;
        private System.Windows.Forms.RadioButton checkBradesco;
        private System.Windows.Forms.RadioButton checkHSBC;
        private System.Windows.Forms.PictureBox picCielo;
        private System.Windows.Forms.RadioButton checkCielo;
        private System.Windows.Forms.PictureBox picSantander;
        private System.Windows.Forms.RadioButton checkSantander;
        private System.Windows.Forms.RadioButton optCadastrarContrato;
        private System.Windows.Forms.RadioButton optCancelarCadastro;
        private System.Windows.Forms.PictureBox picItau;
        private System.Windows.Forms.RadioButton checkItau;
    }
}