using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;
using System.Diagnostics;
using VncSharp;

namespace SmartRDP
{
    public partial class TabWindow : Form
    {
        private RDPServerManager rdpServerManager = RDPServerManager.Instance;

        public TabWindow()
        {
            InitializeComponent();
            Init();
        }

        public TabWindow(string title)
        {
            InitializeComponent();
            this.Text = title;

            Init();
        }

        ~TabWindow()
        {
            if (this.rdp!=null && rdp.Connected == 2)
            {
                this.rdp.Disconnect();
            }

            if (this.vnc!=null && this.vnc.IsConnected)
            {
                this.vnc.Disconnect();
            }
        }

        public void Init()
        {   
            string[] serversName = rdpServerManager.ServerNameArray;
            AutoCompleteStringCollection serverListHistory = new AutoCompleteStringCollection();
            serverListHistory.AddRange(serversName);
            this.textBox_serverName.AutoCompleteCustomSource = serverListHistory;
            this.Tag = "Server Name";

            foreach(RDPServer server in rdpServerManager.Servers)
            {
                Button btn = new Button();
                btn.Height = 100;
                btn.Width = 100;
                btn.Cursor = Cursors.Hand;
                string prtl = server.IsVNC ? "VNC" : "RDP";
                btn.Name = server.Name;
                btn.Text = server.Name + " : " + prtl;
                btn.Click += new EventHandler(item_clicked);
                btn.Tag = server.IsVNC;

                this.flowLayoutPanel_servers.Controls.Add(btn);
            }
        }

        public void ConnectRDP(RDPServer server)
        {
            try
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabWindow));
                this.rdp = new SmartRDP.MyRDP();
                ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
                this.rdp.Dock = System.Windows.Forms.DockStyle.Fill;
                this.rdp.Enabled = true;
                this.rdp.Location = new System.Drawing.Point(0, 0);
                this.rdp.Name = "rdp";
                this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
                //this.rdp.Size = new System.Drawing.Size(1264, 986);
                this.rdp.TabIndex = 10;
                this.Controls.Add(this.rdp);
                ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();

                rdp.Server = server.Name;
                rdp.UserName = server.Username;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = server.Password;
                
                rdp.Connect();
                
                //修改tab标签
                this.Text = server.Name;

                if (rdp.Connected == 2)
                {
                    // 如果连上了 则存储这个server
                    server.IsVNC = false;
                    rdpServerManager.saveOrUpdateServer(server);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ConnectVNC(RDPServer server)
        {
            this.vnc = new VncSharp.RemoteDesktop();
            this.vnc.Size = new Size(608, 427);
            this.vnc.AutoScroll = true;
            this.vnc.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.vnc.Location = new System.Drawing.Point(3, 3);
            this.vnc.Name = "VNC";
            this.vnc.TabIndex = 10;
            this.vnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.vnc);
            this.vnc.ConnectComplete += delegate
            {
                // 如果连上了 则存储这个server
                server.IsVNC = true;
                rdpServerManager.saveOrUpdateServer(server);
                this.vnc.Focus();
            }; 

            // Get a host name from the user.
            string host = server.Name;

            // As long as they didn't click Cancel, try to connect
            if (host != null)
            {
                try
                {
                    this.vnc.GetPassword = new AuthenticateDelegate(server.getPassword);
                    this.vnc.Connect(host);

                    //修改tab标签
                    this.Text = server.Name;
                }
                catch (VncProtocolException vex)
                {
                    MessageBox.Show(this,
                                    string.Format("Unable to connect to VNC host:\n\n{0}.\n\nCheck that a VNC host is running there.", vex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                                    string.Format("Unable to connect to host.  Error was: {0}", ex.Message),
                                    string.Format("Unable to Connect to {0}", host),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            string server = textBox_serverName.Text;
            string password = textBox_password.Text;
            string user = textBox_userName.Text;
            RDPServer rdpServerInfo = new RDPServer(server, user, password);

            panel_connect.Hide();

            if (this.radioButtonRDP.Checked)
                this.ConnectRDP(rdpServerInfo);
            else if (this.radioButtonVNC.Checked)
                this.ConnectVNC(rdpServerInfo);
        }

        private void TabWindow_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("in window");
            if (this.vnc != null && this.vnc.IsConnected)
                this.vnc.Focus();
        }

        private void textBox_serverName_TextChanged(object sender, EventArgs e)
        {
            RDPServer server = rdpServerManager.getServerByName(textBox_serverName.Text, this.radioButtonVNC.Checked);
            if (server != null)
            {
                textBox_userName.Text = server.Username;
                textBox_password.Text = server.Password;
            }
        }

        private void item_clicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string servername = clickedButton.Name;
            clickedButton.Text = "connecting...";
            textBox_serverName.Text = servername;
            bool isVNC = (Boolean)clickedButton.Tag;

            RDPServer server = rdpServerManager.getServerByName(servername, isVNC);
            panel_connect.Hide();
            if (isVNC)
                this.ConnectVNC(server);
            else
                this.ConnectRDP(server);
        }

        private void radioButtonRDP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonRDP.Checked)
            {
                this.textBox_userName.Enabled = true;
            }
        }

        private void radioButtonVNC_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonVNC.Checked)
            {
                this.textBox_userName.Enabled = false;
            }
        }
    }
}
