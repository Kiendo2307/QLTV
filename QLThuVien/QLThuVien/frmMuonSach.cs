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
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }
        public void Load_TL()
        {
            string str = @"select MaTL,TenTL from tblTheLoai";
            DataTable dt = Conn.getDataTable(str);
            dataTL.DataSource = dt;
        }
        public void Load_Sach()
        {
            string str = @"select TenSach,TacGia,NhaXuatBan from tblSach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from tblDocGia";
            cboxMaDG.DisplayMember = "MaDG";
            cboxMaDG.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
            Load_TL();
            Load_Sach();
            //txtMaPM.Text = "PM00";
            //
        }

        private void txtTimTL_TextChanged(object sender, EventArgs e)
        {
            string str = @"select MaTL,TenTL from tblTheLoai where TenTL LIKE N'%"+txtTimTL.Text+"%'";
            DataTable dt = Conn.getDataTable(str);
            dataTL.DataSource = dt;
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            string str = @"select TenSach,TacGia,NhaXuatBan from tblSach where TenSach LIKE N'%"+txtTimSach.Text+"%'";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void dataTL_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataTL.Rows[e.RowIndex];
                txtChonMaTL.Text = row.Cells[0].Value.ToString();
            }
            catch (Exception)
            { }
            string sach = @"select TenSach,TacGia,NhaXuatBan from tblSach where MaTL='" + txtChonMaTL.Text + "'";
            DataTable dt = Conn.getDataTable(sach);
            dataSach.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);

        }
        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (txtMaPM.Text == "")
                MessageBox.Show("Mã Phiếu mượn không được trống!!");
            else
            {
                string muon = @"insert into tblHoaDonMuon(MaPM,MaDG,TinhTrang) values('" + txtMaPM.Text + "','" + cboxMaDG.Text + "',0)"; // 0 chưa trả
                //MessageBox.Show(muon);
                Conn.executeQuery(muon);

                //
                // Thêm vào CT Mượn
                foreach (var listBoxItem in listBox1.Items)
                {
                    //MessageBox.Show(listBoxItem.ToString());
                    string ctMuon = @"insert into tblChiTietMuon(MaPM,MaSach,NgayThue,NgayTra) values('" + txtMaPM.Text + "',(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "'),'" + dateNgayMuon.Text + "','" + dateNgayTra.Text + "')";
                    string upTontai = @"update tblSach set TonTai=(TonTai-1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    string upSLMuon = @"update tblSach set SoLanMuon=(SoLanMuon+1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    Conn.executeQuery(ctMuon);
                    Conn.executeQuery(upTontai);
                    Conn.executeQuery(upSLMuon);
                }
            }
                MessageBox.Show("Mượn thành công!!");
                listBox1.Items.Clear();
            
            //
        }

        private void txtMaPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }
    }
}
