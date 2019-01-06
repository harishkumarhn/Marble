namespace Marbale.Products
{
    partial class DiscountForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TransactionDiscountTab = new System.Windows.Forms.TabControl();
            this.SetupDiscountTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TransactionDiscountGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TransactionDiscountTab.SuspendLayout();
            this.SetupDiscountTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDiscountGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(971, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // TransactionDiscountTab
            // 
            this.TransactionDiscountTab.Controls.Add(this.SetupDiscountTab);
            this.TransactionDiscountTab.Controls.Add(this.tabPage2);
            this.TransactionDiscountTab.Controls.Add(this.tabPage1);
            this.TransactionDiscountTab.Location = new System.Drawing.Point(-1, 1);
            this.TransactionDiscountTab.Name = "TransactionDiscountTab";
            this.TransactionDiscountTab.SelectedIndex = 0;
            this.TransactionDiscountTab.Size = new System.Drawing.Size(944, 410);
            this.TransactionDiscountTab.TabIndex = 1;
            this.TransactionDiscountTab.Click += new System.EventHandler(this.TransactionDiscountTab_Click);
            // 
            // SetupDiscountTab
            // 
            this.SetupDiscountTab.Controls.Add(this.TransactionDiscountGrid);
            this.SetupDiscountTab.Location = new System.Drawing.Point(4, 22);
            this.SetupDiscountTab.Name = "SetupDiscountTab";
            this.SetupDiscountTab.Padding = new System.Windows.Forms.Padding(3);
            this.SetupDiscountTab.Size = new System.Drawing.Size(936, 384);
            this.SetupDiscountTab.TabIndex = 0;
            this.SetupDiscountTab.Text = "TransactionDiscount";
            this.SetupDiscountTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(936, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game Play Discount";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 384);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TransactionDiscountGrid
            // 
            this.TransactionDiscountGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionDiscountGrid.Location = new System.Drawing.Point(9, 6);
            this.TransactionDiscountGrid.Name = "TransactionDiscountGrid";
            this.TransactionDiscountGrid.Size = new System.Drawing.Size(921, 284);
            this.TransactionDiscountGrid.TabIndex = 0;
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 423);
            this.Controls.Add(this.TransactionDiscountTab);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DiscountForm";
            this.Text = "Setup Discount";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TransactionDiscountTab.ResumeLayout(false);
            this.SetupDiscountTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionDiscountGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl TransactionDiscountTab;
        private System.Windows.Forms.TabPage SetupDiscountTab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView TransactionDiscountGrid;
    }
}