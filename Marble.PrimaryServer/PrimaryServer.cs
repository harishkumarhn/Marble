using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;

namespace Marble.PrimaryServer
{
    public partial class PrimaryServer : Form
    {
        GameBL gameBL;
        public PrimaryServer()
        {
            InitializeComponent();
            this.gameBL = new GameBL();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            StartServers();

            try
            {
                var DestPath = "D:\\Projects\\Marbale\\Backup";
                var DbName = "Marbale";

                if (DestPath == "" || DbName == "")
                {
                    MessageBox.Show("Try to select Database and Destination Folder !");
                }
                else
                {
                    string databaseName = DbName;//dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();    

                    //Define a Backup object variable.    
                    Backup sqlBackup = new Backup();

                    ////Specify the type of backup, the description, the name, and the database to be backed up.    
                    sqlBackup.Action = BackupActionType.Database;
                    sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString();
                    sqlBackup.BackupSetName = "FullBackUp";
                    sqlBackup.Database = databaseName;

                    ////Declare a BackupDeviceItem    
                    string destinationPath = DestPath;
                    string backupfileName = DbName + ".bak";
                    var sqlConStrBuilder = new SqlConnectionStringBuilder(@"Data Source=DESKTOP-6LG6FHB;Database=Marbale;Trusted_Connection=True;");

                    // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")

                    using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                    {
                        var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                            sqlConStrBuilder.InitialCatalog, destinationPath + "\\" + backupfileName);

                        using (var command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                    this.richText_primaryServer.AppendText("Successful backup is created!\n");
                }
            }
            catch (Exception ex)
            {
                this.richText_primaryServer.AppendText(ex.Message + "\n");
                // MessageBox.Show(ex.Message);    
            } 
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            ShutDownServers();
            StartServers();
        }

        private void btn_shutDownExit_Click(object sender, EventArgs e)
        {
            ShutDownServers();
            this.Dispose();
        }

        private void btn_ShoutDown_Click(object sender, EventArgs e)
        {
            ShutDownServers();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "HubForm")
                    {
                        Application.OpenForms[index].WindowState = FormWindowState.Minimized;
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            this.WindowState = FormWindowState.Minimized;
        }
        private void StartServers()
        {
            this.richText_primaryServer.Text = "Server Started\n";
            var hubs = gameBL.GetHubs();// GetActiveHubMachines();
            //iterate each group        
            int i = 1;
            foreach (var hub in hubs)
            {
                HubForm hForm = new HubForm(hub.Id);
                hForm.Show();
                i++;
                richText_primaryServer.AppendText("Hub " + hub.Name + " started\n");
            }
        }
        private void ShutDownServers()
        {
            try
            {
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[1].Name == "HubForm")
                    {
                        Application.OpenForms[1].Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
