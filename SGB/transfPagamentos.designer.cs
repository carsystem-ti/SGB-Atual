namespace tranfereQuitacao
{
    partial class transfPagamentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transfPagamentos));
            this.gridParcelas = new System.Windows.Forms.DataGridView();
            this.cmdTransfer = new System.Windows.Forms.Button();
            this.lvParcelas = new System.Windows.Forms.ListView();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridParcelas
            // 
            this.gridParcelas.AllowUserToResizeColumns = false;
            this.gridParcelas.AllowUserToResizeRows = false;
            this.gridParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridParcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gridParcelas.Location = new System.Drawing.Point(8, 39);
            this.gridParcelas.Name = "gridParcelas";
            this.gridParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridParcelas.Size = new System.Drawing.Size(563, 166);
            this.gridParcelas.TabIndex = 0;
            this.gridParcelas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridParcelas_CellBeginEdit);
            this.gridParcelas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellEndEdit);
            this.gridParcelas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridParcelas_DataError);
            this.gridParcelas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParcelas_CellContentClick);
            // 
            // cmdTransfer
            // 
            this.cmdTransfer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTransfer.Location = new System.Drawing.Point(8, 211);
            this.cmdTransfer.Name = "cmdTransfer";
            this.cmdTransfer.Size = new System.Drawing.Size(563, 34);
            this.cmdTransfer.TabIndex = 1;
            this.cmdTransfer.Text = "Transferir";
            this.cmdTransfer.UseVisualStyleBackColor = true;
            this.cmdTransfer.Click += new System.EventHandler(this.cmdTransfer_Click);
            // 
            // lvParcelas
            // 
            this.lvParcelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvParcelas.FullRowSelect = true;
            this.lvParcelas.GridLines = true;
            this.lvParcelas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvParcelas.Location = new System.Drawing.Point(166, 288);
            this.lvParcelas.MultiSelect = false;
            this.lvParcelas.Name = "lvParcelas";
            this.lvParcelas.Size = new System.Drawing.Size(289, 91);
            this.lvParcelas.TabIndex = 2;
            this.lvParcelas.UseCompatibleStateImageBehavior = false;
            this.lvParcelas.View = System.Windows.Forms.View.Details;
            this.lvParcelas.SelectedIndexChanged += new System.EventHandler(this.lvParcelas_SelectedIndexChanged);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Items.AddRange(new object[] {
            "CarSystem",
            "SatNet"});
            this.cbEmpresa.Location = new System.Drawing.Point(8, 12);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(563, 21);
            this.cbEmpresa.TabIndex = 3;
            this.cbEmpresa.TextChanged += new System.EventHandler(this.cbEmpresa_TextChanged);
            // 
            // transfPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(580, 257);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.lvParcelas);
            this.Controls.Add(this.cmdTransfer);
            this.Controls.Add(this.gridParcelas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "transfPagamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferência de Pagamentos";
            ((System.ComponentModel.ISupportInitialize)(this.gridParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridParcelas;
        private System.Windows.Forms.Button cmdTransfer;
        private System.Windows.Forms.ListView lvParcelas;
        private System.Windows.Forms.ComboBox cbEmpresa;
    }
}