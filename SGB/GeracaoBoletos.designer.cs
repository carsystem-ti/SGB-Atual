namespace geracaoRemessa.Formulario
{
    partial class geracaoBoletos
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
            System.Windows.Forms.Label Label2;
            System.Windows.Forms.Label Label8;
            System.Windows.Forms.Label Label10;
            this.btn_processar = new System.Windows.Forms.Button();
            this.pb_progresso = new System.Windows.Forms.ProgressBar();
            this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_selecionados = new System.Windows.Forms.Label();
            this.lbl_processados = new System.Windows.Forms.Label();
            this.lbl_eliminados = new System.Windows.Forms.Label();
            this.lbl_gerados = new System.Windows.Forms.Label();
            this.lbl_titulo = new System.Windows.Forms.Label();
            Label14 = new System.Windows.Forms.Label();
            Label2 = new System.Windows.Forms.Label();
            Label8 = new System.Windows.Forms.Label();
            Label10 = new System.Windows.Forms.Label();
            this.FlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label14
            // 
            Label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label14.ForeColor = System.Drawing.Color.White;
            Label14.Location = new System.Drawing.Point(3, 0);
            Label14.Name = "Label14";
            Label14.Size = new System.Drawing.Size(274, 19);
            Label14.TabIndex = 21;
            Label14.Text = "Selecionados";
            Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label2.ForeColor = System.Drawing.Color.White;
            Label2.Location = new System.Drawing.Point(3, 38);
            Label2.Name = "Label2";
            Label2.Size = new System.Drawing.Size(274, 19);
            Label2.TabIndex = 23;
            Label2.Text = "Processados";
            Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            Label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label8.ForeColor = System.Drawing.Color.White;
            Label8.Location = new System.Drawing.Point(3, 76);
            Label8.Name = "Label8";
            Label8.Size = new System.Drawing.Size(274, 19);
            Label8.TabIndex = 25;
            Label8.Text = "Eliminados";
            Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label10
            // 
            Label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Label10.ForeColor = System.Drawing.Color.White;
            Label10.Location = new System.Drawing.Point(3, 114);
            Label10.Name = "Label10";
            Label10.Size = new System.Drawing.Size(274, 19);
            Label10.TabIndex = 27;
            Label10.Text = "Gerados";
            Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_processar
            // 
            this.btn_processar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_processar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_processar.Location = new System.Drawing.Point(10, 213);
            this.btn_processar.Name = "btn_processar";
            this.btn_processar.Size = new System.Drawing.Size(271, 42);
            this.btn_processar.TabIndex = 26;
            this.btn_processar.Text = "&Processar";
            this.btn_processar.UseVisualStyleBackColor = false;
            this.btn_processar.Click += new System.EventHandler(this.btn_processar_Click);
            // 
            // pb_progresso
            // 
            this.pb_progresso.Location = new System.Drawing.Point(3, 188);
            this.pb_progresso.Name = "pb_progresso";
            this.pb_progresso.Size = new System.Drawing.Size(283, 18);
            this.pb_progresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_progresso.TabIndex = 25;
            // 
            // FlowLayoutPanel1
            // 
            this.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanel1.Controls.Add(Label14);
            this.FlowLayoutPanel1.Controls.Add(this.lbl_selecionados);
            this.FlowLayoutPanel1.Controls.Add(Label2);
            this.FlowLayoutPanel1.Controls.Add(this.lbl_processados);
            this.FlowLayoutPanel1.Controls.Add(Label8);
            this.FlowLayoutPanel1.Controls.Add(this.lbl_eliminados);
            this.FlowLayoutPanel1.Controls.Add(Label10);
            this.FlowLayoutPanel1.Controls.Add(this.lbl_gerados);
            this.FlowLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
            this.FlowLayoutPanel1.Size = new System.Drawing.Size(282, 157);
            this.FlowLayoutPanel1.TabIndex = 24;
            // 
            // lbl_selecionados
            // 
            this.lbl_selecionados.BackColor = System.Drawing.Color.White;
            this.lbl_selecionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_selecionados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selecionados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_selecionados.Location = new System.Drawing.Point(3, 19);
            this.lbl_selecionados.Name = "lbl_selecionados";
            this.lbl_selecionados.Size = new System.Drawing.Size(274, 19);
            this.lbl_selecionados.TabIndex = 22;
            this.lbl_selecionados.Text = "0000000";
            this.lbl_selecionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_processados
            // 
            this.lbl_processados.BackColor = System.Drawing.Color.White;
            this.lbl_processados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_processados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_processados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_processados.Location = new System.Drawing.Point(3, 57);
            this.lbl_processados.Name = "lbl_processados";
            this.lbl_processados.Size = new System.Drawing.Size(274, 19);
            this.lbl_processados.TabIndex = 24;
            this.lbl_processados.Text = "0000000";
            this.lbl_processados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_eliminados
            // 
            this.lbl_eliminados.BackColor = System.Drawing.Color.White;
            this.lbl_eliminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_eliminados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_eliminados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_eliminados.Location = new System.Drawing.Point(3, 95);
            this.lbl_eliminados.Name = "lbl_eliminados";
            this.lbl_eliminados.Size = new System.Drawing.Size(274, 19);
            this.lbl_eliminados.TabIndex = 26;
            this.lbl_eliminados.Text = "0000000";
            this.lbl_eliminados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_gerados
            // 
            this.lbl_gerados.BackColor = System.Drawing.Color.White;
            this.lbl_gerados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_gerados.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gerados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_gerados.Location = new System.Drawing.Point(3, 133);
            this.lbl_gerados.Name = "lbl_gerados";
            this.lbl_gerados.Size = new System.Drawing.Size(274, 19);
            this.lbl_gerados.TabIndex = 28;
            this.lbl_gerados.Text = "0000000";
            this.lbl_gerados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_titulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_titulo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(0, 0);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(286, 19);
            this.lbl_titulo.TabIndex = 23;
            this.lbl_titulo.Text = "Remessa";
            this.lbl_titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // geracaoBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(290, 257);
            this.Controls.Add(this.btn_processar);
            this.Controls.Add(this.pb_progresso);
            this.Controls.Add(this.FlowLayoutPanel1);
            this.Controls.Add(this.lbl_titulo);
            this.Name = "geracaoBoletos";
            this.Text = "geracaoBoletos";
            this.Load += new System.EventHandler(this.geracaoBoletos_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.FlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btn_processar;
        internal System.Windows.Forms.ProgressBar pb_progresso;
        internal System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
        internal System.Windows.Forms.Label lbl_selecionados;
        internal System.Windows.Forms.Label lbl_processados;
        internal System.Windows.Forms.Label lbl_eliminados;
        internal System.Windows.Forms.Label lbl_gerados;
        internal System.Windows.Forms.Label lbl_titulo;
    }
}