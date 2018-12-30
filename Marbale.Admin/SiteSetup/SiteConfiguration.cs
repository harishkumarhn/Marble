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
        public SiteConfiguration()
        {
            InitializeComponent();
            marbaleBusiness = new MarbaleBusiness();

            lstSettings = new List<Settings>();
            lstAppSetting = new List<AppSetting>();
        }

        private void POSTab_Click(object sender, EventArgs e)
        {
            var appSettings = marbaleBusiness.GetAppSettings("POS");
            pos_appSettingsGrid.DataSource = appSettings;
        }

        private void configuration_Click(object sender, EventArgs e)
        {
            var settings = marbaleBusiness.GetSettings();
            settings_grid.DataSource = settings;
        }

        private void settings_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void save_settings_Click(object sender, EventArgs e)
        {
            marbaleBusiness.SaveSettings(lstSettings);
        }

        private void settings_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            //var colIndex = e.ColumnIndex;
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
        }

        private void close_settings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_pos_Click(object sender, EventArgs e)
        {
            if (lstAppSetting.Count > 0)
            {
                marbaleBusiness.SavePOSConfiguration(lstAppSetting);
            }
        }

        private void moduleValuesTab_Click(object sender, EventArgs e)
        {
            var appSettings = marbaleBusiness.GetAppSettings("POS");
            
       
            pos_appSettingsGrid.DataSource = appSettings;
            
            for (int i = 0; i <pos_appSettingsGrid.Rows.Count; i++)
            {

                if (i % 2 != 0)
                {
                    pos_appSettingsGrid.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                    pos_appSettingsGrid.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                    pos_appSettingsGrid.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(192, 255, 255); 
                }
                else
                {
                    pos_appSettingsGrid.Rows[i].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                    pos_appSettingsGrid.Rows[i].Cells[1].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                    pos_appSettingsGrid.Rows[i].Cells[2].Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                }
            }
            pos_appSettingsGrid.Columns[0].Width = 300;
            pos_appSettingsGrid.Columns[1].Width = 300;
            pos_appSettingsGrid.BackgroundColor = Color.White;

            pos_appSettingsGrid.Columns[2].Visible = false;
            pos_appSettingsGrid.Columns[3].Visible = false;

        }
        private void pos_appSettingsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            var rowIndex = e.RowIndex;
            var appSetting = new AppSetting();
            appSetting.Name = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[0].Value);
            appSetting.Value = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[1].Value);
            appSetting.ScreenGroup = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[2].Value);
            appSetting.Type = Convert.ToString(pos_appSettingsGrid.Rows[rowIndex].Cells[3].Value);

            lstAppSetting.Add(appSetting);
        }

        private void pos_appSettingsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
