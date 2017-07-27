namespace erp_final_insankaynaklari
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CALISANID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BASLANGICTARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIKISTARIHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISADI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALADI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALSOYADI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CALISANID,
            this.BASLANGICTARIHI,
            this.CIKISTARIHI,
            this.ISADI,
            this.CALADI,
            this.CALSOYADI});
            this.dataGridView1.Location = new System.Drawing.Point(32, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(784, 261);
            this.dataGridView1.TabIndex = 1;
            // 
            // CALISANID
            // 
            this.CALISANID.DataPropertyName = "CALISANID";
            this.CALISANID.HeaderText = "CALISAN ID";
            this.CALISANID.Name = "CALISANID";
            this.CALISANID.Visible = false;
            // 
            // BASLANGICTARIHI
            // 
            this.BASLANGICTARIHI.DataPropertyName = "BASLANGICTARIHI";
            this.BASLANGICTARIHI.HeaderText = "BASLANGIC TARIHI";
            this.BASLANGICTARIHI.Name = "BASLANGICTARIHI";
            this.BASLANGICTARIHI.Width = 141;
            // 
            // CIKISTARIHI
            // 
            this.CIKISTARIHI.DataPropertyName = "CIKISTARIHI";
            this.CIKISTARIHI.HeaderText = "CIKIS TARIHI";
            this.CIKISTARIHI.Name = "CIKISTARIHI";
            this.CIKISTARIHI.Width = 105;
            // 
            // ISADI
            // 
            this.ISADI.DataPropertyName = "ISADI";
            this.ISADI.HeaderText = "POZISYON ADI";
            this.ISADI.Name = "ISADI";
            this.ISADI.Width = 115;
            // 
            // CALADI
            // 
            this.CALADI.DataPropertyName = "CALADI";
            this.CALADI.HeaderText = "PERSONEL ADI";
            this.CALADI.Name = "CALADI";
            this.CALADI.Width = 121;
            // 
            // CALSOYADI
            // 
            this.CALSOYADI.DataPropertyName = "CALSOYADI";
            this.CALSOYADI.HeaderText = "PERSONEL SOYADI";
            this.CALSOYADI.Name = "CALSOYADI";
            this.CALSOYADI.Width = 145;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(54, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 41);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(857, 429);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form9";
            this.Text = "Calisma Gecmisi";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALISANID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BASLANGICTARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIKISTARIHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISADI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALADI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALSOYADI;
    }
}