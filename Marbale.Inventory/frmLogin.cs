using Marbale.BusinessObject.SiteSetup;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory
{
    public partial class frmLogin : Form
    {

        public static User loggedInUser;
        public bool isLoginSuccess = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.txtUsername.TextValue = "marbale";
            this.txtPassword.TextValue = "marbale";

            string username = txtUsername.TextValue;
            string password = txtPassword.TextValue;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please Enter Username");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please Enter Password");
                return;
            }

            SiteSetupBL siteSetupBL = new SiteSetupBL();
            User userAdaptr = siteSetupBL.GetUser(username, password);
            if (userAdaptr != null && userAdaptr.Id > 0)
            {
                loggedInUser = userAdaptr;
                isLoginSuccess = true;

                MainForm frmMain = new MainForm();
                this.Hide();
                frmMain.Show();
                //Application.Run(new MarblePOS());
            }
            else
            {
                MessageBox.Show("Username or Password is invalid");
            }
        }
    }
}
