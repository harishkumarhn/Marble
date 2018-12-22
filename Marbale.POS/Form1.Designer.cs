namespace Marbale.POS
{
    partial class ShiftForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.closebutton = new System.Windows.Forms.Button();
            this.btnClosedShift = new System.Windows.Forms.Button();
            this.btnOpenShift = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.RichTextBox();
            this.txtGameCard = new System.Windows.Forms.TextBox();
            this.txtCardCount = new System.Windows.Forms.TextBox();
            this.txtCreditCard = new System.Windows.Forms.TextBox();
            this.txtcashblalance = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.lblLoginTime = new System.Windows.Forms.Label();
            this.lblLoginTimes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnCalculator);
            this.panel1.Controls.Add(this.closebutton);
            this.panel1.Controls.Add(this.btnClosedShift);
            this.panel1.Controls.Add(this.btnOpenShift);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 555);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // closebutton
            // 
            this.closebutton.BackColor = System.Drawing.Color.CadetBlue;
            this.closebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebutton.ForeColor = System.Drawing.Color.Red;
            this.closebutton.Location = new System.Drawing.Point(397, 31);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(22, 19);
            this.closebutton.TabIndex = 24;
            this.closebutton.Text = "X";
            this.closebutton.UseVisualStyleBackColor = false;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // btnClosedShift
            // 
            this.btnClosedShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClosedShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClosedShift.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosedShift.Location = new System.Drawing.Point(199, 478);
            this.btnClosedShift.Name = "btnClosedShift";
            this.btnClosedShift.Size = new System.Drawing.Size(129, 42);
            this.btnClosedShift.TabIndex = 22;
            this.btnClosedShift.Text = "Closed Shift";
            this.btnClosedShift.UseVisualStyleBackColor = false;
            // 
            // btnOpenShift
            // 
            this.btnOpenShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenShift.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenShift.Location = new System.Drawing.Point(31, 478);
            this.btnOpenShift.Name = "btnOpenShift";
            this.btnOpenShift.Size = new System.Drawing.Size(129, 42);
            this.btnOpenShift.TabIndex = 21;
            this.btnOpenShift.Text = "Open Shift";
            this.btnOpenShift.UseVisualStyleBackColor = false;
            this.btnOpenShift.Click += new System.EventHandler(this.btnOpenShift_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lblLoginTimes);
            this.panel2.Controls.Add(this.lblLoginTime);
            this.panel2.Controls.Add(this.textBox9);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.txtGameCard);
            this.panel2.Controls.Add(this.txtCardCount);
            this.panel2.Controls.Add(this.txtCreditCard);
            this.panel2.Controls.Add(this.txtcashblalance);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(19, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 346);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox9.Location = new System.Drawing.Point(259, 115);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(50, 20);
            this.textBox9.TabIndex = 19;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox5.Location = new System.Drawing.Point(259, 200);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(50, 20);
            this.textBox5.TabIndex = 18;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox6.Location = new System.Drawing.Point(259, 141);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(50, 20);
            this.textBox6.TabIndex = 17;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBox7.Location = new System.Drawing.Point(259, 171);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(50, 20);
            this.textBox7.TabIndex = 16;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRemarks.Location = new System.Drawing.Point(149, 238);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(166, 61);
            this.txtRemarks.TabIndex = 14;
            this.txtRemarks.Text = "";
            // 
            // txtGameCard
            // 
            this.txtGameCard.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGameCard.Location = new System.Drawing.Point(149, 200);
            this.txtGameCard.Name = "txtGameCard";
            this.txtGameCard.Size = new System.Drawing.Size(50, 20);
            this.txtGameCard.TabIndex = 13;
            // 
            // txtCardCount
            // 
            this.txtCardCount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCardCount.Location = new System.Drawing.Point(149, 142);
            this.txtCardCount.Name = "txtCardCount";
            this.txtCardCount.Size = new System.Drawing.Size(50, 20);
            this.txtCardCount.TabIndex = 12;
            this.txtCardCount.TextChanged += new System.EventHandler(this.txtCardCount_TextChanged);
            this.txtCardCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardCount_KeyPress);
            // 
            // txtCreditCard
            // 
            this.txtCreditCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtCreditCard.Location = new System.Drawing.Point(149, 172);
            this.txtCreditCard.Name = "txtCreditCard";
            this.txtCreditCard.Size = new System.Drawing.Size(50, 20);
            this.txtCreditCard.TabIndex = 11;
            this.txtCreditCard.TextChanged += new System.EventHandler(this.txtCreditCard_TextChanged);
            this.txtCreditCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditCard_KeyPress);
            // 
            // txtcashblalance
            // 
            this.txtcashblalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtcashblalance.Location = new System.Drawing.Point(149, 116);
            this.txtcashblalance.Name = "txtcashblalance";
            this.txtcashblalance.Size = new System.Drawing.Size(50, 20);
            this.txtcashblalance.TabIndex = 10;
            this.txtcashblalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcashblalance_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Fuchsia;
            this.label10.Location = new System.Drawing.Point(256, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "System";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Fuchsia;
            this.label9.Location = new System.Drawing.Point(146, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cashier";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Game Card";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Remarks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Credit Card";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Card Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "CashBalance";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Logout Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cashier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login Time";
            // 
            // btnCalculator
            // 
            this.btnCalculator.Image = global::Marbale.POS.Properties.Resources.Calculator_icon__2_;
            this.btnCalculator.Location = new System.Drawing.Point(363, 491);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(32, 32);
            this.btnCalculator.TabIndex = 25;
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // lblLoginTime
            // 
            this.lblLoginTime.AutoSize = true;
            this.lblLoginTime.Location = new System.Drawing.Point(149, 32);
            this.lblLoginTime.Name = "lblLoginTime";
            this.lblLoginTime.Size = new System.Drawing.Size(0, 13);
            this.lblLoginTime.TabIndex = 20;
            // 
            // lblLoginTimes
            // 
            this.lblLoginTimes.AutoSize = true;
            this.lblLoginTimes.Location = new System.Drawing.Point(149, 32);
            this.lblLoginTimes.Name = "lblLoginTimes";
            this.lblLoginTimes.Size = new System.Drawing.Size(56, 13);
            this.lblLoginTimes.TabIndex = 21;
            this.lblLoginTimes.Text = "LoginTime";
            // 
            // ShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(448, 560);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShiftForm";
            this.Text = "ShiftForm";
            this.Load += new System.EventHandler(this.ShiftForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button btnClosedShift;
        private System.Windows.Forms.Button btnOpenShift;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.RichTextBox txtRemarks;
        private System.Windows.Forms.TextBox txtGameCard;
        private System.Windows.Forms.TextBox txtCardCount;
        private System.Windows.Forms.TextBox txtCreditCard;
        private System.Windows.Forms.TextBox txtcashblalance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Label lblLoginTime;
        private System.Windows.Forms.Label lblLoginTimes;
    }
}

