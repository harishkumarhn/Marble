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
        }

        private void Frm_Reciepts_Load(object sender, EventArgs e)
        {
            LoadInventotyReciepts();
        }

        public void LoadInventotyReciepts()
        {
            InventoryReceiptBL obBL= new InventoryReceiptBL();
            List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>> sparams = new List<KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>>();
            sparams.Add(new KeyValuePair<InventoryReceipt.SearchByInventoryReceiptParameters, string>(InventoryReceipt.SearchByInventoryReceiptParameters.IS_ACTIVE, "1"));
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
    }
}
