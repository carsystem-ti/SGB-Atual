namespace BaixaTitulos
{
    partial class Baixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Baixa));
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.cbBancos = new System.Windows.Forms.ComboBox();
            this.cmdProcessar = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.dgBaixa = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nossoNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBaixadosR = new System.Windows.Forms.Label();
            this.lblBaixadosQ = new System.Windows.Forms.Label();
            this.lblProcessadosR = new System.Windows.Forms.Label();
            this.lblProcessadosQ = new System.Windows.Forms.Label();
            this.lblRecusadosR = new System.Windows.Forms.Label();
            this.lblRecusadosQ = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdResultado = new System.Windows.Forms.Button();
            this.cmdAbrirArquivo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgBaixa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(7, 38);
            this.cbEmpresa.Margin = new System.Windows.Forms.Padding(1);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(132, 22);
            this.cbEmpresa.TabIndex = 10;
            this.cbEmpresa.SelectedValueChanged += new System.EventHandler(this.cbEmpresa_SelectedValueChanged);
            // 
            // cbBancos
            // 
            this.cbBancos.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBancos.FormattingEnabled = true;
            this.cbBancos.Location = new System.Drawing.Point(7, 65);
            this.cbBancos.Margin = new System.Windows.Forms.Padding(1);
            this.cbBancos.Name = "cbBancos";
            this.cbBancos.Size = new System.Drawing.Size(132, 22);
            this.cbBancos.TabIndex = 9;
            this.cbBancos.SelectedIndexChanged += new System.EventHandler(this.cbBancos_SelectedIndexChanged);
            // 
            // cmdProcessar
            // 
            this.cmdProcessar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcessar.Location = new System.Drawing.Point(7, 92);
            this.cmdProcessar.Name = "cmdProcessar";
            this.cmdProcessar.Size = new System.Drawing.Size(130, 26);
            this.cmdProcessar.TabIndex = 11;
            this.cmdProcessar.Text = "&Processar";
            this.cmdProcessar.UseVisualStyleBackColor = true;
            this.cmdProcessar.Click += new System.EventHandler(this.cmdProcessar_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArquivo.Location = new System.Drawing.Point(7, 8);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(688, 22);
            this.txtArquivo.TabIndex = 8;
            this.txtArquivo.DoubleClick += new System.EventHandler(this.txtArquivo_DoubleClick);
            // 
            // dgBaixa
            // 
            this.dgBaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBaixa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.nossoNumero,
            this.valor,
            this.Contrato});
            this.dgBaixa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgBaixa.Location = new System.Drawing.Point(143, 35);
            this.dgBaixa.Name = "dgBaixa";
            this.dgBaixa.Size = new System.Drawing.Size(385, 109);
            this.dgBaixa.TabIndex = 7;
            this.dgBaixa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBaixa_CellContentClick);
            this.dgBaixa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBaixa_CellDoubleClick);
            this.dgBaixa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgBaixa_MouseUp);
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // nossoNumero
            // 
            this.nossoNumero.HeaderText = "NossoNumero";
            this.nossoNumero.Name = "nossoNumero";
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            // 
            // Contrato
            // 
            this.Contrato.HeaderText = "Contrato";
            this.Contrato.Name = "Contrato";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblBaixadosR);
            this.panel1.Controls.Add(this.lblBaixadosQ);
            this.panel1.Controls.Add(this.lblProcessadosR);
            this.panel1.Controls.Add(this.lblProcessadosQ);
            this.panel1.Controls.Add(this.lblRecusadosR);
            this.panel1.Controls.Add(this.lblRecusadosQ);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(534, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 109);
            this.panel1.TabIndex = 6;
            // 
            // lblBaixadosR
            // 
            this.lblBaixadosR.BackColor = System.Drawing.Color.White;
            this.lblBaixadosR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaixadosR.Location = new System.Drawing.Point(104, 19);
            this.lblBaixadosR.Name = "lblBaixadosR";
            this.lblBaixadosR.Size = new System.Drawing.Size(95, 17);
            this.lblBaixadosR.TabIndex = 3;
            this.lblBaixadosR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBaixadosQ
            // 
            this.lblBaixadosQ.BackColor = System.Drawing.Color.White;
            this.lblBaixadosQ.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaixadosQ.Location = new System.Drawing.Point(2, 19);
            this.lblBaixadosQ.Name = "lblBaixadosQ";
            this.lblBaixadosQ.Size = new System.Drawing.Size(95, 17);
            this.lblBaixadosQ.TabIndex = 3;
            this.lblBaixadosQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcessadosR
            // 
            this.lblProcessadosR.BackColor = System.Drawing.Color.White;
            this.lblProcessadosR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessadosR.Location = new System.Drawing.Point(104, 88);
            this.lblProcessadosR.Name = "lblProcessadosR";
            this.lblProcessadosR.Size = new System.Drawing.Size(95, 17);
            this.lblProcessadosR.TabIndex = 3;
            this.lblProcessadosR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcessadosQ
            // 
            this.lblProcessadosQ.BackColor = System.Drawing.Color.White;
            this.lblProcessadosQ.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessadosQ.Location = new System.Drawing.Point(2, 88);
            this.lblProcessadosQ.Name = "lblProcessadosQ";
            this.lblProcessadosQ.Size = new System.Drawing.Size(95, 17);
            this.lblProcessadosQ.TabIndex = 3;
            this.lblProcessadosQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecusadosR
            // 
            this.lblRecusadosR.BackColor = System.Drawing.Color.White;
            this.lblRecusadosR.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecusadosR.Location = new System.Drawing.Point(104, 53);
            this.lblRecusadosR.Name = "lblRecusadosR";
            this.lblRecusadosR.Size = new System.Drawing.Size(95, 17);
            this.lblRecusadosR.TabIndex = 3;
            this.lblRecusadosR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecusadosQ
            // 
            this.lblRecusadosQ.BackColor = System.Drawing.Color.White;
            this.lblRecusadosQ.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecusadosQ.Location = new System.Drawing.Point(2, 53);
            this.lblRecusadosQ.Name = "lblRecusadosQ";
            this.lblRecusadosQ.Size = new System.Drawing.Size(95, 17);
            this.lblRecusadosQ.TabIndex = 3;
            this.lblRecusadosQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(2, 2);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(99, 17);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Baixados";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(101, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "R$";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recusados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "R$";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "R$";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdResultado
            // 
            this.cmdResultado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResultado.Location = new System.Drawing.Point(7, 122);
            this.cmdResultado.Name = "cmdResultado";
            this.cmdResultado.Size = new System.Drawing.Size(130, 26);
            this.cmdResultado.TabIndex = 11;
            this.cmdResultado.Text = "&Resultado";
            this.cmdResultado.UseVisualStyleBackColor = true;
            this.cmdResultado.Click += new System.EventHandler(this.cmdResultado_Click);
            // 
            // cmdAbrirArquivo
            // 
            this.cmdAbrirArquivo.Image = global::SGB.Properties.Resources.Open_FolderPQ;
            this.cmdAbrirArquivo.Location = new System.Drawing.Point(701, 5);
            this.cmdAbrirArquivo.Name = "cmdAbrirArquivo";
            this.cmdAbrirArquivo.Size = new System.Drawing.Size(33, 27);
            this.cmdAbrirArquivo.TabIndex = 12;
            this.cmdAbrirArquivo.UseVisualStyleBackColor = true;
            this.cmdAbrirArquivo.Click += new System.EventHandler(this.txtArquivo_DoubleClick);
            // 
            // Baixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(741, 149);
            this.Controls.Add(this.cmdAbrirArquivo);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.cbBancos);
            this.Controls.Add(this.cmdResultado);
            this.Controls.Add(this.cmdProcessar);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.dgBaixa);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Baixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixa 2012.01.13";
            this.Load += new System.EventHandler(this.Baixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBaixa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.ComboBox cbBancos;
        private System.Windows.Forms.Button cmdProcessar;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.DataGridView dgBaixa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBaixadosR;
        private System.Windows.Forms.Label lblBaixadosQ;
        private System.Windows.Forms.Label lblProcessadosR;
        private System.Windows.Forms.Label lblProcessadosQ;
        private System.Windows.Forms.Label lblRecusadosR;
        private System.Windows.Forms.Label lblRecusadosQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdResultado;
        private System.Windows.Forms.Button cmdAbrirArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn nossoNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrato;
    }
}