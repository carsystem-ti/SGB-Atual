namespace SGB
{
    partial class acertoValores
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
            this.gridClientes = new System.Windows.Forms.DataGridView();
            this.cmdReProcessar = new System.Windows.Forms.Button();
            this.painelLoad = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdLiberar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).BeginInit();
            this.painelLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridClientes
            // 
            this.gridClientes.AllowUserToOrderColumns = true;
            this.gridClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridClientes.Location = new System.Drawing.Point(12, 12);
            this.gridClientes.Name = "gridClientes";
            this.gridClientes.Size = new System.Drawing.Size(1070, 268);
            this.gridClientes.TabIndex = 0;
            this.gridClientes.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridClientes_ColumnHeaderMouseDoubleClick);
            this.gridClientes.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridClientes_CellBeginEdit);
            this.gridClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClientes_CellClick);
            this.gridClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClientes_CellContentClick);
            // 
            // cmdReProcessar
            // 
            this.cmdReProcessar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReProcessar.Location = new System.Drawing.Point(892, 286);
            this.cmdReProcessar.Name = "cmdReProcessar";
            this.cmdReProcessar.Size = new System.Drawing.Size(190, 33);
            this.cmdReProcessar.TabIndex = 1;
            this.cmdReProcessar.Text = "ReProcessar";
            this.cmdReProcessar.UseVisualStyleBackColor = true;
            this.cmdReProcessar.Click += new System.EventHandler(this.cmdReProcessar_Click);
            // 
            // painelLoad
            // 
            this.painelLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.painelLoad.Controls.Add(this.label1);
            this.painelLoad.Controls.Add(this.pictureBox1);
            this.painelLoad.Location = new System.Drawing.Point(432, 335);
            this.painelLoad.Name = "painelLoad";
            this.painelLoad.Size = new System.Drawing.Size(118, 131);
            this.painelLoad.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "CARREGANDO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SGB.Properties.Resources.loading_orange;
            this.pictureBox1.Location = new System.Drawing.Point(21, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 81);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cmdLiberar
            // 
            this.cmdLiberar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLiberar.Location = new System.Drawing.Point(696, 286);
            this.cmdLiberar.Name = "cmdLiberar";
            this.cmdLiberar.Size = new System.Drawing.Size(190, 33);
            this.cmdLiberar.TabIndex = 1;
            this.cmdLiberar.Text = "Liberar Remessa";
            this.cmdLiberar.UseVisualStyleBackColor = true;
            this.cmdLiberar.Click += new System.EventHandler(this.cmdLiberar_Click);
            // 
            // acertoValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 331);
            this.Controls.Add(this.painelLoad);
            this.Controls.Add(this.cmdLiberar);
            this.Controls.Add(this.cmdReProcessar);
            this.Controls.Add(this.gridClientes);
            this.Name = "acertoValores";
            this.Text = "acertoValores";
            this.Load += new System.EventHandler(this.acertoValores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientes)).EndInit();
            this.painelLoad.ResumeLayout(false);
            this.painelLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridClientes;
        private System.Windows.Forms.Button cmdReProcessar;
        private System.Windows.Forms.Panel painelLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdLiberar;
    }
}