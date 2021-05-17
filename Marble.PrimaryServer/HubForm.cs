using Marbale.BusinessObject.Game;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marble.PrimaryServer
{
    public partial class HubForm : Form
    {
        List<ActiveHubMachine> machines;
        GameBL gameBL;
        int hubId,port;
        TcpListener server = null;
        
        public HubForm(int hubId, int port)
        {
            this.gameBL = new GameBL();
            this.hubId = hubId;
            this.port = port;
            InitializeComponent();
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(localAddr, this.port);
            server.Start();
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                StartListener();
            });
            t.Start();
        }
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.AppendText(text);
            }
        }

        private void HubForm_Load(object sender, EventArgs e)
        {
            this.machines = this.gameBL.GetActiveHubMachines(hubId);
            this.hub_dataGridView.DataSource = machines;
            if (this.machines.Count > 0)
            {
                this.lab_Header.Text = this.machines[0].HubName;
            }
        }

        private void btn_shutDown_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            HubForm hForm = new HubForm(this.hubId,this.port);
            hForm.Show();
            this.Close();
            
        }        

        private void StartListener()
        {
            try
            {
                Console.WriteLine("Waiting for a connection...");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected! " + client.ToString());
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }

        private void HandleDeivce(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            var stream = client.GetStream();
            string imei = String.Empty;
            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string hex = BitConverter.ToString(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    SetText(String.Format("\n Received: {0}", data));
                    string str = "Hey Device! I am Hub: "+this.hubId.ToString();
                    Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
                    Thread.Sleep(1000);
                    stream.Write(reply, 0, reply.Length);
                    Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }
    }
}
