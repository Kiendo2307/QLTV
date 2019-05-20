using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        public void Load_TL()
        {
            string str = @"select * from tblTheLoai";
            DataTable dt = Conn.getDataTable(str);
            dataTheLoai.DataSource = dt;
        }
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_TL();
        }

        private void dataTheLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataTheLoai.Rows[e.RowIndex];
                txtMaTL.Text = row.Cells[0].Value.ToString();
                txtTenTL.Text = row.Cells[1].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from tblTheLoai where MaTL='" + txtMaTL.Text + "'";
            if (txtMaTL.Text == "")
                MessageBox.Show("Mã TL không được để trống!!");
            else
            {
                Conn.executeQuery(xoa);
                Load_TL();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string up = @"update tblTheLoai set MaTL='" + txtMaTL.Text + "',TenTL=N'" + txtTenTL.Text + "' where MaTL='" + txtMaTL.Text + "'";
            if (txtMaTL.Text == "")
                MessageBox.Show("Mã TL không được để trống!!");
            else
            {
                Conn.executeQuery(up);
                Load_TL();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            {
                string them = @"insert into tblTheLoai(MaTL,TenTL) values('" + txtMaTL.Text + "',N'" + txtTenTL.Text + "')";
                if (txtMaTL.Text == "")
                    MessageBox.Show("Mã TL không được để trống!!");
                else
                {
                    Conn.executeQuery(them);
                    Load_TL();
                }
            }
        }
    }
}
