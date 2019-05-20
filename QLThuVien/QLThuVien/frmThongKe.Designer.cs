namespace QLThuVien
{
    partial class frmThongKe
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
            this.dataHienThi = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnTruyVab = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataHienThi
            // 
            this.dataHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHienThi.Location = new System.Drawing.Point(12, 383);
            this.dataHienThi.Name = "dataHienThi";
            this.dataHienThi.RowTemplate.Height = 24;
            this.dataHienThi.Size = new System.Drawing.Size(630, 338);
            this.dataHienThi.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Items.AddRange(new object[] {
            "Báo cáo tên 10 đầu sách được mượn nhiều nhất.",
            "Danh mục sách không được mượn lần nào.",
            "Danh mục sách đang được mượn.",
            "Danh mục sách đã quá hạn trả.",
            "Danh sách sinh viên bị phạt vì trả quá hạn."});
            this.listBox1.Location = new System.Drawing.Point(13, 64);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(629, 229);
            this.listBox1.TabIndex = 2;
            // 
            // btnTruyVab
            // 
            this.btnTruyVab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruyVab.Location = new System.Drawing.Point(12, 299);
            this.btnTruyVab.Name = "btnTruyVab";
            this.btnTruyVab.Size = new System.Drawing.Size(125, 78);
            this.btnTruyVab.TabIndex = 3;
            this.btnTruyVab.Text = "Truy Vấn";
            this.btnTruyVab.UseVisualStyleBackColor = true;
            this.btnTruyVab.Click += new System.EventHandler(this.btnTruyVab_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(13, 17);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(629, 41);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "TRUY VẤN NHANH";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(654, 733);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.btnTruyVab);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataHienThi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataHienThi;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnTruyVab;
        private System.Windows.Forms.TextBox textBox3;
    }
}