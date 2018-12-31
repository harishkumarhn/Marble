namespace Marbale.Products
{
    partial class ProductDetail
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
            this.productCardTab = new System.Windows.Forms.TabControl();
            this.pCardPage = new System.Windows.Forms.TabPage();
            this.tbl_pCard = new System.Windows.Forms.TableLayoutPanel();
            this.gb_price = new System.Windows.Forms.GroupBox();
            this.txt_finalprice = new System.Windows.Forms.TextBox();
            this.lbl_finalprice = new System.Windows.Forms.Label();
            this.txt_efectivePrice = new System.Windows.Forms.TextBox();
            this.lbl_efectivePrice = new System.Windows.Forms.Label();
            this.txt_taxPer = new System.Windows.Forms.TextBox();
            this.lbl_taxPer = new System.Windows.Forms.Label();
            this.chk_taxInx = new System.Windows.Forms.CheckBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_faceValue = new System.Windows.Forms.TextBox();
            this.lbl_taxInx = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_faceValue = new System.Windows.Forms.Label();
            this.gb_product = new System.Windows.Forms.GroupBox();
            this.chk_VIP = new System.Windows.Forms.CheckBox();
            this.lbl_vip = new System.Windows.Forms.Label();
            this.chk_agCard = new System.Windows.Forms.CheckBox();
            this.lbl_agCard = new System.Windows.Forms.Label();
            this.txt_dg = new System.Windows.Forms.TextBox();
            this.lbl_dg = new System.Windows.Forms.Label();
            this.cmb_pCounter = new System.Windows.Forms.ComboBox();
            this.lbl_pCounter = new System.Windows.Forms.Label();
            this.cmb_ptype = new System.Windows.Forms.ComboBox();
            this.lbl_pType = new System.Windows.Forms.Label();
            this.cmb_pCty = new System.Windows.Forms.ComboBox();
            this.lbl_pCategory = new System.Windows.Forms.Label();
            this.chk_dip = new System.Windows.Forms.CheckBox();
            this.lbl_dip = new System.Windows.Forms.Label();
            this.chk_pActive = new System.Windows.Forms.CheckBox();
            this.lbl_pActive = new System.Windows.Forms.Label();
            this.txt_pName = new System.Windows.Forms.TextBox();
            this.lbl_pName = new System.Windows.Forms.Label();
            this.txt_pId = new System.Windows.Forms.TextBox();
            this.lbl_pId = new System.Windows.Forms.Label();
            this.pnl_action = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.productCardTab.SuspendLayout();
            this.pCardPage.SuspendLayout();
            this.tbl_pCard.SuspendLayout();
            this.gb_price.SuspendLayout();
            this.gb_product.SuspendLayout();
            this.pnl_action.SuspendLayout();
            this.SuspendLayout();
            // 
            // productCardTab
            // 
            this.productCardTab.Controls.Add(this.pCardPage);
            this.productCardTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productCardTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCardTab.Location = new System.Drawing.Point(0, 0);
            this.productCardTab.Name = "productCardTab";
            this.productCardTab.SelectedIndex = 0;
            this.productCardTab.Size = new System.Drawing.Size(912, 552);
            this.productCardTab.TabIndex = 0;
            // 
            // pCardPage
            // 
            this.pCardPage.Controls.Add(this.tbl_pCard);
            this.pCardPage.Location = new System.Drawing.Point(4, 24);
            this.pCardPage.Name = "pCardPage";
            this.pCardPage.Padding = new System.Windows.Forms.Padding(3);
            this.pCardPage.Size = new System.Drawing.Size(904, 524);
            this.pCardPage.TabIndex = 1;
            this.pCardPage.Text = "Card";
            this.pCardPage.UseVisualStyleBackColor = true;
            // 
            // tbl_pCard
            // 
            this.tbl_pCard.ColumnCount = 2;
            this.tbl_pCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.39052F));
            this.tbl_pCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.60948F));
            this.tbl_pCard.Controls.Add(this.gb_price, 0, 1);
            this.tbl_pCard.Controls.Add(this.gb_product, 0, 0);
            this.tbl_pCard.Controls.Add(this.pnl_action, 0, 2);
            this.tbl_pCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_pCard.Location = new System.Drawing.Point(3, 3);
            this.tbl_pCard.Name = "tbl_pCard";
            this.tbl_pCard.RowCount = 3;
            this.tbl_pCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.01345F));
            this.tbl_pCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.98655F));
            this.tbl_pCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tbl_pCard.Size = new System.Drawing.Size(898, 518);
            this.tbl_pCard.TabIndex = 2;
            // 
            // gb_price
            // 
            this.gb_price.BackColor = System.Drawing.Color.BurlyWood;
            this.gb_price.Controls.Add(this.txt_finalprice);
            this.gb_price.Controls.Add(this.lbl_finalprice);
            this.gb_price.Controls.Add(this.txt_efectivePrice);
            this.gb_price.Controls.Add(this.lbl_efectivePrice);
            this.gb_price.Controls.Add(this.txt_taxPer);
            this.gb_price.Controls.Add(this.lbl_taxPer);
            this.gb_price.Controls.Add(this.chk_taxInx);
            this.gb_price.Controls.Add(this.txt_price);
            this.gb_price.Controls.Add(this.txt_faceValue);
            this.gb_price.Controls.Add(this.lbl_taxInx);
            this.gb_price.Controls.Add(this.lbl_price);
            this.gb_price.Controls.Add(this.lbl_faceValue);
            this.gb_price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_price.Location = new System.Drawing.Point(3, 177);
            this.gb_price.Name = "gb_price";
            this.gb_price.Size = new System.Drawing.Size(347, 266);
            this.gb_price.TabIndex = 1;
            this.gb_price.TabStop = false;
            this.gb_price.Text = "Price";
            // 
            // txt_finalprice
            // 
            this.txt_finalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_finalprice.Location = new System.Drawing.Point(109, 196);
            this.txt_finalprice.Name = "txt_finalprice";
            this.txt_finalprice.Size = new System.Drawing.Size(199, 21);
            this.txt_finalprice.TabIndex = 24;
            // 
            // lbl_finalprice
            // 
            this.lbl_finalprice.AutoSize = true;
            this.lbl_finalprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_finalprice.Location = new System.Drawing.Point(9, 199);
            this.lbl_finalprice.Name = "lbl_finalprice";
            this.lbl_finalprice.Size = new System.Drawing.Size(65, 15);
            this.lbl_finalprice.TabIndex = 23;
            this.lbl_finalprice.Text = "Final Price";
            // 
            // txt_efectivePrice
            // 
            this.txt_efectivePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_efectivePrice.Location = new System.Drawing.Point(109, 162);
            this.txt_efectivePrice.Name = "txt_efectivePrice";
            this.txt_efectivePrice.Size = new System.Drawing.Size(199, 21);
            this.txt_efectivePrice.TabIndex = 22;
            // 
            // lbl_efectivePrice
            // 
            this.lbl_efectivePrice.AutoSize = true;
            this.lbl_efectivePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_efectivePrice.Location = new System.Drawing.Point(9, 165);
            this.lbl_efectivePrice.Name = "lbl_efectivePrice";
            this.lbl_efectivePrice.Size = new System.Drawing.Size(83, 15);
            this.lbl_efectivePrice.TabIndex = 21;
            this.lbl_efectivePrice.Text = "Effective Price";
            // 
            // txt_taxPer
            // 
            this.txt_taxPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_taxPer.Location = new System.Drawing.Point(109, 129);
            this.txt_taxPer.Name = "txt_taxPer";
            this.txt_taxPer.Size = new System.Drawing.Size(199, 21);
            this.txt_taxPer.TabIndex = 20;
            // 
            // lbl_taxPer
            // 
            this.lbl_taxPer.AutoSize = true;
            this.lbl_taxPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taxPer.Location = new System.Drawing.Point(9, 132);
            this.lbl_taxPer.Name = "lbl_taxPer";
            this.lbl_taxPer.Size = new System.Drawing.Size(41, 15);
            this.lbl_taxPer.TabIndex = 19;
            this.lbl_taxPer.Text = "Tax %";
            // 
            // chk_taxInx
            // 
            this.chk_taxInx.AutoSize = true;
            this.chk_taxInx.Location = new System.Drawing.Point(109, 98);
            this.chk_taxInx.Name = "chk_taxInx";
            this.chk_taxInx.Size = new System.Drawing.Size(15, 14);
            this.chk_taxInx.TabIndex = 18;
            this.chk_taxInx.UseVisualStyleBackColor = true;
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.Location = new System.Drawing.Point(109, 63);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(199, 21);
            this.txt_price.TabIndex = 4;
            // 
            // txt_faceValue
            // 
            this.txt_faceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_faceValue.Location = new System.Drawing.Point(109, 27);
            this.txt_faceValue.Name = "txt_faceValue";
            this.txt_faceValue.Size = new System.Drawing.Size(199, 21);
            this.txt_faceValue.TabIndex = 3;
            // 
            // lbl_taxInx
            // 
            this.lbl_taxInx.AutoSize = true;
            this.lbl_taxInx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_taxInx.Location = new System.Drawing.Point(9, 97);
            this.lbl_taxInx.Name = "lbl_taxInx";
            this.lbl_taxInx.Size = new System.Drawing.Size(84, 15);
            this.lbl_taxInx.TabIndex = 2;
            this.lbl_taxInx.Text = "Tax Inclusive?";
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.Location = new System.Drawing.Point(9, 66);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(35, 15);
            this.lbl_price.TabIndex = 1;
            this.lbl_price.Text = "Price";
            // 
            // lbl_faceValue
            // 
            this.lbl_faceValue.AutoSize = true;
            this.lbl_faceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_faceValue.Location = new System.Drawing.Point(9, 30);
            this.lbl_faceValue.Name = "lbl_faceValue";
            this.lbl_faceValue.Size = new System.Drawing.Size(68, 15);
            this.lbl_faceValue.TabIndex = 0;
            this.lbl_faceValue.Text = "Face Value";
            // 
            // gb_product
            // 
            this.gb_product.BackColor = System.Drawing.Color.BurlyWood;
            this.gb_product.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tbl_pCard.SetColumnSpan(this.gb_product, 2);
            this.gb_product.Controls.Add(this.chk_VIP);
            this.gb_product.Controls.Add(this.lbl_vip);
            this.gb_product.Controls.Add(this.chk_agCard);
            this.gb_product.Controls.Add(this.lbl_agCard);
            this.gb_product.Controls.Add(this.txt_dg);
            this.gb_product.Controls.Add(this.lbl_dg);
            this.gb_product.Controls.Add(this.cmb_pCounter);
            this.gb_product.Controls.Add(this.lbl_pCounter);
            this.gb_product.Controls.Add(this.cmb_ptype);
            this.gb_product.Controls.Add(this.lbl_pType);
            this.gb_product.Controls.Add(this.cmb_pCty);
            this.gb_product.Controls.Add(this.lbl_pCategory);
            this.gb_product.Controls.Add(this.chk_dip);
            this.gb_product.Controls.Add(this.lbl_dip);
            this.gb_product.Controls.Add(this.chk_pActive);
            this.gb_product.Controls.Add(this.lbl_pActive);
            this.gb_product.Controls.Add(this.txt_pName);
            this.gb_product.Controls.Add(this.lbl_pName);
            this.gb_product.Controls.Add(this.txt_pId);
            this.gb_product.Controls.Add(this.lbl_pId);
            this.gb_product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_product.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_product.Location = new System.Drawing.Point(3, 3);
            this.gb_product.Name = "gb_product";
            this.gb_product.Size = new System.Drawing.Size(892, 168);
            this.gb_product.TabIndex = 0;
            this.gb_product.TabStop = false;
            this.gb_product.Text = "Product";
            // 
            // chk_VIP
            // 
            this.chk_VIP.AutoSize = true;
            this.chk_VIP.Location = new System.Drawing.Point(328, 103);
            this.chk_VIP.Name = "chk_VIP";
            this.chk_VIP.Size = new System.Drawing.Size(15, 14);
            this.chk_VIP.TabIndex = 19;
            this.chk_VIP.UseVisualStyleBackColor = true;
            // 
            // lbl_vip
            // 
            this.lbl_vip.AutoSize = true;
            this.lbl_vip.Location = new System.Drawing.Point(235, 101);
            this.lbl_vip.Name = "lbl_vip";
            this.lbl_vip.Size = new System.Drawing.Size(87, 16);
            this.lbl_vip.TabIndex = 18;
            this.lbl_vip.Text = "Only for VIP";
            // 
            // chk_agCard
            // 
            this.chk_agCard.AutoSize = true;
            this.chk_agCard.Location = new System.Drawing.Point(205, 103);
            this.chk_agCard.Name = "chk_agCard";
            this.chk_agCard.Size = new System.Drawing.Size(15, 14);
            this.chk_agCard.TabIndex = 17;
            this.chk_agCard.UseVisualStyleBackColor = true;
            // 
            // lbl_agCard
            // 
            this.lbl_agCard.AutoSize = true;
            this.lbl_agCard.Location = new System.Drawing.Point(6, 101);
            this.lbl_agCard.Name = "lbl_agCard";
            this.lbl_agCard.Size = new System.Drawing.Size(193, 16);
            this.lbl_agCard.TabIndex = 16;
            this.lbl_agCard.Text = "Auto Generate Card Number";
            // 
            // txt_dg
            // 
            this.txt_dg.Location = new System.Drawing.Point(508, 62);
            this.txt_dg.Name = "txt_dg";
            this.txt_dg.Size = new System.Drawing.Size(112, 23);
            this.txt_dg.TabIndex = 15;
            // 
            // lbl_dg
            // 
            this.lbl_dg.AutoSize = true;
            this.lbl_dg.Location = new System.Drawing.Point(405, 65);
            this.lbl_dg.Name = "lbl_dg";
            this.lbl_dg.Size = new System.Drawing.Size(97, 16);
            this.lbl_dg.TabIndex = 14;
            this.lbl_dg.Text = "Display Group";
            // 
            // cmb_pCounter
            // 
            this.cmb_pCounter.FormattingEnabled = true;
            this.cmb_pCounter.Location = new System.Drawing.Point(306, 62);
            this.cmb_pCounter.Name = "cmb_pCounter";
            this.cmb_pCounter.Size = new System.Drawing.Size(93, 24);
            this.cmb_pCounter.TabIndex = 13;
            // 
            // lbl_pCounter
            // 
            this.lbl_pCounter.AutoSize = true;
            this.lbl_pCounter.Location = new System.Drawing.Point(203, 65);
            this.lbl_pCounter.Name = "lbl_pCounter";
            this.lbl_pCounter.Size = new System.Drawing.Size(92, 16);
            this.lbl_pCounter.TabIndex = 12;
            this.lbl_pCounter.Text = "POS Counter";
            // 
            // cmb_ptype
            // 
            this.cmb_ptype.FormattingEnabled = true;
            this.cmb_ptype.Location = new System.Drawing.Point(109, 62);
            this.cmb_ptype.Name = "cmb_ptype";
            this.cmb_ptype.Size = new System.Drawing.Size(90, 24);
            this.cmb_ptype.TabIndex = 11;
            // 
            // lbl_pType
            // 
            this.lbl_pType.AutoSize = true;
            this.lbl_pType.Location = new System.Drawing.Point(6, 65);
            this.lbl_pType.Name = "lbl_pType";
            this.lbl_pType.Size = new System.Drawing.Size(97, 16);
            this.lbl_pType.TabIndex = 10;
            this.lbl_pType.Text = "Product Type";
            // 
            // cmb_pCty
            // 
            this.cmb_pCty.FormattingEnabled = true;
            this.cmb_pCty.Location = new System.Drawing.Point(731, 62);
            this.cmb_pCty.Name = "cmb_pCty";
            this.cmb_pCty.Size = new System.Drawing.Size(65, 24);
            this.cmb_pCty.TabIndex = 9;
            // 
            // lbl_pCategory
            // 
            this.lbl_pCategory.AutoSize = true;
            this.lbl_pCategory.Location = new System.Drawing.Point(640, 65);
            this.lbl_pCategory.Name = "lbl_pCategory";
            this.lbl_pCategory.Size = new System.Drawing.Size(68, 16);
            this.lbl_pCategory.TabIndex = 8;
            this.lbl_pCategory.Text = "Category";
            // 
            // chk_dip
            // 
            this.chk_dip.AutoSize = true;
            this.chk_dip.Location = new System.Drawing.Point(687, 31);
            this.chk_dip.Name = "chk_dip";
            this.chk_dip.Size = new System.Drawing.Size(15, 14);
            this.chk_dip.TabIndex = 7;
            this.chk_dip.UseVisualStyleBackColor = true;
            // 
            // lbl_dip
            // 
            this.lbl_dip.AutoSize = true;
            this.lbl_dip.Location = new System.Drawing.Point(577, 29);
            this.lbl_dip.Name = "lbl_dip";
            this.lbl_dip.Size = new System.Drawing.Size(102, 16);
            this.lbl_dip.TabIndex = 6;
            this.lbl_dip.Text = "Display in POS";
            // 
            // chk_pActive
            // 
            this.chk_pActive.AutoSize = true;
            this.chk_pActive.Location = new System.Drawing.Point(546, 31);
            this.chk_pActive.Name = "chk_pActive";
            this.chk_pActive.Size = new System.Drawing.Size(15, 14);
            this.chk_pActive.TabIndex = 5;
            this.chk_pActive.UseVisualStyleBackColor = true;
            // 
            // lbl_pActive
            // 
            this.lbl_pActive.AutoSize = true;
            this.lbl_pActive.Location = new System.Drawing.Point(483, 29);
            this.lbl_pActive.Name = "lbl_pActive";
            this.lbl_pActive.Size = new System.Drawing.Size(57, 16);
            this.lbl_pActive.TabIndex = 4;
            this.lbl_pActive.Text = "Active?";
            // 
            // txt_pName
            // 
            this.txt_pName.Location = new System.Drawing.Point(306, 24);
            this.txt_pName.Name = "txt_pName";
            this.txt_pName.Size = new System.Drawing.Size(149, 23);
            this.txt_pName.TabIndex = 3;
            // 
            // lbl_pName
            // 
            this.lbl_pName.AutoSize = true;
            this.lbl_pName.Location = new System.Drawing.Point(195, 29);
            this.lbl_pName.Name = "lbl_pName";
            this.lbl_pName.Size = new System.Drawing.Size(100, 16);
            this.lbl_pName.TabIndex = 2;
            this.lbl_pName.Text = "Product Name";
            // 
            // txt_pId
            // 
            this.txt_pId.Location = new System.Drawing.Point(109, 25);
            this.txt_pId.Name = "txt_pId";
            this.txt_pId.Size = new System.Drawing.Size(80, 23);
            this.txt_pId.TabIndex = 1;
            // 
            // lbl_pId
            // 
            this.lbl_pId.AutoSize = true;
            this.lbl_pId.Location = new System.Drawing.Point(6, 27);
            this.lbl_pId.Name = "lbl_pId";
            this.lbl_pId.Size = new System.Drawing.Size(77, 16);
            this.lbl_pId.TabIndex = 0;
            this.lbl_pId.Text = "Product Id";
            // 
            // pnl_action
            // 
            this.tbl_pCard.SetColumnSpan(this.pnl_action, 2);
            this.pnl_action.Controls.Add(this.btn_close);
            this.pnl_action.Controls.Add(this.btn_new);
            this.pnl_action.Controls.Add(this.btn_refresh);
            this.pnl_action.Controls.Add(this.btn_Save);
            this.pnl_action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_action.Location = new System.Drawing.Point(3, 449);
            this.pnl_action.Name = "pnl_action";
            this.pnl_action.Size = new System.Drawing.Size(892, 66);
            this.pnl_action.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(430, 22);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(103, 31);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_new
            // 
            this.btn_new.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Location = new System.Drawing.Point(295, 22);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(103, 31);
            this.btn_new.TabIndex = 2;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = false;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(159, 22);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(103, 31);
            this.btn_refresh.TabIndex = 1;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(28, 22);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(103, 31);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // ProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 552);
            this.Controls.Add(this.productCardTab);
            this.Name = "ProductDetail";
            this.Text = "Product Detail";
            this.Load += new System.EventHandler(this.ProductDetail_Load);
            this.productCardTab.ResumeLayout(false);
            this.pCardPage.ResumeLayout(false);
            this.tbl_pCard.ResumeLayout(false);
            this.gb_price.ResumeLayout(false);
            this.gb_price.PerformLayout();
            this.gb_product.ResumeLayout(false);
            this.gb_product.PerformLayout();
            this.pnl_action.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl productCardTab;
        private System.Windows.Forms.TabPage pCardPage;
        private System.Windows.Forms.GroupBox gb_product;
        private System.Windows.Forms.TextBox txt_pName;
        private System.Windows.Forms.Label lbl_pName;
        private System.Windows.Forms.TextBox txt_pId;
        private System.Windows.Forms.Label lbl_pId;
        private System.Windows.Forms.Label lbl_pActive;
        private System.Windows.Forms.GroupBox gb_price;
        private System.Windows.Forms.CheckBox chk_VIP;
        private System.Windows.Forms.Label lbl_vip;
        private System.Windows.Forms.CheckBox chk_agCard;
        private System.Windows.Forms.Label lbl_agCard;
        private System.Windows.Forms.TextBox txt_dg;
        private System.Windows.Forms.Label lbl_dg;
        private System.Windows.Forms.ComboBox cmb_pCounter;
        private System.Windows.Forms.Label lbl_pCounter;
        private System.Windows.Forms.ComboBox cmb_ptype;
        private System.Windows.Forms.Label lbl_pType;
        private System.Windows.Forms.ComboBox cmb_pCty;
        private System.Windows.Forms.Label lbl_pCategory;
        private System.Windows.Forms.CheckBox chk_dip;
        private System.Windows.Forms.Label lbl_dip;
        private System.Windows.Forms.CheckBox chk_pActive;
        private System.Windows.Forms.TableLayoutPanel tbl_pCard;
        private System.Windows.Forms.TextBox txt_faceValue;
        private System.Windows.Forms.Label lbl_taxInx;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label lbl_faceValue;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.CheckBox chk_taxInx;
        private System.Windows.Forms.TextBox txt_finalprice;
        private System.Windows.Forms.Label lbl_finalprice;
        private System.Windows.Forms.TextBox txt_efectivePrice;
        private System.Windows.Forms.Label lbl_efectivePrice;
        private System.Windows.Forms.TextBox txt_taxPer;
        private System.Windows.Forms.Label lbl_taxPer;
        private System.Windows.Forms.Panel pnl_action;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_Save;
    }
}