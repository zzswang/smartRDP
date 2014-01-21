using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;
using SmartRDP.Properties;

namespace SmartRDP
{
    public partial class App : TitleBarTabs
    {
        public App()
        {
            InitializeComponent();

            AeroPeekEnabled = false;
            TabRenderer = new ChromeTabRenderer(this);
            Icon = Resources.Emoticons;
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new TabWindow
                {
                    Text = "New Tab"
                }
            };
        }
    }
}
