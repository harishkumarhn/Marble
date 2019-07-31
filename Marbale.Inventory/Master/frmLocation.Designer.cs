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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpUOM = new System.Windows.Forms.GroupBox();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.lnkLocationType = new System.Windows.Forms.LinkLabel();
            this.grpUOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
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
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(345, 374);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpUOM
            // 
            this.grpUOM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUOM.Controls.Add(this.dgvLocation);
            this.grpUOM.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpUOM.Location = new System.Drawing.Point(9, 12);
            this.grpUOM.Name = "grpUOM";
            this.grpUOM.Size = new System.Drawing.Size(876, 352);
            this.grpUOM.TabIndex = 20;
            this.grpUOM.TabStop = false;
            this.grpUOM.Text = "Location";
            // 
            // dgvLocation
            // 
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Location = new System.Drawing.Point(7, 24);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.Size = new System.Drawing.Size(862, 322);
            this.dgvLocation.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpUOM;
        private System.Windows.Forms.DataGridView dgvLocation;
        private System.Windows.Forms.LinkLabel lnkLocationType;
    }
}