﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AdminOperations a = new AdminOperations();
            bool LoginStatusAdmin = a.LoginAdmin(txtLoginId.Text,txtPassword.Text);
            if (LoginStatusAdmin == true)
            {

            }
            else
            {
                MessageBox.Show("UserName and pAssword is wrong");
            }
        }
    }
}