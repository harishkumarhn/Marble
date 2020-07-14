namespace Marbale.Inventory.Product
{
    partial class Frm_GenerateBarcode
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.txt_barweight = new System.Windows.Forms.TextBox();
            this.btn_genearatebarcode = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text To Encode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bar Weight";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(397, 200);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(58, 200);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 3;
            this.btn_Print.Text = "Print";
            this.btn_Print.UseVisualStyleBackColor = true;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(294, 200);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "Choose";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Location = new System.Drawing.Point(159, 28);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(100, 20);
            this.txt_Barcode.TabIndex = 5;
            // 
            // txt_barweight
            // 
            this.txt_barweight.Location = new System.Drawing.Point(159, 79);
            this.txt_barweight.Name = "txt_barweight";
            this.txt_barweight.Size = new System.Drawing.Size(100, 20);
            this.txt_barweight.TabIndex = 6;
            // 
            // btn_genearatebarcode
            // 
            this.btn_genearatebarcode.Location = new System.Drawing.Point(169, 200);
            this.btn_genearatebarcode.Name = "btn_genearatebarcode";
            this.btn_genearatebarcode.Size = new System.Drawing.Size(108, 23);
            this.btn_genearatebarcode.TabIndex = 7;
            this.btn_genearatebarcode.Text = "Generate Barcode";
            this.btn_genearatebarcode.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(52, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_GenerateBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 259);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_genearatebarcode);
            this.Controls.Add(this.txt_barweight);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_GenerateBarcode";
            this.Text = "Frm_GenerateBarcode";
            this.Load += new System.EventHandler(this.Frm_GenerateBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.TextBox txt_barweight;
        private System.Windows.Forms.Button btn_genearatebarcode;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}