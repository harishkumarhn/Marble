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
            setting.Id = int.Parse(settings_grid.Rows[rowIndex].Cells[0].Value.ToString());
            setting.Name = settings_grid.Rows[rowIndex].Cells[1].Value.ToString();
            setting.Description = settings_grid.Rows[rowIndex].Cells[2].Value.ToString();
            setting.DefaultValue = settings_grid.Rows[rowIndex].Cells[3].Value.ToString();
            setting.ScreenGroup = settings_grid.Rows[rowIndex].Cells[4].Value.ToString();
            setting.Type = settings_grid.Rows[rowIndex].Cells[5].Value.ToString();
            setting.Active = bool.Parse(settings_grid.Rows[rowIndex].Cells[6].Value.ToString());
            setting.UserLevel = bool.Parse(settings_grid.Rows[rowIndex].Cells[7].Value.ToString());
            setting.PosLevel = bool.Parse(settings_grid.Rows[rowIndex].Cells[8].Value.ToString());
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

        private void txt_skin_TextChanged(object sender, EventArgs e)
        {
            lstAppSetting.Add(new AppSetting() {
                Name = "POS_SKIN_COLOR",
                ScreenGroup = "POS",
                Value = txt_skin.Text
            });
        }

        private void cmb_payMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAppSetting.Add(new AppSetting()
            {
                Name = "DEFAULT_PAY_MODE",
                ScreenGroup = "POS",
                Value = cmb_payMode.Text
            });
        }

        private void txt_MaxToken_TextChanged(object sender, EventArgs e)
        {
            lstAppSetting.Add(new AppSetting()
            {
                Name = "MAX_TOKEN_NUMBER",
                ScreenGroup = "POS",
                Value = txt_MaxToken.Text
            });
        }


    }
}
