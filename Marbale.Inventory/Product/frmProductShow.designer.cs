namespace Marbale.Inventory.Product
{
    partial class Frm_AddProduct
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
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_duplicate = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.BOMEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditBOM = new System.Windows.Forms.ToolStripMenuItem();
            this.EditProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cb_printBOM = new System.Windows.Forms.Button();
            this.productBarcodebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_remarks = new System.Windows.Forms.RichTextBox();
            this.lb_productid = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_SalePrice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Variance = new System.Windows.Forms.TextBox();
            this.txt_UpperCostLimit = new System.Windows.Forms.TextBox();
            this.txt_LowerCostLimit = new System.Windows.Forms.TextBox();
            this.txt_InnerCostUnit = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_lastpurchaseprice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_IsSellable = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chk_Purchaseable = new System.Windows.Forms.CheckBox();
            this.gb_add = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_IsRedeemable = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnUPCBarcode = new System.Windows.Forms.Button();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.btnAddUOM = new System.Windows.Forms.Button();
            this.cmbUOM = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkTaxInclusiveCost = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAddTax = new System.Windows.Forms.Button();
            this.cmbTax = new System.Windows.Forms.ComboBox();
            this.cmb_OutboundLocation = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGenerateBarCode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_addvendor = new System.Windows.Forms.Button();
            this.btn_addlocation = new System.Windows.Forms.Button();
            this.btn_addcategory = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_pTicket = new System.Windows.Forms.TextBox();
            this.cmb_Vendor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_InboundLocation = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_reorderquantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReorderpoint = new System.Windows.Forms.TextBox();
            this.cmb_category = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uOMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).BeginInit();
            this.BOMEditMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBarcodebindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb_add.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            // 
            // uOMBindingSource
            // 
            this.uOMBindingSource.DataMember = "UOM";
            // 
            // taxBindingSource
            // 
            this.taxBindingSource.DataMember = "TaxLookupWithNull";
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_exit.Location = new System.Drawing.Point(303, 482);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(97, 23);
            this.btn_exit.TabIndex = 31;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.cb_exit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.CausesValidation = false;
            this.btn_delete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_delete.Enabled = false;
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(400, 482);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(97, 23);
            this.btn_delete.TabIndex = 36;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Visible = false;
            // 
            // btn_duplicate
            // 
            this.btn_duplicate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_duplicate.Location = new System.Drawing.Point(206, 482);
            this.btn_duplicate.Name = "btn_duplicate";
            this.btn_duplicate.Size = new System.Drawing.Size(97, 23);
            this.btn_duplicate.TabIndex = 32;
            this.btn_duplicate.Text = "Duplicate";
            this.btn_duplicate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_duplicate.UseVisualStyleBackColor = true;
            this.btn_duplicate.Click += new System.EventHandler(this.cb_duplicate_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(109, 482);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(97, 23);
            this.btn_Save.TabIndex = 34;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.cb_update_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(12, 482);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(97, 23);
            this.btn_Add.TabIndex = 33;
            this.btn_Add.Text = "New";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // BOMEditMenu
            // 
            this.BOMEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBOM,
            this.EditProduct,
            this.Add,
            this.Remove,
            this.toolStripSeparator1,
            this.menuRefresh});
            this.BOMEditMenu.Name = "BOMEditMenu";
            this.BOMEditMenu.Size = new System.Drawing.Size(140, 120);
            // 
            // EditBOM
            // 
            this.EditBOM.Name = "EditBOM";
            this.EditBOM.Size = new System.Drawing.Size(139, 22);
            this.EditBOM.Text = "Edit BOM";
            // 
            // EditProduct
            // 
            this.EditProduct.Name = "EditProduct";
            this.EditProduct.Size = new System.Drawing.Size(139, 22);
            this.EditProduct.Text = "Edit Product";
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(139, 22);
            this.Add.Text = "Add Child";
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(139, 22);
            this.Remove.Text = "Remove";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // menuRefresh
            // 
            this.menuRefresh.Name = "menuRefresh";
            this.menuRefresh.Size = new System.Drawing.Size(139, 22);
            this.menuRefresh.Text = "Refresh";
            // 
            // btnEdit
            // 
            this.btnEdit.CausesValidation = false;
            this.btnEdit.Location = new System.Drawing.Point(972, 552);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 25);
            this.btnEdit.TabIndex = 39;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.CausesValidation = false;
            this.btnAdd.Location = new System.Drawing.Point(1025, 552);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 25);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.CausesValidation = false;
            this.btnRemove.Location = new System.Drawing.Point(1078, 552);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 25);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // cb_printBOM
            // 
            this.cb_printBOM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_printBOM.Location = new System.Drawing.Point(1132, 552);
            this.cb_printBOM.Name = "cb_printBOM";
            this.cb_printBOM.Size = new System.Drawing.Size(30, 25);
            this.cb_printBOM.TabIndex = 42;
            this.cb_printBOM.UseVisualStyleBackColor = true;
            // 
            // productBarcodebindingSource
            // 
            this.productBarcodebindingSource.DataMember = "ProductBarcode";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Enabled = false;
            this.btn_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Refresh.Location = new System.Drawing.Point(497, 482);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(97, 23);
            this.btn_Refresh.TabIndex = 43;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Visible = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(15, 406);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Remarks:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_remarks
            // 
            this.tb_remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_remarks.Location = new System.Drawing.Point(74, 408);
            this.tb_remarks.Multiline = false;
            this.tb_remarks.Name = "tb_remarks";
            this.tb_remarks.Size = new System.Drawing.Size(590, 20);
            this.tb_remarks.TabIndex = 11;
            this.tb_remarks.Text = "";
            // 
            // lb_productid
            // 
            this.lb_productid.AutoSize = true;
            this.lb_productid.Location = new System.Drawing.Point(115, 22);
            this.lb_productid.Name = "lb_productid";
            this.lb_productid.Size = new System.Drawing.Size(0, 13);
            this.lb_productid.TabIndex = 36;
            this.lb_productid.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_SalePrice);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txt_Variance);
            this.groupBox1.Controls.Add(this.txt_UpperCostLimit);
            this.groupBox1.Controls.Add(this.txt_LowerCostLimit);
            this.groupBox1.Controls.Add(this.txt_InnerCostUnit);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txt_cost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_lastpurchaseprice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(8, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 97);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Costing";
            // 
            // txt_SalePrice
            // 
            this.txt_SalePrice.Location = new System.Drawing.Point(616, 14);
            this.txt_SalePrice.Name = "txt_SalePrice";
            this.txt_SalePrice.Size = new System.Drawing.Size(66, 20);
            this.txt_SalePrice.TabIndex = 70;
            this.txt_SalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(540, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 13);
            this.label18.TabIndex = 71;
            this.label18.Text = "Sale Price:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(177, 44);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 13);
            this.label24.TabIndex = 69;
            this.label24.Text = "Upper Cost Limit:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(177, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 68;
            this.label23.Text = "Lower Cost Limit:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(343, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 15);
            this.label22.TabIndex = 67;
            this.label22.Text = "Variance %";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Variance
            // 
            this.txt_Variance.Location = new System.Drawing.Point(437, 14);
            this.txt_Variance.Name = "txt_Variance";
            this.txt_Variance.Size = new System.Drawing.Size(66, 20);
            this.txt_Variance.TabIndex = 16;
            this.txt_Variance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_UpperCostLimit
            // 
            this.txt_UpperCostLimit.Location = new System.Drawing.Point(266, 40);
            this.txt_UpperCostLimit.Name = "txt_UpperCostLimit";
            this.txt_UpperCostLimit.Size = new System.Drawing.Size(66, 20);
            this.txt_UpperCostLimit.TabIndex = 15;
            this.txt_UpperCostLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_LowerCostLimit
            // 
            this.txt_LowerCostLimit.Location = new System.Drawing.Point(266, 14);
            this.txt_LowerCostLimit.Name = "txt_LowerCostLimit";
            this.txt_LowerCostLimit.Size = new System.Drawing.Size(66, 20);
            this.txt_LowerCostLimit.TabIndex = 14;
            this.txt_LowerCostLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_InnerCostUnit
            // 
            this.txt_InnerCostUnit.Location = new System.Drawing.Point(97, 14);
            this.txt_InnerCostUnit.Name = "txt_InnerCostUnit";
            this.txt_InnerCostUnit.Size = new System.Drawing.Size(66, 20);
            this.txt_InnerCostUnit.TabIndex = 11;
            this.txt_InnerCostUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(14, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 13);
            this.label21.TabIndex = 63;
            this.label21.Text = "Inner Cost Unit:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_cost
            // 
            this.txt_cost.Location = new System.Drawing.Point(97, 40);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.Size = new System.Drawing.Size(66, 20);
            this.txt_cost.TabIndex = 13;
            this.txt_cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(63, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cost:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_lastpurchaseprice
            // 
            this.tb_lastpurchaseprice.Location = new System.Drawing.Point(437, 40);
            this.tb_lastpurchaseprice.Name = "tb_lastpurchaseprice";
            this.tb_lastpurchaseprice.ReadOnly = true;
            this.tb_lastpurchaseprice.Size = new System.Drawing.Size(66, 20);
            this.tb_lastpurchaseprice.TabIndex = 17;
            this.tb_lastpurchaseprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(343, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Last Purch Price:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_IsSellable
            // 
            this.chk_IsSellable.Location = new System.Drawing.Point(817, 100);
            this.chk_IsSellable.Name = "chk_IsSellable";
            this.chk_IsSellable.Size = new System.Drawing.Size(16, 21);
            this.chk_IsSellable.TabIndex = 43;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(757, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 44;
            this.label17.Text = "Sellable?";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_Purchaseable
            // 
            this.chk_Purchaseable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_Purchaseable.Checked = true;
            this.chk_Purchaseable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Purchaseable.Location = new System.Drawing.Point(739, 127);
            this.chk_Purchaseable.Name = "chk_Purchaseable";
            this.chk_Purchaseable.Size = new System.Drawing.Size(93, 19);
            this.chk_Purchaseable.TabIndex = 27;
            this.chk_Purchaseable.Text = "Inventory Item?:";
            this.chk_Purchaseable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_Purchaseable.UseVisualStyleBackColor = true;
            // 
            // gb_add
            // 
            this.gb_add.BackColor = System.Drawing.Color.Transparent;
            this.gb_add.Controls.Add(this.groupBox3);
            this.gb_add.Controls.Add(this.groupBox1);
            this.gb_add.Controls.Add(this.tb_remarks);
            this.gb_add.Controls.Add(this.label12);
            this.gb_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_add.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gb_add.Location = new System.Drawing.Point(12, 12);
            this.gb_add.Name = "gb_add";
            this.gb_add.Size = new System.Drawing.Size(945, 451);
            this.gb_add.TabIndex = 4;
            this.gb_add.TabStop = false;
            this.gb_add.Text = "Maintain Products";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chk_IsRedeemable);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtCode);
            this.groupBox3.Controls.Add(this.btnUPCBarcode);
            this.groupBox3.Controls.Add(this.lb_productid);
            this.groupBox3.Controls.Add(this.tb_barcode);
            this.groupBox3.Controls.Add(this.lblActive);
            this.groupBox3.Controls.Add(this.chk_IsSellable);
            this.groupBox3.Controls.Add(this.chk_active);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.btnAddUOM);
            this.groupBox3.Controls.Add(this.chk_Purchaseable);
            this.groupBox3.Controls.Add(this.cmbUOM);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.chkTaxInclusiveCost);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.btnAddTax);
            this.groupBox3.Controls.Add(this.cmbTax);
            this.groupBox3.Controls.Add(this.cmb_OutboundLocation);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.btnGenerateBarCode);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btn_addvendor);
            this.groupBox3.Controls.Add(this.btn_addlocation);
            this.groupBox3.Controls.Add(this.btn_addcategory);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txt_pTicket);
            this.groupBox3.Controls.Add(this.cmb_Vendor);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmb_InboundLocation);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tb_reorderquantity);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtReorderpoint);
            this.groupBox3.Controls.Add(this.cmb_category);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(8, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(862, 259);
            this.groupBox3.TabIndex = 74;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item Details";
            // 
            // chk_IsRedeemable
            // 
            this.chk_IsRedeemable.Checked = true;
            this.chk_IsRedeemable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IsRedeemable.Location = new System.Drawing.Point(817, 73);
            this.chk_IsRedeemable.Name = "chk_IsRedeemable";
            this.chk_IsRedeemable.Size = new System.Drawing.Size(28, 21);
            this.chk_IsRedeemable.TabIndex = 115;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(721, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 13);
            this.label16.TabIndex = 116;
            this.label16.Text = "Redeemable?:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(111, 42);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(121, 20);
            this.txtCode.TabIndex = 114;
            // 
            // btnUPCBarcode
            // 
            this.btnUPCBarcode.AutoSize = true;
            this.btnUPCBarcode.FlatAppearance.BorderSize = 0;
            this.btnUPCBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUPCBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUPCBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUPCBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPCBarcode.ForeColor = System.Drawing.Color.Black;
            this.btnUPCBarcode.Location = new System.Drawing.Point(104, 179);
            this.btnUPCBarcode.Name = "btnUPCBarcode";
            this.btnUPCBarcode.Size = new System.Drawing.Size(133, 23);
            this.btnUPCBarcode.TabIndex = 113;
            this.btnUPCBarcode.Text = "Generate Bar Code";
            this.btnUPCBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUPCBarcode.UseVisualStyleBackColor = true;
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(111, 154);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.ReadOnly = true;
            this.tb_barcode.Size = new System.Drawing.Size(121, 20);
            this.tb_barcode.TabIndex = 110;
            // 
            // lblActive
            // 
            this.lblActive.Location = new System.Drawing.Point(684, 49);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(113, 13);
            this.lblActive.TabIndex = 105;
            this.lblActive.Text = "Active?:";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_active
            // 
            this.chk_active.Checked = true;
            this.chk_active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_active.Location = new System.Drawing.Point(818, 44);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(16, 24);
            this.chk_active.TabIndex = 76;
            this.chk_active.Text = "Active?:";
            this.chk_active.UseVisualStyleBackColor = true;
            // 
            // btnAddUOM
            // 
            this.btnAddUOM.FlatAppearance.BorderSize = 0;
            this.btnAddUOM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddUOM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddUOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUOM.ForeColor = System.Drawing.Color.Black;
            this.btnAddUOM.Location = new System.Drawing.Point(237, 123);
            this.btnAddUOM.Name = "btnAddUOM";
            this.btnAddUOM.Size = new System.Drawing.Size(75, 23);
            this.btnAddUOM.TabIndex = 98;
            this.btnAddUOM.Text = "Add UOM";
            this.btnAddUOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddUOM.UseVisualStyleBackColor = true;
            this.btnAddUOM.Click += new System.EventHandler(this.btnAddUOM_Click);
            // 
            // cmbUOM
            // 
            this.cmbUOM.DisplayMember = "UOMId";
            this.cmbUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUOM.FormattingEnabled = true;
            this.cmbUOM.Location = new System.Drawing.Point(112, 125);
            this.cmbUOM.Name = "cmbUOM";
            this.cmbUOM.Size = new System.Drawing.Size(121, 21);
            this.cmbUOM.TabIndex = 78;
            this.cmbUOM.ValueMember = "UOMId";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(7, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 15);
            this.label20.TabIndex = 104;
            this.label20.Text = "Unit of Measure:*";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTaxInclusiveCost
            // 
            this.chkTaxInclusiveCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTaxInclusiveCost.Checked = true;
            this.chkTaxInclusiveCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTaxInclusiveCost.Location = new System.Drawing.Point(732, 157);
            this.chkTaxInclusiveCost.Name = "chkTaxInclusiveCost";
            this.chkTaxInclusiveCost.Size = new System.Drawing.Size(100, 24);
            this.chkTaxInclusiveCost.TabIndex = 86;
            this.chkTaxInclusiveCost.Text = "Tax Inclusive?:";
            this.chkTaxInclusiveCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTaxInclusiveCost.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(358, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 15);
            this.label19.TabIndex = 103;
            this.label19.Text = "Tax:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddTax
            // 
            this.btnAddTax.FlatAppearance.BorderSize = 0;
            this.btnAddTax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddTax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddTax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTax.ForeColor = System.Drawing.Color.Black;
            this.btnAddTax.Location = new System.Drawing.Point(551, 76);
            this.btnAddTax.Name = "btnAddTax";
            this.btnAddTax.Size = new System.Drawing.Size(66, 23);
            this.btnAddTax.TabIndex = 102;
            this.btnAddTax.Text = "Add Tax..";
            this.btnAddTax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTax.UseVisualStyleBackColor = true;
            this.btnAddTax.Click += new System.EventHandler(this.btnAddTax_Click);
            // 
            // cmbTax
            // 
            this.cmbTax.DisplayMember = "TaxId";
            this.cmbTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTax.FormattingEnabled = true;
            this.cmbTax.Location = new System.Drawing.Point(452, 74);
            this.cmbTax.Name = "cmbTax";
            this.cmbTax.Size = new System.Drawing.Size(93, 21);
            this.cmbTax.TabIndex = 87;
            this.cmbTax.ValueMember = "TaxId";
            // 
            // cmb_OutboundLocation
            // 
            this.cmb_OutboundLocation.DisplayMember = "LocationId";
            this.cmb_OutboundLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_OutboundLocation.FormattingEnabled = true;
            this.cmb_OutboundLocation.Location = new System.Drawing.Point(452, 215);
            this.cmb_OutboundLocation.Name = "cmb_OutboundLocation";
            this.cmb_OutboundLocation.Size = new System.Drawing.Size(121, 21);
            this.cmb_OutboundLocation.TabIndex = 81;
            this.cmb_OutboundLocation.ValueMember = "LocationId";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(348, 215);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 15);
            this.label15.TabIndex = 101;
            this.label15.Text = "Outbound Location:*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerateBarCode
            // 
            this.btnGenerateBarCode.FlatAppearance.BorderSize = 0;
            this.btnGenerateBarCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGenerateBarCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGenerateBarCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBarCode.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateBarCode.Location = new System.Drawing.Point(237, 152);
            this.btnGenerateBarCode.Name = "btnGenerateBarCode";
            this.btnGenerateBarCode.Size = new System.Drawing.Size(102, 23);
            this.btnGenerateBarCode.TabIndex = 96;
            this.btnGenerateBarCode.Text = "Edit Bar Codes";
            this.btnGenerateBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerateBarCode.UseVisualStyleBackColor = true;
            this.btnGenerateBarCode.Click += new System.EventHandler(this.btnGenerateBarCode_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 97;
            this.label5.Text = "Bar Code:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(7, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 15);
            this.label14.TabIndex = 94;
            this.label14.Text = "Product Id:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Visible = false;
            // 
            // btn_addvendor
            // 
            this.btn_addvendor.FlatAppearance.BorderSize = 0;
            this.btn_addvendor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_addvendor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_addvendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addvendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addvendor.ForeColor = System.Drawing.Color.Black;
            this.btn_addvendor.Location = new System.Drawing.Point(578, 159);
            this.btn_addvendor.Name = "btn_addvendor";
            this.btn_addvendor.Size = new System.Drawing.Size(113, 23);
            this.btn_addvendor.TabIndex = 100;
            this.btn_addvendor.Text = "Add Vendor..";
            this.btn_addvendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addvendor.UseVisualStyleBackColor = true;
            this.btn_addvendor.Click += new System.EventHandler(this.cb_addvendor_Click);
            // 
            // btn_addlocation
            // 
            this.btn_addlocation.FlatAppearance.BorderSize = 0;
            this.btn_addlocation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_addlocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_addlocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addlocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addlocation.ForeColor = System.Drawing.Color.Black;
            this.btn_addlocation.Location = new System.Drawing.Point(237, 208);
            this.btn_addlocation.Name = "btn_addlocation";
            this.btn_addlocation.Size = new System.Drawing.Size(95, 23);
            this.btn_addlocation.TabIndex = 99;
            this.btn_addlocation.Text = "Add Location";
            this.btn_addlocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addlocation.UseVisualStyleBackColor = true;
            this.btn_addlocation.Click += new System.EventHandler(this.cb_addlocation_Click);
            // 
            // btn_addcategory
            // 
            this.btn_addcategory.FlatAppearance.BorderSize = 0;
            this.btn_addcategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_addcategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_addcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addcategory.ForeColor = System.Drawing.Color.Black;
            this.btn_addcategory.Location = new System.Drawing.Point(237, 96);
            this.btn_addcategory.Name = "btn_addcategory";
            this.btn_addcategory.Size = new System.Drawing.Size(95, 23);
            this.btn_addcategory.TabIndex = 95;
            this.btn_addcategory.Text = "Add Category..";
            this.btn_addcategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_addcategory.UseVisualStyleBackColor = true;
            this.btn_addcategory.Click += new System.EventHandler(this.cb_addcategory_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(348, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 15);
            this.label13.TabIndex = 83;
            this.label13.Text = "Price in Tickets:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_pTicket
            // 
            this.txt_pTicket.Location = new System.Drawing.Point(453, 131);
            this.txt_pTicket.Name = "txt_pTicket";
            this.txt_pTicket.Size = new System.Drawing.Size(92, 20);
            this.txt_pTicket.TabIndex = 74;
            this.txt_pTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_Vendor
            // 
            this.cmb_Vendor.DisplayMember = "VendorId";
            this.cmb_Vendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Vendor.FormattingEnabled = true;
            this.cmb_Vendor.Location = new System.Drawing.Point(452, 161);
            this.cmb_Vendor.Name = "cmb_Vendor";
            this.cmb_Vendor.Size = new System.Drawing.Size(121, 21);
            this.cmb_Vendor.TabIndex = 82;
            this.cmb_Vendor.ValueMember = "VendorId";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(348, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 93;
            this.label10.Text = "Preferred Vendor:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_InboundLocation
            // 
            this.cmb_InboundLocation.DisplayMember = "LocationId";
            this.cmb_InboundLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_InboundLocation.FormattingEnabled = true;
            this.cmb_InboundLocation.Location = new System.Drawing.Point(111, 209);
            this.cmb_InboundLocation.Name = "cmb_InboundLocation";
            this.cmb_InboundLocation.Size = new System.Drawing.Size(121, 21);
            this.cmb_InboundLocation.TabIndex = 79;
            this.cmb_InboundLocation.ValueMember = "LocationId";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.label9.TabIndex = 92;
            this.label9.Text = "Inbound Location:*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(342, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 91;
            this.label8.Text = "Reorder Quantity:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_reorderquantity
            // 
            this.tb_reorderquantity.Location = new System.Drawing.Point(453, 100);
            this.tb_reorderquantity.Name = "tb_reorderquantity";
            this.tb_reorderquantity.Size = new System.Drawing.Size(92, 20);
            this.tb_reorderquantity.TabIndex = 89;
            this.tb_reorderquantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(355, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 90;
            this.label7.Text = "Reorder Point:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReorderpoint
            // 
            this.txtReorderpoint.Location = new System.Drawing.Point(452, 46);
            this.txtReorderpoint.Name = "txtReorderpoint";
            this.txtReorderpoint.Size = new System.Drawing.Size(93, 20);
            this.txtReorderpoint.TabIndex = 88;
            this.txtReorderpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_category
            // 
            this.cmb_category.DataSource = this.categoryBindingSource;
            this.cmb_category.DisplayMember = "CategoryName";
            this.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_category.FormattingEnabled = true;
            this.cmb_category.Location = new System.Drawing.Point(112, 97);
            this.cmb_category.Name = "cmb_category";
            this.cmb_category.Size = new System.Drawing.Size(121, 21);
            this.cmb_category.TabIndex = 73;
            this.cmb_category.ValueMember = "CategoryId";
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.Category);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 80;
            this.label3.Text = "Category:*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 77;
            this.label2.Text = "Description:*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(111, 70);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 75;
            this.label1.Text = "Code:*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 522);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.cb_printBOM);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_duplicate);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.gb_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Add Product";
            this.Activated += new System.EventHandler(this.frm_MaintainProducts_Activated);
            this.Load += new System.EventHandler(this.frm_MaintainProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uOMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxBindingSource)).EndInit();
            this.BOMEditMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBarcodebindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_add.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_duplicate;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.BindingSource taxBindingSource;
        private System.Windows.Forms.BindingSource uOMBindingSource;
        private System.Windows.Forms.ContextMenuStrip BOMEditMenu;
        private System.Windows.Forms.ToolStripMenuItem EditBOM;
        private System.Windows.Forms.ToolStripMenuItem Add;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuRefresh;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem EditProduct;
        private System.Windows.Forms.Button cb_printBOM;
        private System.Windows.Forms.BindingSource productBarcodebindingSource;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox tb_remarks;
        private System.Windows.Forms.Label lb_productid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_SalePrice;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_Variance;
        private System.Windows.Forms.TextBox txt_UpperCostLimit;
        private System.Windows.Forms.TextBox txt_LowerCostLimit;
        private System.Windows.Forms.TextBox txt_InnerCostUnit;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_lastpurchaseprice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_IsSellable;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chk_Purchaseable;
        private System.Windows.Forms.GroupBox gb_add;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUPCBarcode;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.Button btnAddUOM;
        private System.Windows.Forms.ComboBox cmbUOM;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkTaxInclusiveCost;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnAddTax;
        private System.Windows.Forms.ComboBox cmbTax;
        private System.Windows.Forms.ComboBox cmb_OutboundLocation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnGenerateBarCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_addvendor;
        private System.Windows.Forms.Button btn_addlocation;
        private System.Windows.Forms.Button btn_addcategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_pTicket;
        private System.Windows.Forms.ComboBox cmb_Vendor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_InboundLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_reorderquantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReorderpoint;
        private System.Windows.Forms.ComboBox cmb_category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IsRedeemable;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSellableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPurchaseableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn isActiveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceInTicketsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutboundLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxInclusiveCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LowerLimitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpperLimitCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostVariancePercentage;
        //private System.Windows.Forms.DataGridViewTextBoxColumn siteIdDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn synchStatusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurnInPriceInTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentCategoryId;
        //private System.Windows.Forms.DataGridViewTextBoxColumn masterEntityIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customDataSetIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lotControlledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn marketListItemDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuingApproachDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private System.Windows.Forms.CheckBox chk_IsRedeemable;
        private System.Windows.Forms.Label label16;
    }
}