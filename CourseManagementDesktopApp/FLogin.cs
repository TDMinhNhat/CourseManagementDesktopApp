using CourseManagementDesktopApp.Properties;
using CourseManagementModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManagementDesktopApp
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));

            Bitmap bitmapLogin = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnLogin.Image"))), new Size(45, 45));
            this.btnLogin.Image = (Image)bitmapLogin;
            this.btnLogin.ImageAlign = ContentAlignment.MiddleLeft;            
            
            Bitmap bitmap = new Bitmap(((System.Drawing.Image)(resources.GetObject("btnExit.Image"))), new Size(45, 45));
            this.btnExit.Image = (Image) bitmap;
            this.btnExit.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void BtnLoginClicked(object sender, EventArgs e)
        {
            if(txbAccountName.Text == String.Empty)
            {
                MessageBox.Show("Tên tài khoản không được để trống", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbAccountName.Focus();
                return;
            } else if(txbPassword.Text == String.Empty)
            {
                MessageBox.Show("Mật khẩu không được để trống", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbPassword.Focus();
                return;
            }

            using(CourseManagementEntities entities = new CourseManagementEntities())
            {
                Person target = entities.People.FirstOrDefault(p => p.AccountName.Equals(txbAccountName.Text) && p.Password.Equals(txbPassword.Text));
                if(target is null)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbAccountName.Focus();
                    return;
                } else if(target.Role.Equals("Học Viên") || target.Role.Equals("Giảng Viên"))
                {
                    MessageBox.Show("Phần mềm chỉ chấp nhận các tài khoản thuộc quyền QUẢN LÝ thực hiện", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                niLogin.ShowBalloonTip(5000);
                HideForm(true);
                new FDashBoard().Show();
            }
        }

        private void BtnExitClicked(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void HideForm(bool value)
        {
            if (value)
                Hide();
            else 
                Show();
        }

        private void FCLoginEvent(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
