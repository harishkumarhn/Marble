namespace Marble.PrimaryServer
{
    partial class HubForm
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
            this.hubLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headePanel = new System.Windows.Forms.Panel();
            this.lab_Header = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.btn_shutDown = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_clearLog = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.hub_dataGridView = new System.Windows.Forms.DataGridView();
            this.hubLayout.SuspendLayout();
            this.headePanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hub_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // hubLayout
            // 
            this.hubLayout.ColumnCount = 1;
            this.hubLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hubLayout.Controls.Add(this.headePanel, 0, 0);
            this.hubLayout.Controls.Add(this.footerPanel, 0, 2);
            this.hubLayout.Controls.Add(this.hub_dataGridView, 0, 1);
            this.hubLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hubLayout.Location = new System.Drawing.Point(0, 0);
            this.hubLayout.Name = "hubLayout";
            this.hubLayout.RowCount = 3;
            this.hubLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.hubLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.hubLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.hubLayout.Size = new System.Drawing.Size(619, 428);
            this.hubLayout.TabIndex = 0;
            // 
            // headePanel
            // 
            this.headePanel.Controls.Add(this.lab_Header);
            this.headePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headePanel.Location = new System.Drawing.Point(3, 3);
            this.headePanel.Name = "headePanel";
            this.headePanel.Size = new System.Drawing.Size(613, 58);
            this.headePanel.TabIndex = 0;
            // 
            // lab_Header
            // 
            this.lab_Header.AutoSize = true;
            this.lab_Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Header.Location = new System.Drawing.Point(15, 0);
            this.lab_Header.Name = "lab_Header";
            this.lab_Header.Size = new System.Drawing.Size(34, 17);
            this.lab_Header.TabIndex = 0;
            this.lab_Header.Text = "Hub";
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.btn_shutDown);
            this.footerPanel.Controls.Add(this.btn_restart);
            this.footerPanel.Controls.Add(this.btn_clearLog);
            this.footerPanel.Controls.Add(this.btn_pause);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerPanel.Location = new System.Drawing.Point(3, 388);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(613, 37);
            this.footerPanel.TabIndex = 1;
            // 
            // btn_shutDown
            // 
            this.btn_shutDown.BackColor = System.Drawing.Color.White;
            this.btn_shutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_shutDown.Location = new System.Drawing.Point(434, 3);
            this.btn_shutDown.Name = "btn_shutDown";
            this.btn_shutDown.Size = new System.Drawing.Size(107, 31);
            this.btn_shutDown.TabIndex = 3;
            this.btn_shutDown.Text = "ShutDown";
            this.btn_shutDown.UseVisualStyleBackColor = false;
            this.btn_shutDown.Click += new System.EventHandler(this.btn_shutDown_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.BackColor = System.Drawing.Color.White;
            this.btn_restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart.Location = new System.Drawing.Point(298, 3);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(107, 31);
            this.btn_restart.TabIndex = 2;
            this.btn_restart.Text = "Restart";
            this.btn_restart.UseVisualStyleBackColor = false;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.BackColor = System.Drawing.Color.White;
            this.btn_clearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearLog.Location = new System.Drawing.Point(160, 3);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(107, 31);
            this.btn_clearLog.TabIndex = 1;
            this.btn_clearLog.Text = "Clear Log";
            this.btn_clearLog.UseVisualStyleBackColor = false;
            // 
            // btn_pause
            // 
            this.btn_pause.BackColor = System.Drawing.Color.White;
            this.btn_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.Location = new System.Drawing.Point(18, 3);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(107, 31);
            this.btn_pause.TabIndex = 0;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = false;
            // 
            // hub_dataGridView
            // 
            this.hub_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hub_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hub_dataGridView.Location = new System.Drawing.Point(3, 67);
            this.hub_dataGridView.Name = "hub_dataGridView";
            this.hub_dataGridView.Size = new System.Drawing.Size(613, 315);
            this.hub_dataGridView.TabIndex = 2;
            // 
            // HubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 428);
            this.Controls.Add(this.hubLayout);
            this.Name = "HubForm";
            this.Text = "Hub";
            this.Load += new System.EventHandler(this.HubForm_Load);
            this.hubLayout.ResumeLayout(false);
            this.headePanel.ResumeLayout(false);
            this.headePanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hub_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel hubLayout;
        private System.Windows.Forms.Panel headePanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.DataGridView hub_dataGridView;
        private System.Windows.Forms.Label lab_Header;
        private System.Windows.Forms.Button btn_shutDown;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_clearLog;
        private System.Windows.Forms.Button btn_pause;
    }
}