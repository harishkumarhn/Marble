namespace Marbale.SiteSetup
{
    partial class SiteConfiguration
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
            this.configuration = new System.Windows.Forms.TabControl();
            this.valuesTabPage = new System.Windows.Forms.TabPage();
            this.moduleValuesTab = new System.Windows.Forms.TabControl();
            this.POSTab = new System.Windows.Forms.TabPage();
            this.cardsTab = new System.Windows.Forms.TabPage();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.close_settings = new System.Windows.Forms.Button();
            this.Refresh_settings = new System.Windows.Forms.Button();
            this.save_settings = new System.Windows.Forms.Button();
            this.settings_grid = new System.Windows.Forms.DataGridView();
            this.LastUpdatedDate_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdateBy_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScreenGroup_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSLevel_cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserLevel_cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ActiveFlag_cl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DataType_cl = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DefaultValue_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_cl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configuration.SuspendLayout();
            this.valuesTabPage.SuspendLayout();
            this.moduleValuesTab.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settings_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // configuration
            // 
            this.configuration.Controls.Add(this.valuesTabPage);
            this.configuration.Controls.Add(this.settingsTabPage);
            this.configuration.Location = new System.Drawing.Point(1, 0);
            this.configuration.Name = "configuration";
            this.configuration.SelectedIndex = 0;
            this.configuration.Size = new System.Drawing.Size(909, 530);
            this.configuration.TabIndex = 0;
            this.configuration.Click += new System.EventHandler(this.configuration_Click);
            // 
            // valuesTabPage
            // 
            this.valuesTabPage.Controls.Add(this.moduleValuesTab);
            this.valuesTabPage.Location = new System.Drawing.Point(4, 22);
            this.valuesTabPage.Name = "valuesTabPage";
            this.valuesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.valuesTabPage.Size = new System.Drawing.Size(901, 504);
            this.valuesTabPage.TabIndex = 0;
            this.valuesTabPage.Text = "Values";
            this.valuesTabPage.UseVisualStyleBackColor = true;
            // 
            // moduleValuesTab
            // 
            this.moduleValuesTab.Controls.Add(this.POSTab);
            this.moduleValuesTab.Controls.Add(this.cardsTab);
            this.moduleValuesTab.Location = new System.Drawing.Point(7, 6);
            this.moduleValuesTab.Name = "moduleValuesTab";
            this.moduleValuesTab.SelectedIndex = 0;
            this.moduleValuesTab.Size = new System.Drawing.Size(891, 498);
            this.moduleValuesTab.TabIndex = 0;
            // 
            // POSTab
            // 
            this.POSTab.Location = new System.Drawing.Point(4, 22);
            this.POSTab.Name = "POSTab";
            this.POSTab.Padding = new System.Windows.Forms.Padding(3);
            this.POSTab.Size = new System.Drawing.Size(883, 472);
            this.POSTab.TabIndex = 0;
            this.POSTab.Text = "POS";
            this.POSTab.UseVisualStyleBackColor = true;
            this.POSTab.Click += new System.EventHandler(this.POSTab_Click);
            // 
            // cardsTab
            // 
            this.cardsTab.Location = new System.Drawing.Point(4, 22);
            this.cardsTab.Name = "cardsTab";
            this.cardsTab.Padding = new System.Windows.Forms.Padding(3);
            this.cardsTab.Size = new System.Drawing.Size(883, 472);
            this.cardsTab.TabIndex = 1;
            this.cardsTab.Text = "Cards";
            this.cardsTab.UseVisualStyleBackColor = true;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.close_settings);
            this.settingsTabPage.Controls.Add(this.Refresh_settings);
            this.settingsTabPage.Controls.Add(this.save_settings);
            this.settingsTabPage.Controls.Add(this.settings_grid);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(901, 504);
            this.settingsTabPage.TabIndex = 1;
            this.settingsTabPage.Text = "Settings";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // close_settings
            // 
            this.close_settings.Location = new System.Drawing.Point(213, 472);
            this.close_settings.Name = "close_settings";
            this.close_settings.Size = new System.Drawing.Size(75, 23);
            this.close_settings.TabIndex = 3;
            this.close_settings.Text = "Close";
            this.close_settings.UseVisualStyleBackColor = true;
            this.close_settings.Click += new System.EventHandler(this.close_settings_Click);
            // 
            // Refresh_settings
            // 
            this.Refresh_settings.Location = new System.Drawing.Point(115, 472);
            this.Refresh_settings.Name = "Refresh_settings";
            this.Refresh_settings.Size = new System.Drawing.Size(75, 23);
            this.Refresh_settings.TabIndex = 2;
            this.Refresh_settings.Text = "Refresh";
            this.Refresh_settings.UseVisualStyleBackColor = true;
            this.Refresh_settings.Click += new System.EventHandler(this.Refresh_settings_Click);
            // 
            // save_settings
            // 
            this.save_settings.Location = new System.Drawing.Point(19, 472);
            this.save_settings.Name = "save_settings";
            this.save_settings.Size = new System.Drawing.Size(75, 23);
            this.save_settings.TabIndex = 1;
            this.save_settings.Text = "Savr";
            this.save_settings.UseVisualStyleBackColor = true;
            this.save_settings.Click += new System.EventHandler(this.save_settings_Click);
            // 
            // settings_grid
            // 
            this.settings_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settings_grid.Location = new System.Drawing.Point(3, 6);
            this.settings_grid.Name = "settings_grid";
            this.settings_grid.Size = new System.Drawing.Size(891, 444);
            this.settings_grid.TabIndex = 0;
            this.settings_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.settings_grid_CellContentClick);
            this.settings_grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.settings_grid_CellValueChanged);
            // 
            // LastUpdatedDate_cl
            // 
            this.LastUpdatedDate_cl.HeaderText = "LastUpdatedDate";
            this.LastUpdatedDate_cl.Name = "LastUpdatedDate_cl";
            // 
            // LastUpdateBy_cl
            // 
            this.LastUpdateBy_cl.HeaderText = "LastUpdated";
            this.LastUpdateBy_cl.Name = "LastUpdateBy_cl";
            // 
            // ScreenGroup_cl
            // 
            this.ScreenGroup_cl.HeaderText = "ScreenGroup";
            this.ScreenGroup_cl.Name = "ScreenGroup_cl";
            // 
            // POSLevel_cl
            // 
            this.POSLevel_cl.HeaderText = "POSLevel";
            this.POSLevel_cl.Name = "POSLevel_cl";
            // 
            // UserLevel_cl
            // 
            this.UserLevel_cl.HeaderText = "UserLevel";
            this.UserLevel_cl.Name = "UserLevel_cl";
            // 
            // ActiveFlag_cl
            // 
            this.ActiveFlag_cl.HeaderText = "ActiveFlag";
            this.ActiveFlag_cl.Name = "ActiveFlag_cl";
            // 
            // DataType_cl
            // 
            this.DataType_cl.HeaderText = "DataType";
            this.DataType_cl.Name = "DataType_cl";
            this.DataType_cl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataType_cl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DefaultValue_cl
            // 
            this.DefaultValue_cl.HeaderText = "DefaultValue";
            this.DefaultValue_cl.Name = "DefaultValue_cl";
            // 
            // Description_cl
            // 
            this.Description_cl.HeaderText = "Description";
            this.Description_cl.Name = "Description_cl";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Name_cl
            // 
            this.Name_cl.HeaderText = "Name";
            this.Name_cl.Name = "Name_cl";
            // 
            // cl_Id
            // 
            this.cl_Id.HeaderText = "ID";
            this.cl_Id.Name = "cl_Id";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 529);
            this.Controls.Add(this.configuration);
            this.Name = "ConfigForm";
            this.Text = "Configuration";
            this.configuration.ResumeLayout(false);
            this.valuesTabPage.ResumeLayout(false);
            this.moduleValuesTab.ResumeLayout(false);
            this.settingsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settings_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl configuration;
        private System.Windows.Forms.TabPage valuesTabPage;
        private System.Windows.Forms.TabControl moduleValuesTab;
        private System.Windows.Forms.TabPage POSTab;
        private System.Windows.Forms.TabPage cardsTab;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Button close_settings;
        private System.Windows.Forms.Button Refresh_settings;
        private System.Windows.Forms.Button save_settings;
        private System.Windows.Forms.DataGridView settings_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedDate_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdateBy_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScreenGroup_cl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn POSLevel_cl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UserLevel_cl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ActiveFlag_cl;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_cl;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Id;

    }
}