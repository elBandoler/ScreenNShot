#define WIN
//#define LINUX
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

#if WIN 
using NHotkey;
using NHotkey.WindowsForms;
#elif LINUX 
using ...
#endif

namespace ScreenNShot
{
    internal class MainContext : ApplicationContext
    {
        public static Queue<Stream> CurrentPictures = new Queue<Stream>();
        public static NotifyIcon notifyIcon;

        public static bool PrintingScreen = false;
        public static bool SavingPDF = false;

        /// creates the notify icon and initializes everything
        public MainContext()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("Take Screenshot", Keys.PrintScreen, true, OnTryTakeScreenShot);
            }
            catch (HotkeyAlreadyRegisteredException)
            {
                MessageBox.Show("The Print Screen key is already binded to other programs. Please bind new keys in the configuration screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Run(new Configuration());
            }
            try
            {
                HotkeyManager.Current.AddOrReplace("Save to PDF", Keys.Pause, true, OnTryPDFSave);
            }
            catch (HotkeyAlreadyRegisteredException)
            {
                MessageBox.Show("The Save to PDF key is already binded to other programs. Please bind new keys in the configuration screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Run(new Configuration());
            }

            ToolStripMenuItem configMenuItem = new ToolStripMenuItem("Configuration");
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("About");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");
            configMenuItem.Click += ConfigMenuItem_Click;
            aboutMenuItem.Click += AboutMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resources.sns;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.AddRange(new[] { configMenuItem, exitMenuItem });
            notifyIcon.DoubleClick += ConfigMenuItem_Click;
            notifyIcon.Visible = true;
        }

        /// <summary>
        /// Handles the screenshot taking
        /// </summary>
        internal static void OnTryTakeScreenShot(object sender, HotkeyEventArgs e)
        {
            if (PrintingScreen) return;
            PrintingScreen = true;
            // implement a way to choose part of the screen + allow copying the image to memory, uploading it (?) or adding it to the PDF
            var screen = Screen.FromPoint(Cursor.Position);
            var bounds = screen.Bounds;
            using var bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(screen.WorkingArea.X, screen.WorkingArea.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            Stream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            CurrentPictures.Enqueue(stream);
            bitmap.Dispose();
            // DEBUG
            /*if (File.Exists("filename.jpg"))
                File.Delete("filename.jpg");
            bitmap.Save("filename.jpg", ImageFormat.Jpeg);*/
            PrintingScreen = false;
        }

        /// <summary>
        /// Handles the saving of all pictures to pdf
        /// </summary>
        internal static void OnTryPDFSave(object sender, HotkeyEventArgs e)
        {
            if (SavingPDF) return;
            SavingPDF = true;
            if (CurrentPictures.Count == 0)
                notifyIcon.ShowBalloonTip(10, "No images in memory", "You can't save a PDF out of nothing :(", ToolTipIcon.Error);
            else
                Actions.SavePDF(CurrentPictures);
            SavingPDF = false;
        }

        /// <summary>
        /// Processes a click on the Configuration ToolStripMenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigMenuItem_Click(object sender, EventArgs e)
        {
            new Configuration().Show();
        }


        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Processes a click on the Exit ToolStripMenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            // if is recording, we should remind the user he's recording and offer a way to export or something
            // we should also ask the user in the config if we should ask him if he wants to exit
            switch(MessageBox.Show("Are you sure you want to quit ScreenNShot?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                case DialogResult.OK:
                    {
                        Environment.Exit(0);
                        break;
                    }
                case DialogResult.Cancel:
                    break;
            }
        }
    }
}