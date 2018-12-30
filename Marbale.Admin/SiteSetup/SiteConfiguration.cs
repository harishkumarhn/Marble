using Marbale.Business;
using Marbale.Business.ViewModels;
using Marble.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.SiteSetup
{
    public partial class SiteConfiguration : Form
    {
        List<Settings> lstSettings;
        List<AppSetting> lstAppSetting;
        MarbaleBusiness marbaleBusiness;
        bool posGridLoadCompleted = false;
        public SiteConfiguration()
        {
            InitializeComponent();
            marbaleBusiness = new MarbaleBusiness();

            lstSettings = new List<Settings>();
            lstAppSetting = new List<AppSetting>();
        }

        private void configuration_Click(object sender, EventArgs e)
        {
            var settings = marbaleBusiness.GetSettings();
            settings_grid.DataSource = settings;

            settings_grid.Columns[1].Width = 300;
            settings_grid.Columns[0].ReadOnly = true;
            settings_grid.Columns[1].ReadOnly = true;

            settings_grid.Columns[3].Width = 300;
            settings_grid.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            settings_grid.RowHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            settings_grid.EnableHeadersVisualStyles = false; 

            for (int i = 0; i < settings.Count; i++)
            {
                DataGridViewComboBoxCell dropDown = new DataGridViewComboBoxCell();
                dropDown.DataSource = new List<string>() { "int", "string","bool","datetime" };
                this.settings_grid[5, i] = dropDown;
                this.settings_grid[5, i].Value = settings[i].Type;
            }

        }
    
        private void save_settings_Click(object sender, EventArgs e)
        {
            marbaleBusiness.SaveSettings(lstSettings);
            MessageBox.Show("Setting saved");
        }

        private void settings_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var setting = new Settings();
            setting.Id = Convert.ToInt32(settings_grid.Rows[rowIndex].Cells[0].Value);
            setting.Name = Convert.ToString(settings_grid.Rows[rowIndex].Cells[1].Value);
            setting.Caption = Convert.ToString(settings_grid.Rows[rowIndex].Cells[2].Value);
            setting.Description = Convert.ToString(settings_grid.Rows[rowIndex].Cells[3].Value);
            setting.DefaultValue = Convert.ToString(settings_grid.Rows[rowIndex].Cells[4].Value);
            setting.Type = Convert.ToString(settings_grid.Rows[rowIndex].Cells[5].Value);
            setting.ScreenGroup = Convert.ToString(settings_grid.Rows[rowIndex].Cells[6].Value);
            setting.Active = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[7].Value);
            setting.UserLevel = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[8].Value);
            setting.PosLevel = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[9].Value);
            setting.LastUpdatedBy = "Harish";
            lstSettings.Add(setting);

        }

        private void Refresh_settings_Click(object sender, EventArgs e)
        {
            var settings = marbaleBusiness.GetSettings();
            settings_grid.DataSource = settings;

            settings_grid.Columns[1].Width = 300;
            settings_grid.Columns[0].ReadOnly = true;
            settings_grid.Columns[1].ReadOnly = true;

            settings_grid.Columns[3].Width = 300;
            settings_grid.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            settings_grid.RowHeadersDefaultCellStyle.BackColor = Color.BurlyWood;
            settings_grid.EnableHeadersVisualStyles = false; 

            for (int i = 0; i < settings.Count; i++)
            {
                DataGridViewComboBoxCell dropDown = new DataGridViewComboBoxCell();
                dropDown.DataSource = new List<string>() { "int", "string", "bool", "datetime" };
                this.settings_grid[5, i] = dropDown;
                this.settings_grid[5, i].Value = settings[i].Type;
            }
        }

        private void close_settings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_pos_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstAppSetting.Count > 0)
                {
                    var result = marbaleBusiness.SavePOSConfiguration(lstAppSetting);
                    MessageBox.Show("Data Saved Succesfully");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void moduleValuesTab_Click(object sender, EventArgs e)
        {
            var appSettings = marbaleBusiness.GetAppSettings("POS");
            pos_appSettingsGrid.DataSource = appSettings;
            pos_appSettingsGrid.Columns[0].Width = 300;
            pos_appSettingsGrid.Columns[1].Width = 300;
            pos_appSettingsGrid.BackgroundColor = Color.White;

            for(int i = 0 ;i < appSettings.Count ; i++)
            {
                if (appSettings[i].Type == "bool")
                {
                    DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                    CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.pos_appSettingsGrid[1, i] = CheckBoxCell;
                    this.pos_appSettingsGrid[1, i].Value = appSettings[i].Value;
                }
            }

            pos_appSettingsGrid.Columns[2].Visible = false;
            pos_appSettingsGrid.Columns[3].Visible = false;
            pos_appSettingsGrid.Columns[4].Visible = false;
        }

        private void pos_appSettingsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (posGridLoadCompleted == true)
            {
                var rowIndex = e.RowIndex;
                var appSetting = new AppSetting();
                appSetting.Name = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[0].Value);
                appSetting.Value = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[1].Value);
                appSetting.Caption = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[2].Value);
                appSetting.ScreenGroup = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[3].Value);
                appSetting.Type = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[4].Value);

                lstAppSetting.Add(appSetting);
            }
        }

        private void refresh_pos_Click(object sender, EventArgs e)
        {
            getPOSSetings();
        }

        private void getPOSSetings()
        {
            var appSettings = marbaleBusiness.GetAppSettings("POS");
            pos_appSettingsGrid.DataSource = appSettings;

            pos_appSettingsGrid.Columns[0].Width = 300;
            pos_appSettingsGrid.Columns[1].Width = 300;
            pos_appSettingsGrid.BackgroundColor = Color.White;

            for (int i = 0; i < appSettings.Count; i++)
            {
                if (appSettings[i].Type == "bool")
                {
                    DataGridViewCheckBoxCell CheckBoxCell = new DataGridViewCheckBoxCell();
                    CheckBoxCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.pos_appSettingsGrid[1, i] = CheckBoxCell;
                    this.pos_appSettingsGrid[1, i].Value = appSettings[i].Value;
                }
            }

            pos_appSettingsGrid.Columns[2].Visible = false;
            pos_appSettingsGrid.Columns[3].Visible = false;
            pos_appSettingsGrid.Columns[4].Visible = false;
            posGridLoadCompleted = true;
        }

        private void moduleValuesTab_Selected(object sender, TabControlEventArgs e)
        {
            if (moduleValuesTab.TabPages[moduleValuesTab.SelectedIndex].Text == "POS")
            {
                getPOSSetings();
            }
        }

        private void close_pos_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
