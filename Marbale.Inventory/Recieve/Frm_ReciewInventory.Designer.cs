namespace Marbale.Inventory.Recieve
{
    partial class Frm_ReciewInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_receive = new System.Windows.Forms.GroupBox();
            this.lb_orderid = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_receive = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TaxPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxInclusive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequiredByDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkGrdRecieve = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtReceiptId = new System.Windows.Forms.Label();
            this.lblOrderDocumentType = new System.Windows.Forms.Label();
            this.lnkApplyTaxToAllLines = new System.Windows.Forms.LinkLabel();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_status = new System.Windows.Forms.TextBox();
            this.dt_ReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.cmb_DefaultTax = new System.Windows.Forms.ComboBox();
            this.cmb_vendor = new System.Windows.Forms.ComboBox();
            this.txt_contact = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txtGRN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_date = new System.Windows.Forms.TextBox();
            this.tb_order = new System.Windows.Forms.TextBox();
            this.txt_GatePassNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_BillNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_prodcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grd_products = new System.Windows.Forms.DataGridView();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultLocationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reorderPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reorderQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uomIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masterPackQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innerPackQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultVendorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPurchasePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isRedeemableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isSellableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPurchaseableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.priceInTicketsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outboundLocationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxInclusiveCostDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lowerLimitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperLimitCostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costVariancePercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnInPriceInTicketsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotControlledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.marketListItemDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.expiryTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuingApproachDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemMarkupPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inventoryProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Receipts = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cb_complete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.gb_receive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receive)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_products)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_receive
            // 
            this.gb_receive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_receive.BackColor = System.Drawing.Color.Transparent;
            this.gb_receive.Controls.Add(this.lb_orderid);
            this.gb_receive.Controls.Add(this.label12);
            this.gb_receive.Controls.Add(this.label1);
            this.gb_receive.Controls.Add(this.dgv_receive);
            this.gb_receive.Controls.Add(this.panel2);
            this.gb_receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_receive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gb_receive.Location = new System.Drawing.Point(355, 12);
            this.gb_receive.Name = "gb_receive";
            this.gb_receive.Size = new System.Drawing.Size(1002, 519);
            this.gb_receive.TabIndex = 18;
            this.gb_receive.TabStop = false;
            this.gb_receive.Text = "Receive Products";
            // 
            // lb_orderid
            // 
            this.lb_orderid.AutoSize = true;
            this.lb_orderid.BackColor = System.Drawing.Color.White;
            this.lb_orderid.Location = new System.Drawing.Point(438, 17);
            this.lb_orderid.Name = "lb_orderid";
            this.lb_orderid.Size = new System.Drawing.Size(81, 13);
            this.lb_orderid.TabIndex = 55;
            this.lb_orderid.Text = "Hidden Order id";
            this.lb_orderid.Visible = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(316, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "PO Date:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 481);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Remarks:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgv_receive
            // 
            this.dgv_receive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_receive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_receive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_receive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_receive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductCode,
            this.Description,
            this.Qty,
            this.Price,
            this.TaxId,
            this.TaxPercentage,
            this.TaxInclusive,
            this.Amount,
            this.RequiredByDate,
            this.chkGrdRecieve});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_receive.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_receive.GridColor = System.Drawing.Color.Khaki;
            this.dgv_receive.Location = new System.Drawing.Point(9, 198);
            this.dgv_receive.Name = "dgv_receive";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_receive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_receive.Size = new System.Drawing.Size(892, 246);
            this.dgv_receive.TabIndex = 37;
            this.dgv_receive.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_receive_CellValueChanged);
            this.dgv_receive.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_receive_DataError);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 78;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Width = 97;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 48;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.Width = 56;
            // 
            // TaxId
            // 
            this.TaxId.HeaderText = "Tax";
            this.TaxId.Name = "TaxId";
            this.TaxId.Width = 39;
            // 
            // TaxPercentage
            // 
            this.TaxPercentage.HeaderText = "Tax %";
            this.TaxPercentage.Name = "TaxPercentage";
            this.TaxPercentage.ReadOnly = true;
            this.TaxPercentage.Width = 61;
            // 
            // TaxInclusive
            // 
            this.TaxInclusive.FalseValue = "N";
            this.TaxInclusive.HeaderText = "Tax Incl";
            this.TaxInclusive.Name = "TaxInclusive";
            this.TaxInclusive.TrueValue = "Y";
            this.TaxInclusive.Width = 51;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Amount.Width = 49;
            // 
            // RequiredByDate
            // 
            this.RequiredByDate.HeaderText = "Required Date";
            this.RequiredByDate.Name = "RequiredByDate";
            this.RequiredByDate.ReadOnly = true;
            this.RequiredByDate.Width = 101;
            // 
            // chkGrdRecieve
            // 
            this.chkGrdRecieve.HeaderText = "Recieve";
            this.chkGrdRecieve.Name = "chkGrdRecieve";
            this.chkGrdRecieve.Width = 53;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txt_Address);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtReceiptId);
            this.panel2.Controls.Add(this.lblOrderDocumentType);
            this.panel2.Controls.Add(this.lnkApplyTaxToAllLines);
            this.panel2.Controls.Add(this.txt_total);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.tb_status);
            this.panel2.Controls.Add(this.dt_ReceiveDate);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.cmb_DefaultTax);
            this.panel2.Controls.Add(this.cmb_vendor);
            this.panel2.Controls.Add(this.txt_contact);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txt_phone);
            this.panel2.Controls.Add(this.txtGRN);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.tb_date);
            this.panel2.Controls.Add(this.tb_order);
            this.panel2.Controls.Add(this.txt_GatePassNo);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txt_BillNo);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 498);
            this.panel2.TabIndex = 34;
            // 
            // txtReceiptId
            // 
            this.txtReceiptId.AutoSize = true;
            this.txtReceiptId.Location = new System.Drawing.Point(38, 103);
            this.txtReceiptId.Name = "txtReceiptId";
            this.txtReceiptId.Size = new System.Drawing.Size(0, 13);
            this.txtReceiptId.TabIndex = 78;
            this.txtReceiptId.Visible = false;
            // 
            // lblOrderDocumentType
            // 
            this.lblOrderDocumentType.AutoSize = true;
            this.lblOrderDocumentType.Location = new System.Drawing.Point(37, 139);
            this.lblOrderDocumentType.Name = "lblOrderDocumentType";
            this.lblOrderDocumentType.Size = new System.Drawing.Size(0, 13);
            this.lblOrderDocumentType.TabIndex = 77;
            this.lblOrderDocumentType.Visible = false;
            // 
            // lnkApplyTaxToAllLines
            // 
            this.lnkApplyTaxToAllLines.AutoSize = true;
            this.lnkApplyTaxToAllLines.Location = new System.Drawing.Point(658, 167);
            this.lnkApplyTaxToAllLines.Name = "lnkApplyTaxToAllLines";
            this.lnkApplyTaxToAllLines.Size = new System.Drawing.Size(86, 13);
            this.lnkApplyTaxToAllLines.TabIndex = 33;
            this.lnkApplyTaxToAllLines.TabStop = true;
            this.lnkApplyTaxToAllLines.Text = "Apply to all Lines";
            this.lnkApplyTaxToAllLines.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkApplyTaxToAllLines_LinkClicked);
            // 
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(642, 438);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(102, 20);
            this.txt_total.TabIndex = 73;
            this.txt_total.Text = "0";
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(550, 441);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 13);
            this.label20.TabIndex = 72;
            this.label20.Text = "Total:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(313, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 13);
            this.label18.TabIndex = 57;
            this.label18.Text = "Status:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_status
            // 
            this.tb_status.Enabled = false;
            this.tb_status.Location = new System.Drawing.Point(388, 66);
            this.tb_status.Name = "tb_status";
            this.tb_status.ReadOnly = true;
            this.tb_status.Size = new System.Drawing.Size(83, 20);
            this.tb_status.TabIndex = 27;
            // 
            // dt_ReceiveDate
            // 
            this.dt_ReceiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dt_ReceiveDate.Enabled = false;
            this.dt_ReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_ReceiveDate.Location = new System.Drawing.Point(627, 15);
            this.dt_ReceiveDate.Name = "dt_ReceiveDate";
            this.dt_ReceiveDate.Size = new System.Drawing.Size(117, 20);
            this.dt_ReceiveDate.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(531, 127);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 70;
            this.label19.Text = "Default Tax:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_DefaultTax
            // 
            this.cmb_DefaultTax.DisplayMember = "TaxName";
            this.cmb_DefaultTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DefaultTax.FormattingEnabled = true;
            this.cmb_DefaultTax.Location = new System.Drawing.Point(627, 124);
            this.cmb_DefaultTax.Name = "cmb_DefaultTax";
            this.cmb_DefaultTax.Size = new System.Drawing.Size(117, 21);
            this.cmb_DefaultTax.TabIndex = 32;
            this.cmb_DefaultTax.ValueMember = "TaxId";
            // 
            // cmb_vendor
            // 
            this.cmb_vendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_vendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_vendor.DisplayMember = "VendorId";
            this.cmb_vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_vendor.FormattingEnabled = true;
            this.cmb_vendor.Location = new System.Drawing.Point(82, 14);
            this.cmb_vendor.Name = "cmb_vendor";
            this.cmb_vendor.Size = new System.Drawing.Size(189, 21);
            this.cmb_vendor.TabIndex = 19;
            this.cmb_vendor.ValueMember = "VendorId";
            this.cmb_vendor.SelectedIndexChanged += new System.EventHandler(this.cmb_vendor_SelectedIndexChanged);
            // 
            // txt_contact
            // 
            this.txt_contact.Enabled = false;
            this.txt_contact.Location = new System.Drawing.Point(82, 39);
            this.txt_contact.Name = "txt_contact";
            this.txt_contact.ReadOnly = true;
            this.txt_contact.Size = new System.Drawing.Size(189, 20);
            this.txt_contact.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(531, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 63;
            this.label13.Text = "Receipt Date:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_phone
            // 
            this.txt_phone.Enabled = false;
            this.txt_phone.Location = new System.Drawing.Point(82, 66);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.ReadOnly = true;
            this.txt_phone.Size = new System.Drawing.Size(189, 20);
            this.txt_phone.TabIndex = 23;
            // 
            // txtGRN
            // 
            this.txtGRN.Location = new System.Drawing.Point(627, 41);
            this.txtGRN.Name = "txtGRN";
            this.txtGRN.ReadOnly = true;
            this.txtGRN.Size = new System.Drawing.Size(117, 20);
            this.txtGRN.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(531, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 13);
            this.label16.TabIndex = 61;
            this.label16.Text = "GRN:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_date
            // 
            this.tb_date.Enabled = false;
            this.tb_date.Location = new System.Drawing.Point(388, 39);
            this.tb_date.Name = "tb_date";
            this.tb_date.ReadOnly = true;
            this.tb_date.Size = new System.Drawing.Size(83, 20);
            this.tb_date.TabIndex = 26;
            // 
            // tb_order
            // 
            this.tb_order.Enabled = false;
            this.tb_order.Location = new System.Drawing.Point(388, 14);
            this.tb_order.Name = "tb_order";
            this.tb_order.ReadOnly = true;
            this.tb_order.Size = new System.Drawing.Size(83, 20);
            this.tb_order.TabIndex = 25;
            // 
            // txt_GatePassNo
            // 
            this.txt_GatePassNo.Location = new System.Drawing.Point(627, 70);
            this.txt_GatePassNo.Name = "txt_GatePassNo";
            this.txt_GatePassNo.Size = new System.Drawing.Size(117, 20);
            this.txt_GatePassNo.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(531, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 13);
            this.label15.TabIndex = 59;
            this.label15.Text = "Gate Pass No:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_BillNo
            // 
            this.txt_BillNo.Location = new System.Drawing.Point(627, 96);
            this.txt_BillNo.Name = "txt_BillNo";
            this.txt_BillNo.Size = new System.Drawing.Size(117, 20);
            this.txt_BillNo.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(527, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "Bill / Invoice No:*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(313, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Order #:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Vendor:*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(7, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Phone:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(7, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Contact:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_search);
            this.groupBox1.Controls.Add(this.txt_prodcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.grd_products);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 512);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Products";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_search.Location = new System.Drawing.Point(214, 443);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(95, 23);
            this.btn_search.TabIndex = 20;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // txt_prodcode
            // 
            this.txt_prodcode.Location = new System.Drawing.Point(91, 417);
            this.txt_prodcode.Name = "txt_prodcode";
            this.txt_prodcode.Size = new System.Drawing.Size(218, 20);
            this.txt_prodcode.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Product Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grd_products
            // 
            this.grd_products.AutoGenerateColumns = false;
            this.grd_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_products.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.remarksDataGridViewTextBoxColumn,
            this.categoryIdDataGridViewTextBoxColumn,
            this.defaultLocationIdDataGridViewTextBoxColumn,
            this.reorderPointDataGridViewTextBoxColumn,
            this.reorderQuantityDataGridViewTextBoxColumn,
            this.uomIdDataGridViewTextBoxColumn,
            this.masterPackQtyDataGridViewTextBoxColumn,
            this.innerPackQtyDataGridViewTextBoxColumn,
            this.defaultVendorIdDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn,
            this.lastPurchasePriceDataGridViewTextBoxColumn,
            this.isRedeemableDataGridViewCheckBoxColumn,
            this.isSellableDataGridViewCheckBoxColumn,
            this.isPurchaseableDataGridViewCheckBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.priceInTicketsDataGridViewTextBoxColumn,
            this.outboundLocationIdDataGridViewTextBoxColumn,
            this.salePriceDataGridViewTextBoxColumn,
            this.taxIdDataGridViewTextBoxColumn,
            this.taxInclusiveCostDataGridViewCheckBoxColumn,
            this.lowerLimitCostDataGridViewTextBoxColumn,
            this.upperLimitCostDataGridViewTextBoxColumn,
            this.costVariancePercentageDataGridViewTextBoxColumn,
            this.turnInPriceInTicketsDataGridViewTextBoxColumn,
            this.lotControlledDataGridViewCheckBoxColumn,
            this.marketListItemDataGridViewCheckBoxColumn,
            this.expiryTypeDataGridViewTextBoxColumn,
            this.issuingApproachDataGridViewTextBoxColumn,
            this.expiryDaysDataGridViewTextBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.itemMarkupPercentDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.isChangedDataGridViewCheckBoxColumn});
            this.grd_products.DataSource = this.inventoryProductBindingSource;
            this.grd_products.Location = new System.Drawing.Point(6, 24);
            this.grd_products.Name = "grd_products";
            this.grd_products.Size = new System.Drawing.Size(303, 384);
            this.grd_products.TabIndex = 0;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // remarksDataGridViewTextBoxColumn
            // 
            this.remarksDataGridViewTextBoxColumn.DataPropertyName = "Remarks";
            this.remarksDataGridViewTextBoxColumn.HeaderText = "Remarks";
            this.remarksDataGridViewTextBoxColumn.Name = "remarksDataGridViewTextBoxColumn";
            this.remarksDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            this.categoryIdDataGridViewTextBoxColumn.DataPropertyName = "CategoryId";
            this.categoryIdDataGridViewTextBoxColumn.HeaderText = "CategoryId";
            this.categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            this.categoryIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // defaultLocationIdDataGridViewTextBoxColumn
            // 
            this.defaultLocationIdDataGridViewTextBoxColumn.DataPropertyName = "DefaultLocationId";
            this.defaultLocationIdDataGridViewTextBoxColumn.HeaderText = "DefaultLocationId";
            this.defaultLocationIdDataGridViewTextBoxColumn.Name = "defaultLocationIdDataGridViewTextBoxColumn";
            this.defaultLocationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // reorderPointDataGridViewTextBoxColumn
            // 
            this.reorderPointDataGridViewTextBoxColumn.DataPropertyName = "ReorderPoint";
            this.reorderPointDataGridViewTextBoxColumn.HeaderText = "ReorderPoint";
            this.reorderPointDataGridViewTextBoxColumn.Name = "reorderPointDataGridViewTextBoxColumn";
            this.reorderPointDataGridViewTextBoxColumn.Visible = false;
            // 
            // reorderQuantityDataGridViewTextBoxColumn
            // 
            this.reorderQuantityDataGridViewTextBoxColumn.DataPropertyName = "ReorderQuantity";
            this.reorderQuantityDataGridViewTextBoxColumn.HeaderText = "ReorderQuantity";
            this.reorderQuantityDataGridViewTextBoxColumn.Name = "reorderQuantityDataGridViewTextBoxColumn";
            this.reorderQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // uomIdDataGridViewTextBoxColumn
            // 
            this.uomIdDataGridViewTextBoxColumn.DataPropertyName = "UomId";
            this.uomIdDataGridViewTextBoxColumn.HeaderText = "UomId";
            this.uomIdDataGridViewTextBoxColumn.Name = "uomIdDataGridViewTextBoxColumn";
            this.uomIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // masterPackQtyDataGridViewTextBoxColumn
            // 
            this.masterPackQtyDataGridViewTextBoxColumn.DataPropertyName = "MasterPackQty";
            this.masterPackQtyDataGridViewTextBoxColumn.HeaderText = "MasterPackQty";
            this.masterPackQtyDataGridViewTextBoxColumn.Name = "masterPackQtyDataGridViewTextBoxColumn";
            this.masterPackQtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // innerPackQtyDataGridViewTextBoxColumn
            // 
            this.innerPackQtyDataGridViewTextBoxColumn.DataPropertyName = "InnerPackQty";
            this.innerPackQtyDataGridViewTextBoxColumn.HeaderText = "InnerPackQty";
            this.innerPackQtyDataGridViewTextBoxColumn.Name = "innerPackQtyDataGridViewTextBoxColumn";
            this.innerPackQtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // defaultVendorIdDataGridViewTextBoxColumn
            // 
            this.defaultVendorIdDataGridViewTextBoxColumn.DataPropertyName = "DefaultVendorId";
            this.defaultVendorIdDataGridViewTextBoxColumn.HeaderText = "DefaultVendorId";
            this.defaultVendorIdDataGridViewTextBoxColumn.Name = "defaultVendorIdDataGridViewTextBoxColumn";
            this.defaultVendorIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            this.costDataGridViewTextBoxColumn.HeaderText = "Cost";
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            this.costDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastPurchasePriceDataGridViewTextBoxColumn
            // 
            this.lastPurchasePriceDataGridViewTextBoxColumn.DataPropertyName = "LastPurchasePrice";
            this.lastPurchasePriceDataGridViewTextBoxColumn.HeaderText = "LastPurchasePrice";
            this.lastPurchasePriceDataGridViewTextBoxColumn.Name = "lastPurchasePriceDataGridViewTextBoxColumn";
            this.lastPurchasePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // isRedeemableDataGridViewCheckBoxColumn
            // 
            this.isRedeemableDataGridViewCheckBoxColumn.DataPropertyName = "IsRedeemable";
            this.isRedeemableDataGridViewCheckBoxColumn.HeaderText = "IsRedeemable";
            this.isRedeemableDataGridViewCheckBoxColumn.Name = "isRedeemableDataGridViewCheckBoxColumn";
            this.isRedeemableDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isSellableDataGridViewCheckBoxColumn
            // 
            this.isSellableDataGridViewCheckBoxColumn.DataPropertyName = "IsSellable";
            this.isSellableDataGridViewCheckBoxColumn.HeaderText = "IsSellable";
            this.isSellableDataGridViewCheckBoxColumn.Name = "isSellableDataGridViewCheckBoxColumn";
            this.isSellableDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isPurchaseableDataGridViewCheckBoxColumn
            // 
            this.isPurchaseableDataGridViewCheckBoxColumn.DataPropertyName = "IsPurchaseable";
            this.isPurchaseableDataGridViewCheckBoxColumn.HeaderText = "IsPurchaseable";
            this.isPurchaseableDataGridViewCheckBoxColumn.Name = "isPurchaseableDataGridViewCheckBoxColumn";
            this.isPurchaseableDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.Visible = false;
            // 
            // priceInTicketsDataGridViewTextBoxColumn
            // 
            this.priceInTicketsDataGridViewTextBoxColumn.DataPropertyName = "PriceInTickets";
            this.priceInTicketsDataGridViewTextBoxColumn.HeaderText = "PriceInTickets";
            this.priceInTicketsDataGridViewTextBoxColumn.Name = "priceInTicketsDataGridViewTextBoxColumn";
            this.priceInTicketsDataGridViewTextBoxColumn.Visible = false;
            // 
            // outboundLocationIdDataGridViewTextBoxColumn
            // 
            this.outboundLocationIdDataGridViewTextBoxColumn.DataPropertyName = "OutboundLocationId";
            this.outboundLocationIdDataGridViewTextBoxColumn.HeaderText = "OutboundLocationId";
            this.outboundLocationIdDataGridViewTextBoxColumn.Name = "outboundLocationIdDataGridViewTextBoxColumn";
            this.outboundLocationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            this.salePriceDataGridViewTextBoxColumn.DataPropertyName = "SalePrice";
            this.salePriceDataGridViewTextBoxColumn.HeaderText = "SalePrice";
            this.salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            this.salePriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // taxIdDataGridViewTextBoxColumn
            // 
            this.taxIdDataGridViewTextBoxColumn.DataPropertyName = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.HeaderText = "TaxId";
            this.taxIdDataGridViewTextBoxColumn.Name = "taxIdDataGridViewTextBoxColumn";
            this.taxIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // taxInclusiveCostDataGridViewCheckBoxColumn
            // 
            this.taxInclusiveCostDataGridViewCheckBoxColumn.DataPropertyName = "TaxInclusiveCost";
            this.taxInclusiveCostDataGridViewCheckBoxColumn.HeaderText = "TaxInclusiveCost";
            this.taxInclusiveCostDataGridViewCheckBoxColumn.Name = "taxInclusiveCostDataGridViewCheckBoxColumn";
            this.taxInclusiveCostDataGridViewCheckBoxColumn.Visible = false;
            // 
            // lowerLimitCostDataGridViewTextBoxColumn
            // 
            this.lowerLimitCostDataGridViewTextBoxColumn.DataPropertyName = "LowerLimitCost";
            this.lowerLimitCostDataGridViewTextBoxColumn.HeaderText = "LowerLimitCost";
            this.lowerLimitCostDataGridViewTextBoxColumn.Name = "lowerLimitCostDataGridViewTextBoxColumn";
            this.lowerLimitCostDataGridViewTextBoxColumn.Visible = false;
            // 
            // upperLimitCostDataGridViewTextBoxColumn
            // 
            this.upperLimitCostDataGridViewTextBoxColumn.DataPropertyName = "UpperLimitCost";
            this.upperLimitCostDataGridViewTextBoxColumn.HeaderText = "UpperLimitCost";
            this.upperLimitCostDataGridViewTextBoxColumn.Name = "upperLimitCostDataGridViewTextBoxColumn";
            this.upperLimitCostDataGridViewTextBoxColumn.Visible = false;
            // 
            // costVariancePercentageDataGridViewTextBoxColumn
            // 
            this.costVariancePercentageDataGridViewTextBoxColumn.DataPropertyName = "CostVariancePercentage";
            this.costVariancePercentageDataGridViewTextBoxColumn.HeaderText = "CostVariancePercentage";
            this.costVariancePercentageDataGridViewTextBoxColumn.Name = "costVariancePercentageDataGridViewTextBoxColumn";
            this.costVariancePercentageDataGridViewTextBoxColumn.Visible = false;
            // 
            // turnInPriceInTicketsDataGridViewTextBoxColumn
            // 
            this.turnInPriceInTicketsDataGridViewTextBoxColumn.DataPropertyName = "TurnInPriceInTickets";
            this.turnInPriceInTicketsDataGridViewTextBoxColumn.HeaderText = "TurnInPriceInTickets";
            this.turnInPriceInTicketsDataGridViewTextBoxColumn.Name = "turnInPriceInTicketsDataGridViewTextBoxColumn";
            this.turnInPriceInTicketsDataGridViewTextBoxColumn.Visible = false;
            // 
            // lotControlledDataGridViewCheckBoxColumn
            // 
            this.lotControlledDataGridViewCheckBoxColumn.DataPropertyName = "LotControlled";
            this.lotControlledDataGridViewCheckBoxColumn.HeaderText = "LotControlled";
            this.lotControlledDataGridViewCheckBoxColumn.Name = "lotControlledDataGridViewCheckBoxColumn";
            this.lotControlledDataGridViewCheckBoxColumn.Visible = false;
            // 
            // marketListItemDataGridViewCheckBoxColumn
            // 
            this.marketListItemDataGridViewCheckBoxColumn.DataPropertyName = "MarketListItem";
            this.marketListItemDataGridViewCheckBoxColumn.HeaderText = "MarketListItem";
            this.marketListItemDataGridViewCheckBoxColumn.Name = "marketListItemDataGridViewCheckBoxColumn";
            this.marketListItemDataGridViewCheckBoxColumn.Visible = false;
            // 
            // expiryTypeDataGridViewTextBoxColumn
            // 
            this.expiryTypeDataGridViewTextBoxColumn.DataPropertyName = "ExpiryType";
            this.expiryTypeDataGridViewTextBoxColumn.HeaderText = "ExpiryType";
            this.expiryTypeDataGridViewTextBoxColumn.Name = "expiryTypeDataGridViewTextBoxColumn";
            this.expiryTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // issuingApproachDataGridViewTextBoxColumn
            // 
            this.issuingApproachDataGridViewTextBoxColumn.DataPropertyName = "IssuingApproach";
            this.issuingApproachDataGridViewTextBoxColumn.HeaderText = "IssuingApproach";
            this.issuingApproachDataGridViewTextBoxColumn.Name = "issuingApproachDataGridViewTextBoxColumn";
            this.issuingApproachDataGridViewTextBoxColumn.Visible = false;
            // 
            // expiryDaysDataGridViewTextBoxColumn
            // 
            this.expiryDaysDataGridViewTextBoxColumn.DataPropertyName = "ExpiryDays";
            this.expiryDaysDataGridViewTextBoxColumn.HeaderText = "ExpiryDays";
            this.expiryDaysDataGridViewTextBoxColumn.Name = "expiryDaysDataGridViewTextBoxColumn";
            this.expiryDaysDataGridViewTextBoxColumn.Visible = false;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "BarCode";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "BarCode";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemMarkupPercentDataGridViewTextBoxColumn
            // 
            this.itemMarkupPercentDataGridViewTextBoxColumn.DataPropertyName = "ItemMarkupPercent";
            this.itemMarkupPercentDataGridViewTextBoxColumn.HeaderText = "ItemMarkupPercent";
            this.itemMarkupPercentDataGridViewTextBoxColumn.Name = "itemMarkupPercentDataGridViewTextBoxColumn";
            this.itemMarkupPercentDataGridViewTextBoxColumn.Visible = false;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.Name = "lastUpdatedByDataGridViewTextBoxColumn";
            this.lastUpdatedByDataGridViewTextBoxColumn.Visible = false;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // isChangedDataGridViewCheckBoxColumn
            // 
            this.isChangedDataGridViewCheckBoxColumn.DataPropertyName = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.HeaderText = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.Name = "isChangedDataGridViewCheckBoxColumn";
            this.isChangedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // inventoryProductBindingSource
            // 
            this.inventoryProductBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.InventoryProduct);
            // 
            // btn_Receipts
            // 
            this.btn_Receipts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Receipts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Receipts.Location = new System.Drawing.Point(355, 547);
            this.btn_Receipts.Name = "btn_Receipts";
            this.btn_Receipts.Size = new System.Drawing.Size(121, 23);
            this.btn_Receipts.TabIndex = 44;
            this.btn_Receipts.Text = "View Receipts";
            this.btn_Receipts.UseVisualStyleBackColor = true;
            this.btn_Receipts.Click += new System.EventHandler(this.btn_Receipts_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(493, 547);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 23);
            this.btnRefresh.TabIndex = 46;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cb_complete
            // 
            this.cb_complete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_complete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cb_complete.Location = new System.Drawing.Point(609, 547);
            this.cb_complete.Name = "cb_complete";
            this.cb_complete.Size = new System.Drawing.Size(86, 23);
            this.cb_complete.TabIndex = 45;
            this.cb_complete.Text = "Complete";
            this.cb_complete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(713, 547);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(82, 96);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(189, 49);
            this.txt_Address.TabIndex = 80;
            // 
            // Frm_ReciewInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 595);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cb_complete);
            this.Controls.Add(this.btn_Receipts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_receive);
            this.Name = "Frm_ReciewInventory";
            this.Text = "Frm_ReciewInventory";
            this.Load += new System.EventHandler(this.Frm_ReciewInventory_Load);
            this.gb_receive.ResumeLayout(false);
            this.gb_receive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_receive)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_products)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryProductBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gb_receive;
        private System.Windows.Forms.Label lb_orderid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_receive;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtReceiptId;
        private System.Windows.Forms.Label lblOrderDocumentType;
        private System.Windows.Forms.LinkLabel lnkApplyTaxToAllLines;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_status;
        private System.Windows.Forms.DateTimePicker dt_ReceiveDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmb_DefaultTax;
        private System.Windows.Forms.ComboBox cmb_vendor;
        private System.Windows.Forms.TextBox txt_contact;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txtGRN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_date;
        private System.Windows.Forms.TextBox tb_order;
        private System.Windows.Forms.TextBox txt_GatePassNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_BillNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grd_products;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultLocationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reorderPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reorderQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uomIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterPackQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerPackQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultVendorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPurchasePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isRedeemableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSellableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPurchaseableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceInTicketsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outboundLocationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn taxInclusiveCostDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowerLimitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn upperLimitCostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costVariancePercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnInPriceInTicketsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lotControlledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn marketListItemDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuingApproachDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemMarkupPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChangedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource inventoryProductBindingSource;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_prodcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Receipts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button cb_complete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewComboBoxColumn TaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxPercentage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TaxInclusive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequiredByDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkGrdRecieve;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label3;
    }
}