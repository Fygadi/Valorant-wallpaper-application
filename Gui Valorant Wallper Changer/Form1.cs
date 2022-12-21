using Microsoft.Win32;
using System.Windows.Forms.Design;

namespace Gui_Valorant_Wallper_Changer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = true;
		}

		private enum EnumModeSelected
		{
			File,
			Folder
		}

		private EnumModeSelected ModeSelect()
		{
			EnumModeSelected mode = EnumModeSelected.File;

			if (CheckBoxFile.Checked)
				mode = EnumModeSelected.File;
			else if (CheckBoxFolder.Checked)
				mode = EnumModeSelected.Folder;

			return mode;
		}

		private enum EnumTimerDelay
		{
			Secondes,
			Minutes
		}
		private EnumTimerDelay TimerDelayFormat()
		{
			EnumTimerDelay mode = EnumTimerDelay.Secondes;

			if (CheckBoxSeconds.Checked)
				mode = EnumTimerDelay.Secondes;
			else if (CheckBoxMinutes.Checked)
				mode = EnumTimerDelay.Minutes;

			return mode;
		}

		private void ButtOpenFileExplorer_Click(object sender, EventArgs e)
		{
			if (ModeSelect() == EnumModeSelected.File)
			{
				using (OpenFileDialog windowsFileExplorer = new OpenFileDialog())
				{
					windowsFileExplorer.Filter = "MP4 files|*.mp4";
					windowsFileExplorer.FilterIndex = 1;
					windowsFileExplorer.RestoreDirectory = true;

					if (windowsFileExplorer.ShowDialog() == DialogResult.OK)
					{
						TxtBoxSelectedPath.Text = windowsFileExplorer.FileName;

						MyRegistry.SetWallPaperPath(windowsFileExplorer.FileName);
					}
				}
			}
			else if (ModeSelect() == EnumModeSelected.Folder)
			{
				using (FolderBrowserDialog windowsFolderBrowserExplorer = new FolderBrowserDialog())
				{
					if (windowsFolderBrowserExplorer.ShowDialog() == DialogResult.OK)
					{
						TxtBoxSelectedPath.Text = windowsFolderBrowserExplorer.SelectedPath;
						MyRegistry.SetWallPaperPath(windowsFolderBrowserExplorer.SelectedPath);
					}
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

		private void checkBoxSeconds_Click(object sender, EventArgs e)
		{
			CheckBoxSeconds.Checked = true;
			CheckBoxMinutes.Checked = false;
		}

		private void checkBoxMinutes_Click(object sender, EventArgs e)
		{
			CheckBoxMinutes.Checked = true;
			CheckBoxSeconds.Checked = false;
		}

		private void TrackBarTimer_Scroll(object sender, EventArgs e)
		{
			TxtBoxTimer.Text = TrackBarTimer.Value.ToString();
		}

		private void TxtBoxTimer_KeyDown(object sender, KeyEventArgs e)
		{
			//avoid bee sound
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
			{
				e.SuppressKeyPress = true;
			}

			//Save the value in the registry
			if (e.KeyCode == Keys.Enter)
			{
				//unfocus the current control
				this.ActiveControl = lblInformation;

				if (TxtBoxTimer.Text == "")
					TxtBoxTimer.Text = "0";

				int value = int.Parse(TxtBoxTimer.Text);

				if (CheckBoxSeconds.Checked)
					value *= 1000;
				else
					value *= 60000;

				MyRegistry.SetTimerDelay(value);
			}
		}

		private void TxtBoxTimer_KeyPress(object sender, KeyPressEventArgs e)
		{
			//only allow numbers
			e.Handled = false;
			if (!char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
			{
				e.Handled = true;
			}
		}

		private void TxtBoxTimer_TextChanged(object sender, EventArgs e)
		{
			int.TryParse(TxtBoxTimer.Text, out int value);
			if (value > TrackBarTimer.Maximum)
				TrackBarTimer.Value = TrackBarTimer.Maximum;
			else if (value < TrackBarTimer.Minimum)
				TrackBarTimer.Value = TrackBarTimer.Minimum;
			else
				TrackBarTimer.Value = value;
		}

		private void ButtOkTime_Click(object sender, EventArgs e)
		{
			lblInformation.Text = "The timer delay has been changed to " + TxtBoxTimer.Text + " " + TimerDelayFormat();

			//Save the value in the registry 
				if (TxtBoxTimer.Text == "")
					TxtBoxTimer.Text = "0";

				int value = int.Parse(TxtBoxTimer.Text);

				if (CheckBoxSeconds.Checked)
					value *= 1000;
				else
					value *= 60000;

				MyRegistry.SetTimerDelay(value);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			lblInformation.Text = "The current timer delay is " + TxtBoxTimer.Text + " " + TimerDelayFormat();
		}
	}
}