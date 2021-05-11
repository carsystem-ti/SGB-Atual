namespace geracaoRemessa.Formulario
{
    partial class BloqueioBoletos
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
            this.btn_valor = new System.Windows.Forms.Button();
            this.btn_filtro_2 = new System.Windows.Forms.Button();
            this.txt_pedido = new System.Windows.Forms.TextBox();
            this.lbl_pedido = new System.Windows.Forms.Label();
            this.lbl_motivos = new System.Windows.Forms.Label();
            this.cb_motivos = new System.Windows.Forms.ComboBox();
            this.dg_Filtrados = new System.Windows.Forms.DataGridView();
            this.btn_bloquear = new System.Windows.Forms.Button();
            this.btn_exportar = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.listaValor = new System.Windows.Forms.ListBox();
            this.listaStatus = new System.Windows.Forms.ListBox();
            this.listaProduto = new System.Windows.Forms.ListBox();
            this.btn_filtro = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lbl_produto = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_selecionados = new System.Windows.Forms.Label();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.lbl_fundo = new System.Windows.Forms.Label();
            this.listaTodos = new System.Windows.Forms.TextBox();
            Label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Filtrados)).BeginInit();
            this.FlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label14
            // 
            Label14.BackColor = System.Drawing.Color.Red;
            Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label14.ForeColor = System.Drawing.Color.White;
            Label14.Location = new System.Drawing.Point(3, 0);
            Label14.Name = "Label14";
            Label14.Size = new System.Drawing.Size(867, 18);
            Label14.TabIndex = 21;
            Label14.Text = "Selecionados";
            Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_valor
            // 
            this.btn_valor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_valor.Location = new System.Drawing.Point(542, 240);
            this.btn_valor.Name = "btn_valor";
            this.btn_valor.Size = new System.Drawing.Size(169, 29);
            this.btn_valor.TabIndex = 66;
            this.btn_valor.Text = "&Alterar Valor";
            this.btn_valor.UseVisualStyleBackColor = true;
            this.btn_valor.Click += new System.EventHandler(this.btn_valor_Click);
            // 
            // btn_filtro_2
            // 
            this.btn_filtro_2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filtro_2.Location = new System.Drawing.Point(717, 240);
            this.btn_filtro_2.Name = "btn_filtro_2";
            this.btn_filtro_2.Size = new System.Drawing.Size(169, 29);
            this.btn_filtro_2.TabIndex = 63;
            this.btn_filtro_2.Text = "&Imprimir";
            this.btn_filtro_2.UseVisualStyleBackColor = true;
            this.btn_filtro_2.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // txt_pedido
            // 
            this.txt_pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_pedido.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pedido.Location = new System.Drawing.Point(374, 241);
            this.txt_pedido.Name = "txt_pedido";
            this.txt_pedido.Size = new System.Drawing.Size(162, 27);
            this.txt_pedido.TabIndex = 62;
            this.txt_pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_pedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pedido_KeyPress);
            // 
            // lbl_pedido
            // 
            this.lbl_pedido.AutoSize = true;
            this.lbl_pedido.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_pedido.Location = new System.Drawing.Point(323, 247);
            this.lbl_pedido.Name = "lbl_pedido";
            this.lbl_pedido.Size = new System.Drawing.Size(40, 13);
            this.lbl_pedido.TabIndex = 61;
            this.lbl_pedido.Text = "Pedido";
            // 
            // lbl_motivos
            // 
            this.lbl_motivos.AutoSize = true;
            this.lbl_motivos.BackColor = System.Drawing.Color.Transparent;
            this.lbl_motivos.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motivos.Location = new System.Drawing.Point(323, 208);
            this.lbl_motivos.Name = "lbl_motivos";
            this.lbl_motivos.Size = new System.Drawing.Size(50, 13);
            this.lbl_motivos.TabIndex = 60;
            this.lbl_motivos.Text = "Motivos";
            // 
            // cb_motivos
            // 
            this.cb_motivos.DisplayMember = "cd_bloqueio";
            this.cb_motivos.FormattingEnabled = true;
            this.cb_motivos.Location = new System.Drawing.Point(374, 205);
            this.cb_motivos.Name = "cb_motivos";
            this.cb_motivos.Size = new System.Drawing.Size(225, 21);
            this.cb_motivos.TabIndex = 59;
            // 
            // dg_Filtrados
            // 
            this.dg_Filtrados.AllowUserToAddRows = false;
            this.dg_Filtrados.AllowUserToDeleteRows = false;
            this.dg_Filtrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Filtrados.Location = new System.Drawing.Point(12, 281);
            this.dg_Filtrados.Name = "dg_Filtrados";
            this.dg_Filtrados.ReadOnly = true;
            this.dg_Filtrados.Size = new System.Drawing.Size(880, 190);
            this.dg_Filtrados.TabIndex = 58;
            this.dg_Filtrados.DoubleClick += new System.EventHandler(this.dg_Filtrados_DoubleClick);
            this.dg_Filtrados.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dg_Filtrados_MouseUp);
            // 
            // btn_bloquear
            // 
            this.btn_bloquear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bloquear.Location = new System.Drawing.Point(612, 195);
            this.btn_bloquear.Name = "btn_bloquear";
            this.btn_bloquear.Size = new System.Drawing.Size(275, 31);
            this.btn_bloquear.TabIndex = 57;
            this.btn_bloquear.Text = "&Bloquear";
            this.btn_bloquear.UseVisualStyleBackColor = true;
            this.btn_bloquear.Click += new System.EventHandler(this.btn_bloquear_Click);
            // 
            // btn_exportar
            // 
            this.btn_exportar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportar.Location = new System.Drawing.Point(13, 238);
            this.btn_exportar.Name = "btn_exportar";
            this.btn_exportar.Size = new System.Drawing.Size(304, 31);
            this.btn_exportar.TabIndex = 56;
            this.btn_exportar.Text = "&Exportar";
            this.btn_exportar.UseVisualStyleBackColor = true;
            this.btn_exportar.Click += new System.EventHandler(this.btn_exportar_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(477, 605);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(158, 33);
            this.Button1.TabIndex = 55;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // listaValor
            // 
            this.listaValor.FormattingEnabled = true;
            this.listaValor.Location = new System.Drawing.Point(612, 82);
            this.listaValor.Name = "listaValor";
            this.listaValor.Size = new System.Drawing.Size(278, 56);
            this.listaValor.TabIndex = 54;
            this.listaValor.SelectedIndexChanged += new System.EventHandler(this.listaValor_SelectedIndexChanged);
            // 
            // listaStatus
            // 
            this.listaStatus.FormattingEnabled = true;
            this.listaStatus.Location = new System.Drawing.Point(313, 82);
            this.listaStatus.Name = "listaStatus";
            this.listaStatus.Size = new System.Drawing.Size(278, 56);
            this.listaStatus.TabIndex = 53;
            this.listaStatus.SelectedIndexChanged += new System.EventHandler(this.listaStatus_SelectedIndexChanged);
            // 
            // listaProduto
            // 
            this.listaProduto.FormattingEnabled = true;
            this.listaProduto.Location = new System.Drawing.Point(13, 82);
            this.listaProduto.Name = "listaProduto";
            this.listaProduto.Size = new System.Drawing.Size(278, 56);
            this.listaProduto.TabIndex = 52;
            this.listaProduto.SelectedIndexChanged += new System.EventHandler(this.listaProduto_SelectedIndexChanged);
            // 
            // btn_filtro
            // 
            this.btn_filtro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filtro.Location = new System.Drawing.Point(13, 197);
            this.btn_filtro.Name = "btn_filtro";
            this.btn_filtro.Size = new System.Drawing.Size(304, 31);
            this.btn_filtro.TabIndex = 51;
            this.btn_filtro.Text = "&Filtrar";
            this.btn_filtro.UseVisualStyleBackColor = true;
            this.btn_filtro.Click += new System.EventHandler(this.btn_filtro_Click);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(608, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(278, 18);
            this.Label2.TabIndex = 50;
            this.Label2.Text = "Valor";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(314, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(281, 18);
            this.Label1.TabIndex = 49;
            this.Label1.Text = "Status";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_produto
            // 
            this.lbl_produto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_produto.Location = new System.Drawing.Point(11, 38);
            this.lbl_produto.Name = "lbl_produto";
            this.lbl_produto.Size = new System.Drawing.Size(281, 18);
            this.lbl_produto.TabIndex = 48;
            this.lbl_produto.Text = "Produto";
            this.lbl_produto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanel1.Controls.Add(Label14);
            this.FlowLayoutPanel1.Controls.Add(this.lbl_selecionados);
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(13, 146);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(877, 43);
            this.FlowLayoutPanel1.TabIndex = 47;
            // 
            // lbl_selecionados
            // 
            this.lbl_selecionados.BackColor = System.Drawing.Color.White;
            this.lbl_selecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_selecionados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecionados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_selecionados.Location = new System.Drawing.Point(3, 18);
            this.lbl_selecionados.Name = "lbl_selecionados";
            this.lbl_selecionados.Size = new System.Drawing.Size(869, 19);
            this.lbl_selecionados.TabIndex = 22;
            this.lbl_selecionados.Text = "0000000";
            this.lbl_selecionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_titulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_titulo.Font = new System.Drawing.Font("Verdana", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(20, 7);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(873, 36);
            this.lbl_titulo.TabIndex = 46;
            this.lbl_titulo.Text = "Remessa";
            this.lbl_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_fundo
            // 
            this.lbl_fundo.Location = new System.Drawing.Point(9, 194);
            this.lbl_fundo.Name = "lbl_fundo";
            this.lbl_fundo.Size = new System.Drawing.Size(881, 84);
            this.lbl_fundo.TabIndex = 64;
            // 
            // listaTodos
            // 
            this.listaTodos.BackColor = System.Drawing.Color.White;
            this.listaTodos.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listaTodos.Location = new System.Drawing.Point(13, 60);
            this.listaTodos.Name = "listaTodos";
            this.listaTodos.ReadOnly = true;
            this.listaTodos.Size = new System.Drawing.Size(877, 20);
            this.listaTodos.TabIndex = 67;
            this.listaTodos.Text = "#TODOS#";
            this.listaTodos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.listaTodos.Click += new System.EventHandler(this.listaTodos_Click);
            // 
            // BloqueioBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(905, 489);
            this.Controls.Add(this.listaTodos);
            this.Controls.Add(this.btn_valor);
            this.Controls.Add(this.btn_filtro_2);
            this.Controls.Add(this.txt_pedido);
            this.Controls.Add(this.lbl_pedido);
            this.Controls.Add(this.lbl_motivos);
            this.Controls.Add(this.cb_motivos);
            this.Controls.Add(this.btn_bloquear);
            this.Controls.Add(this.btn_exportar);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.listaValor);
            this.Controls.Add(this.listaStatus);
            this.Controls.Add(this.listaProduto);
            this.Controls.Add(this.btn_filtro);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lbl_produto);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.lbl_fundo);
            this.Controls.Add(this.dg_Filtrados);
            this.Name = "BloqueioBoletos";
            this.Text = "BloqueioBoletos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.BloqueioBoletos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Filtrados)).EndInit();
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_valor;
        internal System.Windows.Forms.Button btn_filtro_2;
        internal System.Windows.Forms.TextBox txt_pedido;
        internal System.Windows.Forms.Label lbl_pedido;
        internal System.Windows.Forms.Label lbl_motivos;
        internal System.Windows.Forms.ComboBox cb_motivos;
        internal System.Windows.Forms.DataGridView dg_Filtrados;
        internal System.Windows.Forms.Button btn_bloquear;
        internal System.Windows.Forms.Button btn_exportar;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.ListBox listaValor;
        internal System.Windows.Forms.ListBox listaStatus;
        internal System.Windows.Forms.ListBox listaProduto;
        internal System.Windows.Forms.Button btn_filtro;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lbl_produto;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Label lbl_selecionados;
        internal System.Windows.Forms.Label lbl_titulo;
        internal System.Windows.Forms.Label lbl_fundo;
        private System.Windows.Forms.TextBox listaTodos;
    }
}