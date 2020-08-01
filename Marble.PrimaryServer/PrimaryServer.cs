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
using System.Net;
using System.Net.Sockets;

namespace Marble.PrimaryServer
{
    public partial class PrimaryServer : Form
    {
        GameBL gameBL;
        //TcpClient client = null;
        //NetworkStream stream = null;

        public PrimaryServer()
        {
            InitializeComponent();
            this.gameBL = new GameBL();            
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richText_primaryServer.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richText_primaryServer.AppendText(text);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateHubs();

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
                    ServerConnection connection = new ServerConnection(new SqlConnection(@"Data Source=DESKTOP-V5T880D\SQLEXPRESS;Initial Catalog=Marbale;Trusted_Connection=True;"));
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
            CreateHubs();
        }

        private void btn_shutDownExit_Click(object sender, EventArgs e)
        {
            ShutDownServers();
            this.Dispose();
            //stream.Close();
            //client.Close();
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
        private void CreateHubs()
        {
            this.richText_primaryServer.Text = "Server Started\n";
            var hubs = gameBL.GetHubs();// GetActiveHubMachines();
            //iterate each group        
            int i = 1;
            foreach (var hub in hubs)
            {
                HubForm hForm = new HubForm(hub.Id,13000 * (i+1));
                hForm.Show();
                i++;
                richText_primaryServer.AppendText("Hub " + hub.Name + " started\n");
                new Thread(() =>
                {
                    Connect("127.0.0.1", 13000 * (i + 1),hub.Id.ToString());
                }).Start();
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


        private void Connect(String server, int port,string hubname)
        {
            try
            {
                Thread.Sleep(5000);
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();
                int count = 0;
                while (count++ < 3)
                {
                    // Translate the Message into ASCII.
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("I am the Primary server");
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    SetText(String.Format("\nSent: {0} to {1}", "I am the Primary server",hubname));
                    // Bytes Array to receive Server Response.
                    data = new Byte[256];
                    String response = String.Empty;
                    // Read the Tcp Server Response Bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    SetText(String.Format("\nReceived: {0} from {1}", response,hubname));
                    //Thread.Sleep(new Random().Next(0, 10) * 1000);
                }
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            Console.Read();
        }

    }
}
