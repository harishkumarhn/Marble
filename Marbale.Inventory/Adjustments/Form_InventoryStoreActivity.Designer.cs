namespace Marbale.Inventory.Adjustments
{
    partial class Form_InventoryStoreActivity
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
            this.dgv_activity = new System.Windows.Forms.DataGridView();
            this.inventoryAdjustmentsActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trxTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferLocationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_activity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryAdjustmentsActivityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_activity
            // 
            this.dgv_activity.AllowUserToAddRows = false;
            this.dgv_activity.AllowUserToDeleteRows = false;
            this.dgv_activity.AutoGenerateColumns = false;
            this.dgv_activity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_activity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trxTypeDataGridViewTextBoxColumn,
            this.productIdDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.locationIdDataGridViewTextBoxColumn,
            this.transferLocationIdDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.fromLocationDataGridViewTextBoxColumn,
            this.transferLocationDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.isChangedDataGridViewCheckBoxColumn});
            this.dgv_activity.DataSource = this.inventoryAdjustmentsActivityBindingSource;
            this.dgv_activity.Location = new System.Drawing.Point(12, 51);
            this.dgv_activity.Name = "dgv_activity";
            this.dgv_activity.ReadOnly = true;
            this.dgv_activity.Size = new System.Drawing.Size(1258, 377);
            this.dgv_activity.TabIndex = 0;
            // 
            // inventoryAdjustmentsActivityBindingSource
            // 
            this.inventoryAdjustmentsActivityBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.InventoryAdjustmentsActivity);
            // 
            // trxTypeDataGridViewTextBoxColumn
            // 
            this.trxTypeDataGridViewTextBoxColumn.DataPropertyName = "TrxType";
            this.trxTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.trxTypeDataGridViewTextBoxColumn.Name = "trxTypeDataGridViewTextBoxColumn";
            this.trxTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "ProductId";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "ProductId";
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Product Name";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.productNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // locationIdDataGridViewTextBoxColumn
            // 
            this.locationIdDataGridViewTextBoxColumn.DataPropertyName = "LocationId";
            this.locationIdDataGridViewTextBoxColumn.HeaderText = "LocationId";
            this.locationIdDataGridViewTextBoxColumn.Name = "locationIdDataGridViewTextBoxColumn";
            this.locationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // transferLocationIdDataGridViewTextBoxColumn
            // 
            this.transferLocationIdDataGridViewTextBoxColumn.DataPropertyName = "TransferLocationId";
            this.transferLocationIdDataGridViewTextBoxColumn.HeaderText = "TransferLocationId";
            this.transferLocationIdDataGridViewTextBoxColumn.Name = "transferLocationIdDataGridViewTextBoxColumn";
            this.transferLocationIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.transferLocationIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromLocationDataGridViewTextBoxColumn
            // 
            this.fromLocationDataGridViewTextBoxColumn.DataPropertyName = "FromLocation";
            this.fromLocationDataGridViewTextBoxColumn.HeaderText = "From Location";
            this.fromLocationDataGridViewTextBoxColumn.Name = "fromLocationDataGridViewTextBoxColumn";
            this.fromLocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transferLocationDataGridViewTextBoxColumn
            // 
            this.transferLocationDataGridViewTextBoxColumn.DataPropertyName = "TransferLocation";
            this.transferLocationDataGridViewTextBoxColumn.HeaderText = "Transfer Location";
            this.transferLocationDataGridViewTextBoxColumn.Name = "transferLocationDataGridViewTextBoxColumn";
            this.transferLocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "Last Updated Date";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdatedByDataGridViewTextBoxColumn
            // 
            this.lastUpdatedByDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.HeaderText = "LastUpdatedBy";
            this.lastUpdatedByDataGridViewTextBoxColumn.Name = "lastUpdatedByDataGridViewTextBoxColumn";
            this.lastUpdatedByDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedByDataGridViewTextBoxColumn.Visible = false;
            // 
            // isChangedDataGridViewCheckBoxColumn
            // 
            this.isChangedDataGridViewCheckBoxColumn.DataPropertyName = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.HeaderText = "IsChanged";
            this.isChangedDataGridViewCheckBoxColumn.Name = "isChangedDataGridViewCheckBoxColumn";
            this.isChangedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isChangedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // Form_InventoryStoreActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 450);
            this.Controls.Add(this.dgv_activity);
            this.Name = "Form_InventoryStoreActivity";
            this.Text = "Form_InventoryStoreActivity";
            this.Load += new System.EventHandler(this.Form_InventoryStoreActivity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_activity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryAdjustmentsActivityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_activity;
        private System.Windows.Forms.BindingSource inventoryAdjustmentsActivityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn trxTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferLocationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChangedDataGridViewCheckBoxColumn;
    }
}