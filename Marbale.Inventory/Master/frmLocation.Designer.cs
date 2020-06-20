namespace Marbale.Inventory.Master
{
    partial class frmLocation
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpUOM = new System.Windows.Forms.GroupBox();
            this.dgv_Location = new System.Windows.Forms.DataGridView();
            this.locationIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isAvailableToSellDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTurnInLocationDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isStoreDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.allowForMassUpdateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.locationTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChangedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkLocationType = new System.Windows.Forms.LinkLabel();
            this.grpUOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Location)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(133, 374);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 30);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(241, 374);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 30);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(345, 374);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpUOM
            // 
            this.grpUOM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUOM.Controls.Add(this.dgv_Location);
            this.grpUOM.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpUOM.Location = new System.Drawing.Point(9, 12);
            this.grpUOM.Name = "grpUOM";
            this.grpUOM.Size = new System.Drawing.Size(876, 352);
            this.grpUOM.TabIndex = 20;
            this.grpUOM.TabStop = false;
            this.grpUOM.Text = "Location";
            // 
            // dgv_Location
            // 
            this.dgv_Location.AutoGenerateColumns = false;
            this.dgv_Location.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Location.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.locationIdDataGridViewTextBoxColumn,
            this.locationNameDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.isAvailableToSellDataGridViewCheckBoxColumn,
            this.barCodeDataGridViewTextBoxColumn,
            this.isTurnInLocationDataGridViewCheckBoxColumn,
            this.isStoreDataGridViewCheckBoxColumn,
            this.allowForMassUpdateDataGridViewCheckBoxColumn,
            this.locationTypeIdDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.lastUpdatedByDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.isChangedDataGridViewCheckBoxColumn});
            this.dgv_Location.DataSource = this.locationBindingSource;
            this.dgv_Location.Location = new System.Drawing.Point(8, 24);
            this.dgv_Location.Name = "dgv_Location";
            this.dgv_Location.Size = new System.Drawing.Size(862, 322);
            this.dgv_Location.TabIndex = 0;
            this.dgv_Location.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_Location_DataError);
            this.dgv_Location.SelectionChanged += new System.EventHandler(this.dgvLocation_SelectionChanged);
            // 
            // locationIdDataGridViewTextBoxColumn
            // 
            this.locationIdDataGridViewTextBoxColumn.DataPropertyName = "LocationId";
            this.locationIdDataGridViewTextBoxColumn.HeaderText = "Location Id";
            this.locationIdDataGridViewTextBoxColumn.Name = "locationIdDataGridViewTextBoxColumn";
            this.locationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationNameDataGridViewTextBoxColumn
            // 
            this.locationNameDataGridViewTextBoxColumn.DataPropertyName = "LocationName";
            this.locationNameDataGridViewTextBoxColumn.HeaderText = "Location Name";
            this.locationNameDataGridViewTextBoxColumn.Name = "locationNameDataGridViewTextBoxColumn";
            this.locationNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "Is Active";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isAvailableToSellDataGridViewCheckBoxColumn
            // 
            this.isAvailableToSellDataGridViewCheckBoxColumn.DataPropertyName = "IsAvailableToSell";
            this.isAvailableToSellDataGridViewCheckBoxColumn.HeaderText = "Is Available To Sell";
            this.isAvailableToSellDataGridViewCheckBoxColumn.Name = "isAvailableToSellDataGridViewCheckBoxColumn";
            this.isAvailableToSellDataGridViewCheckBoxColumn.Width = 150;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "BarCode";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Bar Code";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            // 
            // isTurnInLocationDataGridViewCheckBoxColumn
            // 
            this.isTurnInLocationDataGridViewCheckBoxColumn.DataPropertyName = "IsTurnInLocation";
            this.isTurnInLocationDataGridViewCheckBoxColumn.HeaderText = "Is TurnIn Location";
            this.isTurnInLocationDataGridViewCheckBoxColumn.Name = "isTurnInLocationDataGridViewCheckBoxColumn";
            this.isTurnInLocationDataGridViewCheckBoxColumn.Width = 150;
            // 
            // isStoreDataGridViewCheckBoxColumn
            // 
            this.isStoreDataGridViewCheckBoxColumn.DataPropertyName = "IsStore";
            this.isStoreDataGridViewCheckBoxColumn.HeaderText = "Is Store";
            this.isStoreDataGridViewCheckBoxColumn.Name = "isStoreDataGridViewCheckBoxColumn";
            // 
            // allowForMassUpdateDataGridViewCheckBoxColumn
            // 
            this.allowForMassUpdateDataGridViewCheckBoxColumn.DataPropertyName = "AllowForMassUpdate";
            this.allowForMassUpdateDataGridViewCheckBoxColumn.HeaderText = "Allow For Mass Update";
            this.allowForMassUpdateDataGridViewCheckBoxColumn.Name = "allowForMassUpdateDataGridViewCheckBoxColumn";
            this.allowForMassUpdateDataGridViewCheckBoxColumn.Width = 150;
            // 
            // locationTypeIdDataGridViewTextBoxColumn
            // 
            this.locationTypeIdDataGridViewTextBoxColumn.DataPropertyName = "LocationTypeId";
            this.locationTypeIdDataGridViewTextBoxColumn.HeaderText = "Location Type ";
            this.locationTypeIdDataGridViewTextBoxColumn.Name = "locationTypeIdDataGridViewTextBoxColumn";
            this.locationTypeIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.locationTypeIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.locationTypeIdDataGridViewTextBoxColumn.Width = 150;
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
            // locationBindingSource
            // 
            this.locationBindingSource.DataSource = typeof(Marbale.BusinessObject.Inventory.Location);
            // 
            // lnkLocationType
            // 
            this.lnkLocationType.AutoSize = true;
            this.lnkLocationType.Location = new System.Drawing.Point(760, 383);
            this.lnkLocationType.Name = "lnkLocationType";
            this.lnkLocationType.Size = new System.Drawing.Size(97, 13);
            this.lnkLocationType.TabIndex = 21;
            this.lnkLocationType.TabStop = true;
            this.lnkLocationType.Text = "Add Location Type";
            this.lnkLocationType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLocationType_LinkClicked);
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(892, 422);
            this.Controls.Add(this.lnkLocationType);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpUOM);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location";
            this.Load += new System.EventHandler(this.frmLocation_Load);
            this.grpUOM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Location)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpUOM;
        private System.Windows.Forms.DataGridView dgv_Location;
        private System.Windows.Forms.LinkLabel lnkLocationType;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAvailableToSellDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTurnInLocationDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isStoreDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn allowForMassUpdateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn locationTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChangedDataGridViewCheckBoxColumn;
    }
}