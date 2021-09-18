using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace ScreenNShot
{
    internal class Update
    {
        internal static bool CheckForUpdates()
        {
            var data = new WebClient().DownloadString("http://sns.bandoler.com/sns");
            var new_version = new Version(data.Split(",")[0]);
            var current_version = Assembly.GetExecutingAssembly().GetName().Version;
            return new_version > current_version && data.Split(",").Length == 3; 
        }

        internal static void Updated()
        {
            var client = new WebClient();
            string URI = client.DownloadString("http://sns.bandoler.com/sns").Split(",")[1];
            client.DownloadFile(URI, "Update.exe");
            Process.Start("Update.exe");
            Environment.Exit(0);
            MessageBox.Show($"{URI}\n{URI}");
        }


    }
}