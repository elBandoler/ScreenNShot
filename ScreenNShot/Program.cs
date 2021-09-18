#define WIN
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#if WIN
using NHotkey.WindowsForms;
#elif LINUX 
#endif


namespace ScreenNShot
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{99929CBD-1376-41ED-9D54-2D2F8A7BA342}");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var cp = Process.GetCurrentProcess().ProcessName;
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Screen&Shot is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return;
            }
            else mutex.ReleaseMutex();
            if (!Update.CheckForUpdates()) // no update
            {
                AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
                if (Properties.Settings.Default.Output_Path.Length == 0)
                {
                    Properties.Settings.Default.Output_Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/ScreenNShot Output/";
                }
                if (!Directory.Exists(Properties.Settings.Default.Output_Path))
                    Directory.CreateDirectory(Properties.Settings.Default.Output_Path);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainContext());
            }
            else // yes update
            {
                if (File.Exists("Update.exe"))
                    File.Delete("Update.exe");
                Update.Updated();
            }
        }

        /// <summary>
        /// when the program closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (HotkeyManager.Current.IsEnabled)
            {
                HotkeyManager.Current.Remove("Take Screenshot");
                HotkeyManager.Current.Remove("Save to PDF");
            }
            if (MainContext.notifyIcon.Visible)
                MainContext.notifyIcon.Dispose();
        }
    }
}
