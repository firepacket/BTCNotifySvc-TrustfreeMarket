using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BtcNotifySvc
{
    static class Program
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetProcessDPIAware();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
           
            try
            {
                Application.Run(new Form1(args.Length > 0 ? false : true));
            } catch (Exception err)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
