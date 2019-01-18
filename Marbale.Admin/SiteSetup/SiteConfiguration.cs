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
            setting.Id = Convert.ToInt32(settings_grid.Rows[rowIndex].Cells[0].Value);
            setting.Name = Convert.ToString(settings_grid.Rows[rowIndex].Cells[1].Value);
            setting.Description = Convert.ToString(settings_grid.Rows[rowIndex].Cells[2].Value);
            setting.DefaultValue = Convert.ToString(settings_grid.Rows[rowIndex].Cells[3].Value);
            setting.Type = Convert.ToString(settings_grid.Rows[rowIndex].Cells[4].Value);
            setting.ScreenGroup = Convert.ToString(settings_grid.Rows[rowIndex].Cells[5].Value);
            setting.Active = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[6].Value);
            setting.UserLevel = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[7].Value);
            setting.PosLevel = Convert.ToBoolean(settings_grid.Rows[rowIndex].Cells[8].Value);
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
