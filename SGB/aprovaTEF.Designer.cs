namespace SGB
{
    partial class aprovaTEF
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
            this.dgvDebitos = new System.Windows.Forms.DataGridView();
            this.mcInicio = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.txtFim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebitos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDebitos
            // 
            this.dgvDebitos.AllowUserToAddRows = false;
            this.dgvDebitos.AllowUserToDeleteRows = false;
            this.dgvDebitos.AllowUserToOrderColumns = true;
            this.dgvDebitos.AllowUserToResizeColumns = false;
            this.dgvDebitos.AllowUserToResizeRows = false;
            this.dgvDebitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebitos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDebitos.Location = new System.Drawing.Point(12, 12);
            this.dgvDebitos.Name = "dgvDebitos";
            this.dgvDebitos.Size = new System.Drawing.Size(703, 407);
            this.dgvDebitos.TabIndex = 0;
            this.dgvDebitos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDebitos_CellContentClick);
            // 
            // mcInicio
            // 
            this.mcInicio.Location = new System.Drawing.Point(383, 434);
            this.mcInicio.MaxSelectionCount = 1;
            this.mcInicio.Name = "mcInicio";
            this.mcInicio.ShowToday = false;
            this.mcInicio.TabIndex = 3;
            this.mcInicio.Visible = false;
            this.mcInicio.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcInicio_DateChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(703, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Processar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 592);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Início:";
            this.label1.Visible = false;
            // 
            // txtInicio
            // 
            this.txtInicio.BackColor = System.Drawing.Color.White;
            this.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInicio.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(383, 608);
            this.txtInicio.MaxLength = 8;
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.ReadOnly = true;
            this.txtInicio.Size = new System.Drawing.Size(107, 26);
            this.txtInicio.TabIndex = 5;
            this.txtInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInicio.Visible = false;
            // 
            // txtFim
            // 
            this.txtFim.BackColor = System.Drawing.Color.White;
            this.txtFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFim.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Location = new System.Drawing.Point(503, 608);
            this.txtFim.MaxLength = 8;
            this.txtFim.Name = "txtFim";
            this.txtFim.ReadOnly = true;
            this.txtFim.Size = new System.Drawing.Size(107, 26);
            this.txtFim.TabIndex = 5;
            this.txtFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFim.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(500, 592);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fim:";
            this.label2.Visible = false;
            // 
            // aprovaTEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 431);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFim);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mcInicio);
            this.Controls.Add(this.dgvDebitos);
            this.Name = "aprovaTEF";
            this.Text = "DÉBITO AUTOMÁTICO";
            this.Load += new System.EventHandler(this.aprovaTEF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebitos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDebitos;
        private System.Windows.Forms.MonthCalendar mcInicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.TextBox txtFim;
        private System.Windows.Forms.Label label2;
    }
}