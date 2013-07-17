using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRDP
{
    class MyRDP : AxMSTSCLib.AxMsRdpClientNotSafeForScripting
    {
        public MyRDP()
            : base()
        {
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            //Fix for the missing focus issue on the rdp client component
            if (m.Msg == 0x0021)
                //WM_MOUSEACTIVATE ref:http://msdn.microsoft.com/en-us/library/ms645612(VS.85).aspx
                if (this.ContainsFocus == false)
                {
                    this.Focus();
                }
            base.WndProc(ref m);
        }
    }
}
