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
    public partial class frmDanhMucSach : Form
    {
        public frmDanhMucSach()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            string str = @"select * from tblSach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from tblTheLoai";
            cboxMaTL.DisplayMember = "MaTL";
            cboxMaTL.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
            Load_Data();
        }

        private void dataSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells[0].Value.ToString();
                cboxMaTL.Text = row.Cells[1].Value.ToString();
                txtTenSach.Text = row.Cells[2].Value.ToString();
                txtTacGia.Text = row.Cells[3].Value.ToString();
                txtNhaXB.Text = row.Cells[4].Value.ToString();
                dateNgayMua.Text = row.Cells[5].Value.ToString();
                txtTonTai.Text = row.Cells[6].Value.ToString();
                txtSoLanMuon.Text = row.Cells[7].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            cboxMaTL.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            txtNhaXB.Text = "";
            dateNgayMua.Text = "1/1/2016";
            txtTonTai.Text = "";
            txtSoLanMuon.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from tblSach where MaSach='" + txtMaSach.Text + "'";
            if (txtMaSach.Text == "")
                MessageBox.Show("Mã sách không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa sách :" + txtTenSach.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
                        MessageBox.Show("Xóa thành công!!");
                        Load_Data();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    //
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string capnhat = @"update tblSach set MaSach='" + txtMaSach.Text + "',MaTL='" + cboxMaTL.Text + "',TenSach=N'" + txtTenSach.Text + "',TacGia=N'" + txtTacGia.Text + "',NhaXuatBan=N'" + txtNhaXB.Text + "',NgayMuaSach='" + dateNgayMua.Text + "',TonTai='"+txtTonTai.Text+"',SoLanMuon='"+txtSoLanMuon.Text+"' where MaSach='" + txtMaSach.Text + "'";
            Conn.executeQuery(capnhat);
            MessageBox.Show("Cập nhật thành công!!");
            Load_Data();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string them = @"insert into tblSach(MaSach,MaTL,TenSach,TacGia,NhaXuatBan,NgayMuaSach,TonTai,SoLanMuon) values ('" + txtMaSach.Text + "','" + cboxMaTL.Text + "',N'" + txtTenSach.Text + "',N'" + txtTacGia.Text + "',N'" + txtNhaXB.Text + "','" + dateNgayMua.Text + "','" + txtTonTai.Text + "','" + txtSoLanMuon.Text + "')";
            Conn.executeQuery(them);
            MessageBox.Show("Thêm sách thành công!!");
            Load_Data();
        }

        private void txtTonTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from tblSach where MaSach LIKE N'%"+txtTimKiem.Text+"%' or TenSach LIKE N'%"+txtTimKiem.Text+ "%' or TacGia LIKE N'%" + txtTimKiem.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
    }
}
