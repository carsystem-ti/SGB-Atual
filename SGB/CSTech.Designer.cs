namespace SGB
{
    partial class CSTech
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            this.textPesquisa = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botaoPesquisar = new System.Windows.Forms.Button();
            this.comboPesquisa = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdEnviar = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.treeEmpresa = new System.Windows.Forms.TreeView();
            this.gridDebitos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textDemonstrativo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDebitos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.Color.White;
            label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(19, 9);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 19);
            label6.TabIndex = 76;
            label6.Text = "Pesquisa";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.White;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(540, 544);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 19);
            label1.TabIndex = 76;
            label1.Text = "Email";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.White;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(19, 544);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(114, 19);
            label2.TabIndex = 76;
            label2.Text = "Demonstrativo";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textPesquisa
            // 
            this.textPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPesquisa.Location = new System.Drawing.Point(29, 29);
            this.textPesquisa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textPesquisa.Name = "textPesquisa";
            this.textPesquisa.Size = new System.Drawing.Size(172, 20);
            this.textPesquisa.TabIndex = 73;
            this.textPesquisa.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.botaoPesquisar);
            this.panel1.Controls.Add(this.comboPesquisa);
            this.panel1.Controls.Add(this.textPesquisa);
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 135);
            this.panel1.TabIndex = 75;
            // 
            // botaoPesquisar
            // 
            this.botaoPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.botaoPesquisar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoPesquisar.Location = new System.Drawing.Point(29, 84);
            this.botaoPesquisar.Name = "botaoPesquisar";
            this.botaoPesquisar.Size = new System.Drawing.Size(172, 21);
            this.botaoPesquisar.TabIndex = 75;
            this.botaoPesquisar.Text = "Pesquisar";
            this.botaoPesquisar.UseVisualStyleBackColor = true;
            this.botaoPesquisar.Click += new System.EventHandler(this.botaoPesquisar_Click);
            // 
            // comboPesquisa
            // 
            this.comboPesquisa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPesquisa.FormattingEnabled = true;
            this.comboPesquisa.Location = new System.Drawing.Point(29, 57);
            this.comboPesquisa.Name = "comboPesquisa";
            this.comboPesquisa.Size = new System.Drawing.Size(172, 21);
            this.comboPesquisa.TabIndex = 74;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdEnviar);
            this.panel2.Controls.Add(this.textEmail);
            this.panel2.Location = new System.Drawing.Point(533, 555);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 79);
            this.panel2.TabIndex = 75;
            // 
            // cmdEnviar
            // 
            this.cmdEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEnviar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnviar.Location = new System.Drawing.Point(145, 47);
            this.cmdEnviar.Name = "cmdEnviar";
            this.cmdEnviar.Size = new System.Drawing.Size(120, 21);
            this.cmdEnviar.TabIndex = 75;
            this.cmdEnviar.Text = "Enviar";
            this.cmdEnviar.UseVisualStyleBackColor = true;
            this.cmdEnviar.Click += new System.EventHandler(this.cmdEnviar_Click);
            // 
            // textEmail
            // 
            this.textEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEmail.Location = new System.Drawing.Point(6, 21);
            this.textEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(259, 20);
            this.textEmail.TabIndex = 73;
            this.textEmail.TabStop = false;
            // 
            // treeEmpresa
            // 
            this.treeEmpresa.Location = new System.Drawing.Point(254, 20);
            this.treeEmpresa.Name = "treeEmpresa";
            this.treeEmpresa.Size = new System.Drawing.Size(682, 135);
            this.treeEmpresa.TabIndex = 78;
            this.treeEmpresa.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeEmpresa_BeforeExpand);
            this.treeEmpresa.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeEmpresa_NodeMouseClick);
            // 
            // gridDebitos
            // 
            this.gridDebitos.AllowUserToAddRows = false;
            this.gridDebitos.AllowUserToDeleteRows = false;
            this.gridDebitos.AllowUserToResizeRows = false;
            this.gridDebitos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridDebitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDebitos.Location = new System.Drawing.Point(12, 166);
            this.gridDebitos.MultiSelect = false;
            this.gridDebitos.Name = "gridDebitos";
            this.gridDebitos.Size = new System.Drawing.Size(924, 368);
            this.gridDebitos.TabIndex = 79;
            this.gridDebitos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDebitos_CellValueChanged);
            this.gridDebitos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridDebitos_CellBeginEdit);
            this.gridDebitos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDebitos_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textDemonstrativo);
            this.panel3.Location = new System.Drawing.Point(12, 555);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 79);
            this.panel3.TabIndex = 75;
            // 
            // textDemonstrativo
            // 
            this.textDemonstrativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDemonstrativo.Location = new System.Drawing.Point(4, 10);
            this.textDemonstrativo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textDemonstrativo.Multiline = true;
            this.textDemonstrativo.Name = "textDemonstrativo";
            this.textDemonstrativo.Size = new System.Drawing.Size(505, 64);
            this.textDemonstrativo.TabIndex = 73;
            this.textDemonstrativo.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(816, 555);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(122, 79);
            this.panel4.TabIndex = 75;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(18, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 75;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cmdEnviar_Click);
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.White;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(823, 544);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 19);
            label3.TabIndex = 76;
            label3.Text = "Impressão";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CSTech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 646);
            this.Controls.Add(this.treeEmpresa);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(label6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridDebitos);
            this.Name = "CSTech";
            this.Text = "CSTech";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDebitos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textPesquisa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button botaoPesquisar;
        private System.Windows.Forms.ComboBox comboPesquisa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdEnviar;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TreeView treeEmpresa;
        private System.Windows.Forms.DataGridView gridDebitos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textDemonstrativo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
    }
}