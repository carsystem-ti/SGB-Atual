namespace geracaoRemessa.Formulario
{
    partial class infoCliente
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
            System.Windows.Forms.Label lbl_pedido;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtRenovacao = new System.Windows.Forms.TextBox();
            this.dgDebitos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgRemessa = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUltimoVencimento = new System.Windows.Forms.TextBox();
            lbl_pedido = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRemessa)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPedido
            // 
            this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPedido.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(60, 14);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(162, 27);
            this.txtPedido.TabIndex = 64;
            this.txtPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_pedido
            // 
            lbl_pedido.AutoSize = true;
            lbl_pedido.BackColor = System.Drawing.Color.Transparent;
            lbl_pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            lbl_pedido.Location = new System.Drawing.Point(9, 20);
            lbl_pedido.Name = "lbl_pedido";
            lbl_pedido.Size = new System.Drawing.Size(40, 13);
            lbl_pedido.TabIndex = 63;
            lbl_pedido.Text = "Pedido";
            // 
            // txtProduto
            // 
            this.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduto.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(288, 14);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(162, 27);
            this.txtProduto.TabIndex = 66;
            this.txtProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Location = new System.Drawing.Point(237, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 13);
            label1.TabIndex = 65;
            label1.Text = "Produto";
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(294, 55);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(393, 27);
            this.txtNome.TabIndex = 68;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Location = new System.Drawing.Point(243, 61);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(35, 13);
            label2.TabIndex = 67;
            label2.Text = "Nome";
            // 
            // txtRenovacao
            // 
            this.txtRenovacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRenovacao.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRenovacao.Location = new System.Drawing.Point(524, 14);
            this.txtRenovacao.Name = "txtRenovacao";
            this.txtRenovacao.Size = new System.Drawing.Size(162, 27);
            this.txtRenovacao.TabIndex = 72;
            this.txtRenovacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Location = new System.Drawing.Point(458, 20);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(63, 13);
            label4.TabIndex = 71;
            label4.Text = "Renovação";
            // 
            // dgDebitos
            // 
            this.dgDebitos.AllowUserToAddRows = false;
            this.dgDebitos.AllowUserToDeleteRows = false;
            this.dgDebitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDebitos.Location = new System.Drawing.Point(10, 110);
            this.dgDebitos.Name = "dgDebitos";
            this.dgDebitos.ReadOnly = true;
            this.dgDebitos.Size = new System.Drawing.Size(678, 190);
            this.dgDebitos.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(674, 23);
            this.label3.TabIndex = 75;
            this.label3.Text = "Débitos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgRemessa
            // 
            this.dgRemessa.AllowUserToAddRows = false;
            this.dgRemessa.AllowUserToDeleteRows = false;
            this.dgRemessa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRemessa.Location = new System.Drawing.Point(9, 324);
            this.dgRemessa.Name = "dgRemessa";
            this.dgRemessa.ReadOnly = true;
            this.dgRemessa.Size = new System.Drawing.Size(678, 190);
            this.dgRemessa.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(674, 23);
            this.label5.TabIndex = 77;
            this.label5.Text = "Remessa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtUltimoVencimento
            // 
            this.txtUltimoVencimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUltimoVencimento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimoVencimento.Location = new System.Drawing.Point(72, 55);
            this.txtUltimoVencimento.Name = "txtUltimoVencimento";
            this.txtUltimoVencimento.Size = new System.Drawing.Size(162, 27);
            this.txtUltimoVencimento.TabIndex = 79;
            this.txtUltimoVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label6.Location = new System.Drawing.Point(6, 61);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(67, 13);
            label6.TabIndex = 78;
            label6.Text = "Ultimo Venc.";
            // 
            // infoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(697, 527);
            this.Controls.Add(this.txtUltimoVencimento);
            this.Controls.Add(label6);
            this.Controls.Add(this.dgRemessa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgDebitos);
            this.Controls.Add(this.txtRenovacao);
            this.Controls.Add(label4);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(label2);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(lbl_pedido);
            this.Controls.Add(this.label3);
            this.Name = "infoCliente";
            this.Text = "infoCliente";
            this.Load += new System.EventHandler(this.infoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDebitos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRemessa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPedido;
        internal System.Windows.Forms.TextBox txtProduto;
        internal System.Windows.Forms.TextBox txtNome;
        internal System.Windows.Forms.TextBox txtRenovacao;
        internal System.Windows.Forms.DataGridView dgDebitos;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.DataGridView dgRemessa;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtUltimoVencimento;
    }
}