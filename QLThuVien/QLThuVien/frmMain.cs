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
using System.IO;

namespace QLThuVien
{
    public partial class frmMain : Form
    {
        string username, password;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string user, string pass)
        {
            InitializeComponent();
            username = user;
            password = pass;
        }
        // BackUp

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form NV = new frmTTNhanVien();
            NV.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Form login = new frmDangNhap();
                login.ShowDialog();
            }
            else if (dialog == DialogResult.No)
            {
                //
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DMK = new frmDoiMatKhau(username, password);
            DMK.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("xin chào: " + username);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form TL = new frmTheLoai();
            TL.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form DG = new frmDocGia();
            DG.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form GT = new frmGioiThieu();
            GT.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form S = new frmDanhMucSach();
            S.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form Tra = new frmTraSach();
            Tra.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DG = new frmDocGia();
            DG.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form S = new frmDanhMucSach();
            S.ShowDialog();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Muon = new frmMuonSach();
            Muon.ShowDialog();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Tra = new frmTraSach();
            Tra.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form NV = new frmTTNhanVien();
            NV.ShowDialog();
        }

        private void giớiThiệuPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form GT = new frmGioiThieu();
            GT.ShowDialog();
        }

        //BackUp
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\SQLBackup"))
            {
                if (File.Exists(@"c:\SQLBackup\QLTV.bak"))
                {
                    if (MessageBox.Show(@"Bạn có muốn thay thế nó?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\SQLBackup\QLTV.bak");
                    }
                    else
                        bBackUpStatus = false;
                }
            }
            else
                Directory.CreateDirectory(@"c:\SQLBackup");

            if (bBackUpStatus)
            {
                //Connect to DB
                SqlConnection connect;
                string con = @"Data Source=DESKTOP-KA710V7\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
                connect = new SqlConnection(con);
                connect.Open();
                //----------------------------------------------------------------------------------------------------

                //Execute SQL---------------
                SqlCommand command;
                command = new SqlCommand(@"backup database QLThuVien to disk ='c:\SQLBackup\QLTV.bak' with init,stats=10", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("Backup dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Restore
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (File.Exists(@"c:\SQLBackup\QLTV.bak"))
                {
                    if (MessageBox.Show("Bạn có muốn khôi phục?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Connect SQL-----------
                        SqlConnection connect;
                        string con = @"Data Source=DESKTOP-KA710V7\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
                        connect = new SqlConnection(con);
                        connect.Open();
                        //-----------------------------------------------------------------------------------------

                        //Excute SQL----------------
                        SqlCommand command;
                        command = new SqlCommand("use master", connect);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(@"restore database QLThuVien from disk = 'c:\SQLBackup\QLTV.bak'", connect);
                        command.ExecuteNonQuery();
                        //--------------------------------------------------------------------------------------------------------
                        connect.Close();

                        MessageBox.Show("Khôi phục dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show(@"Không thực hiện bất kỳ sự chứng thực ở trên (hoặc không có trong đường dẫn chính xác )", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void thốngKêNhanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form TK = new frmThongKe();
            TK.ShowDialog();
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form NguoiDung = new frmNguoiDung(username, password);
            NguoiDung.ShowDialog();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form Muon = new frmMuonSach();
            Muon.ShowDialog();
        }
    }
}
