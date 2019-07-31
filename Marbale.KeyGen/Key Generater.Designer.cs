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
            this.tabs_KeyGen = new System.Windows.Forms.TabControl();
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
            this.btn_decode_close = new System.Windows.Forms.Button();
            this.btn_decode = new System.Windows.Forms.Button();
            this.txt_ed_deode = new System.Windows.Forms.TextBox();
            this.chk_never_decode = new System.Windows.Forms.CheckBox();
            this.txt_sk_decode = new System.Windows.Forms.TextBox();
            this.lab_ed_decode = new System.Windows.Forms.Label();
            this.lab_sk_decode = new System.Windows.Forms.Label();
            this.txt_lk_decode = new System.Windows.Forms.TextBox();
            this.lab_lk_decode = new System.Windows.Forms.Label();
            this.lab_validation = new System.Windows.Forms.Label();
            this.tabs_KeyGen.SuspendLayout();
            this.GenerateKey.SuspendLayout();
            this.Decode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs_KeyGen
            // 
            this.tabs_KeyGen.Controls.Add(this.GenerateKey);
            this.tabs_KeyGen.Controls.Add(this.Decode);
            this.tabs_KeyGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs_KeyGen.Location = new System.Drawing.Point(0, 0);
            this.tabs_KeyGen.Name = "tabs_KeyGen";
            this.tabs_KeyGen.SelectedIndex = 0;
            this.tabs_KeyGen.Size = new System.Drawing.Size(406, 265);
            this.tabs_KeyGen.TabIndex = 0;
            // 
            // GenerateKey
            // 
            this.GenerateKey.BackColor = System.Drawing.Color.White;
            this.GenerateKey.Controls.Add(this.lab_validation);
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
            // 
            // chk_never
            // 
            this.chk_never.AutoSize = true;
            this.chk_never.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_never.Location = new System.Drawing.Point(310, 67);
            this.chk_never.Name = "chk_never";
            this.chk_never.Size = new System.Drawing.Size(58, 19);
            this.chk_never.TabIndex = 8;
            this.chk_never.Text = "Never";
            this.chk_never.UseVisualStyleBackColor = true;
            // 
            // btn_generate
            // 
            this.btn_generate.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_generate.Location = new System.Drawing.Point(90, 144);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(91, 32);
            this.btn_generate.TabIndex = 7;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = false;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btn_close.Location = new System.Drawing.Point(205, 143);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(85, 33);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            // 
            // txt_license
            // 
            this.txt_license.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_license.Location = new System.Drawing.Point(90, 103);
            this.txt_license.Name = "txt_license";
            this.txt_license.Size = new System.Drawing.Size(200, 21);
            this.txt_license.TabIndex = 5;
            // 
            // lab_licenseKey
            // 
            this.lab_licenseKey.AutoSize = true;
            this.lab_licenseKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_licenseKey.Location = new System.Drawing.Point(9, 106);
            this.lab_licenseKey.Name = "lab_licenseKey";
            this.lab_licenseKey.Size = new System.Drawing.Size(73, 15);
            this.lab_licenseKey.TabIndex = 4;
            this.lab_licenseKey.Text = "License Key";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(90, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // lab_expiry
            // 
            this.lab_expiry.AutoSize = true;
            this.lab_expiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_expiry.Location = new System.Drawing.Point(9, 67);
            this.lab_expiry.Name = "lab_expiry";
            this.lab_expiry.Size = new System.Drawing.Size(69, 15);
            this.lab_expiry.TabIndex = 2;
            this.lab_expiry.Text = "Expiry Date";
            // 
            // txt_site
            // 
            this.txt_site.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_site.Location = new System.Drawing.Point(90, 29);
            this.txt_site.Name = "txt_site";
            this.txt_site.Size = new System.Drawing.Size(200, 21);
            this.txt_site.TabIndex = 1;
            // 
            // lab_siteKey
            // 
            this.lab_siteKey.AutoSize = true;
            this.lab_siteKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_siteKey.Location = new System.Drawing.Point(9, 32);
            this.lab_siteKey.Name = "lab_siteKey";
            this.lab_siteKey.Size = new System.Drawing.Size(51, 15);
            this.lab_siteKey.TabIndex = 0;
            this.lab_siteKey.Text = "Site Key";
            // 
            // Decode
            // 
            this.Decode.Controls.Add(this.btn_decode_close);
            this.Decode.Controls.Add(this.btn_decode);
            this.Decode.Controls.Add(this.txt_ed_deode);
            this.Decode.Controls.Add(this.chk_never_decode);
            this.Decode.Controls.Add(this.txt_sk_decode);
            this.Decode.Controls.Add(this.lab_ed_decode);
            this.Decode.Controls.Add(this.lab_sk_decode);
            this.Decode.Controls.Add(this.txt_lk_decode);
            this.Decode.Controls.Add(this.lab_lk_decode);
            this.Decode.Location = new System.Drawing.Point(4, 22);
            this.Decode.Name = "Decode";
            this.Decode.Padding = new System.Windows.Forms.Padding(3);
            this.Decode.Size = new System.Drawing.Size(398, 239);
            this.Decode.TabIndex = 1;
            this.Decode.Text = "Decode";
            this.Decode.UseVisualStyleBackColor = true;
            // 
            // btn_decode_close
            // 
            this.btn_decode_close.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_decode_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decode_close.Location = new System.Drawing.Point(196, 151);
            this.btn_decode_close.Name = "btn_decode_close";
            this.btn_decode_close.Size = new System.Drawing.Size(76, 33);
            this.btn_decode_close.TabIndex = 14;
            this.btn_decode_close.Text = "Close";
            this.btn_decode_close.UseVisualStyleBackColor = false;
            // 
            // btn_decode
            // 
            this.btn_decode.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_decode.Location = new System.Drawing.Point(96, 151);
            this.btn_decode.Name = "btn_decode";
            this.btn_decode.Size = new System.Drawing.Size(78, 33);
            this.btn_decode.TabIndex = 13;
            this.btn_decode.Text = "Decode";
            this.btn_decode.UseVisualStyleBackColor = false;
            this.btn_decode.Click += new System.EventHandler(this.btn_decode_Click);
            // 
            // txt_ed_deode
            // 
            this.txt_ed_deode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ed_deode.Location = new System.Drawing.Point(96, 98);
            this.txt_ed_deode.Name = "txt_ed_deode";
            this.txt_ed_deode.Size = new System.Drawing.Size(200, 21);
            this.txt_ed_deode.TabIndex = 12;
            // 
            // chk_never_decode
            // 
            this.chk_never_decode.AutoSize = true;
            this.chk_never_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_never_decode.Location = new System.Drawing.Point(315, 97);
            this.chk_never_decode.Name = "chk_never_decode";
            this.chk_never_decode.Size = new System.Drawing.Size(58, 19);
            this.chk_never_decode.TabIndex = 11;
            this.chk_never_decode.Text = "Never";
            this.chk_never_decode.UseVisualStyleBackColor = true;
            // 
            // txt_sk_decode
            // 
            this.txt_sk_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sk_decode.Location = new System.Drawing.Point(96, 66);
            this.txt_sk_decode.Name = "txt_sk_decode";
            this.txt_sk_decode.Size = new System.Drawing.Size(200, 21);
            this.txt_sk_decode.TabIndex = 10;
            // 
            // lab_ed_decode
            // 
            this.lab_ed_decode.AutoSize = true;
            this.lab_ed_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ed_decode.Location = new System.Drawing.Point(8, 101);
            this.lab_ed_decode.Name = "lab_ed_decode";
            this.lab_ed_decode.Size = new System.Drawing.Size(69, 15);
            this.lab_ed_decode.TabIndex = 8;
            this.lab_ed_decode.Text = "Expiry Date";
            // 
            // lab_sk_decode
            // 
            this.lab_sk_decode.AutoSize = true;
            this.lab_sk_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_sk_decode.Location = new System.Drawing.Point(8, 66);
            this.lab_sk_decode.Name = "lab_sk_decode";
            this.lab_sk_decode.Size = new System.Drawing.Size(51, 15);
            this.lab_sk_decode.TabIndex = 7;
            this.lab_sk_decode.Text = "Site Key";
            // 
            // txt_lk_decode
            // 
            this.txt_lk_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lk_decode.Location = new System.Drawing.Point(96, 22);
            this.txt_lk_decode.Name = "txt_lk_decode";
            this.txt_lk_decode.Size = new System.Drawing.Size(274, 21);
            this.txt_lk_decode.TabIndex = 6;
            // 
            // lab_lk_decode
            // 
            this.lab_lk_decode.AutoSize = true;
            this.lab_lk_decode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_lk_decode.Location = new System.Drawing.Point(8, 22);
            this.lab_lk_decode.Name = "lab_lk_decode";
            this.lab_lk_decode.Size = new System.Drawing.Size(73, 15);
            this.lab_lk_decode.TabIndex = 5;
            this.lab_lk_decode.Text = "License Key";
            // 
            // lab_validation
            // 
            this.lab_validation.AutoSize = true;
            this.lab_validation.ForeColor = System.Drawing.Color.Red;
            this.lab_validation.Location = new System.Drawing.Point(12, 7);
            this.lab_validation.Name = "lab_validation";
            this.lab_validation.Size = new System.Drawing.Size(79, 13);
            this.lab_validation.TabIndex = 9;
            this.lab_validation.Text = "Invalid Licence";
            // 
            // KeyGenerater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 265);
            this.Controls.Add(this.tabs_KeyGen);
            this.Name = "KeyGenerater";
            this.Text = "KeyGenerater";
            this.Load += new System.EventHandler(this.KeyGenerater_Load);
            this.tabs_KeyGen.ResumeLayout(false);
            this.GenerateKey.ResumeLayout(false);
            this.GenerateKey.PerformLayout();
            this.Decode.ResumeLayout(false);
            this.Decode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs_KeyGen;
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
        private System.Windows.Forms.Button btn_decode_close;
        private System.Windows.Forms.Button btn_decode;
        private System.Windows.Forms.TextBox txt_ed_deode;
        private System.Windows.Forms.CheckBox chk_never_decode;
        private System.Windows.Forms.TextBox txt_sk_decode;
        private System.Windows.Forms.Label lab_ed_decode;
        private System.Windows.Forms.Label lab_sk_decode;
        private System.Windows.Forms.TextBox txt_lk_decode;
        private System.Windows.Forms.Label lab_lk_decode;
        private System.Windows.Forms.Label lab_validation;
    }
}

