using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLThuVien
{
    public partial class frmTraSach : Form
    {
        public frmTraSach()
        {
            InitializeComponent();
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from tblDocGia";
            cboxMaDG.DisplayMember = "MaDG";
            cboxMaDG.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        public void Load_Sach()
        {
            string str = @"select MaSach,TenSach from tblSach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_Muon()
        {
            //string Muon = @"select MaSach,TenSach from tblSach where MaSach=(select MaSach from tblChiTietMuon where tblChiTietMuon.MaPM='"+cboxMaPM.Text+"' and tblChiTietMuon.NgayThue='"+cboxNgayMuon.Text+"')";
            string Muon = @"select MaSach,TenSach from tblSach where MaSach=(  select MaSach from tblChiTietMuon where (tblChiTietMuon.MaPM='" + cboxMaPM.Text + "' and tblChiTietMuon.NgayThue='" + cboxNgayMuon.Text + "' and tblSach.MaSach=tblChiTietMuon.MaSach))";
            //MessageBox.Show(Muon);
            DataTable dt = Conn.getDataTable(Muon);
            dataSach.DataSource = dt;
        }
        private void frmTraSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
        }

        private void cboxMaDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcboxSup_ = "select * from tblHoaDonMuon where MaDG='" + cboxMaDG.Text + "'"; // tới đây!!
            cboxMaPM.DisplayMember = "MaPM";
            cboxMaPM.DataSource = Conn.getDataTable(sqlcboxSup_);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Load_Muon();
        }

        private void cboxMaPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcboxSup_ = "select * from tblChiTietMuon where MaPM='" + cboxMaPM.Text + "'"; // tới đây!!
            cboxNgayMuon.DisplayMember = "NgayThue";
            cboxNgayMuon.DataSource = Conn.getDataTable(sqlcboxSup_);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[1].Value.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
        }

        public int Kiemtra()
        {
            int check = 1; // 0--->chưa trả đủ
            int TongSoMuon, TongSoTra;
            TongSoMuon = dataSach.Rows.Count - 1;
            TongSoTra = Int16.Parse(listBox1.Items.Count.ToString());
            if (TongSoMuon > TongSoTra)
            {
                //MessageBox.Show("->> in phiếu mới!!");
                check = 0;
            }
            else
                if (TongSoMuon == TongSoTra)
            {
                //MessageBox.Show("thành công");
                check = 1;
            }
            return check;
        }
        private void btnTra_Click(object sender, EventArgs e)
        {
            if (Kiemtra() == 1)
            {
                string xoaHoaDonMuon = @"update tblHoaDonMuon set TinhTrang=1 where MaPM='" + cboxMaPM.Text + "' and MaDG='" + cboxMaDG.Text + "'";
                //MessageBox.Show(xoaHoaDonMuon);
                Conn.executeQuery(xoaHoaDonMuon);
                //
                foreach (var listBoxItem in listBox1.Items)
                {
                    string tra = @"delete from tblChiTietMuon where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "' and tblChiTietMuon.MaPM='" + cboxMaPM.Text + "' and tblChiTietMuon.NgayThue='" + cboxNgayMuon.Text + "')";
                    string upTontai = @"update tblSach set TonTai=(TonTai+1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    string upSLMuon = @"update tblSach set SoLanMuon=(SoLanMuon-1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    //MessageBox.Show(upTontai);
                    Conn.executeQuery(upTontai);
                    //MessageBox.Show(upSLMuon);
                    Conn.executeQuery(upSLMuon);
                    //MessageBox.Show(tra);
                    Conn.executeQuery(tra);
                }
                MessageBox.Show("Bạn đã trả hết sách thành công!! Bạn có thể mượn ở lần tới.");
                listBox1.Items.Clear();
            }
            else
            {
                string xoaHoaDonMuon = @"update tblHoaDonMuon set TinhTrang=0 where MaPM='" + cboxMaPM.Text + "' and MaDG='" + cboxMaDG.Text + "'";
                //MessageBox.Show(xoaHoaDonMuon);
                Conn.executeQuery(xoaHoaDonMuon);
                foreach (var listBoxItem in listBox1.Items)
                {
                    string tra = @"delete from tblChiTietMuon where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "' and tblChiTietMuon.MaPM='" + cboxMaPM.Text + "' and tblChiTietMuon.NgayThue='" + cboxNgayMuon.Text + "')";
                    string upTontai = @"update tblSach set TonTai=(TonTai+1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    string upSLMuon = @"update tblSach set SoLanMuon=(SoLanMuon-1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    //MessageBox.Show(upTontai);
                    Conn.executeQuery(upTontai);
                    //MessageBox.Show(upSLMuon);
                    Conn.executeQuery(upSLMuon);
                    //MessageBox.Show(tra);
                    Conn.executeQuery(tra);
                }
                MessageBox.Show("Bạn đã trả sách thành công nhưng chưa đủ!!");
                listBox1.Items.Clear();
            }


            //MessageBox.Show("Trả thành công");

        }
    }
}
