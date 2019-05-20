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
    public partial class frmTTNhanVien : Form
    {
        public frmTTNhanVien()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            string str = @"select * from tblTTNhanVien";
            DataTable dt = Conn.getDataTable(str);
            dataNhanVien.DataSource = dt;
        }
        private void frmTTNhanVien_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
            radioNam.Checked = true;
        }

        private void dataNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataNhanVien.Rows[e.RowIndex];
                if (row.Cells[2].Value.ToString() == "0")
                    radioNam.Checked = true;
                else
                    radioNu.Checked = true;
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                dateNgaySinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            dateNgaySinh.Text = "01/01/1990";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from tblTTNhanVien where MaNV='"+txtMaNV.Text+"'";
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa nhân viên:" + txtMaNV.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được trống!!");
            else
            {
                string GioiTinh;
                if (radioNam.Checked == true)
                    GioiTinh = "0"; //Nam
                else
                    GioiTinh = "1"; //Nữ

                string capnhat = @"update tblTTNhanVien set MaNV='" + txtMaNV.Text + "',HoTen=N'" + txtHoTen.Text + "',GioiTinh='" + GioiTinh + "',NgaySinh='" + dateNgaySinh.Text + "',DiaChi=N'" + txtDiaChi.Text + "',DienThoai='" + txtSDT.Text + "' where MaNV='" + txtMaNV.Text + "'";
                Conn.executeQuery(capnhat);
                Load_Data();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
                MessageBox.Show("Mã nhân viên không được trống!!");
            else
            {
                int GioiTinh;
                if (radioNam.Checked == true)
                    GioiTinh = 0; //Nam
                else
                    GioiTinh = 1; //Nữ

                string them = @"insert into tblTTNhanVien(MaNV,HoTen,GioiTinh,NgaySinh,DiaChi,DienThoai) values('" + txtMaNV.Text + "',N'" + txtHoTen.Text + "','" + GioiTinh + "','" + dateNgaySinh.Text + "',N'" + txtDiaChi.Text + "','" + txtSDT.Text + "')";
                Conn.executeQuery(them);
                Load_Data();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from tblTTNhanVien where HoTen LIKE N'%"+txtTimKiem.Text+"%' or MaNV LIKE N'%"+txtTimKiem.Text+"%'";
            DataTable dt = Conn.getDataTable(str);
            dataNhanVien.DataSource = dt;
        }
    }
}
