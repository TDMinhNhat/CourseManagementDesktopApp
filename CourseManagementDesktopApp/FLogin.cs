using CourseManagementDesktopApp.Properties;
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

        }

        private void BtnExitClicked(object sender, EventArgs e)
        {

        }
    }
}
