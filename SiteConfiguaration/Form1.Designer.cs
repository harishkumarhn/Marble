namespace SiteConfiguaration
{
    partial class Form1
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
            this.lab_ConnectionString = new System.Windows.Forms.Label();
            this.txt_ConnectionString = new System.Windows.Forms.TextBox();
            this.btn_SaveConn = new System.Windows.Forms.Button();
            this.btn_retrive = new System.Windows.Forms.Button();
            this.lblGetConnectionString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_ConnectionString
            // 
            this.lab_ConnectionString.AutoSize = true;
            this.lab_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ConnectionString.Location = new System.Drawing.Point(13, 13);
            this.lab_ConnectionString.Name = "lab_ConnectionString";
            this.lab_ConnectionString.Size = new System.Drawing.Size(142, 13);
            this.lab_ConnectionString.TabIndex = 0;
            this.lab_ConnectionString.Text = "Enter Connection String";
            // 
            // txt_ConnectionString
            // 
            this.txt_ConnectionString.Location = new System.Drawing.Point(161, 10);
            this.txt_ConnectionString.Name = "txt_ConnectionString";
            this.txt_ConnectionString.Size = new System.Drawing.Size(449, 20);
            this.txt_ConnectionString.TabIndex = 1;
            // 
            // btn_SaveConn
            // 
            this.btn_SaveConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveConn.Location = new System.Drawing.Point(171, 37);
            this.btn_SaveConn.Name = "btn_SaveConn";
            this.btn_SaveConn.Size = new System.Drawing.Size(99, 23);
            this.btn_SaveConn.TabIndex = 2;
            this.btn_SaveConn.Text = "Save";
            this.btn_SaveConn.UseVisualStyleBackColor = true;
            this.btn_SaveConn.Click += new System.EventHandler(this.btn_SaveConn_Click);
            // 
            // btn_retrive
            // 
            this.btn_retrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_retrive.Location = new System.Drawing.Point(307, 37);
            this.btn_retrive.Name = "btn_retrive";
            this.btn_retrive.Size = new System.Drawing.Size(75, 23);
            this.btn_retrive.TabIndex = 3;
            this.btn_retrive.Text = "Retrive";
            this.btn_retrive.UseVisualStyleBackColor = true;
            this.btn_retrive.Click += new System.EventHandler(this.btn_retrive_Click);
            // 
            // lblGetConnectionString
            // 
            this.lblGetConnectionString.AutoSize = true;
            this.lblGetConnectionString.Location = new System.Drawing.Point(161, 75);
            this.lblGetConnectionString.Name = "lblGetConnectionString";
            this.lblGetConnectionString.Size = new System.Drawing.Size(0, 13);
            this.lblGetConnectionString.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 118);
            this.Controls.Add(this.lblGetConnectionString);
            this.Controls.Add(this.btn_retrive);
            this.Controls.Add(this.btn_SaveConn);
            this.Controls.Add(this.txt_ConnectionString);
            this.Controls.Add(this.lab_ConnectionString);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_ConnectionString;
        private System.Windows.Forms.TextBox txt_ConnectionString;
        private System.Windows.Forms.Button btn_SaveConn;
        private System.Windows.Forms.Button btn_retrive;
        private System.Windows.Forms.Label lblGetConnectionString;
    }
}

