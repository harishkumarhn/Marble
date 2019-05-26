using Marbale.BusinessObject.Game;
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
        int hubCount;
        public HubForm(List<ActiveHubMachine> machines, int hubCount)
        {
            this.machines = machines;
            this.hubCount = hubCount;
            InitializeComponent();
        }

        private void HubForm_Load(object sender, EventArgs e)
        {
            this.hub_dataGridView.DataSource = this.machines;
            this.lab_Header.Text = this.machines[0].HubName;
            this.Text = "Hub " + hubCount;
        }

        private void btn_shutDown_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            HubForm hForm = new HubForm(this.machines, this.hubCount);
            hForm.Show();
            this.Close();
        }
    }
}
