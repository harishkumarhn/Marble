namespace Marbale.KeyGen
{
    partial class KeyGenerater
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GenerateKey = new System.Windows.Forms.TabPage();
            this.chk_never = new System.Windows.Forms.CheckBox();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_license = new System.Windows.Forms.TextBox();
            this.lab_licenseKey = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lab_expiry = new System.Windows.Forms.Label();
            this.txt_site = new System.Windows.Forms.TextBox();
            this.lab_siteKey = new System.Windows.Forms.Label();
            this.Decode = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.GenerateKey.SuspendLayout();
            this.Decode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GenerateKey);
            this.tabControl1.Controls.Add(this.Decode);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(406, 265);
            this.tabControl1.TabIndex = 0;
            // 
            // GenerateKey
            // 
            this.GenerateKey.Controls.Add(this.chk_never);
            this.GenerateKey.Controls.Add(this.btn_generate);
            this.GenerateKey.Controls.Add(this.btn_close);
            this.GenerateKey.Controls.Add(this.txt_license);
            this.GenerateKey.Controls.Add(this.lab_licenseKey);
            this.GenerateKey.Controls.Add(this.dateTimePicker1);
            this.GenerateKey.Controls.Add(this.lab_expiry);
            this.GenerateKey.Controls.Add(this.txt_site);
            this.GenerateKey.Controls.Add(this.lab_siteKey);
            this.GenerateKey.Location = new System.Drawing.Point(4, 22);
            this.GenerateKey.Name = "GenerateKey";
            this.GenerateKey.Padding = new System.Windows.Forms.Padding(3);
            this.GenerateKey.Size = new System.Drawing.Size(398, 239);
            this.GenerateKey.TabIndex = 0;
            this.GenerateKey.Text = "Generate Key";
            this.GenerateKey.UseVisualStyleBackColor = true;
            // 
            // chk_never
            // 
            this.chk_never.AutoSize = true;
            this.chk_never.Location = new System.Drawing.Point(310, 67);
            this.chk_never.Name = "chk_never";
            this.chk_never.Size = new System.Drawing.Size(55, 17);
            this.chk_never.TabIndex = 8;
            this.chk_never.Text = "Never";
            this.chk_never.UseVisualStyleBackColor = true;
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(90, 152);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(75, 23);
            this.btn_generate.TabIndex = 7;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(187, 152);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            // 
            // txt_license
            // 
            this.txt_license.Location = new System.Drawing.Point(90, 103);
            this.txt_license.Name = "txt_license";
            this.txt_license.Size = new System.Drawing.Size(200, 20);
            this.txt_license.TabIndex = 5;
            // 
            // lab_licenseKey
            // 
            this.lab_licenseKey.AutoSize = true;
            this.lab_licenseKey.Location = new System.Drawing.Point(9, 106);
            this.lab_licenseKey.Name = "lab_licenseKey";
            this.lab_licenseKey.Size = new System.Drawing.Size(65, 13);
            this.lab_licenseKey.TabIndex = 4;
            this.lab_licenseKey.Text = "License Key";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(90, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // lab_expiry
            // 
            this.lab_expiry.AutoSize = true;
            this.lab_expiry.Location = new System.Drawing.Point(9, 67);
            this.lab_expiry.Name = "lab_expiry";
            this.lab_expiry.Size = new System.Drawing.Size(61, 13);
            this.lab_expiry.TabIndex = 2;
            this.lab_expiry.Text = "Expiry Date";
            // 
            // txt_site
            // 
            this.txt_site.Location = new System.Drawing.Point(90, 29);
            this.txt_site.Name = "txt_site";
            this.txt_site.Size = new System.Drawing.Size(200, 20);
            this.txt_site.TabIndex = 1;
            // 
            // lab_siteKey
            // 
            this.lab_siteKey.AutoSize = true;
            this.lab_siteKey.Location = new System.Drawing.Point(9, 32);
            this.lab_siteKey.Name = "lab_siteKey";
            this.lab_siteKey.Size = new System.Drawing.Size(46, 13);
            this.lab_siteKey.TabIndex = 0;
            this.lab_siteKey.Text = "Site Key";
            // 
            // Decode
            // 
            this.Decode.Controls.Add(this.label2);
            this.Decode.Controls.Add(this.label1);
            this.Decode.Location = new System.Drawing.Point(4, 22);
            this.Decode.Name = "Decode";
            this.Decode.Padding = new System.Windows.Forms.Padding(3);
            this.Decode.Size = new System.Drawing.Size(398, 239);
            this.Decode.TabIndex = 1;
            this.Decode.Text = "Decode";
            this.Decode.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // KeyGenerater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 265);
            this.Controls.Add(this.tabControl1);
            this.Name = "KeyGenerater";
            this.Text = "KeyGenerater";
            this.tabControl1.ResumeLayout(false);
            this.GenerateKey.ResumeLayout(false);
            this.GenerateKey.PerformLayout();
            this.Decode.ResumeLayout(false);
            this.Decode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GenerateKey;
        private System.Windows.Forms.TabPage Decode;
        private System.Windows.Forms.CheckBox chk_never;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_license;
        private System.Windows.Forms.Label lab_licenseKey;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lab_expiry;
        private System.Windows.Forms.TextBox txt_site;
        private System.Windows.Forms.Label lab_siteKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

