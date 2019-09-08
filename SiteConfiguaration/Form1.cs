using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteConfiguaration
{
    public partial class Form1 : Form
    {
        //configuration data for the local machine
        //Windows registry base key HKEY_LOCAL_MACHINE
        RegistryKey objRegistryKey = Registry.LocalMachine;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_SaveConn_Click(object sender, EventArgs e)
        {
            try
            {
                //now set the new key under the base key
                //argument 1) Name Of The Key (MyConnectionString)
                //         2) Key (TextBox Enter Value)
                //         3) value type (string)
                //now i am use hardcoded key value
                objRegistryKey.SetValue("ConnectionString", txt_ConnectionString.Text, RegistryValueKind.String);
                MessageBox.Show("Key Is Sucessfully Registered");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can Not Store Data In Registry" + ex.Message.ToString());
            }
        }

        private void btn_retrive_Click(object sender, EventArgs e)
        {
            string values = (string)objRegistryKey.GetValue("ConnectionString");
            //display the connection string value in the label
            lblGetConnectionString.Text = values;
        }
    }
}
