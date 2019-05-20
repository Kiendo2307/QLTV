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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnTruyVab_Click(object sender, EventArgs e)
        {
            string currTime = DateTime.Now.Date.ToShortDateString();
            if (Convert.ToString(listBox1.SelectedItem)== "Báo cáo tên 10 đầu sách được mượn nhiều nhất.")
            {
                string str = @"SELECT TOP(10) MaSach,TenSach,TacGia,NhaXuatBan,SoLanMuon FROM tblSach ORDER BY SoLanMuon DESC;";
                DataTable dt = Conn.getDataTable(str);
                dataHienThi.DataSource = dt;
            }
            //
            if (Convert.ToString(listBox1.SelectedItem) == "Danh mục sách không được mượn lần nào.")
            {
                string str = @"SELECT MaSach,TenSach,TacGia,NhaXuatBan,SoLanMuon FROM tblSach where SoLanMuon=0";
                DataTable dt = Conn.getDataTable(str);
                dataHienThi.DataSource = dt;
            }
            //
            if (Convert.ToString(listBox1.SelectedItem) == "Danh mục sách đang được mượn.")
            {
                string str = @"select MaSach,TenSach,TacGia,NhaXuatBan from tblSach where MaSach=(select MaSach from tblChiTietMuon where tblChiTietMuon.MaSach=tblSach.MaSach)";
                DataTable dt = Conn.getDataTable(str);
                dataHienThi.DataSource = dt;
                //MessageBox.Show(DateTime.Now.Date.ToShortDateString());
            }
            //
            if (Convert.ToString(listBox1.SelectedItem) == "Danh mục sách đã quá hạn trả.")
            {
                string str = @"SELECT MaSach,TenSach,TacGia,NhaXuatBan from tblSach where MaSach=(select MaSach from tblChiTietMuon where NgayTra <'"+currTime+"')";
                DataTable dt = Conn.getDataTable(str);
                dataHienThi.DataSource = dt;
            }
            if (Convert.ToString(listBox1.SelectedItem) == "Danh sách sinh viên bị phạt vì trả quá hạn.")
            {
                string str = @"select * from tblDocGia where MaDG=(select MaDG from tblHoaDonMuon,tblChiTietMuon where tblHoaDonMuon.MaPM=tblChiTietMuon.MaPM and tblChiTietMuon.NgayTra<'" + currTime + "')";
                DataTable dt = Conn.getDataTable(str);
                dataHienThi.DataSource = dt;
            }

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
