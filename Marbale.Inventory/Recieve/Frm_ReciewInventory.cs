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
        public Frm_ReciewInventory()
        {
            InitializeComponent();
           
        }
        private void Frm_ReciewInventory_Load(object sender, EventArgs e)
        {
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

        private void btn_Receipts_Click(object sender, EventArgs e)
        {

        }

        private void dgv_receive_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(fireOnChange)
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
                        dgv_receive[0, e.RowIndex].Value = ptable.Rows[0]["Code"];
                        dgv_receive[1, e.RowIndex].Value = ptable.Rows[0]["Description"];
                        dgv_receive[2, e.RowIndex].Value = ptable.Rows[0]["ReorderQuantity"];
                        dgv_receive[3, e.RowIndex].Value = ptable.Rows[0]["Cost"];
                        //dgv_receive[4, e.RowIndex].Value = ptable.Rows[0]["TaxId"];
                        dgv_receive[5, e.RowIndex].Value = 0;// ptable.Rows[0]["taxpercentage"];
                        dgv_receive[6, e.RowIndex].Value = ptable.Rows[0]["TaxInclusiveCost"];
                        dgv_receive[7, e.RowIndex].Value = 0;
                        dgv_receive[8, e.RowIndex].Value = DBNull.Value;
                        dgv_receive[9, e.RowIndex].Value = "Receive";
                        dgv_receive[10, e.RowIndex].Value = DBNull.Value;
                        dgv_receive[11, e.RowIndex].Value = DBNull.Value;
                        dgv_receive[12, e.RowIndex].Value = ptable.Rows[0]["LowerLimitCost"];
                        //dgv_receive[13, e.RowIndex].Value = ptable.Rows[0]["UpperLimitCost"];
                        //dgv_receive[14, e.RowIndex].Value = ptable.Rows[0]["CostVariancePercentage"];
                        //dgv_receive[15, e.RowIndex].Value = ptable.Rows[0]["Cost"];
                        //dgv_receive[16, e.RowIndex].Value = ptable.Rows[0]["LotControlled"];
                        //dgv_receive[17, e.RowIndex].Value = ptable.Rows[0]["ExpiryType"];
                        //dgv_receive[18, e.RowIndex].Value = ptable.Rows[0]["productid"];
                        //dgv_receive["PriceInTickets", e.RowIndex].Value = ptable.Rows[0]["PriceInTickets"];

                        if (cmbLocation.SelectedIndex != -1)
                        {
                            if (Convert.ToInt32(cmbLocation.SelectedValue) != -1)
                                dgv_receive["recvLocation", e.RowIndex].Value = cmbLocation.SelectedValue;
                        }

                        //setupReceiveButton();
                        //calculateAmount(e.RowIndex);
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
                //else if (dgv_receive.Columns[e.ColumnIndex].Name == "Qty" || dgv_receive.Columns[e.ColumnIndex].Name == "Price")
                //{
                //    calculateAmount(e.RowIndex);
                //}
                //else if (dgv_receive.Columns[e.ColumnIndex].Name == "TaxId" || dgv_receive.Columns[e.ColumnIndex].Name == "TaxInclusive")
                //{
                //    getTax(e.RowIndex);
                //}
                dgv_receive.Refresh();
            }
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

            if (cmbLocation.SelectedIndex != -1)
            {
                if (Convert.ToInt32(cmbLocation.SelectedValue) != -1)
                    dgv_receive["recvLocation", mgridSelectedindex].Value = cmbLocation.SelectedValue;
            }

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
            if(productList!=null && productList.Count>0)
            dataTable = productList.ToDataTable();

            return dataTable;
        }
    }


    public static class ListtoDataTableConverter

    {

        public static DataTable ToDataTable<T>(this  List<T> items)

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
