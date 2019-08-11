using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.KeyGen
{
    public partial class KeyGenerater : Form
    {
        string key = "sblw-3hn8-sqoy19";
        private SiteSetupBL siteSetupBL;
        public KeyGenerater()
        {
            siteSetupBL = new SiteSetupBL();
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_never.Checked)
                {
                    txt_license.Text = this.Encrypt(txt_site.Text + "|never", key);
                }
                else
                {
                    txt_license.Text = this.Encrypt(txt_site.Text + "|" + dateTimePicker1.Text, key);
                }
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
            }
        }


        public string Encrypt(string input, string key)
        {
            byte[] resultArray;
            try
            {
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
                throw;
            }
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string Decrypt(string input, string key)
        {
            byte[] resultArray;
            try
            {
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
                throw;
            }
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private void btn_decode_Click(object sender, EventArgs e)
        {
            try
            {
                string value = this.Decrypt(txt_lk_decode.Text, key);
                if (!string.IsNullOrWhiteSpace(value))
                {
                    string[] keys = value.Split('|');
                    txt_sk_decode.Text = keys[0];
                    txt_ed_deode.Text = keys[1];
                    chk_never_decode.Checked = keys[1] == "never";
                }
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
            }
        }

        private void KeyGenerater_Load(object sender, EventArgs e)
        {
            this.lab_validation.Visible = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_decode_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
