using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;

namespace SmartRDP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            App app = new App();

            app.Tabs.Add(app.CreateTab());
            app.SelectedTabIndex = 0;

            Application.Run(app);
        }
    }
}
