﻿namespace Marbale.POS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tbLoadMultiple = new System.Windows.Forms.TabPage();
            this.tbTransferCard = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTransferCardOk = new System.Windows.Forms.Button();
            this.btnGetTocard = new System.Windows.Forms.Button();
            this.txtTocardNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetFromcard = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvToCard = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvFromCard = new System.Windows.Forms.DataGridView();
            this.txtFromCardnumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbConsilidated = new System.Windows.Forms.TabPage();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTabControl.SuspendLayout();
            this.tbLoadTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardTickets)).BeginInit();
            this.tbLoadBonus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusCard)).BeginInit();
            this.tbTransferCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromCard)).BeginInit();
            this.SuspendLayout();
            // 
            // CardTabControl
            // 
            this.CardTabControl.Controls.Add(this.tbLoadTickets);
            this.CardTabControl.Controls.Add(this.tbLoadBonus);
            this.CardTabControl.Controls.Add(this.tbLoadMultiple);
            this.CardTabControl.Controls.Add(this.tbTransferCard);
            this.CardTabControl.Controls.Add(this.tbConsilidated);
            this.CardTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardTabControl.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.CardTabControl.Location = new System.Drawing.Point(0, 0);
            this.CardTabControl.Name = "CardTabControl";
            this.CardTabControl.SelectedIndex = 0;
            this.CardTabControl.Size = new System.Drawing.Size(744, 423);
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
            this.tbLoadTickets.Size = new System.Drawing.Size(736, 395);
            this.tbLoadTickets.TabIndex = 0;
            this.tbLoadTickets.Tag = "0";
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
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCardTickets.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            this.tbLoadBonus.Size = new System.Drawing.Size(736, 395);
            this.tbLoadBonus.TabIndex = 1;
            this.tbLoadBonus.Tag = "1";
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
            this.btnBonusClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBonusClose.Location = new System.Drawing.Point(364, 297);
            this.btnBonusClose.Name = "btnBonusClose";
            this.btnBonusClose.Size = new System.Drawing.Size(102, 39);
            this.btnBonusClose.TabIndex = 12;
            this.btnBonusClose.Text = "Close";
            this.btnBonusClose.UseVisualStyleBackColor = true;
            this.btnBonusClose.Click += new System.EventHandler(this.btnBonusClose_Click);
            // 
            // btnBonusOk
            // 
            this.btnBonusOk.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBonusCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            // tbLoadMultiple
            // 
            this.tbLoadMultiple.Location = new System.Drawing.Point(4, 24);
            this.tbLoadMultiple.Name = "tbLoadMultiple";
            this.tbLoadMultiple.Size = new System.Drawing.Size(736, 395);
            this.tbLoadMultiple.TabIndex = 3;
            this.tbLoadMultiple.Tag = "2";
            this.tbLoadMultiple.Text = "Load Multiple";
            this.tbLoadMultiple.UseVisualStyleBackColor = true;
            // 
            // tbTransferCard
            // 
            this.tbTransferCard.Controls.Add(this.textBox3);
            this.tbTransferCard.Controls.Add(this.label6);
            this.tbTransferCard.Controls.Add(this.button2);
            this.tbTransferCard.Controls.Add(this.btnTransferCardOk);
            this.tbTransferCard.Controls.Add(this.btnGetTocard);
            this.tbTransferCard.Controls.Add(this.txtTocardNumber);
            this.tbTransferCard.Controls.Add(this.label5);
            this.tbTransferCard.Controls.Add(this.btnGetFromcard);
            this.tbTransferCard.Controls.Add(this.label4);
            this.tbTransferCard.Controls.Add(this.dgvToCard);
            this.tbTransferCard.Controls.Add(this.label3);
            this.tbTransferCard.Controls.Add(this.dgvFromCard);
            this.tbTransferCard.Controls.Add(this.txtFromCardnumber);
            this.tbTransferCard.Controls.Add(this.label2);
            this.tbTransferCard.Location = new System.Drawing.Point(4, 24);
            this.tbTransferCard.Name = "tbTransferCard";
            this.tbTransferCard.Padding = new System.Windows.Forms.Padding(3);
            this.tbTransferCard.Size = new System.Drawing.Size(736, 395);
            this.tbTransferCard.TabIndex = 2;
            this.tbTransferCard.Tag = "3";
            this.tbTransferCard.Text = "Transfer card";
            this.tbTransferCard.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(252, 275);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(364, 42);
            this.textBox3.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(176, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Remarks :";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(433, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 39);
            this.button2.TabIndex = 25;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnTransferCardOk
            // 
            this.btnTransferCardOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTransferCardOk.Location = new System.Drawing.Point(144, 338);
            this.btnTransferCardOk.Name = "btnTransferCardOk";
            this.btnTransferCardOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnTransferCardOk.Size = new System.Drawing.Size(102, 39);
            this.btnTransferCardOk.TabIndex = 24;
            this.btnTransferCardOk.Text = "OK";
            this.btnTransferCardOk.UseVisualStyleBackColor = true;
            this.btnTransferCardOk.Click += new System.EventHandler(this.btnTransferCardOk_Click);
            // 
            // btnGetTocard
            // 
            this.btnGetTocard.Location = new System.Drawing.Point(433, 152);
            this.btnGetTocard.Name = "btnGetTocard";
            this.btnGetTocard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGetTocard.Size = new System.Drawing.Size(93, 23);
            this.btnGetTocard.TabIndex = 23;
            this.btnGetTocard.Text = "Get Details";
            this.btnGetTocard.UseVisualStyleBackColor = true;
            this.btnGetTocard.Click += new System.EventHandler(this.btnGetTocard_Click);
            // 
            // txtTocardNumber
            // 
            this.txtTocardNumber.Location = new System.Drawing.Point(252, 152);
            this.txtTocardNumber.MaxLength = 10;
            this.txtTocardNumber.Name = "txtTocardNumber";
            this.txtTocardNumber.Size = new System.Drawing.Size(161, 23);
            this.txtTocardNumber.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(92, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Enter To CardNumber :";
            // 
            // btnGetFromcard
            // 
            this.btnGetFromcard.Location = new System.Drawing.Point(433, 21);
            this.btnGetFromcard.Name = "btnGetFromcard";
            this.btnGetFromcard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGetFromcard.Size = new System.Drawing.Size(93, 23);
            this.btnGetFromcard.TabIndex = 20;
            this.btnGetFromcard.Text = "Get Details";
            this.btnGetFromcard.UseVisualStyleBackColor = true;
            this.btnGetFromcard.Click += new System.EventHandler(this.btnGetFromcard_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(78, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "To Card Details";
            // 
            // dgvToCard
            // 
            this.dgvToCard.AllowUserToAddRows = false;
            this.dgvToCard.AllowUserToDeleteRows = false;
            this.dgvToCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Column3,
            this.fv});
            this.dgvToCard.Location = new System.Drawing.Point(81, 207);
            this.dgvToCard.MultiSelect = false;
            this.dgvToCard.Name = "dgvToCard";
            this.dgvToCard.ReadOnly = true;
            this.dgvToCard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvToCard.RowHeadersVisible = false;
            this.dgvToCard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvToCard.Size = new System.Drawing.Size(605, 50);
            this.dgvToCard.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "CardNumber";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "credit";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Bonus";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // fv
            // 
            this.fv.HeaderText = "Tickets";
            this.fv.Name = "fv";
            this.fv.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(78, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "From Card Details";
            // 
            // dgvFromCard
            // 
            this.dgvFromCard.AllowUserToAddRows = false;
            this.dgvFromCard.AllowUserToDeleteRows = false;
            this.dgvFromCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFromCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column1,
            this.Column2});
            this.dgvFromCard.Location = new System.Drawing.Point(81, 71);
            this.dgvFromCard.MultiSelect = false;
            this.dgvFromCard.Name = "dgvFromCard";
            this.dgvFromCard.ReadOnly = true;
            this.dgvFromCard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFromCard.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFromCard.RowHeadersVisible = false;
            this.dgvFromCard.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvFromCard.Size = new System.Drawing.Size(605, 50);
            this.dgvFromCard.TabIndex = 16;
            // 
            // txtFromCardnumber
            // 
            this.txtFromCardnumber.Location = new System.Drawing.Point(252, 21);
            this.txtFromCardnumber.MaxLength = 10;
            this.txtFromCardnumber.Name = "txtFromCardnumber";
            this.txtFromCardnumber.Size = new System.Drawing.Size(161, 23);
            this.txtFromCardnumber.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(78, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter From CardNumber :";
            // 
            // tbConsilidated
            // 
            this.tbConsilidated.Location = new System.Drawing.Point(4, 24);
            this.tbConsilidated.Name = "tbConsilidated";
            this.tbConsilidated.Size = new System.Drawing.Size(736, 395);
            this.tbConsilidated.TabIndex = 4;
            this.tbConsilidated.Tag = "4";
            this.tbConsilidated.Text = "Consolidate Cards";
            this.tbConsilidated.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "CardNumber";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Credit";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Bonus";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tickets";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // frmTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 423);
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
            this.tbTransferCard.ResumeLayout(false);
            this.tbTransferCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFromCard)).EndInit();
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
        private System.Windows.Forms.TabPage tbTransferCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvFromCard;
        private System.Windows.Forms.TextBox txtFromCardnumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvToCard;
        private System.Windows.Forms.Button btnGetFromcard;
        private System.Windows.Forms.Button btnGetTocard;
        private System.Windows.Forms.TextBox txtTocardNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTransferCardOk;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fv;
        private System.Windows.Forms.TabPage tbLoadMultiple;
        private System.Windows.Forms.TabPage tbConsilidated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}