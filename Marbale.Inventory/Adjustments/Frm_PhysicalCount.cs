using Marbale.BusinessObject.Inventory;
using Marbale.BusinessObject.SiteSetup;
using Marble.Business.InventoryBL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Inventory.Adjustments
{
    public partial class Frm_PhysicalCount : Form
    {
        private string status = "";
        private string PhyscicalDescription = "";
        private int physicalCountId = 0;
        public Frm_PhysicalCount()
        {
            InitializeComponent();
        }
        private void Frm_PhysicalCount_Load(object sender, EventArgs e)
        {
            loadOpenStatus();
            PopulateProductGrid();
            LoadLocationCombobox();
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
            drp_Location.DataSource = lstLocation;
            drp_Location.DisplayMember = "LocationName";
            drp_Location.ValueMember = "LocationId";


        }

        public void loadOpenStatus()
        {
            InventoryPhysicalCountBL inventoryPhysicalCountBL = new InventoryPhysicalCountBL();
            InventoryPhysicalCount inventoryPhysicalCount = inventoryPhysicalCountBL.GetInventoryPhysicalCount("Open");

            if (inventoryPhysicalCount != null && inventoryPhysicalCount.Id > 0)
            {
                btn_initaiate.Text = "Close Count Process";
                status = "open";

                physicalCountId = inventoryPhysicalCount.Id;

            }
            else
            {
                btn_initaiate.Text = "Open Count Process";

                status = "closed";
            }
        }

        void PopulateProductGrid()
        {
            //lblFilter.Text = string.Empty;

            BindingSource productListBS = new BindingSource();
            InventoryProductBL productBL = new InventoryProductBL();
            List<InventoryProduct> productList;

            List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>> searchParameters = new List<KeyValuePair<InventoryProduct.SearchByProductParameters, string>>();
            searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.IS_ACTIVE, "1"));

            if (!string.IsNullOrEmpty(txt_PCode.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_CODE, txt_PCode.Text));
            }
            if (!string.IsNullOrEmpty(txt_Description.Text))
            {
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.DESCRIPTION, txt_Description.Text));
            }
            if (drp_Location.SelectedIndex > 0)
            {
                //search location
                searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.DEFAULT_LOCATION, drp_Location.SelectedValue.ToString()));
            }
            //if (!string.IsNullOrEmpty(txt_Description.Text))
            //{
            //    searchParameters.Add(new KeyValuePair<InventoryProduct.SearchByProductParameters, string>(InventoryProduct.SearchByProductParameters.PRODUCT_NAME, txt_Description.Text));
            //}
            // lblFilter.Text = filter;
            productList = productBL.GetInventoryProductListWithStoreData(searchParameters);

            if (productList != null)
            {
                productListBS.DataSource = productList;
            }
            else
            {
                productListBS.DataSource = new List<InventoryProduct>();
            }

            dgv_Products.DataSource = productListBS;
        }

        private void btn_initaiate_Click(object sender, EventArgs e)
        {
            if (status == "open")
            {

                if (MessageBox.Show("Do you want to close physical count?", "Physical Count ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    InventoryPhysicalCountLogBL inventoryPhysicalCountLogBL = new InventoryPhysicalCountLogBL();

                    inventoryPhysicalCountLogBL.InsertInventoryPhysicalCountLogByID(physicalCountId, "rakshih");
                    //
                    InventoryPhysicalCountBL inventoryPhysicalCountBL = new InventoryPhysicalCountBL();
                    InventoryPhysicalCount inventoryPhysicalCount = inventoryPhysicalCountBL.GetInventoryPhysicalCount("Open");

                    if (inventoryPhysicalCount != null && inventoryPhysicalCount.Id > 0)
                    {
                        inventoryPhysicalCount.Status = "Closed";
                        inventoryPhysicalCount.ClosedBy = LogedInUser.LoginId;
                        inventoryPhysicalCount.ClosedDate = DateTime.Now;
                        inventoryPhysicalCountBL.Save(inventoryPhysicalCount, LogedInUser.LoginId);

                    }

                    loadOpenStatus();
                }
                else
                {

                }



            }
            else if (status == "closed")
            {
                Frm_PhysicalCountPopup frm_PhysicalCountPopup = new Frm_PhysicalCountPopup();

                frm_PhysicalCountPopup.ShowDialog();

                loadOpenStatus();
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            bool saved = false;
            try
            {


                InventoryStoreBL inventoryStoreBL = new InventoryStoreBL();
                for (int i = 0; i < dgv_Products.RowCount; i++)
                {
                    //if (dgv_Products["chkSelectItem", i].Value != null && Convert.ToBoolean(dgv_Products["chkSelectItem", i].Value) == true)
                    //{

                    //if (Convert.ToInt32(dgv_Products["storeLocationIdDgvColumn", i].Value) <= 0)
                    //    continue;

                    if (dgv_Products["txt_newQuantity", i].Value == null
                        || string.IsNullOrEmpty(dgv_Products["txt_newQuantity", i].Value.ToString()))
                    {
                        continue;
                    }

                    InventoryStore inventoryStore = new InventoryStore();
                    //inventoryStore.LocationId = Convert.ToInt32(cmb_TransferLocation.SelectedValue);
                    inventoryStore.ProductId = Convert.ToInt32(dgv_Products["productIdDataGridViewTextBoxColumn", i].Value);
                    inventoryStore.Quantity = Convert.ToInt32(dgv_Products["txt_newQuantity", i].Value);
                    inventoryStore.LocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value);
                    InventoryStore termpInventoryStore = inventoryStoreBL.GetInventoryStore(inventoryStore.ProductId, inventoryStore.LocationId);
                    if (termpInventoryStore != null && termpInventoryStore.Id > 0)
                    {
                        inventoryStoreBL.UpdateInventoryStoreOnAdjustment(inventoryStore, LogedInUser.LoginId);
                    }

                    InventoryAdjustments inventoryAdjustments = new InventoryAdjustments()
                    {
                        ProductId = Convert.ToInt32(dgv_Products["productIdDataGridViewTextBoxColumn", i].Value),
                        AdjustmentQuantity = Convert.ToInt32(dgv_Products["txt_newQuantity", i].Value),
                        Remarks = dgv_Products["txt_Remarks", i].Value == null ? "" : dgv_Products["txt_Remarks", i].Value.ToString(),
                        AdjustmentType = "Adjustment",
                        FromLocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value),
                        ToLocationId = Convert.ToInt32(dgv_Products["defaultLocationIdDataGridViewTextBoxColumn", i].Value)
                    };

                    InventoryAdjustmentsBL inventoryAdjustmentsBL = new InventoryAdjustmentsBL();
                    inventoryAdjustmentsBL.Save(inventoryAdjustments, LogedInUser.LoginId);
                    saved = true;
                    //  }
                }
            }
            catch (Exception ex)
            {
                saved = false;
            }
            if (saved)
            {
                MessageBox.Show("Products are adjsuted");
                PopulateProductGrid();
            }
            else
            {
                MessageBox.Show("Failed to save.");
            }
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            txt_PCode.Text = "";
            txt_Description.Text = "";
            txt_Barcode.Text = "";
            chk_Purchaseable.Checked = true;
            PopulateProductGrid();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            PopulateProductGrid();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {




            try
            {


                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.InitialDirectory = @ "C:\";      
                saveFileDialog1.Title = "Save Products";
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xlxs";
                saveFileDialog1.Filter = "Excel files (*.xlxs)|*.xlxs|All files (*.*)|*.*";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path= saveFileDialog1.FileName;
                    SaveExcelWithData(path);
                }
                
            }
            catch (Exception ex) { }

        }

        private void UploadExcel(string path)
        {
            DataTable dt1 = null;

            try
            {

                //string basepath = System.AppDomain.CurrentDomain.BaseDirectory;
                //string foldername = "DownloadUpload";
                //if (!Directory.Exists(basepath + "\\" + foldername))
                //    Directory.CreateDirectory(basepath + foldername);

                //string filepath = basepath + foldername + "\\" + "Download.xlsx";

                byte[] bin = File.ReadAllBytes(path);

                using (MemoryStream stream = new MemoryStream(bin))
                {
                    using (ExcelPackage excelPackage1 = new ExcelPackage(stream))
                    {
                        dt1 = ExcelPackageToDataTable(excelPackage1);
                    }
                }



                //DataTable dt = GetDataTableFromExcel("", true);
                if (dt1 != null)
                {
                    if (dt1.Rows.Count == 0)
                    {
                        MessageBox.Show("Unable to Load Excel");
                        return;
                    }
                    uploadData(dt1);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Load Excel");
            }
        }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {


                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    //InitialDirectory = @"D:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    //ReadOnlyChecked = true,
                    //ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename= openFileDialog1.FileName;
                    UploadExcel(filename);
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show("Unable to Load Excel");
            }


        }

        void uploadData(DataTable dt)
        {
            int successRowCount = 0;
            double CurrentQty, AdjQty = 0;
            double newQuantity = 0;
            InventoryStoreBL inventoryStoreBL = new InventoryStoreBL();
            InventoryAdjustmentsBL inventoryAdjustmentsBL = new InventoryAdjustmentsBL();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    int locationId = -1;

                    if (dt.Rows[i]["New_Quantity"] != null && dt.Rows[i]["New_Quantity"] != DBNull.Value)
                    {

                        if (dt.Rows[i]["LocationId"] != null && dt.Rows[i]["LocationId"] != DBNull.Value)
                        {
                            locationId = Convert.ToInt32(dt.Rows[i]["LocationId"]);
                        }

                        if (dt.Rows[i]["LocationId"] != DBNull.Value)
                        {
                            InventoryStore inventoryStore = inventoryStoreBL.GetInventoryStore(Convert.ToInt32(dt.Rows[i]["ProductId"]), locationId);

                            if (inventoryStore != null)
                            {
                                CurrentQty = inventoryStore.Quantity;
                            }
                            else
                            {
                                CurrentQty = 0;
                            }

                            newQuantity = Convert.ToDouble(dt.Rows[i]["New_Quantity"]);
                            if (newQuantity < 0)
                                continue;
                            AdjQty = newQuantity - CurrentQty;

                            if (AdjQty == 0)
                            {
                                successRowCount += 1;
                                dt.Rows[i]["Status"] = "Success";
                                continue;
                            }

                            try
                            {
                                InventoryStore inventoryStorenew = inventoryStoreBL.GetInventoryStore(Convert.ToInt32(dt.Rows[i]["ProductId"]), Convert.ToInt32(dt.Rows[i]["LocationId"]));

                                if (inventoryStorenew != null)
                                {
                                    inventoryStorenew.Quantity = AdjQty + inventoryStorenew.Quantity;
                                    inventoryStorenew.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                                    inventoryStorenew.LocationId = locationId;

                                    inventoryStoreBL.Save(inventoryStorenew, LogedInUser.LoginId);
                                }
                                else
                                {

                                    InventoryStore inventoryStore1 = new InventoryStore();
                                    inventoryStore1.Quantity = AdjQty;
                                    inventoryStore1.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                                    inventoryStore1.LocationId = locationId;

                                    inventoryStoreBL.Save(inventoryStore1, LogedInUser.LoginId);
                                }


                                InventoryAdjustments inventoryAdjustments = new InventoryAdjustments();
                                inventoryAdjustments.AdjustmentType = "Adjustment";
                                inventoryAdjustments.AdjustmentQuantity = AdjQty;
                                inventoryAdjustments.FromLocationId = locationId;
                                inventoryAdjustments.Remarks = "Bulk Adjustment: " + dt.Rows[i]["Remarks"];
                                inventoryAdjustments.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);

                                inventoryAdjustmentsBL.Save(inventoryAdjustments, LogedInUser.LoginId);
                                //dt.Rows[i]["Status"] = "Success";

                                successRowCount++;
                            }
                            catch (Exception ex)
                            {
                                dt.Rows[i]["Status"] = ex.Message;

                            }
                        }
                    }
                    else
                    {
                        successRowCount += 1;
                        //                        //dt.Rows[i]["Status"] = "Success";
                    }
                }
                catch (Exception ex)
                {
                    dt.Rows[i]["Status"] = ex.Message;
                    //MessageBox.Show(ex.Message, CommonFuncs.Utilities.MessageUtils.getMessage("Inventory data upload Error"));
                    continue;
                }
            }
            //lblMessage.Text = "Successfully loaded " + successRowCount.ToString() + " of " + dt.Rows.Count.ToString() + " records";
            //if (dt.Rows.Count - successRowCount > 0)
            //{
            //    lnkError.Text = (dt.Rows.Count - successRowCount).ToString() + " Errors";
            //    lnkError.Enabled = true;

            //    int count = dt.Rows.Count;

            //    for (int j = 0; j < count; j++)
            //    {
            //        if (dt.Rows[j]["Status"].ToString() == "Success")
            //        {
            //            dt.Rows.RemoveAt(j);
            //            count = dt.Rows.Count;
            //            j = -1;
            //        }
            //    }
            //    lnkError.Tag = dt;
            //}
            //else
            //{
            //    lnkError.Enabled = false;
            //    lnkError.Tag = null;
            //}
        }
        public static DataTable ExcelPackageToDataTable(ExcelPackage excelPackage)
        {




            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }

            //create a list to hold the column names
            List<string> columnNames = new List<string>();

            //needed to keep track of empty column headers
            int currentColumn = 1;

            //loop all columns in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();

                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }

                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);

                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }

                //add the column to the datatable
                dt.Columns.Add(columnName);

                currentColumn++;
            }

            //start adding the contents of the excel file to the datatable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();

                //loop all cells in the row
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }
        //public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        //{
        //    string basepath = System.AppDomain.CurrentDomain.BaseDirectory;
        //    string foldername = "temp";
        //    if (!Directory.Exists(basepath + "\\" + foldername))
        //        Directory.CreateDirectory(basepath + foldername);

        //    string filepath = basepath +  foldername + "\\" + "Download.xlxs";
        //    FileInfo newFile = new FileInfo(filepath);

        //    try
        //    {

        //    using (var pck = new OfficeOpenXml.ExcelPackage())
        //    {
        //        using (var stream = File.OpenRead(filepath))
        //        {
        //            pck.Load(stream);
        //        }


        //            ////======================
        //            var ws = pck.Workbook.Worksheets.First();
        //            DataTable tbl = new DataTable();
        //            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
        //            {
        //                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
        //            }
        //            var startRow = hasHeader ? 2 : 1;
        //            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
        //            {
        //                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
        //                DataRow row = tbl.Rows.Add();
        //                foreach (var cell in wsRow)
        //                {
        //                    row[cell.Start.Column - 1] = cell.Text;
        //                }
        //            }

        //            return tbl;
        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}


        void SaveExcelWithData(string path)
        {


            try
            {
                InventoryProductBL inventoryProductBL = new InventoryProductBL();
                DataTable dt = new DataTable();
                dt = inventoryProductBL.GetInventoryDataExport();
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Unable to Download Excel");
                    return;
                }
                //string basepath = System.AppDomain.CurrentDomain.BaseDirectory;
                //string foldername = "DownloadUpload";
                //if (!Directory.Exists(basepath + "\\" + foldername))
                //    Directory.CreateDirectory(basepath + foldername);

                //string filepath = basepath + "\\" + foldername + "\\" + "Download.xlsx";
                FileInfo newFile = new FileInfo(path);

                using (ExcelPackage pck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Inventory1");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    pck.Save();
                    MessageBox.Show("File Downloaded");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Unable to Download Excel");
            }
        }
    }
}
