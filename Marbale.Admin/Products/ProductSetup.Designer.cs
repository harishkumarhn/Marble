namespace Marbale.Products
{
    partial class ProductSetup
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
            this.tab_ProductList = new System.Windows.Forms.TabControl();
            this.tabPage_ProductList = new System.Windows.Forms.TabPage();
            this.tab_ProductList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_ProductList
            // 
            this.tab_ProductList.Controls.Add(this.tabPage_ProductList);
            this.tab_ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ProductList.Location = new System.Drawing.Point(0, 0);
            this.tab_ProductList.Name = "tab_ProductList";
            this.tab_ProductList.SelectedIndex = 0;
            this.tab_ProductList.Size = new System.Drawing.Size(898, 495);
            this.tab_ProductList.TabIndex = 0;
            // 
            // tabPage_ProductList
            // 
            this.tabPage_ProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_ProductList.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ProductList.Name = "tabPage_ProductList";
            this.tabPage_ProductList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ProductList.Size = new System.Drawing.Size(890, 469);
            this.tabPage_ProductList.TabIndex = 0;
            this.tabPage_ProductList.Text = "Products";
            this.tabPage_ProductList.UseVisualStyleBackColor = true;
            // 
            // ProductSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 495);
            this.Controls.Add(this.tab_ProductList);
            this.Name = "ProductSetup";
            this.Text = "ProductSetup";
            this.Load += new System.EventHandler(this.ProductSetup_Load);
            this.tab_ProductList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_ProductList;
        private System.Windows.Forms.TabPage tabPage_ProductList;
    }
}