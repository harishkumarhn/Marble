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
    public partial class InventoryLogin : Form
    {

        public static User loggedInUser;
        public bool isLoginSuccess = false;
        public InventoryLogin()
        {
            InitializeComponent();
            txtPassword.KeyPress += TxtPassword_KeyPress;
        }
        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
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

                LogedInUser.Id = userAdaptr.Id;
                LogedInUser.LoginId = userAdaptr.LoginId;
                LogedInUser.Name = userAdaptr.Name;
                LogedInUser.RoleId = userAdaptr.RoleId;
                //loggedInUser = userAdaptr;
                isLoginSuccess = true;
                
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password is invalid");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
