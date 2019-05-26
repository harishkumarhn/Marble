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
                    BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\" + backupfileName, DeviceType.File);
                    ////Define Server connection    

                    //ServerConnection connection = new ServerConnection(frm.serverName, frm.userName, frm.password);    
                    ServerConnection connection = new ServerConnection("HARISH-PC\\SQLEXPRESS", "sa", "marble");
                    ////To Avoid TimeOut Exception    
                    Server sqlServer = new Server(connection);
                    sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
                    Database db = sqlServer.Databases[databaseName];

                    sqlBackup.Initialize = true;
                    sqlBackup.Checksum = true;
                    sqlBackup.ContinueAfterError = true;

                    ////Add the device to the Backup object.    
                    sqlBackup.Devices.Add(deviceItem);
                    ////Set the Incremental property to False to specify that this is a full database backup.    
                    sqlBackup.Incremental = false;

                    sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                    ////Specify that the log must be truncated after the backup is complete.    
                    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                    sqlBackup.FormatMedia = false;
                    ////Run SqlBackup to perform the full database backup on the instance of SQL Server.    
                    sqlBackup.SqlBackup(sqlServer);
                    ////Remove the backup device from the Backup object.    
                    sqlBackup.Devices.Remove(deviceItem);
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
            var activeHubMachines = gameBL.GetActiveHubMachines();

            var groupedResult = from s in activeHubMachines
                                group s by s.HubName;

            //iterate each group        
            int i = 1;
            foreach (var hub in groupedResult)
            {
                HubForm hForm = new HubForm(hub.ToList(), i);
                hForm.Show();
                i++;
                richText_primaryServer.AppendText("Hub " + hub.ToList()[0].HubName + " started\n");
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
