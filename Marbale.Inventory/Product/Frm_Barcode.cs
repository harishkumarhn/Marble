using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.SiteSetup;
using Marbale.Inventory.Model;
using Marble.Business.InventoryBL;
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
    public partial class Frm_Barcode : Form
    {
        //public Frm_Barcode()
        //{
        //    InitializeComponent();
        //    chk_Active.Checked = true;
        //}

        int pid = -1;
        string prodName = "";

        public Frm_Barcode(int productid,string productName)
        {
            InitializeComponent();
            chk_Active.Checked = true;
            pid = productid;
            prodName = productName;
            lbl_header.Text = "Barcode for " + productName;
        }

        private void Frm_Barcode_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            InventoryProductBarcodeBL inventoryProductBarcodeBL = new InventoryProductBarcodeBL();
            List<KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>> searchParams = new List<KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>>();
            searchParams.Add(new KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>(InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.IS_ACTIVE, "1"));
            searchParams.Add(new KeyValuePair<InventoryProductBarcode.SearchByInventoryProductBarcodeParameters, string>(InventoryProductBarcode.SearchByInventoryProductBarcodeParameters.PRODUCT_ID, pid.ToString()));


            List<InventoryProductBarcode> inventoryProductBarcodeList = inventoryProductBarcodeBL.GetInventoryStoreist(searchParams);

            BindingSource listBS = new BindingSource();

            if (inventoryProductBarcodeList != null)
            {
                listBS.DataSource = inventoryProductBarcodeList;
            }
            else
            {
                listBS.DataSource = new List<InventoryProduct>();
            }

            dgv_barcodes.DataSource = listBS;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            lbl_barcodeId.Text = "";
            txt_barcode.Text = "";

            chk_Active.Checked = true;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(txt_barcode.Text) )
            {
                MessageBox.Show("Please enter the barcode");
                return;

            }
            InventoryProductBarcodeBL inventoryProductBarcodeBL = new InventoryProductBarcodeBL();

            InventoryProductBarcode inventoryProductBarcode = new InventoryProductBarcode()
            {
                BarCode = txt_barcode.Text,
                IsActive = chk_Active.Checked,
                ProductId = pid
            }; ;

            int id= inventoryProductBarcodeBL.Save(inventoryProductBarcode, LogedInUser.LoginId);
            MessageBox.Show("Saved successfully");

            Clear();
            LoadProducts();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_GenerateBarcode frm_GenerateBarcode = new Frm_GenerateBarcode();
            

            if (frm_GenerateBarcode.ShowDialog() == DialogResult.OK)
            txt_barcode.Text = BarcodeReader.Barcode;
        }

        private void btn_updateProduct_Click(object sender, EventArgs e)
        {
            InventoryProductBL inventoryProductBL = new InventoryProductBL();
            InventoryProduct inventoryProduct = new InventoryProduct();
            string code = dgv_barcodes.CurrentRow.Cells["barCodeDataGridViewTextBoxColumn"].Value.ToString();

            if (pid > 0)
            {
                inventoryProduct = inventoryProductBL.GetInventoryProduct(pid);
                inventoryProduct.BarCode = code;
                inventoryProductBL.Save(inventoryProduct, LogedInUser.LoginId);
                BarcodeReader.Barcode = code;
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Barcode Updated");
               
            }

        }
    }
}
