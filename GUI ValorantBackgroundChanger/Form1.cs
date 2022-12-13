using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using GUI_ValorantBackgroundChanger;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Media;

namespace GUI_ValorantBackgroundChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtBoxSelectedPath.Text = MyRegistry.GetWallPaperPath();

            TxtBoxTimer.Text = (MyRegistry.GetTimerDelay() / 1000).ToString();
        }

        public static class DataContainer
        {
            public enum modeSelected
            {
                File,
                Folder
            }
        }

        public static class MyRegistry
        {
            public const string MyHive = "HKEY_CURRENT_USER";
            public const string MyPath = @"SOFTWARE\ValorantWallPaper";
            public const string MyHiveAndPath = MyHive + @"\" + MyPath;
            public const string MyNameNewWallPaper = "NewWallPaper";
            public const string MyNameTimerDelay = "TimerDelay";

            public static string GetWallPaperPath()
            {
                string WallPaperPath = null;

                RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, true);
                key.GetValue(MyNameNewWallPaper);
                if (key != null)
                {
                    WallPaperPath = key.GetValue(MyNameNewWallPaper).ToString();
                    Console.WriteLine("WallPaperPath = " + WallPaperPath);
                }
                else Console.WriteLine("WallPaperPath = NULL");

                return WallPaperPath;
            }

            /// <summary>Get the the timer delay</summary>
            /// <returns>In ms the delay selected or null if there's no delay"/></returns>
            public static int GetTimerDelay()
            {
                int timerDelay;
                RegistryKey key = Registry.CurrentUser.OpenSubKey(MyPath, false);
                timerDelay = Convert.ToInt32(key.GetValue(MyNameTimerDelay));

                return timerDelay;
            }

            public static void SetWallPaperPath(string value)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(MyRegistry.MyPath, true);
                if (key != null)
                {
                    key.SetValue(MyRegistry.MyNameNewWallPaper, value);
                    key.Close();
                }
                else
                {
                    key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath);
                    key.SetValue(MyRegistry.MyNameNewWallPaper, value);
                    key.Close();
                }
            }

            public static void SetTimerDelay(int value)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(MyRegistry.MyPath, true);
                if (key != null)
                {
                    key.SetValue(MyRegistry.MyNameTimerDelay, value);
                    key.Close();
                }
                else
                {
                    key = Registry.CurrentUser.CreateSubKey(MyRegistry.MyPath);
                    key.SetValue(MyRegistry.MyNameTimerDelay, value);
                    key.Close();
                }
            }
        }


        private void CheckBoxFolder_Click(object sender, EventArgs e)
        {
            CheckBoxFolder.Checked = true;
            CheckBoxFile.Checked = false;
        }

        private void CheckBoxFile_Click(object sender, EventArgs e)
        {
            CheckBoxFile.Checked = true;
            CheckBoxFolder.Checked = false;
        }

        private DataContainer.modeSelected ModeSelect()
        {
            DataContainer.modeSelected mode = DataContainer.modeSelected.File;

            if (CheckBoxFile.Checked)
                mode = DataContainer.modeSelected.File;
            else if (CheckBoxFolder.Checked)
                mode = DataContainer.modeSelected.Folder;

            return mode;
        }


        private void ButOpenFileExplorer_Click(object sender, EventArgs e)
        {
            if (ModeSelect() == DataContainer.modeSelected.File)
            {
                using (OpenFileDialog windowsFileExplorer = new OpenFileDialog())
                {
                    windowsFileExplorer.Filter = "MP4 files|*.mp4";
                    windowsFileExplorer.FilterIndex = 1;
                    windowsFileExplorer.RestoreDirectory = true;

                    if (windowsFileExplorer.ShowDialog() == DialogResult.OK)
                    {
                        txtBoxSelectedPath.Text = windowsFileExplorer.FileName;

                        MyRegistry.SetWallPaperPath(windowsFileExplorer.FileName);
                    }
                }
            }
            else if (ModeSelect() == DataContainer.modeSelected.Folder)
            {
                using (FolderBrowserDialog windowsFolderBrowserExplorer = new FolderBrowserDialog())
                {
                    if (windowsFolderBrowserExplorer.ShowDialog() == DialogResult.OK)
                    {
                        txtBoxSelectedPath.Text = windowsFolderBrowserExplorer.SelectedPath;


                        MyRegistry.SetWallPaperPath(windowsFolderBrowserExplorer.SelectedPath);
                    }
                }
            }
        }

        private void TrackBarTimer_Scroll(object sender, EventArgs e)
        {
            TxtBoxTimer.Text = TrackBarTimer.Value.ToString();
        }

        private void TxtBoxTimer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (!char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void TxtBoxTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //unfocus the current control
                this.ActiveControl = lblTimer;

                if (TxtBoxTimer.Text == "")
                    TxtBoxTimer.Text = "0";

                int value = int.Parse(TxtBoxTimer.Text);

                if (CheckBoxSeconds.Checked)
                    value *= 1000;
                else
                    value *= 60000;

                MyRegistry.SetTimerDelay(value);
            }

            //avoid bee sound
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CheckBoxMinutes_Click(object sender, EventArgs e)
        {
            CheckBoxMinutes.Checked = true;
            CheckBoxSeconds.Checked = false;
        }

        private void CheckBoxSeconds_Click(object sender, EventArgs e)
        {
            CheckBoxSeconds.Checked = true;
            CheckBoxMinutes.Checked = false;
        }













        private Rectangle originalFormSize;

        private Rectangle ScaleButOpenFileExplorer;
        private Rectangle ScaleTxtBoxSelectedPath;
        private Rectangle ScaleLblFileExplorer;
        private Rectangle ScaleCheckBoxFolder;
        private Rectangle ScaleCheckBoxFile;
        private Rectangle ScaleLblTimer;
        private Rectangle ScaleCheckBoxSeconds;
        private Rectangle ScaleCheckBoxMinutes;
        private Rectangle ScaleTrackBarTimer;
        private Rectangle ScaleTxtBoxTimer;
        private Rectangle ScaleButtSubmitTimer;
        private Rectangle ScaleLblCreatedby;
        private Rectangle ScaleButtSubmit;

        private void Form1_Load(object sender, EventArgs e)
        {


            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            ScaleButOpenFileExplorer = new Rectangle(ButOpenFileExplorer.Location.X, ButOpenFileExplorer.Location.Y, ButOpenFileExplorer.Width, ButOpenFileExplorer.Height);
            ScaleTxtBoxSelectedPath = new Rectangle(txtBoxSelectedPath.Location.X, txtBoxSelectedPath.Location.Y, txtBoxSelectedPath.Width, txtBoxSelectedPath.Height);
            ScaleLblFileExplorer = new Rectangle(lblFileExplorer.Location.X, lblFileExplorer.Location.Y, lblFileExplorer.Width, lblFileExplorer.Height);
            ScaleCheckBoxFolder = new Rectangle(CheckBoxFolder.Location.X, CheckBoxFolder.Location.Y, CheckBoxFolder.Width, CheckBoxFolder.Height);
            ScaleCheckBoxFile = new Rectangle(CheckBoxFile.Location.X, CheckBoxFile.Location.Y, CheckBoxFile.Width, CheckBoxFile.Height);
            ScaleLblTimer = new Rectangle(lblTimer.Location.X, lblTimer.Location.Y, lblTimer.Width, lblTimer.Height);
            ScaleCheckBoxSeconds = new Rectangle(CheckBoxSeconds.Location.X, CheckBoxSeconds.Location.Y, CheckBoxSeconds.Width, CheckBoxSeconds.Height);
            ScaleCheckBoxMinutes = new Rectangle(CheckBoxMinutes.Location.X, CheckBoxMinutes.Location.Y, CheckBoxMinutes.Width, CheckBoxMinutes.Height);
            ScaleTrackBarTimer = new Rectangle(TrackBarTimer.Location.X, TrackBarTimer.Location.Y, TrackBarTimer.Width, TrackBarTimer.Height);
            ScaleTxtBoxTimer = new Rectangle(TxtBoxTimer.Location.X, TxtBoxTimer.Location.Y, TxtBoxTimer.Width, TxtBoxTimer.Height);
            ScaleLblCreatedby = new Rectangle(lblCreatedby.Location.X, lblCreatedby.Location.Y, lblCreatedby.Width, lblCreatedby.Height);
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(ScaleButOpenFileExplorer, ButOpenFileExplorer);
            resizeControl(ScaleTxtBoxSelectedPath, txtBoxSelectedPath);
            resizeControl(ScaleLblFileExplorer, lblFileExplorer);
            resizeControl(ScaleCheckBoxFolder, CheckBoxFolder);
            resizeControl(ScaleCheckBoxFile, CheckBoxFile);
            resizeControl(ScaleLblTimer, lblTimer);
            resizeControl(ScaleCheckBoxSeconds, CheckBoxSeconds);
            resizeControl(ScaleCheckBoxMinutes, CheckBoxMinutes);
            resizeControl(ScaleTrackBarTimer, TrackBarTimer);
            resizeControl(ScaleTxtBoxTimer, TxtBoxTimer);
            resizeControl(ScaleLblCreatedby, lblCreatedby);
        }
    }
}
