namespace SmartRDP
{
    partial class TabWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabWindow));
            this.button_connect = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_serverName = new System.Windows.Forms.TextBox();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.panel_connect = new System.Windows.Forms.Panel();
            this.flowLayoutPanel_servers = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_create = new System.Windows.Forms.GroupBox();
            this.rdp = new SmartRDP.MyRDP();
            this.panel_connect.SuspendLayout();
            this.groupBox_create.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
            this.SuspendLayout();
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.SystemColors.Control;
            this.button_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_connect.Location = new System.Drawing.Point(37, 146);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(247, 36);
            this.button_connect.TabIndex = 3;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(54, 44);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(39, 13);
            this.label_server.TabIndex = 2;
            this.label_server.Text = "server:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "user name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "password:";
            // 
            // textBox_serverName
            // 
            this.textBox_serverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_serverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_serverName.Location = new System.Drawing.Point(122, 44);
            this.textBox_serverName.Name = "textBox_serverName";
            this.textBox_serverName.Size = new System.Drawing.Size(162, 20);
            this.textBox_serverName.TabIndex = 0;
            this.textBox_serverName.TextChanged += new System.EventHandler(this.textBox_serverName_TextChanged);
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(122, 70);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(162, 20);
            this.textBox_userName.TabIndex = 1;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(122, 96);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(162, 20);
            this.textBox_password.TabIndex = 2;
            // 
            // panel_connect
            // 
            this.panel_connect.Controls.Add(this.flowLayoutPanel_servers);
            this.panel_connect.Controls.Add(this.groupBox_create);
            this.panel_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_connect.Location = new System.Drawing.Point(0, 0);
            this.panel_connect.Name = "panel_connect";
            this.panel_connect.Size = new System.Drawing.Size(326, 289);
            this.panel_connect.TabIndex = 8;
            // 
            // flowLayoutPanel_servers
            // 
            this.flowLayoutPanel_servers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_servers.AutoScroll = true;
            this.flowLayoutPanel_servers.Location = new System.Drawing.Point(3, 260);
            this.flowLayoutPanel_servers.Name = "flowLayoutPanel_servers";
            this.flowLayoutPanel_servers.Size = new System.Drawing.Size(320, 26);
            this.flowLayoutPanel_servers.TabIndex = 9;
            // 
            // groupBox_create
            // 
            this.groupBox_create.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_create.Controls.Add(this.textBox_serverName);
            this.groupBox_create.Controls.Add(this.label3);
            this.groupBox_create.Controls.Add(this.textBox_password);
            this.groupBox_create.Controls.Add(this.label2);
            this.groupBox_create.Controls.Add(this.button_connect);
            this.groupBox_create.Controls.Add(this.label_server);
            this.groupBox_create.Controls.Add(this.textBox_userName);
            this.groupBox_create.Location = new System.Drawing.Point(-6, 12);
            this.groupBox_create.Name = "groupBox_create";
            this.groupBox_create.Size = new System.Drawing.Size(325, 195);
            this.groupBox_create.TabIndex = 8;
            this.groupBox_create.TabStop = false;
            this.groupBox_create.Text = "create new connection";
            // 
            // rdp
            // 
            this.rdp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdp.Enabled = true;
            this.rdp.Location = new System.Drawing.Point(0, 0);
            this.rdp.Name = "rdp";
            this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
            this.rdp.Size = new System.Drawing.Size(326, 289);
            this.rdp.TabIndex = 10;
            // 
            // TabWindow
            // 
            this.AcceptButton = this.button_connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 289);
            this.Controls.Add(this.panel_connect);
            this.Controls.Add(this.rdp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabWindow";
            this.Activated += new System.EventHandler(this.TabWindow_Activated);
            this.panel_connect.ResumeLayout(false);
            this.groupBox_create.ResumeLayout(false);
            this.groupBox_create.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyRDP rdp;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_serverName;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Panel panel_connect;
        private System.Windows.Forms.GroupBox groupBox_create;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_servers;
    }
}

