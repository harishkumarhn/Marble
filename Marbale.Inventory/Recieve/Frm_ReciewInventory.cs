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
    public partial class Frm_ReciewInventory : Form
    {

        bool fireOnChange = true;
        int mgridSelectedindex = -1;
        Vendor vendor = new Vendor();
        public Frm_ReciewInventory()
        {
            InitializeComponent();

        }
        private void Frm_ReciewInventory_Load(object sender, EventArgs e)
        {
            populateVendor();
            populateTax();
            PopulateProductGrid();
        }
        void PopulateProductGrid()
        {
            //lblFilter.Text = string.Empty;

            BindingSource productListBS = new BindingSource();
            InventoryProductBL productBL = new InventoryProductBL();
            List<InventoryProduct> productList;

            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            // lblFilter.Text = filter;
            productList = productBL.GetInventoryProductList(searchParameters);

            if (productList != null)
            {
                productListBS.DataSource = productList;
            }
            else
            {
                productListBS.DataSource = new List<InventoryProduct>();
            }

            grd_products.DataSource = productListBS;
        }

        void populateVendor()
        {
            VendorBL vendorBl = new VendorBL();
            List<KeyValuePair<Vendor.SearchByVendorParameters, string>> searchParameters = new List<KeyValuePair<Vendor.SearchByVendorParameters, string>>();
            searchParameters.Add(new KeyValuePair<Vendor.SearchByVendorParameters, string>(Vendor.SearchByVendorParameters.IS_ACTIVE, "1"));

            List<Vendor> lstVendor = vendorBl.GetVendorList(searchParameters);

            if (lstVendor == null)
                lstVendor = new List<Vendor>();
            BindingSource vendorBS = new BindingSource();

            lstVendor.Insert(0, new Vendor());
            cmb_vendor.DataSource = lstVendor;
            cmb_vendor.ValueMember = "VendorId";
            cmb_vendor.DisplayMember = "VendorName";

        }
        void populateTax()
        {

            PurchaseTaxBL taxBL = new PurchaseTaxBL();
            List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>> taxSearchParams = new List<KeyValuePair<PurchaseTax.SearchByTaxParameters, string>>();
            taxSearchParams.Add(new KeyValuePair<PurchaseTax.SearchByTaxParameters, string>(PurchaseTax.SearchByTaxParameters.IS_ACTIVE, "1"));

            List<PurchaseTax> ListTax = taxBL.GetTaxList(taxSearchParams);


            if (ListTax == null)
            {
                ListTax = new List<PurchaseTax>();
            }
            BindingSource taxBS = new BindingSource();
            BindingSource taxBS1 = new BindingSource();
            ListTax.Insert(0, new PurchaseTax());
            taxBS.DataSource = ListTax;
            taxBS1.DataSource = ListTax;
           
            cmb_DefaultTax.DataSource = taxBS;
            cmb_DefaultTax.ValueMember = "TaxId";
            cmb_DefaultTax.DisplayMember = "TaxName";
            cmb_DefaultTax.SelectedIndex = 0;
            TaxId.DataSource = taxBS1;
            TaxId.ValueMember = "TaxId";
            TaxId.DisplayMember = "TaxName";
            //TaxId.SelectedIndex = 0;
        }
        private void btn_Receipts_Click(object sender, EventArgs e)
        {
            //int rid = -1;
            //int.TryParse(dgv_receive.CurrentRow.Cells["ProductId"].Value.ToString(), out rid);
            Frm_Reciepts frm_Reciepts = new Frm_Reciepts();
            frm_Reciepts.ShowDialog();
        }

        private void dgv_receive_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (fireOnChange)
            {
                if (dgv_receive.Columns[e.ColumnIndex].Name == "ProductCode")
                {
                    DataTable ptable = new DataTable();
                    if (dgv_receive[e.ColumnIndex, e.RowIndex].Value != null)
                        ptable = SearchProduct(dgv_receive[e.ColumnIndex, e.RowIndex].Value.ToString());

                    if (ptable.Rows.Count < 1)
                    {
                        MessageBox.Show("Unable to find Products");
                        mgridSelectedindex = e.RowIndex;
                        dgv_receive.Rows.Remove(dgv_receive.Rows[mgridSelectedindex]);
                        //cb_add.Visible = true;
                        //cb_add.Focus();
                        //cb_add.BackColor = Color.Red;
                        //cb_add.ForeColor = Color.White;

                    }
                    else if (ptable.Rows.Count == 1)
                    {
                        fireOnChange = false;
                        mgridSelectedindex = e.RowIndex;
                        dgv_receive[0, e.RowIndex].Value = ptable.Rows[0]["ProductId"];
                        dgv_receive[1, e.RowIndex].Value = ptable.Rows[0]["Code"];
                        dgv_receive[2, e.RowIndex].Value = ptable.Rows[0]["Description"];
                        dgv_receive[3, e.RowIndex].Value = ptable.Rows[0]["ReorderQuantity"];
                        dgv_receive[4, e.RowIndex].Value = ptable.Rows[0]["Cost"];
                        int taxid = 0;
                        if (ptable.Rows[0]["TaxId"] != null)
                            int.TryParse(ptable.Rows[0]["TaxId"].ToString(), out taxid);
                        dgv_receive[5, e.RowIndex].Value = taxid;
                        //dgv_receive[5, e.RowIndex].Value = 0;// ptable.Rows[0]["taxpercentage"];
                        dgv_receive[6, e.RowIndex].Value = "";// ptable.Rows[0]["TaxInclusiveCost"];
                        dgv_receive[7, e.RowIndex].Value = 0;
                        dgv_receive[8, e.RowIndex].Value = DBNull.Value;
                        //dgv_receive[9, e.RowIndex].Value = "Receive";
                        //dgv_receive[10, e.RowIndex].Value = DBNull.Value;
                        //dgv_receive[11, e.RowIndex].Value = DBNull.Value;
                        //dgv_receive[12, e.RowIndex].Value = ptable.Rows[0]["LowerLimitCost"];
                        //dgv_receive[13, e.RowIndex].Value = ptable.Rows[0]["UpperLimitCost"];
                        //dgv_receive[14, e.RowIndex].Value = ptable.Rows[0]["CostVariancePercentage"];
                        //dgv_receive[15, e.RowIndex].Value = ptable.Rows[0]["Cost"];
                        //dgv_receive[16, e.RowIndex].Value = ptable.Rows[0]["LotControlled"];
                        //dgv_receive[17, e.RowIndex].Value = ptable.Rows[0]["ExpiryType"];
                        //dgv_receive[18, e.RowIndex].Value = ptable.Rows[0]["productid"];
                        //dgv_receive["PriceInTickets", e.RowIndex].Value = ptable.Rows[0]["PriceInTickets"];
                      
                        fireOnChange = true;
                    }
                    else
                    {
                        mgridSelectedindex = e.RowIndex;
                        Panel pnlMultiple_dgv = new Panel();
                        this.Controls.Add(pnlMultiple_dgv);
                        DataGridView multiple_dgv = new DataGridView();
                        //this.Controls.Add(multiple_dgv);
                        pnlMultiple_dgv.Controls.Add(multiple_dgv);
                        multiple_dgv.LostFocus += new EventHandler(mGrid_LostFocus);
                        multiple_dgv.Click += new EventHandler(mGrid_Click);
                        multiple_dgv.Focus();
                        multiple_dgv.DataSource = ptable;
                        multiple_dgv.Refresh();
                        mGrid_Build(ref pnlMultiple_dgv, ref multiple_dgv);
                    }
                }
                else if (dgv_receive.Columns[e.ColumnIndex].Name == "Qty" || dgv_receive.Columns[e.ColumnIndex].Name == "Price")
                {
                    SetAmount(e.RowIndex);
                }
                else if (dgv_receive.Columns[e.ColumnIndex].Name == "TaxId" || dgv_receive.Columns[e.ColumnIndex].Name == "TaxInclusive")
                {
                    getTax(e.RowIndex);
                }
                dgv_receive.Refresh();
            }
        }
        public void SetAmount(int rowIndex)
        {
            //decimal taxPer = Convert.ToDecimal((dgv_receive["TaxPercentage", rowIndex].Value == DBNull.Value ? 0 : dgv_receive["TaxPercentage", rowIndex].Value));

            decimal taxPer = 0;
            decimal price = Convert.ToDecimal((dgv_receive["Price", rowIndex].Value == DBNull.Value ? 0 : dgv_receive["Price", rowIndex].Value));
            decimal qty = Convert.ToDecimal((dgv_receive["Qty", rowIndex].Value == DBNull.Value ? 0 : dgv_receive["Qty", rowIndex].Value));

            if (dgv_receive["TaxInclusive", rowIndex].Value != null)
            {
                if (dgv_receive["TaxInclusive", rowIndex].Value.ToString() == "true")
                {
                    dgv_receive["Amount", rowIndex].Value = qty * price;
                }
                else
                {
                    dgv_receive["Amount", rowIndex].Value = qty * (price + price * taxPer / 100);
                }
            }
            CalculateTotal();
        }
        void getTax(int rowIndex)
        {
            PurchaseTax purchaseTax = null;
            if (dgv_receive["TaxId", rowIndex].Value == null || dgv_receive["TaxId", rowIndex].Value == DBNull.Value || Convert.ToInt32(dgv_receive["TaxId", rowIndex].Value) == -1)
            {
                //Do nothing
            }
            else
            {
                PurchaseTaxBL taxBL = new PurchaseTaxBL();

                int taxid = Convert.ToInt32(dgv_receive["TaxId", rowIndex].Value);
                  purchaseTax = taxBL.GetPurchaseTax(taxid);
            }
            if (purchaseTax == null)
            {
                dgv_receive["TaxPercentage", rowIndex].Value = DBNull.Value;
            }
            else
            {
                dgv_receive["TaxPercentage", rowIndex].Value = purchaseTax.TaxPercentage;
            }
            SetAmount(rowIndex);
        }
        public void CalculateTotal()
        {
            decimal tot = 0;
            for (int i = 0; i < dgv_receive.RowCount; i++)
            {
                if (dgv_receive["Amount", i].Value != null)
                    tot += Convert.ToDecimal(dgv_receive["Amount", i].Value);
            }
            txt_total.Text = String.Format("{0:N2}", tot);
        }
        void mGrid_Build(ref Panel pnlMultiple_dgv, ref DataGridView multiple_dgv)
        {
            pnlMultiple_dgv.Size = new Size(250, (dgv_receive.Rows[0].Cells[0].Size.Height * 10) - 3);
            pnlMultiple_dgv.AutoScroll = true;

            pnlMultiple_dgv.Location = new Point(100 + gb_receive.Location.X + dgv_receive.Location.X + dgv_receive.RowHeadersWidth + dgv_receive.Rows[dgv_receive.CurrentRow.Index].Cells["Qty"].ContentBounds.Location.X, (dgv_receive.Location.Y + dgv_receive.ColumnHeadersHeight));
            pnlMultiple_dgv.BringToFront();
            pnlMultiple_dgv.BackColor = Color.White;
            pnlMultiple_dgv.BorderStyle = BorderStyle.None;
            multiple_dgv.BorderStyle = BorderStyle.None;
            multiple_dgv.AllowUserToAddRows = false;
            multiple_dgv.BackgroundColor = Color.White;
            multiple_dgv.Columns[0].Visible = false;
            for (int i = 3; i < multiple_dgv.Columns.Count; i++)
                multiple_dgv.Columns[i].Visible = false;
            multiple_dgv.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //multiple_dgv.Columns["ReorderQuantity"].DefaultCellStyle = CommonFuncs.Utilities.gridViewAmountCellStyle();
            multiple_dgv.Font = new Font("Arial", 8, FontStyle.Regular);
            multiple_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            multiple_dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            multiple_dgv.ReadOnly = true;
            multiple_dgv.BorderStyle = BorderStyle.None;
            multiple_dgv.RowHeadersVisible = false;
            multiple_dgv.ColumnHeadersVisible = false;
            multiple_dgv.AllowUserToResizeColumns = false;
            multiple_dgv.MultiSelect = false;
            multiple_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            multiple_dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;


        }
        void mGrid_Click(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            fireOnChange = false;
            dgv_receive[0, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["Code"].Value;
            dgv_receive[1, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["Description"].Value;
            dgv_receive[2, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["ReorderQuantity"].Value;
            dgv_receive[3, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["cost"].Value;
            dgv_receive[4, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["taxid"].Value;
            dgv_receive[5, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["TaxPercentage"].Value;
            dgv_receive[6, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["taxinclusivecost"].Value;
            dgv_receive[7, mgridSelectedindex].Value = 0;
            dgv_receive[8, mgridSelectedindex].Value = DBNull.Value;
            dgv_receive[9, mgridSelectedindex].Value = "Receive";
            dgv_receive[10, mgridSelectedindex].Value = DBNull.Value;
            dgv_receive[11, mgridSelectedindex].Value = DBNull.Value;
            dgv_receive[12, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells[7].Value;
            dgv_receive[13, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells[8].Value;
            dgv_receive[14, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells[9].Value;
            dgv_receive[15, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["Cost"].Value;
            dgv_receive[16, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["LotControlled"].Value;
            dgv_receive[17, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["ExpiryType"].Value;
            dgv_receive[18, mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["productid"].Value;
            dgv_receive["PriceInTickets", mgridSelectedindex].Value = dg.Rows[dg.CurrentRow.Index].Cells["PriceInTickets"].Value;

            
            //calculateAmount(mgridSelectedindex);
            fireOnChange = true;
            dg.Visible = false;
            dg.Parent.Visible = false;

        }
        void mGrid_LostFocus(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if (dg.SelectedRows.Count == 0)
            {
                try
                {
                    dgv_receive.Rows.Remove(dgv_receive.Rows[mgridSelectedindex]);
                }
                catch { }
            }
            dg.Visible = false;
            dg.Parent.Visible = false;
            gb_receive.Controls.Remove(dg.Parent);
            //gb_receive.Controls.Remove(dg);
        }

        private DataTable SearchProduct(string pcode)
        {
            DataTable dataTable = new DataTable();
            List<InventoryProduct> productList;
            InventoryProductBL productBL = new InventoryProductBL();
            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_CODE, pcode));
            // lblFilter.Text = filter;
            productList = productBL.GetInventoryProductList(searchParameters);
            if (productList != null && productList.Count > 0)
                dataTable = productList.ToDataTable();

            return dataTable;
        }

        private void lnkApplyTaxToAllLines_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < dgv_receive.RowCount; i++)
            {
                if (dgv_receive["ProductCode", i].Value != null)
                    dgv_receive["TaxId", i].Value = cmb_DefaultTax.SelectedValue;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (cmb_vendor.SelectedIndex <=0)
            {
                MessageBox.Show("Please select Vendor.");
                return;
            }
            if (txt_BillNo.Text == "")
            {
                MessageBox.Show("Bill/Invoice number required.");
                return;
            }

            if (dgv_receive.RowCount > 0)
            {


                PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder.OrderStatus = "Received";
                purchaseOrder.OrderNumber = "";
                purchaseOrder.OrderDate = DateTime.Now;
                purchaseOrder.VendorId = (int)cmb_vendor.SelectedValue;
                purchaseOrder.ContactName = txt_contact.Text;
                purchaseOrder.Phone = txt_phone.Text;
                purchaseOrder.VendorAddress1 = vendor.AddressLine1;
                purchaseOrder.VendorAddress2 = vendor.AddressLine2;
                purchaseOrder.VendorCity = vendor.City;
                purchaseOrder.VendorState = vendor.State;
                purchaseOrder.VendorCountry = vendor.Country;
                purchaseOrder.VendorPostalCode = vendor.PostalCode;
                purchaseOrder.ShipToAddress1 = "";
                purchaseOrder.ShipToAddress2 = "";
                purchaseOrder.ShipToCity = "";
                purchaseOrder.ShipToState = "";
                purchaseOrder.ShipToCountry = "";
                purchaseOrder.ShipToPostalCode = "";
                purchaseOrder.ShipToAddressRemarks = "";
                purchaseOrder.RequestShipDate = DateTime.MinValue;
                purchaseOrder.OrderTotal = Convert.ToDouble(txt_total.Text);// dgv_receive["Amount", i].Value;
                                                                            //purchaseOrder.OrderRemarks = "";
                purchaseOrder.ReceiveRemarks = "";
                //purchaseOrder.CancelledDate = DateTime.MinValue;
                purchaseOrder.IsActive = true;
                //purchaseOrder.CreatedBy
                //purchaseOrder.CreatedDate

                PurchaseOrderBL purchaseOrderBL = new PurchaseOrderBL();
                purchaseOrder.PurchaseOrderId = purchaseOrderBL.Save(purchaseOrder, "rakshith");

                //XXXXXXXXX
                //get Purchase order id
                //int purchaseOrderId = 0;

                InventoryReceipt inventoryReceipt = new InventoryReceipt();
                inventoryReceipt.VendorBillNumber = txt_BillNo.Text;
                inventoryReceipt.GatePassNumber = txt_GatePassNo.Text;
                //inventoryReceipt.GRN=""
                inventoryReceipt.PurchaseOrderId = purchaseOrder.PurchaseOrderId;
                inventoryReceipt.Remarks = "";
                inventoryReceipt.ReceiveDate = Convert.ToDateTime(dt_ReceiveDate.Text);
                inventoryReceipt.ReceivedBy = "rakshith";
                inventoryReceipt.IsActive = true;

                InventoryReceiptBL inventoryReceiptBL = new InventoryReceiptBL();
                inventoryReceipt.InventoryReceiptID = inventoryReceiptBL.Save(inventoryReceipt, "rakshith");

                for (int i = 0; i < dgv_receive.RowCount - 1; i++)
                {
                    //if (dgv_receive["ProductCode", i].Value != null)
                    //    dgv_receive["TaxId", i].Value = cmbDefaultTax.SelectedValue;

                    if (dgv_receive["chkGrdRecieve", i].Value != null && (bool)dgv_receive["chkGrdRecieve", i].Value == true)
                    {


                        //XXXXXXXXXXXXXXXXXXXXXXX
                        //get prodcut based on id
                        InventoryProductBL inventoryProductBL = new InventoryProductBL();

                        int pid = Convert.ToInt32(dgv_receive["ProductId", i].Value);
                        InventoryProduct inventoryProduct = inventoryProductBL.GetInventoryProduct(pid);


                        PurchaseOrderLine purchaseOrderLine = new PurchaseOrderLine();
                        //purchaseOrderLine.PurchaseOrderLineId
                        purchaseOrderLine.PurchaseOrderId = purchaseOrder.PurchaseOrderId;
                        purchaseOrderLine.ItemCode = inventoryProduct.Code;
                        purchaseOrderLine.Description = inventoryProduct.Description;
                        purchaseOrderLine.Quantity = Convert.ToInt32(dgv_receive["Qty", i].Value);
                        purchaseOrderLine.UnitPrice = Convert.ToDouble(dgv_receive["Price", i].Value);
                        purchaseOrderLine.SubTotal = dgv_receive["Amount", i].Value == DBNull.Value ? 0 : Convert.ToDouble(dgv_receive["Amount", i].Value);
                        ///purchaseOrderLine.TaxAmount = dgv_receive["TaxPercentage", i].Value == DBNull.Value ? 0 : Convert.ToDouble(dgv_receive["TaxPercentage", i].Value);
                        //purchaseOrderLine.DiscountPercentage
                        purchaseOrderLine.RequiredByDate = dgv_receive["RequiredByDate", i].Value != null ? Convert.ToDateTime(dgv_receive["RequiredByDate", i].Value) : DateTime.MinValue;
                        purchaseOrderLine.ProductId = inventoryProduct.ProductId;
                        purchaseOrderLine.IsActive = true;
                        //purchaseOrderLine.CancelledDate
                        PurchaseOrderLineBL purchaseOrderLineBL = new PurchaseOrderLineBL();
                        purchaseOrderLine.PurchaseOrderLineId = purchaseOrderLineBL.Save(purchaseOrderLine, "rakshith");


                        PurchaseOrderReceiveLine purchaseOrderReceiveLine = new PurchaseOrderReceiveLine();
                        purchaseOrderReceiveLine.PurchaseOrderId = purchaseOrder.PurchaseOrderId;

                        purchaseOrderReceiveLine.ProductId = inventoryProduct.ProductId;
                        purchaseOrderReceiveLine.Description = inventoryProduct.Description;
                        purchaseOrderReceiveLine.VendorItemCode = inventoryProduct.Code;
                        purchaseOrderReceiveLine.Quantity = dgv_receive["Qty", i].Value == DBNull.Value ? 0 : Convert.ToInt32(dgv_receive["Qty", i].Value);
                        //purchaseOrderReceiveLine.LocationId
                        purchaseOrderReceiveLine.IsReceived = Convert.ToBoolean(dgv_receive["chkGrdRecieve", i].Value);
                        purchaseOrderReceiveLine.PurchaseOrderLineId = purchaseOrderLine.PurchaseOrderLineId;
                        purchaseOrderReceiveLine.Price = dgv_receive["Price", i].Value != null ? 0 : Convert.ToDouble(dgv_receive["Price", i].Value);
                        //purchaseOrderReceiveLine.TaxPercentage =  Convert.ToDouble(dgv_receive["TaxPercentage", i].Value);
                        purchaseOrderReceiveLine.Amount = dgv_receive["Amount", i].Value != null ? 0 : Convert.ToDouble(dgv_receive["Amount", i].Value);
                        purchaseOrderReceiveLine.TaxInclusive = Convert.ToBoolean(dgv_receive["TaxInclusive", i].Value);
                        purchaseOrderReceiveLine.TaxId = dgv_receive["TaxId", i].Value != null ? -1 : Convert.ToInt32(dgv_receive["TaxId", i].Value);
                        purchaseOrderReceiveLine.ReceiptId = inventoryReceipt.InventoryReceiptID;
                        purchaseOrderReceiveLine.VendorBillNumber = txt_BillNo.Text;
                        purchaseOrderReceiveLine.ReceivedBy = "rakshith";
                        purchaseOrderReceiveLine.IsActive = true;

                        PurchaseOrderReceiveLineBL purchaseOrderReceiveLineBL = new PurchaseOrderReceiveLineBL();
                        purchaseOrderReceiveLine.PurchaseOrderLineId = purchaseOrderReceiveLineBL.Save(purchaseOrderReceiveLine, "rakshith");


                    }
                }


                MessageBox.Show("Saved successfully");
                Reset();
            }
        }

        private void dgv_receive_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void cmb_vendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vendorid = (int)cmb_vendor.SelectedValue;
            VendorBL vendorBl = new VendorBL();
            Vendor vendor = vendorBl.GetVendor(vendorid);
            txt_contact.Text = vendor.ContactName;
            txt_phone.Text = vendor.Phone;
            txt_Address.Text = vendor.AddressLine1 + "\n" + vendor.AddressLine2 ;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            dgv_receive.Rows.Clear();
            cmb_vendor.SelectedIndex =0;
            txt_contact.Text = "";
            txt_phone.Text = "";
            txt_Address.Text = "";
            txt_BillNo.Text = "";
            txtGRN.Text = "";
            txt_GatePassNo.Text = "";
            cmb_DefaultTax.SelectedIndex = 0;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            BindingSource productListBS = new BindingSource();
            InventoryProductBL productBL = new InventoryProductBL();
            List<InventoryProduct> productList;

            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_CODE, txt_prodcode.Text));

            productList = productBL.GetInventoryProductList(searchParameters);

            if (productList != null)
            {
                productListBS.DataSource = productList;
            }
            else
            {
                productListBS.DataSource = new List<InventoryProduct>();
            }

            grd_products.DataSource = productListBS;
        }
    }


    public static class ListtoDataTableConverter

    {

        public static DataTable ToDataTable<T>(this List<T> items)

        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)

            {

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)

            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)

                {
                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }


            return dataTable;

        }

    }
}
