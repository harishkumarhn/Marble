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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.configuration = new System.Windows.Forms.TabControl();
            this.valuesTabPage = new System.Windows.Forms.TabPage();
            this.moduleValuesTab = new System.Windows.Forms.TabControl();
            this.POSTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pos_contentPanel = new System.Windows.Forms.Panel();
            this.txt_MaxToken = new System.Windows.Forms.TextBox();
            this.lab_maxToken = new System.Windows.Forms.Label();
            this.cmb_payMode = new System.Windows.Forms.ComboBox();
            this.lab_payMode = new System.Windows.Forms.Label();
            this.txt_skin = new System.Windows.Forms.TextBox();
            this.lab_skin = new System.Windows.Forms.Label();
            this.pos_actionPanel = new System.Windows.Forms.Panel();
            this.close_pos = new System.Windows.Forms.Button();
            this.refresh_pos = new System.Windows.Forms.Button();
            this.save_pos = new System.Windows.Forms.Button();
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
            this.POSTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pos_contentPanel.SuspendLayout();
            this.pos_actionPanel.SuspendLayout();
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
            this.POSTab.Controls.Add(this.tableLayoutPanel1);
            this.POSTab.Location = new System.Drawing.Point(4, 22);
            this.POSTab.Name = "POSTab";
            this.POSTab.Padding = new System.Windows.Forms.Padding(3);
            this.POSTab.Size = new System.Drawing.Size(883, 472);
            this.POSTab.TabIndex = 0;
            this.POSTab.Text = "POS";
            this.POSTab.UseVisualStyleBackColor = true;
            this.POSTab.Click += new System.EventHandler(this.POSTab_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.pos_contentPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pos_actionPanel, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.58785F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.41215F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pos_contentPanel
            // 
            this.pos_contentPanel.Controls.Add(this.txt_MaxToken);
            this.pos_contentPanel.Controls.Add(this.lab_maxToken);
            this.pos_contentPanel.Controls.Add(this.cmb_payMode);
            this.pos_contentPanel.Controls.Add(this.lab_payMode);
            this.pos_contentPanel.Controls.Add(this.txt_skin);
            this.pos_contentPanel.Controls.Add(this.lab_skin);
            this.pos_contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pos_contentPanel.Location = new System.Drawing.Point(3, 3);
            this.pos_contentPanel.Name = "pos_contentPanel";
            this.pos_contentPanel.Size = new System.Drawing.Size(871, 406);
            this.pos_contentPanel.TabIndex = 0;
            // 
            // txt_MaxToken
            // 
            this.txt_MaxToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaxToken.Location = new System.Drawing.Point(175, 83);
            this.txt_MaxToken.Name = "txt_MaxToken";
            this.txt_MaxToken.Size = new System.Drawing.Size(100, 22);
            this.txt_MaxToken.TabIndex = 5;
            this.txt_MaxToken.TextChanged += new System.EventHandler(this.txt_MaxToken_TextChanged);
            // 
            // lab_maxToken
            // 
            this.lab_maxToken.AutoSize = true;
            this.lab_maxToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_maxToken.Location = new System.Drawing.Point(47, 86);
            this.lab_maxToken.Name = "lab_maxToken";
            this.lab_maxToken.Size = new System.Drawing.Size(123, 16);
            this.lab_maxToken.TabIndex = 4;
            this.lab_maxToken.Text = "MaxToken Number";
            // 
            // cmb_payMode
            // 
            this.cmb_payMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_payMode.FormattingEnabled = true;
            this.cmb_payMode.Items.AddRange(new object[] {
            "Cash",
            "None",
            "Credit Card",
            "Game Card"});
            this.cmb_payMode.Location = new System.Drawing.Point(175, 47);
            this.cmb_payMode.Name = "cmb_payMode";
            this.cmb_payMode.Size = new System.Drawing.Size(121, 24);
            this.cmb_payMode.TabIndex = 3;
            this.cmb_payMode.SelectedIndexChanged += new System.EventHandler(this.cmb_payMode_SelectedIndexChanged);
            // 
            // lab_payMode
            // 
            this.lab_payMode.AutoSize = true;
            this.lab_payMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_payMode.Location = new System.Drawing.Point(47, 50);
            this.lab_payMode.Name = "lab_payMode";
            this.lab_payMode.Size = new System.Drawing.Size(115, 16);
            this.lab_payMode.TabIndex = 2;
            this.lab_payMode.Text = "Default Pay Mode";
            // 
            // txt_skin
            // 
            this.txt_skin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_skin.Location = new System.Drawing.Point(175, 9);
            this.txt_skin.Name = "txt_skin";
            this.txt_skin.Size = new System.Drawing.Size(100, 22);
            this.txt_skin.TabIndex = 1;
            this.txt_skin.TextChanged += new System.EventHandler(this.txt_skin_TextChanged);
            // 
            // lab_skin
            // 
            this.lab_skin.AutoSize = true;
            this.lab_skin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_skin.Location = new System.Drawing.Point(47, 12);
            this.lab_skin.Name = "lab_skin";
            this.lab_skin.Size = new System.Drawing.Size(100, 16);
            this.lab_skin.TabIndex = 0;
            this.lab_skin.Text = "POS Skin Color";
            // 
            // pos_actionPanel
            // 
            this.pos_actionPanel.BackColor = System.Drawing.Color.LightGray;
            this.pos_actionPanel.Controls.Add(this.close_pos);
            this.pos_actionPanel.Controls.Add(this.refresh_pos);
            this.pos_actionPanel.Controls.Add(this.save_pos);
            this.pos_actionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pos_actionPanel.Location = new System.Drawing.Point(3, 415);
            this.pos_actionPanel.Name = "pos_actionPanel";
            this.pos_actionPanel.Size = new System.Drawing.Size(871, 43);
            this.pos_actionPanel.TabIndex = 1;
            // 
            // close_pos
            // 
            this.close_pos.BackColor = System.Drawing.Color.White;
            this.close_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_pos.Location = new System.Drawing.Point(218, 3);
            this.close_pos.Name = "close_pos";
            this.close_pos.Size = new System.Drawing.Size(79, 30);
            this.close_pos.TabIndex = 2;
            this.close_pos.Text = "Close";
            this.close_pos.UseVisualStyleBackColor = false;
            // 
            // refresh_pos
            // 
            this.refresh_pos.BackColor = System.Drawing.Color.White;
            this.refresh_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_pos.Location = new System.Drawing.Point(117, 3);
            this.refresh_pos.Name = "refresh_pos";
            this.refresh_pos.Size = new System.Drawing.Size(79, 30);
            this.refresh_pos.TabIndex = 1;
            this.refresh_pos.Text = "Refresh";
            this.refresh_pos.UseVisualStyleBackColor = false;
            // 
            // save_pos
            // 
            this.save_pos.BackColor = System.Drawing.Color.White;
            this.save_pos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_pos.Location = new System.Drawing.Point(20, 3);
            this.save_pos.Name = "save_pos";
            this.save_pos.Size = new System.Drawing.Size(79, 30);
            this.save_pos.TabIndex = 0;
            this.save_pos.Text = "Save";
            this.save_pos.UseVisualStyleBackColor = false;
            this.save_pos.Click += new System.EventHandler(this.save_pos_Click);
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
            this.close_settings.BackColor = System.Drawing.Color.White;
            this.close_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_settings.Location = new System.Drawing.Point(213, 472);
            this.close_settings.Name = "close_settings";
            this.close_settings.Size = new System.Drawing.Size(80, 30);
            this.close_settings.TabIndex = 3;
            this.close_settings.Text = "Close";
            this.close_settings.UseVisualStyleBackColor = false;
            this.close_settings.Click += new System.EventHandler(this.close_settings_Click);
            // 
            // Refresh_settings
            // 
            this.Refresh_settings.BackColor = System.Drawing.Color.White;
            this.Refresh_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Refresh_settings.Location = new System.Drawing.Point(115, 472);
            this.Refresh_settings.Name = "Refresh_settings";
            this.Refresh_settings.Size = new System.Drawing.Size(80, 30);
            this.Refresh_settings.TabIndex = 2;
            this.Refresh_settings.Text = "Refresh";
            this.Refresh_settings.UseVisualStyleBackColor = false;
            this.Refresh_settings.Click += new System.EventHandler(this.Refresh_settings_Click);
            // 
            // save_settings
            // 
            this.save_settings.BackColor = System.Drawing.Color.White;
            this.save_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_settings.Location = new System.Drawing.Point(19, 472);
            this.save_settings.Name = "save_settings";
            this.save_settings.Size = new System.Drawing.Size(80, 30);
            this.save_settings.TabIndex = 1;
            this.save_settings.Text = "Save";
            this.save_settings.UseVisualStyleBackColor = false;
            this.save_settings.Click += new System.EventHandler(this.save_settings_Click);
            // 
            // settings_grid
            // 
            this.settings_grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.settings_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.settings_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.settings_grid.DefaultCellStyle = dataGridViewCellStyle3;
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
            // SiteConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 529);
            this.Controls.Add(this.configuration);
            this.Name = "SiteConfiguration";
            this.Text = "Configuration";
            this.configuration.ResumeLayout(false);
            this.valuesTabPage.ResumeLayout(false);
            this.moduleValuesTab.ResumeLayout(false);
            this.POSTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pos_contentPanel.ResumeLayout(false);
            this.pos_contentPanel.PerformLayout();
            this.pos_actionPanel.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pos_contentPanel;
        private System.Windows.Forms.Panel pos_actionPanel;
        private System.Windows.Forms.Button close_pos;
        private System.Windows.Forms.Button refresh_pos;
        private System.Windows.Forms.Button save_pos;
        private System.Windows.Forms.TextBox txt_MaxToken;
        private System.Windows.Forms.Label lab_maxToken;
        private System.Windows.Forms.ComboBox cmb_payMode;
        private System.Windows.Forms.Label lab_payMode;
        private System.Windows.Forms.TextBox txt_skin;
        private System.Windows.Forms.Label lab_skin;

    }
}