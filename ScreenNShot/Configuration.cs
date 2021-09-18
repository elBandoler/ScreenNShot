using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Windows.Forms;

namespace ScreenNShot
{
    enum KeyChanged : short
    {
        NONE = 0,
        PRINT_SCREEN = 1,
        SAVE_PDF = 2
    }
    public partial class Configuration : Form
    {
        static KeyChanged ChangingKey = KeyChanged.NONE;
        public Configuration()
        {
            InitializeComponent();
            textBox_PrintScreen.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Print_Screen_Key);
            textBox_SavePDF.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Save_PDF_Key);
            textBox_OutputPath.Text = Properties.Settings.Default.Output_Path;
        }

        private void button_Edit_PrintScreen_Click(object sender, EventArgs e)
        {
            if (HotkeyManager.Current.IsEnabled) // stop listening for action!
            {
                HotkeyManager.Current.Remove("Take Screenshot");
            }
            ChangingKey = KeyChanged.PRINT_SCREEN; // listening to key press for this action
            textBox_PrintScreen.Text = "Press a key...";
            KeyPreview = true;
        }

        private void button_Edit_SavePDF_Click(object sender, EventArgs e)
        {
            /*if (HotkeyManager.Current.IsEnabled) // stop listening for action!
            {
                HotkeyManager.Current.Remove("Save to PDF");
            }*/
            ChangingKey = KeyChanged.SAVE_PDF; // listening to key press for this action
            textBox_SavePDF.Text = "Press a key...";
            KeyPreview = true;
        }

        private void button_OutputPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())  // open file browser and save the path to memory
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Properties.Settings.Default.Output_Path = fbd.SelectedPath;
                    textBox_OutputPath.Text = Properties.Settings.Default.Output_Path;
                }
            }

        }

        /// <summary>
        /// Actually handles the key press registration when editing a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Configuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (ChangingKey == KeyChanged.NONE || e.KeyCode == Keys.None) 
                return;

            bool isValid = true;
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Alt || e.KeyCode == Keys.Shift || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                isValid = false;
            }

            try
            {
                string Name = null;
                EventHandler<HotkeyEventArgs> HandlingEvent = null;
                switch (ChangingKey)
                {
                    case KeyChanged.PRINT_SCREEN:
                        {
                            Name = "Take Screenshot";
                            HandlingEvent = MainContext.OnTryTakeScreenShot;
                            if (isValid)
                            {
                                Properties.Settings.Default.Print_Screen_Key = e.KeyValue;
                                textBox_PrintScreen.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Print_Screen_Key);
                            }
                            else
                            {
                                textBox_PrintScreen.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Print_Screen_Key);
                                HotkeyManager.Current.AddOrReplace(Name, (Keys)Properties.Settings.Default.Print_Screen_Key, HandlingEvent);
                                return;
                            }
                            break;
                        }
                    case KeyChanged.SAVE_PDF:
                        {
                            Name = "Save to PDF";
                            HandlingEvent = MainContext.OnTryPDFSave;
                            if (isValid)
                            {
                                Properties.Settings.Default.Save_PDF_Key = e.KeyValue;
                                textBox_SavePDF.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Save_PDF_Key);
                            }
                            else
                            {
                                textBox_PrintScreen.Text = Enum.GetName(typeof(Keys), Properties.Settings.Default.Save_PDF_Key);
                                HotkeyManager.Current.AddOrReplace(Name, (Keys)Properties.Settings.Default.Save_PDF_Key, HandlingEvent);
                                return;
                            }
                            break;
                        }
                }
            if (Name == null || HandlingEvent == null)
                    return; 
               HotkeyManager.Current.AddOrReplace(Name, e.KeyCode, HandlingEvent);
            }
            catch (HotkeyAlreadyRegisteredException)
            {
                MessageBox.Show("Some keys are already binded to other programs. Please bind new keys in the configuration screen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ChangingKey = KeyChanged.NONE;
            KeyPreview = false;
        }

        private void button_ResetPrintScreen_Click(object sender, EventArgs e)
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("Take Screenshot", Keys.PrintScreen, MainContext.OnTryTakeScreenShot);
                Properties.Settings.Default.Print_Screen_Key = (int)Keys.PrintScreen;
                textBox_PrintScreen.Text = Enum.GetName(typeof(Keys), Keys.PrintScreen);
            } catch (HotkeyAlreadyRegisteredException)
            {
                MessageBox.Show("The default key is already binded to another program. Please choose a different one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://bandoler.com") { UseShellExecute = true });
        }
    }
}
