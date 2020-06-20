using Marbale.Inventory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory.Product
{
    public partial class Frm_GenerateBarcode : Form
    {
        public Frm_GenerateBarcode()
        {
            InitializeComponent();
        }

        private void Frm_GenerateBarcode_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            //BarcodeReader.Barcode= 
            if(string.IsNullOrEmpty(txt_Barcode.Text))
            {
                MessageBox.Show("Please enter barcode");

            }
            else
            {

                BarcodeReader.Barcode = txt_Barcode.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

         
    }
}
