using Marbale.Business;
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

namespace Marbale.POS
{
    public partial class FrmLogin : Form
    {
        public static User loggedInUser;
        public bool isLoginSuccess = false;

        public FrmLogin()
        {
            InitializeComponent();
           


            txtPassword.KeyPress += TxtPassword_KeyPress;
           
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            User userAdaptr  = siteSetupBL.GetUser(username, password);
            if (userAdaptr != null && userAdaptr.Id > 0)
            {
                loggedInUser = userAdaptr;
                isLoginSuccess = true;

                 MarblePOS marblePOS = new MarblePOS();
                this.Hide();
                marblePOS.Show();
                //Application.Run(new MarblePOS());
            }
            else
            {
                MessageBox.Show("Username or Password is invalid");
            }
        }

       

    }
}
