using Marbale.BusinessObject.Inventory;
using Marble.Business.InventoryBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Marbale.Inventory.Recieve
{
    public partial class Frm_Reciepts : Form
    {
        //int purchaseorderId = 0;
        public Frm_Reciepts()
        {
            //purchaseorderId = poId;
            InitializeComponent();

            //
        }

        private void Frm_Reciepts_Load(object sender, EventArgs e)
        {
            LoadLocationCombobox();
            LoadInventotyReciepts();
            //LoadInventotyReciepts();

        }
        void populateTax()
        {

            PurchaseTaxBL taxBL = new PurchaseTaxBL();
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> searchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            searchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.IS_ACTIVE, "1"));

            List<PurchaseTax> ListTax = taxBL.GetTaxList(searchParams);


            if (ListTax == null)
            {
                ListTax = new List<PurchaseTax>();
            }
            BindingSource taxBS = new BindingSource();
            BindingSource taxBS1 = new BindingSource();
            ListTax.Insert(0, new PurchaseTax());
            taxBS.DataSource = ListTax;
            taxIdDataGridViewTextBoxColumn.DataSource = taxBS;
            taxIdDataGridViewTextBoxColumn.ValueMember = "TaxId";
            taxIdDataGridViewTextBoxColumn.DisplayMember = "TaxName";
            

 



        }

        void LoadLocationCombobox()
        {
            LocationBL locationTypeBL = new LocationBL();
            List<Location> lstLocation = locationTypeBL.GetLocation();
            BindingSource locationBS = new BindingSource();
            if (lstLocation == null)
            {
                lstLocation = new List<Location>();
            }

            lstLocation.Insert(0, new Location());
            lstLocation[0].LocationName = "None";
            locationIdDataGridViewTextBoxColumn.DataSource = lstLocation;
            locationIdDataGridViewTextBoxColumn.DisplayMember = "LocationName";
            locationIdDataGridViewTextBoxColumn.ValueMember = "LocationId";
            
        }
        public void LoadInventotyReciepts()
        {
            InventoryReceiptBL obBL= new InventoryReceiptBL();
            List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>> sparams = new List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>>();
            sparams.Add(new KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>(InventoryReceipt.SearchByInventoryReceiptParameters.IS_ACTIVE, "1"));
           if(!string.IsNullOrEmpty(txt_vendor.Text))
            sparams.Add(new KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>(InventoryReceipt.SearchByInventoryReceiptParameters.VENDOR_NAME, txt_vendor.Text));
            if (!string.IsNullOrEmpty(txt_GRN.Text))
                sparams.Add(new KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>(InventoryReceipt.SearchByInventoryReceiptParameters.GRN, txt_GRN.Text));
            //sparams.Add(new KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>(InventoryReceipt.SearchByInventoryReceiptParameters.INVENTORY_RECEIPT_ID, purchaseorderId.ToString()));

            List<InventoryReceipt> inventoryReceiptList = obBL.GetInventoryReceiptList(sparams);

            BindingSource recieptListBS = new BindingSource();

            if (inventoryReceiptList != null)
            {
                recieptListBS.DataSource = inventoryReceiptList;
            }
            else
            {
                recieptListBS.DataSource = new List<InventoryProduct>();
            }

            dgv_Reciepts.DataSource = recieptListBS;
        }

        public void LoadInventotyRecieptDetails(int ReceiptId)
        {
            PurchaseOrderReceiveLineBL obBL = new PurchaseOrderReceiveLineBL();
            List<KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>> sparams = new List<KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>>();
            sparams.Add(new KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>(PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters.IS_ACTIVE, "1"));
            sparams.Add(new KeyValuePair<PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters, string>(PurchaseOrderReceiveLine.SearchByPurchaseOrderRecieveLineParameters.RECEIPT_ID, ReceiptId.ToString()));

            List<PurchaseOrderReceiveLine> purchaseOrderReceiveLineList = obBL.GetPurchaseOrderReceiveLineList(sparams);

            BindingSource recieptListBS = new BindingSource();

            if (purchaseOrderReceiveLineList != null)
            {
                recieptListBS.DataSource = purchaseOrderReceiveLineList;
            }
            else
            {
                recieptListBS.DataSource = new List<InventoryProduct>();
            }

            dgv_RecieptDetails.DataSource = recieptListBS;
        }

        private void dgv_Reciepts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rid = -1;
            int.TryParse(dgv_Reciepts.CurrentRow.Cells["InventoryReceiptID"].Value.ToString(), out rid);
            LoadInventotyRecieptDetails(rid);
        }

        private void dgv_Reciepts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rid = -1;
            int.TryParse(dgv_Reciepts.CurrentRow.Cells["InventoryReceiptID"].Value.ToString(), out rid);
            LoadInventotyRecieptDetails(rid);
        }

        private void dgv_RecieptDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            LoadInventotyReciepts();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_GRN.Text = "";
            txt_vendor.Text = "";
            LoadInventotyReciepts();
        }
    }
}
