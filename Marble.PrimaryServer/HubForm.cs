using Marbale.BusinessObject.Game;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marble.PrimaryServer
{
    public partial class HubForm : Form
    {
        List<ActiveHubMachine> machines;
        GameBL gameBL;
        int hubId;
        public HubForm(int hubId)
        {
            this.gameBL = new GameBL();
            this.hubId = hubId;
            InitializeComponent();
        }

        private void HubForm_Load(object sender, EventArgs e)
        {
            var machines = this.gameBL.GetActiveHubMachines(hubId);
            this.hub_dataGridView.DataSource = machines;
            this.lab_Header.Text = this.machines[0].HubName;
        }

        private void btn_shutDown_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            HubForm hForm = new HubForm(this.hubId);
            hForm.Show();
            this.Close();
        }
    }
}
