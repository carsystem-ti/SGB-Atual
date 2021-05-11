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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmdEmail = new System.Windows.Forms.Button();
            this.gridParcelas = new System.Windows.Forms.DataGridView();
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
            this.cmdCancelaLista = new System.Windows.Forms.Button();
            this.cmdCarregarLista = new System.Windows.Forms.Button();
            this.cmdAlterar = new System.Windows.Forms.Button();
            this.radCS = new System.Windows.Forms.RadioButton();
            this.radST = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            lblTitulo = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(563, 116);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 13);
            label6.TabIndex = 72;
            label6.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(132, 14);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 64;
            label3.Text = "Pedido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(243, 14);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 63;
            label2.Text = "Placa";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(563, 68);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 62;
            label1.Text = "Produto";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTitulo.Location = new System.Drawing.Point(563, 17);
            lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(44, 13);
            lblTitulo.TabIndex = 58;
            lblTitulo.Text = "Nome";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(567, 133);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(519, 21);
            this.txtEmail.TabIndex = 71;
            this.txtEmail.TabStop = false;
            // 
            // cmdEmail
            // 
            this.cmdEmail.Enabled = false;
            this.cmdEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEmail.Location = new System.Drawing.Point(224, 478);
            this.cmdEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdEmail.Name = "cmdEmail";
            this.cmdEmail.Size = new System.Drawing.Size(161, 30);
            this.cmdEmail.TabIndex = 70;
            this.cmdEmail.Text = "e&Mail";
            this.cmdEmail.UseVisualStyleBackColor = true;
            this.cmdEmail.Click += new System.EventHandler(this.cmdEmail_Click);
            // 
            // gridParcelas
            // 
            this.gridParcelas.AllowUserToAddRows = false;
            this.gridParcelas.AllowUserToDeleteRows = false;
            this.gridParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParcelas.Location = new System.Drawing.Point(13, 169);
            this.gridParcelas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridParcelas.Name = "gridParcelas";
            this.gridParcelas.Size = new System.Drawing.Size(1073, 284);
            this.gridParcelas.TabIndex = 69;
            this.gridParcelas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellValueChanged);
            this.gridParcelas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridParcelas_CellBeginEdit);
            this.gridParcelas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellClick);
            this.gridParcelas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridParcelas_DataError);
            this.gridParcelas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellContentClick);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Enabled = false;
            this.cmdImprimir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.Location = new System.Drawing.Point(54, 478);
            this.cmdImprimir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(161, 30);
            this.cmdImprimir.TabIndex = 60;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdProcessar
            // 
            this.cmdProcessar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcessar.Location = new System.Drawing.Point(317, 80);
            this.cmdProcessar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdProcessar.Name = "cmdProcessar";
            this.cmdProcessar.Size = new System.Drawing.Size(213, 30);
            this.cmdProcessar.TabIndex = 61;
            this.cmdProcessar.Text = "&Processar";
            this.cmdProcessar.UseVisualStyleBackColor = true;
            this.cmdProcessar.Click += new System.EventHandler(this.cmdProcessar_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(199, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Parcelas";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nud_Parcelas
            // 
            this.nud_Parcelas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Parcelas.Location = new System.Drawing.Point(196, 84);
            this.nud_Parcelas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.nud_Parcelas.Size = new System.Drawing.Size(111, 23);
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
            this.label5.Location = new System.Drawing.Point(12, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
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
            this.dtInicioVencimento.Location = new System.Drawing.Point(13, 84);
            this.dtInicioVencimento.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dtInicioVencimento.Name = "dtInicioVencimento";
            this.dtInicioVencimento.Size = new System.Drawing.Size(172, 23);
            this.dtInicioVencimento.TabIndex = 65;
            this.dtInicioVencimento.Value = new System.DateTime(2007, 6, 1, 0, 0, 0, 0);
            // 
            // cmdPesquisar
            // 
            this.cmdPesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPesquisar.Location = new System.Drawing.Point(349, 24);
            this.cmdPesquisar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdPesquisar.Name = "cmdPesquisar";
            this.cmdPesquisar.Size = new System.Drawing.Size(181, 30);
            this.cmdPesquisar.TabIndex = 59;
            this.cmdPesquisar.Text = "p&Esquisar";
            this.cmdPesquisar.UseVisualStyleBackColor = true;
            this.cmdPesquisar.Click += new System.EventHandler(this.cmdPesquisar_Click);
            // 
            // txtPedido
            // 
            this.txtPedido.Location = new System.Drawing.Point(136, 30);
            this.txtPedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(101, 21);
            this.txtPedido.TabIndex = 55;
            this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(247, 30);
            this.txtPlaca.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(95, 21);
            this.txtPlaca.TabIndex = 57;
            this.txtPlaca.TextChanged += new System.EventHandler(this.txtPlaca_TextChanged);
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(567, 85);
            this.txtProduto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(519, 21);
            this.txtProduto.TabIndex = 54;
            this.txtProduto.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(567, 34);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(519, 21);
            this.txtNome.TabIndex = 56;
            this.txtNome.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optTodas);
            this.groupBox1.Controls.Add(this.optVencidas);
            this.groupBox1.Controls.Add(this.optVencer);
            this.groupBox1.Location = new System.Drawing.Point(601, 448);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(96, 85);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            // 
            // optTodas
            // 
            this.optTodas.AutoSize = true;
            this.optTodas.Checked = true;
            this.optTodas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTodas.Location = new System.Drawing.Point(8, 53);
            this.optTodas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optTodas.Name = "optTodas";
            this.optTodas.Size = new System.Drawing.Size(63, 20);
            this.optTodas.TabIndex = 3;
            this.optTodas.TabStop = true;
            this.optTodas.Text = "Todas";
            this.optTodas.UseVisualStyleBackColor = true;
            this.optTodas.CheckedChanged += new System.EventHandler(this.setOpcaoStatus);
            // 
            // optVencidas
            // 
            this.optVencidas.AutoSize = true;
            this.optVencidas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVencidas.Location = new System.Drawing.Point(8, 34);
            this.optVencidas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optVencidas.Name = "optVencidas";
            this.optVencidas.Size = new System.Drawing.Size(83, 20);
            this.optVencidas.TabIndex = 2;
            this.optVencidas.Text = "Vencidas";
            this.optVencidas.UseVisualStyleBackColor = true;
            this.optVencidas.CheckedChanged += new System.EventHandler(this.setOpcaoStatus);
            // 
            // optVencer
            // 
            this.optVencer.AutoSize = true;
            this.optVencer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVencer.Location = new System.Drawing.Point(8, 16);
            this.optVencer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optVencer.Name = "optVencer";
            this.optVencer.Size = new System.Drawing.Size(83, 20);
            this.optVencer.TabIndex = 1;
            this.optVencer.Text = "À Vencer";
            this.optVencer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optVencer.UseVisualStyleBackColor = true;
            this.optVencer.CheckedChanged += new System.EventHandler(this.setOpcaoStatus);
            // 
            // cmdCancelaLista
            // 
            this.cmdCancelaLista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancelaLista.Location = new System.Drawing.Point(317, 123);
            this.cmdCancelaLista.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdCancelaLista.Name = "cmdCancelaLista";
            this.cmdCancelaLista.Size = new System.Drawing.Size(213, 30);
            this.cmdCancelaLista.TabIndex = 59;
            this.cmdCancelaLista.Text = "&Cancelar Lista";
            this.cmdCancelaLista.UseVisualStyleBackColor = true;
            this.cmdCancelaLista.Click += new System.EventHandler(this.cmdCancelaLista_Click);
            // 
            // cmdCarregarLista
            // 
            this.cmdCarregarLista.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCarregarLista.Location = new System.Drawing.Point(16, 123);
            this.cmdCarregarLista.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdCarregarLista.Name = "cmdCarregarLista";
            this.cmdCarregarLista.Size = new System.Drawing.Size(291, 30);
            this.cmdCarregarLista.TabIndex = 59;
            this.cmdCarregarLista.Text = "c&Arregar Lista";
            this.cmdCarregarLista.UseVisualStyleBackColor = true;
            this.cmdCarregarLista.Click += new System.EventHandler(this.cmdCarregarLista_Click);
            // 
            // cmdAlterar
            // 
            this.cmdAlterar.Enabled = false;
            this.cmdAlterar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAlterar.Location = new System.Drawing.Point(393, 478);
            this.cmdAlterar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdAlterar.Name = "cmdAlterar";
            this.cmdAlterar.Size = new System.Drawing.Size(161, 30);
            this.cmdAlterar.TabIndex = 70;
            this.cmdAlterar.Text = "al&Terar";
            this.cmdAlterar.UseVisualStyleBackColor = true;
            this.cmdAlterar.Click += new System.EventHandler(this.cmdAlterar_Click);
            // 
            // radCS
            // 
            this.radCS.AutoSize = true;
            this.radCS.Checked = true;
            this.radCS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCS.Location = new System.Drawing.Point(16, 13);
            this.radCS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radCS.Name = "radCS";
            this.radCS.Size = new System.Drawing.Size(95, 17);
            this.radCS.TabIndex = 74;
            this.radCS.TabStop = true;
            this.radCS.Text = "CarSystem";
            this.radCS.UseVisualStyleBackColor = true;
            this.radCS.CheckedChanged += new System.EventHandler(this.empresa_CheckedChanged);
            // 
            // radST
            // 
            this.radST.AutoSize = true;
            this.radST.Enabled = false;
            this.radST.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radST.Location = new System.Drawing.Point(16, 33);
            this.radST.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radST.Name = "radST";
            this.radST.Size = new System.Drawing.Size(68, 17);
            this.radST.TabIndex = 74;
            this.radST.Text = "SatNet";
            this.radST.UseVisualStyleBackColor = true;
            this.radST.CheckedChanged += new System.EventHandler(this.empresa_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(label10);
            this.panel5.Controls.Add(label9);
            this.panel5.Controls.Add(label8);
            this.panel5.Controls.Add(label7);
            this.panel5.Location = new System.Drawing.Point(723, 459);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(363, 66);
            this.panel5.TabIndex = 84;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(99, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 24);
            this.panel2.TabIndex = 88;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(15, 26);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 24);
            this.panel4.TabIndex = 89;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(267, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(78, 24);
            this.panel3.TabIndex = 90;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(183, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 24);
            this.panel1.TabIndex = 91;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(109, 10);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(58, 13);
            label10.TabIndex = 85;
            label10.Text = "Vencido";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.Location = new System.Drawing.Point(269, 10);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(74, 13);
            label9.TabIndex = 84;
            label9.Text = "Cancelado";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(24, 10);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(60, 13);
            label8.TabIndex = 86;
            label8.Text = "aVencer";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(194, 10);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 13);
            label7.TabIndex = 87;
            label7.Text = "Quitado";
            // 
            // OperBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1100, 533);
            this.Controls.Add(this.gridParcelas);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.radST);
            this.Controls.Add(this.radCS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cmdCarregarLista);
            this.Controls.Add(this.cmdCancelaLista);
            this.Controls.Add(this.cmdAlterar);
            this.Controls.Add(this.cmdEmail);
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
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OperBoletos";
            this.Text = "Operações Boletos 4.6";
            this.Load += new System.EventHandler(this.Boletos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Parcelas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button cmdEmail;
        private System.Windows.Forms.DataGridView gridParcelas;
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
        private System.Windows.Forms.Button cmdCancelaLista;
        private System.Windows.Forms.Button cmdCarregarLista;
        private System.Windows.Forms.Button cmdAlterar;
        private System.Windows.Forms.RadioButton radCS;
        private System.Windows.Forms.RadioButton radST;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}

