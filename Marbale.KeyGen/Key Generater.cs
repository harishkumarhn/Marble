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
        
        public KeyGenerater()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (chk_never.Checked)
                {
                    txt_license.Text = this.Encrypt(txt_site.Text + "|never");
                }
                else
                {
                    txt_license.Text = this.Encrypt(txt_site.Text + "|" + dateTimePicker1.Text);
                }
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
            }
        }
        private string Encrypt(string clearText)
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        clearText = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
                throw;
            }

            return clearText;
        }
        private string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                this.lab_validation.Visible = true;
                throw;
            }
            return cipherText;
        }

        private void btn_decode_Click(object sender, EventArgs e)
        {
            try
            {
                string value = this.Decrypt(txt_lk_decode.Text);
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

    }
}
