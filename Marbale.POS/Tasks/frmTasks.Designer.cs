namespace Marbale.POS
{
    partial class frmTasks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CardTabControl = new System.Windows.Forms.TabControl();
            this.tbLoadTickets = new System.Windows.Forms.TabPage();
            this.lblCardDetails = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTicketRemarks = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtTickets = new System.Windows.Forms.TextBox();
            this.lblEnterTickets = new System.Windows.Forms.Label();
            this.dgvCardTickets = new System.Windows.Forms.DataGridView();
            this.CardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tickets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLoadBonus = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBonusRemarks = new System.Windows.Forms.TextBox();
            this.lblBonusRemarks = new System.Windows.Forms.Label();
            this.btnBonusClose = new System.Windows.Forms.Button();
            this.btnBonusOk = new System.Windows.Forms.Button();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.lblBonus = new System.Windows.Forms.Label();
            this.dgvBonusCard = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTabControl.SuspendLayout();
            this.tbLoadTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardTickets)).BeginInit();
            this.tbLoadBonus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusCard)).BeginInit();
            this.SuspendLayout();
            // 
            // CardTabControl
            // 
            this.CardTabControl.Controls.Add(this.tbLoadTickets);
            this.CardTabControl.Controls.Add(this.tbLoadBonus);
            this.CardTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardTabControl.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.CardTabControl.Location = new System.Drawing.Point(0, 0);
            this.CardTabControl.Name = "CardTabControl";
            this.CardTabControl.SelectedIndex = 0;
            this.CardTabControl.Size = new System.Drawing.Size(702, 401);
            this.CardTabControl.TabIndex = 0;
            // 
            // tbLoadTickets
            // 
            this.tbLoadTickets.Controls.Add(this.lblCardDetails);
            this.tbLoadTickets.Controls.Add(this.txtRemarks);
            this.tbLoadTickets.Controls.Add(this.lblTicketRemarks);
            this.tbLoadTickets.Controls.Add(this.btnClose);
            this.tbLoadTickets.Controls.Add(this.btnOk);
            this.tbLoadTickets.Controls.Add(this.txtTickets);
            this.tbLoadTickets.Controls.Add(this.lblEnterTickets);
            this.tbLoadTickets.Controls.Add(this.dgvCardTickets);
            this.tbLoadTickets.Location = new System.Drawing.Point(4, 24);
            this.tbLoadTickets.Name = "tbLoadTickets";
            this.tbLoadTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tbLoadTickets.Size = new System.Drawing.Size(694, 373);
            this.tbLoadTickets.TabIndex = 0;
            this.tbLoadTickets.Tag = "1";
            this.tbLoadTickets.Text = "Load Tickets";
            this.tbLoadTickets.UseVisualStyleBackColor = true;
            // 
            // lblCardDetails
            // 
            this.lblCardDetails.AutoSize = true;
            this.lblCardDetails.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCardDetails.Location = new System.Drawing.Point(45, 30);
            this.lblCardDetails.Name = "lblCardDetails";
            this.lblCardDetails.Size = new System.Drawing.Size(91, 15);
            this.lblCardDetails.TabIndex = 7;
            this.lblCardDetails.Text = "Card Details";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(218, 226);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(308, 42);
            this.txtRemarks.TabIndex = 6;
            // 
            // lblTicketRemarks
            // 
            this.lblTicketRemarks.AutoSize = true;
            this.lblTicketRemarks.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTicketRemarks.Location = new System.Drawing.Point(143, 226);
            this.lblTicketRemarks.Name = "lblTicketRemarks";
            this.lblTicketRemarks.Size = new System.Drawing.Size(70, 15);
            this.lblTicketRemarks.TabIndex = 5;
            this.lblTicketRemarks.Text = "Remarks :";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(351, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(126, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnOk.Size = new System.Drawing.Size(102, 39);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtTickets
            // 
            this.txtTickets.Location = new System.Drawing.Point(218, 181);
            this.txtTickets.MaxLength = 5;
            this.txtTickets.Name = "txtTickets";
            this.txtTickets.Size = new System.Drawing.Size(306, 23);
            this.txtTickets.TabIndex = 2;
            this.txtTickets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTickets_KeyPress);
            // 
            // lblEnterTickets
            // 
            this.lblEnterTickets.AutoSize = true;
            this.lblEnterTickets.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEnterTickets.Location = new System.Drawing.Point(45, 181);
            this.lblEnterTickets.Name = "lblEnterTickets";
            this.lblEnterTickets.Size = new System.Drawing.Size(168, 15);
            this.lblEnterTickets.TabIndex = 1;
            this.lblEnterTickets.Text = "Enter Tickets to Load :";
            // 
            // dgvCardTickets
            // 
            this.dgvCardTickets.AllowUserToAddRows = false;
            this.dgvCardTickets.AllowUserToDeleteRows = false;
            this.dgvCardTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardNumber,
            this.IssueDate,
            this.Tickets});
            this.dgvCardTickets.Location = new System.Drawing.Point(48, 48);
            this.dgvCardTickets.MultiSelect = false;
            this.dgvCardTickets.Name = "dgvCardTickets";
            this.dgvCardTickets.ReadOnly = true;
            this.dgvCardTickets.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCardTickets.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCardTickets.RowHeadersVisible = false;
            this.dgvCardTickets.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCardTickets.Size = new System.Drawing.Size(535, 50);
            this.dgvCardTickets.TabIndex = 0;
            // 
            // CardNumber
            // 
            this.CardNumber.HeaderText = "CardNumber";
            this.CardNumber.Name = "CardNumber";
            this.CardNumber.ReadOnly = true;
            this.CardNumber.Width = 150;
            // 
            // IssueDate
            // 
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.ReadOnly = true;
            this.IssueDate.Width = 150;
            // 
            // Tickets
            // 
            this.Tickets.HeaderText = "Available Tickets on Card";
            this.Tickets.Name = "Tickets";
            this.Tickets.ReadOnly = true;
            this.Tickets.Width = 230;
            // 
            // tbLoadBonus
            // 
            this.tbLoadBonus.Controls.Add(this.label1);
            this.tbLoadBonus.Controls.Add(this.txtBonusRemarks);
            this.tbLoadBonus.Controls.Add(this.lblBonusRemarks);
            this.tbLoadBonus.Controls.Add(this.btnBonusClose);
            this.tbLoadBonus.Controls.Add(this.btnBonusOk);
            this.tbLoadBonus.Controls.Add(this.txtBonus);
            this.tbLoadBonus.Controls.Add(this.lblBonus);
            this.tbLoadBonus.Controls.Add(this.dgvBonusCard);
            this.tbLoadBonus.Location = new System.Drawing.Point(4, 24);
            this.tbLoadBonus.Name = "tbLoadBonus";
            this.tbLoadBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tbLoadBonus.Size = new System.Drawing.Size(694, 373);
            this.tbLoadBonus.TabIndex = 1;
            this.tbLoadBonus.Tag = "2";
            this.tbLoadBonus.Text = "Load Bonus";
            this.tbLoadBonus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(58, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Card Details";
            // 
            // txtBonusRemarks
            // 
            this.txtBonusRemarks.Location = new System.Drawing.Point(231, 233);
            this.txtBonusRemarks.Multiline = true;
            this.txtBonusRemarks.Name = "txtBonusRemarks";
            this.txtBonusRemarks.Size = new System.Drawing.Size(308, 42);
            this.txtBonusRemarks.TabIndex = 14;
            // 
            // lblBonusRemarks
            // 
            this.lblBonusRemarks.AutoSize = true;
            this.lblBonusRemarks.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBonusRemarks.Location = new System.Drawing.Point(156, 233);
            this.lblBonusRemarks.Name = "lblBonusRemarks";
            this.lblBonusRemarks.Size = new System.Drawing.Size(70, 15);
            this.lblBonusRemarks.TabIndex = 13;
            this.lblBonusRemarks.Text = "Remarks :";
            // 
            // btnBonusClose
            // 
            this.btnBonusClose.Location = new System.Drawing.Point(364, 297);
            this.btnBonusClose.Name = "btnBonusClose";
            this.btnBonusClose.Size = new System.Drawing.Size(102, 39);
            this.btnBonusClose.TabIndex = 12;
            this.btnBonusClose.Text = "Close";
            this.btnBonusClose.UseVisualStyleBackColor = true;
            // 
            // btnBonusOk
            // 
            this.btnBonusOk.Location = new System.Drawing.Point(139, 297);
            this.btnBonusOk.Name = "btnBonusOk";
            this.btnBonusOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBonusOk.Size = new System.Drawing.Size(102, 39);
            this.btnBonusOk.TabIndex = 11;
            this.btnBonusOk.Text = "OK";
            this.btnBonusOk.UseVisualStyleBackColor = true;
            this.btnBonusOk.Click += new System.EventHandler(this.btnBonusOk_Click);
            // 
            // txtBonus
            // 
            this.txtBonus.Location = new System.Drawing.Point(231, 188);
            this.txtBonus.MaxLength = 5;
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(306, 23);
            this.txtBonus.TabIndex = 10;
            this.txtBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTickets_KeyPress);
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBonus.Location = new System.Drawing.Point(72, 188);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(154, 15);
            this.lblBonus.TabIndex = 9;
            this.lblBonus.Text = "Enter Bonus to Load :";
            // 
            // dgvBonusCard
            // 
            this.dgvBonusCard.AllowUserToAddRows = false;
            this.dgvBonusCard.AllowUserToDeleteRows = false;
            this.dgvBonusCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvBonusCard.Location = new System.Drawing.Point(61, 55);
            this.dgvBonusCard.MultiSelect = false;
            this.dgvBonusCard.Name = "dgvBonusCard";
            this.dgvBonusCard.ReadOnly = true;
            this.dgvBonusCard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonusCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBonusCard.RowHeadersVisible = false;
            this.dgvBonusCard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBonusCard.Size = new System.Drawing.Size(535, 50);
            this.dgvBonusCard.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "CardNumber";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Available Bonus on Card";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 230;
            // 
            // frmTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 401);
            this.Controls.Add(this.CardTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Tasks";
            this.TopMost = true;
            this.CardTabControl.ResumeLayout(false);
            this.tbLoadTickets.ResumeLayout(false);
            this.tbLoadTickets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardTickets)).EndInit();
            this.tbLoadBonus.ResumeLayout(false);
            this.tbLoadBonus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl CardTabControl;
        private System.Windows.Forms.TabPage tbLoadTickets;
        private System.Windows.Forms.TabPage tbLoadBonus;
        private System.Windows.Forms.DataGridView dgvCardTickets;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtTickets;
        private System.Windows.Forms.Label lblEnterTickets;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTicketRemarks;
        private System.Windows.Forms.Label lblCardDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBonusRemarks;
        private System.Windows.Forms.Label lblBonusRemarks;
        private System.Windows.Forms.Button btnBonusClose;
        private System.Windows.Forms.Button btnBonusOk;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.DataGridView dgvBonusCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}