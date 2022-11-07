namespace geracaoRemessa.Formulario
{
    partial class InformacoesRemessa
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
            this.btn_etiqueta = new System.Windows.Forms.Button();
            this.comboEmpresa = new System.Windows.Forms.ComboBox();
            this.lblTituloRemessas = new System.Windows.Forms.Label();
            this.btnCriaRemessa = new System.Windows.Forms.Button();
            this.tvInformacoesRemessa = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btn_etiqueta
            // 
            this.btn_etiqueta.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_etiqueta.Location = new System.Drawing.Point(10, 261);
            this.btn_etiqueta.Name = "btn_etiqueta";
            this.btn_etiqueta.Size = new System.Drawing.Size(283, 30);
            this.btn_etiqueta.TabIndex = 11;
            this.btn_etiqueta.Text = "&Etiquetas";
            this.btn_etiqueta.UseVisualStyleBackColor = true;
            // 
            // comboEmpresa
            // 
            this.comboEmpresa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEmpresa.FormattingEnabled = true;
            this.comboEmpresa.Items.AddRange(new object[] {
            "CarSystem",
            "SatNet"});
            this.comboEmpresa.Location = new System.Drawing.Point(439, 14);
            this.comboEmpresa.Name = "comboEmpresa";
            this.comboEmpresa.Size = new System.Drawing.Size(121, 21);
            this.comboEmpresa.TabIndex = 10;
            this.comboEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            // 
            // lblTituloRemessas
            // 
            this.lblTituloRemessas.AutoSize = true;
            this.lblTituloRemessas.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRemessas.Location = new System.Drawing.Point(181, 4);
            this.lblTituloRemessas.Name = "lblTituloRemessas";
            this.lblTituloRemessas.Size = new System.Drawing.Size(211, 23);
            this.lblTituloRemessas.TabIndex = 9;
            this.lblTituloRemessas.Text = "Selecione a Remessa";
            // 
            // btnCriaRemessa
            // 
            this.btnCriaRemessa.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriaRemessa.Location = new System.Drawing.Point(299, 261);
            this.btnCriaRemessa.Name = "btnCriaRemessa";
            this.btnCriaRemessa.Size = new System.Drawing.Size(261, 30);
            this.btnCriaRemessa.TabIndex = 8;
            this.btnCriaRemessa.Text = "&Nova Remessa";
            this.btnCriaRemessa.UseVisualStyleBackColor = true;
            this.btnCriaRemessa.Click += new System.EventHandler(this.btnCriaRemessa_Click);
            // 
            // tvInformacoesRemessa
            // 
            this.tvInformacoesRemessa.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvInformacoesRemessa.Location = new System.Drawing.Point(12, 41);
            this.tvInformacoesRemessa.Name = "tvInformacoesRemessa";
            this.tvInformacoesRemessa.Size = new System.Drawing.Size(548, 214);
            this.tvInformacoesRemessa.TabIndex = 7;
            this.tvInformacoesRemessa.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvInformacoesRemessa_AfterSelect);
            this.tvInformacoesRemessa.DoubleClick += new System.EventHandler(this.tvInformacoesRemessa_doubleClick);
            // 
            // InformacoesRemessa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(571, 303);
            this.Controls.Add(this.btn_etiqueta);
            this.Controls.Add(this.comboEmpresa);
            this.Controls.Add(this.lblTituloRemessas);
            this.Controls.Add(this.btnCriaRemessa);
            this.Controls.Add(this.tvInformacoesRemessa);
            this.Name = "InformacoesRemessa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformacoesRemessa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InformacoesRemessa_FormClosed);
            this.Load += new System.EventHandler(this.comboEmpresa_SelectedIndexChanged);
            this.Click += new System.EventHandler(this.InformacoesRemessa_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_etiqueta;
        internal System.Windows.Forms.ComboBox comboEmpresa;
        internal System.Windows.Forms.Label lblTituloRemessas;
        internal System.Windows.Forms.Button btnCriaRemessa;
        internal System.Windows.Forms.TreeView tvInformacoesRemessa;
    }
}