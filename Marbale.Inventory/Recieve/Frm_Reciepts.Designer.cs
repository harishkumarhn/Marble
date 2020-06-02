namespace Marbale.Inventory.Recieve
{
    partial class Frm_Reciepts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_GRN = new System.Windows.Forms.TextBox();
            this.txt_vendor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_Reciepts = new System.Windows.Forms.DataGridView();
            this.inventoryReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_RecieptDetails = new System.Windows.Forms.DataGridView();
            this.purchaseOrderReceiveLineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InventoryReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorBillNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gatePassNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gRNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorItemCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isReceivedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.purchaseOrderLineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxInclusiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taxIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.receiptIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorBillNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivedByDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createdByDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChangedDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reciepts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReceiptBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecieptDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderReceiveLineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.txt_GRN);
            this.groupBox1.Controls.Add(this.txt_vendor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(477, 14);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // txt_GRN
            // 
            this.txt_GRN.Location = new System.Drawing.Point(291, 14);
            this.txt_GRN.Name = "txt_GRN";
            this.txt_GRN.Size = new System.Drawing.Size(100, 20);
            this.txt_GRN.TabIndex = 3;
            // 
            // txt_vendor
            // 
            this.txt_vendor.Location = new System.Drawing.Point(105, 14);
            this.txt_vendor.Name = "txt_vendor";
            this.txt_vendor.Size = new System.Drawing.Size(100, 20);
            this.txt_vendor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "GRN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_Reciepts);
            this.groupBox2.Location = new System.Drawing.Point(28, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reciepts";
            // 
            // dgv_Reciepts
            // 
            this.dgv_Reciepts.AutoGenerateColumns = false;
            this.dgv_Reciepts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reciepts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryReceiptID,
            this.vendorBillNumberDataGridViewTextBoxColumn,
            this.gatePassNumberDataGridViewTextBoxColumn,
            this.gRNDataGridViewTextBoxColumn,
            this.purchaseOrderIdDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.receiveDateDataGridViewTextBoxColumn,
            this.receivedByDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.isChangedDataGridViewCheckBoxColumn});
            this.dgv_Reciepts.DataSource = this.inventoryReceiptBindingSource;
            this.dgv_Reciepts.Location = new System.Drawing.Point(0, 19);
            this.dgv_Reciepts.Name = "dgv_Reciepts";
            this.dgv_Reciepts.ReadOnly = true;
            this.dgv_Reciepts.Size = new System.Drawing.Size(734, 116);
            this.dgv_Reciepts.TabIndex = 0;
            this.dgv_Reciepts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Reciepts_CellClick);
            this.dgv_Reciepts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Reciepts_CellContentClick);
            // 
            // inventoryReceiptBindingSource
            // 
            this.inventoryReceiptBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.InventoryReceipt);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_RecieptDetails);
            this.groupBox3.Location = new System.Drawing.Point(28, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(746, 192);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reciept Details";
            // 
            // dgv_RecieptDetails
            // 
            this.dgv_RecieptDetails.AllowDrop = true;
            this.dgv_RecieptDetails.AllowUserToAddRows = false;
            this.dgv_RecieptDetails.AllowUserToDeleteRows = false;
            this.dgv_RecieptDetails.AutoGenerateColumns = false;
            this.dgv_RecieptDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RecieptDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn,
            this.purchaseOrderIdDataGridViewTextBoxColumn1,
            this.productIdDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.vendorItemCodeDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.locationIdDataGridViewTextBoxColumn,
            this.isReceivedDataGridViewCheckBoxColumn,
            this.purchaseOrderLineIdDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.taxPercentageDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.taxInclusiveDataGridViewCheckBoxColumn,
            this.taxIdDataGridViewTextBoxColumn,
            this.receiptIdDataGridViewTextBoxColumn,
            this.vendorBillNumberDataGridViewTextBoxColumn1,
            this.receivedByDataGridViewTextBoxColumn1,
            this.isActiveDataGridViewCheckBoxColumn1,
            this.createdByDataGridViewTextBoxColumn1,
            this.lastUpdatedByDataGridViewTextBoxColumn1,
            this.createdDateDataGridViewTextBoxColumn1,
            this.lastUpdatedDateDataGridViewTextBoxColumn1,
            this.isChangedDataGridViewCheckBoxColumn1});
            this.dgv_RecieptDetails.DataSource = this.purchaseOrderReceiveLineBindingSource;
            this.dgv_RecieptDetails.Location = new System.Drawing.Point(6, 27);
            this.dgv_RecieptDetails.Name = "dgv_RecieptDetails";
            this.dgv_RecieptDetails.ReadOnly = true;
            this.dgv_RecieptDetails.Size = new System.Drawing.Size(734, 121);
            this.dgv_RecieptDetails.TabIndex = 1;
            this.dgv_RecieptDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_RecieptDetails_DataError);
            // 
            // purchaseOrderReceiveLineBindingSource
            // 
            this.purchaseOrderReceiveLineBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.PurchaseOrderReceiveLine);
            // 
            // InventoryReceiptID
            // 
            this.InventoryReceiptID.DataPropertyName = "InventoryReceiptID";
            this.InventoryReceiptID.HeaderText = "InventoryReceiptID";
            this.InventoryReceiptID.Name = "InventoryReceiptID";
            this.InventoryReceiptID.ReadOnly = true;
            // 
            // vendorBillNumberDataGridViewTextBoxColumn
            // 
            this.vendorBillNumberDataGridViewTextBoxColumn.DataPropertyName = "VendorBillNumber";
            this.vendorBillNumberDataGridViewTextBoxColumn.HeaderText = "VendorBillNumber";
            this.vendorBillNumberDataGridViewTextBoxColumn.Name = "vendorBillNumberDataGridViewTextBoxColumn";
            this.vendorBillNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gatePassNumberDataGridViewTextBoxColumn
            // 
            this.gatePassNumberDataGridViewTextBoxColumn.DataPropertyName = "GatePassNumber";
            this.gatePassNumberDataGridViewTextBoxColumn.HeaderText = "GatePassNumber";
            this.gatePassNumberDataGridViewTextBoxColumn.Name = "gatePassNumberDataGridViewTextBoxColumn";
            this.gatePassNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gRNDataGridViewTextBoxColumn
            // 
            this.gRNDataGridViewTextBoxColumn.DataPropertyName = "GRN";
            this.gRNDataGridViewTextBoxColumn.HeaderText = "GRN";
            this.gRNDataGridViewTextBoxColumn.Name = "gRNDataGridViewTextBoxColumn";
            this.gRNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchaseOrderIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn.Name = "purchaseOrderIdDataGridViewTextBoxColumn";
            this.purchaseOrderIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiveDateDataGridViewTextBoxColumn
            // 
            this.receiveDateDataGridViewTextBoxColumn.DataPropertyName = "ReceiveDate";
            this.receiveDateDataGridViewTextBoxColumn.HeaderText = "ReceiveDate";
            this.receiveDateDataGridViewTextBoxColumn.Name = "receiveDateDataGridViewTextBoxColumn";
            this.receiveDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receivedByDataGridViewTextBoxColumn
            // 
            this.receivedByDataGridViewTextBoxColumn.DataPropertyName = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn.HeaderText = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn.Name = "receivedByDataGridViewTextBoxColumn";
            this.receivedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.Name = "lastUpdatedByDataGridViewTextBoxColumn";
            this.lastUpdatedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isChangedDataGridViewCheckBoxColumn
            // 
            this.isChangedDataGridViewCheckBoxColumn.DataPropertyName = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.HeaderText = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.Name = "isChangedDataGridViewCheckBoxColumn";
            this.isChangedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isChangedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // purchaseOrderReceiveLineIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderReceiveLineId";
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderReceiveLineId";
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn.Name = "purchaseOrderReceiveLineIdDataGridViewTextBoxColumn";
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderReceiveLineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // purchaseOrderIdDataGridViewTextBoxColumn1
            // 
            this.purchaseOrderIdDataGridViewTextBoxColumn1.DataPropertyName = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn1.HeaderText = "PurchaseOrderId";
            this.purchaseOrderIdDataGridViewTextBoxColumn1.Name = "purchaseOrderIdDataGridViewTextBoxColumn1";
            this.purchaseOrderIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.purchaseOrderIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorItemCodeDataGridViewTextBoxColumn
            // 
            this.vendorItemCodeDataGridViewTextBoxColumn.DataPropertyName = "VendorItemCode";
            this.vendorItemCodeDataGridViewTextBoxColumn.HeaderText = "VendorItemCode";
            this.vendorItemCodeDataGridViewTextBoxColumn.Name = "vendorItemCodeDataGridViewTextBoxColumn";
            this.vendorItemCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationIdDataGridViewTextBoxColumn
            // 
            this.locationIdDataGridViewTextBoxColumn.DataPropertyName = "LocationId";
            this.locationIdDataGridViewTextBoxColumn.HeaderText = "LocationId";
            this.locationIdDataGridViewTextBoxColumn.Name = "locationIdDataGridViewTextBoxColumn";
            this.locationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.locationIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // isReceivedDataGridViewCheckBoxColumn
            // 
            this.isReceivedDataGridViewCheckBoxColumn.DataPropertyName = "IsReceived";
            this.isReceivedDataGridViewCheckBoxColumn.HeaderText = "IsReceived";
            this.isReceivedDataGridViewCheckBoxColumn.Name = "isReceivedDataGridViewCheckBoxColumn";
            this.isReceivedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // purchaseOrderLineIdDataGridViewTextBoxColumn
            // 
            this.purchaseOrderLineIdDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderLineId";
            this.purchaseOrderLineIdDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderLineId";
            this.purchaseOrderLineIdDataGridViewTextBoxColumn.Name = "purchaseOrderLineIdDataGridViewTextBoxColumn";
            this.purchaseOrderLineIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseOrderLineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxPercentageDataGridViewTextBoxColumn
            // 
            this.taxPercentageDataGridViewTextBoxColumn.DataPropertyName = "TaxPercentage";
            this.taxPercentageDataGridViewTextBoxColumn.HeaderText = "TaxPercentage";
            this.taxPercentageDataGridViewTextBoxColumn.Name = "taxPercentageDataGridViewTextBoxColumn";
            this.taxPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxInclusiveDataGridViewCheckBoxColumn
            // 
            this.taxInclusiveDataGridViewCheckBoxColumn.DataPropertyName = "TaxInclusive";
            this.taxInclusiveDataGridViewCheckBoxColumn.HeaderText = "TaxInclusive";
            this.taxInclusiveDataGridViewCheckBoxColumn.Name = "taxInclusiveDataGridViewCheckBoxColumn";
            this.taxInclusiveDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // taxIdDataGridViewTextBoxColumn
            // 
            this.taxIdDataGridViewTextBoxColumn.DataPropertyName = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.HeaderText = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.Name = "taxIdDataGridViewTextBoxColumn";
            this.taxIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.taxIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.taxIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // receiptIdDataGridViewTextBoxColumn
            // 
            this.receiptIdDataGridViewTextBoxColumn.DataPropertyName = "ReceiptId";
            this.receiptIdDataGridViewTextBoxColumn.HeaderText = "ReceiptId";
            this.receiptIdDataGridViewTextBoxColumn.Name = "receiptIdDataGridViewTextBoxColumn";
            this.receiptIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.receiptIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // vendorBillNumberDataGridViewTextBoxColumn1
            // 
            this.vendorBillNumberDataGridViewTextBoxColumn1.DataPropertyName = "VendorBillNumber";
            this.vendorBillNumberDataGridViewTextBoxColumn1.HeaderText = "VendorBillNumber";
            this.vendorBillNumberDataGridViewTextBoxColumn1.Name = "vendorBillNumberDataGridViewTextBoxColumn1";
            this.vendorBillNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // receivedByDataGridViewTextBoxColumn1
            // 
            this.receivedByDataGridViewTextBoxColumn1.DataPropertyName = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn1.HeaderText = "ReceivedBy";
            this.receivedByDataGridViewTextBoxColumn1.Name = "receivedByDataGridViewTextBoxColumn1";
            this.receivedByDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // isActiveDataGridViewCheckBoxColumn1
            // 
            this.isActiveDataGridViewCheckBoxColumn1.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn1.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn1.Name = "isActiveDataGridViewCheckBoxColumn1";
            this.isActiveDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.isActiveDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // createdByDataGridViewTextBoxColumn1
            // 
            this.createdByDataGridViewTextBoxColumn1.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn1.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn1.Name = "createdByDataGridViewTextBoxColumn1";
            this.createdByDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn1
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn1.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn1.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn1.Name = "lastUpdatedByDataGridViewTextBoxColumn1";
            this.lastUpdatedByDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lastUpdatedByDataGridViewTextBoxColumn1.Visible = false;
            // 
            // createdDateDataGridViewTextBoxColumn1
            // 
            this.createdDateDataGridViewTextBoxColumn1.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn1.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn1.Name = "createdDateDataGridViewTextBoxColumn1";
            this.createdDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn1
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn1.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn1.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn1.Name = "lastUpdatedDateDataGridViewTextBoxColumn1";
            this.lastUpdatedDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lastUpdatedDateDataGridViewTextBoxColumn1.Visible = false;
            // 
            // isChangedDataGridViewCheckBoxColumn1
            // 
            this.isChangedDataGridViewCheckBoxColumn1.DataPropertyName = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn1.HeaderText = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn1.Name = "isChangedDataGridViewCheckBoxColumn1";
            this.isChangedDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.isChangedDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // Frm_Reciepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Reciepts";
            this.Text = "Frm_Reciepts";
            this.Load += new System.EventHandler(this.Frm_Reciepts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reciepts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryReceiptBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecieptDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderReceiveLineBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_GRN;
        private System.Windows.Forms.TextBox txt_vendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_Reciepts;
        private System.Windows.Forms.BindingSource inventoryReceiptBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_RecieptDetails;
        private System.Windows.Forms.BindingSource purchaseOrderReceiveLineBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorBillNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gatePassNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gRNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChangedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderReceiveLineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorItemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn locationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReceivedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseOrderLineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxPercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taxInclusiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn taxIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorBillNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivedByDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChangedDataGridViewCheckBoxColumn1;
    }
}