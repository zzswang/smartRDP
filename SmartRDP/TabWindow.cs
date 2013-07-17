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
            if (rdp.Connected == 2)
            {
                rdp.Disconnect();
            }
        }

        public void Init()
        {   
            string[] servers = rdpServerManager.ServerNameArray;
            AutoCompleteStringCollection serverListHistory = new AutoCompleteStringCollection();
            serverListHistory.AddRange(servers);
            this.textBox_serverName.AutoCompleteCustomSource = serverListHistory;
            this.Tag = "Server Name";

            foreach(string server in servers)
            {
                Button btn = new Button();
                btn.Height = 100;
                btn.Width = 100;
                btn.Cursor = Cursors.Hand;
                btn.Name = btn.Text = server;
                btn.Click += new EventHandler(item_clicked);

                this.flowLayoutPanel_servers.Controls.Add(btn);
            }
        }

        public void ConnectRDP(RDPServer server)
        {
            try
            {
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
                    rdpServerManager.saveOrUpdateServer(server);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            string server = textBox_serverName.Text;
            string password = textBox_password.Text;
            string user = textBox_userName.Text;

            panel_connect.Hide();

            this.ConnectRDP(new RDPServer(server, user, password));
        }

        private void TabWindow_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("in window");
        }

        private void textBox_serverName_TextChanged(object sender, EventArgs e)
        {
            RDPServer server = rdpServerManager.getServerByName(textBox_serverName.Text);
            if (server != null)
            {
                textBox_userName.Text = server.Username;
                textBox_password.Text = server.Password;
            }
        }

        private void item_clicked(Object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string servername = clickedButton.Text;
            clickedButton.Text = "connecting...";
            textBox_serverName.Text = servername;

            RDPServer server = rdpServerManager.getServerByName(servername);
            panel_connect.Hide();
            this.ConnectRDP(server);
        }
    }
}
