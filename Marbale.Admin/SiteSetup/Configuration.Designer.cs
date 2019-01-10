namespace Marbale.SiteSetup
{
    partial class Configuration
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
            this.valuesTab = new System.Windows.Forms.TabPage();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.Cards = new System.Windows.Forms.TabControl();
            this.POSTab = new System.Windows.Forms.TabPage();
            this.CardsTab = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.valuesTab.SuspendLayout();
            this.Cards.SuspendLayout();
            this.POSTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.valuesTab);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-3, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 521);
            this.tabControl1.TabIndex = 1;
            // 
            // valuesTab
            // 
            this.valuesTab.Controls.Add(this.Cards);
            this.valuesTab.Location = new System.Drawing.Point(4, 22);
            this.valuesTab.Name = "valuesTab";
            this.valuesTab.Padding = new System.Windows.Forms.Padding(3);
            this.valuesTab.Size = new System.Drawing.Size(932, 495);
            this.valuesTab.TabIndex = 0;
            this.valuesTab.Text = "Values";
            this.valuesTab.UseVisualStyleBackColor = true;
            this.valuesTab.Click += new System.EventHandler(this.valuesTab_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(932, 495);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // Cards
            // 
            this.Cards.Controls.Add(this.POSTab);
            this.Cards.Controls.Add(this.CardsTab);
            this.Cards.Controls.Add(this.tabPage1);
            this.Cards.Location = new System.Drawing.Point(6, 6);
            this.Cards.Name = "Cards";
            this.Cards.SelectedIndex = 0;
            this.Cards.Size = new System.Drawing.Size(924, 477);
            this.Cards.TabIndex = 0;
            // 
            // POSTab
            // 
            this.POSTab.Controls.Add(this.checkBox1);
            this.POSTab.Location = new System.Drawing.Point(4, 22);
            this.POSTab.Name = "POSTab";
            this.POSTab.Padding = new System.Windows.Forms.Padding(3);
            this.POSTab.Size = new System.Drawing.Size(916, 451);
            this.POSTab.TabIndex = 0;
            this.POSTab.Text = "POS";
            this.POSTab.UseVisualStyleBackColor = true;
            this.POSTab.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // CardsTab
            // 
            this.CardsTab.Location = new System.Drawing.Point(4, 22);
            this.CardsTab.Name = "CardsTab";
            this.CardsTab.Padding = new System.Windows.Forms.Padding(3);
            this.CardsTab.Size = new System.Drawing.Size(916, 451);
            this.CardsTab.TabIndex = 1;
            this.CardsTab.Text = "Cards";
            this.CardsTab.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(932, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DataTypes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(253, 200);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 513);
            this.Controls.Add(this.tabControl1);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.tabControl1.ResumeLayout(false);
            this.valuesTab.ResumeLayout(false);
            this.Cards.ResumeLayout(false);
            this.POSTab.ResumeLayout(false);
            this.POSTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage valuesTab;
        private System.Windows.Forms.TabControl Cards;
        private System.Windows.Forms.TabPage POSTab;
        private System.Windows.Forms.TabPage CardsTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}