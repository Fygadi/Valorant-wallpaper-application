namespace Gui_Valorant_Wallper_Changer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.ButtOpenFileExplorer = new System.Windows.Forms.Button();
			this.TxtBoxSelectedPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CheckBoxFolder = new System.Windows.Forms.CheckBox();
			this.CheckBoxFile = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TrackBarTimer = new System.Windows.Forms.TrackBar();
			this.CheckBoxSeconds = new System.Windows.Forms.CheckBox();
			this.CheckBoxMinutes = new System.Windows.Forms.CheckBox();
			this.TxtBoxTimer = new System.Windows.Forms.TextBox();
			this.groupBoxTimer = new System.Windows.Forms.GroupBox();
			this.ButtOkTime = new System.Windows.Forms.Button();
			this.groupBoxWallpaperSelecteur = new System.Windows.Forms.GroupBox();
			this.lblInformation = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.TrackBarTimer)).BeginInit();
			this.groupBoxTimer.SuspendLayout();
			this.groupBoxWallpaperSelecteur.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtOpenFileExplorer
			// 
			this.ButtOpenFileExplorer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ButtOpenFileExplorer.Location = new System.Drawing.Point(10, 57);
			this.ButtOpenFileExplorer.Margin = new System.Windows.Forms.Padding(4);
			this.ButtOpenFileExplorer.Name = "ButtOpenFileExplorer";
			this.ButtOpenFileExplorer.Size = new System.Drawing.Size(50, 38);
			this.ButtOpenFileExplorer.TabIndex = 0;
			this.ButtOpenFileExplorer.Text = "...";
			this.ButtOpenFileExplorer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.ButtOpenFileExplorer.UseVisualStyleBackColor = true;
			this.ButtOpenFileExplorer.Click += new System.EventHandler(this.ButtOpenFileExplorer_Click);
			// 
			// TxtBoxSelectedPath
			// 
			this.TxtBoxSelectedPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TxtBoxSelectedPath.Location = new System.Drawing.Point(90, 29);
			this.TxtBoxSelectedPath.Margin = new System.Windows.Forms.Padding(4);
			this.TxtBoxSelectedPath.Multiline = true;
			this.TxtBoxSelectedPath.Name = "TxtBoxSelectedPath";
			this.TxtBoxSelectedPath.ReadOnly = true;
			this.TxtBoxSelectedPath.Size = new System.Drawing.Size(265, 99);
			this.TxtBoxSelectedPath.TabIndex = 1;
			this.TxtBoxSelectedPath.TabStop = false;
			this.TxtBoxSelectedPath.Text = "Your File/Folder path\r\n   will be show here ";
			this.TxtBoxSelectedPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(406, 29);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 21);
			this.label1.TabIndex = 2;
			this.label1.Text = "Type";
			// 
			// CheckBoxFolder
			// 
			this.CheckBoxFolder.AutoSize = true;
			this.CheckBoxFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CheckBoxFolder.Location = new System.Drawing.Point(384, 85);
			this.CheckBoxFolder.Name = "CheckBoxFolder";
			this.CheckBoxFolder.Size = new System.Drawing.Size(64, 21);
			this.CheckBoxFolder.TabIndex = 3;
			this.CheckBoxFolder.Text = "Folder";
			this.CheckBoxFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CheckBoxFolder.UseVisualStyleBackColor = true;
			this.CheckBoxFolder.Click += new System.EventHandler(this.CheckBoxFolder_Click);
			// 
			// CheckBoxFile
			// 
			this.CheckBoxFile.AutoSize = true;
			this.CheckBoxFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxFile.Checked = true;
			this.CheckBoxFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CheckBoxFile.Location = new System.Drawing.Point(402, 57);
			this.CheckBoxFile.Name = "CheckBoxFile";
			this.CheckBoxFile.Size = new System.Drawing.Size(46, 21);
			this.CheckBoxFile.TabIndex = 4;
			this.CheckBoxFile.Text = "File";
			this.CheckBoxFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CheckBoxFile.UseVisualStyleBackColor = true;
			this.CheckBoxFile.Click += new System.EventHandler(this.CheckBoxFile_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(160, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 21);
			this.label2.TabIndex = 5;
			this.label2.Text = "Format";
			// 
			// TrackBarTimer
			// 
			this.TrackBarTimer.Location = new System.Drawing.Point(15, 67);
			this.TrackBarTimer.Maximum = 60;
			this.TrackBarTimer.Name = "TrackBarTimer";
			this.TrackBarTimer.Size = new System.Drawing.Size(106, 45);
			this.TrackBarTimer.TabIndex = 6;
			this.TrackBarTimer.TickFrequency = 10;
			this.TrackBarTimer.Value = 5;
			this.TrackBarTimer.Scroll += new System.EventHandler(this.TrackBarTimer_Scroll);
			// 
			// CheckBoxSeconds
			// 
			this.CheckBoxSeconds.AutoSize = true;
			this.CheckBoxSeconds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxSeconds.Checked = true;
			this.CheckBoxSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxSeconds.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CheckBoxSeconds.Location = new System.Drawing.Point(144, 49);
			this.CheckBoxSeconds.Name = "CheckBoxSeconds";
			this.CheckBoxSeconds.Size = new System.Drawing.Size(76, 21);
			this.CheckBoxSeconds.TabIndex = 7;
			this.CheckBoxSeconds.Text = "Seconds";
			this.CheckBoxSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CheckBoxSeconds.UseVisualStyleBackColor = true;
			this.CheckBoxSeconds.Click += new System.EventHandler(this.checkBoxSeconds_Click);
			// 
			// CheckBoxMinutes
			// 
			this.CheckBoxMinutes.AutoSize = true;
			this.CheckBoxMinutes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxMinutes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CheckBoxMinutes.Location = new System.Drawing.Point(147, 67);
			this.CheckBoxMinutes.Name = "CheckBoxMinutes";
			this.CheckBoxMinutes.Size = new System.Drawing.Size(73, 21);
			this.CheckBoxMinutes.TabIndex = 8;
			this.CheckBoxMinutes.Text = "Minutes";
			this.CheckBoxMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CheckBoxMinutes.UseVisualStyleBackColor = true;
			this.CheckBoxMinutes.Click += new System.EventHandler(this.checkBoxMinutes_Click);
			// 
			// TxtBoxTimer
			// 
			this.TxtBoxTimer.Location = new System.Drawing.Point(15, 28);
			this.TxtBoxTimer.MaxLength = 2;
			this.TxtBoxTimer.Name = "TxtBoxTimer";
			this.TxtBoxTimer.Size = new System.Drawing.Size(50, 29);
			this.TxtBoxTimer.TabIndex = 9;
			this.TxtBoxTimer.Text = "5";
			this.TxtBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtBoxTimer.TextChanged += new System.EventHandler(this.TxtBoxTimer_TextChanged);
			this.TxtBoxTimer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBoxTimer_KeyDown);
			this.TxtBoxTimer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBoxTimer_KeyPress);
			// 
			// groupBoxTimer
			// 
			this.groupBoxTimer.Controls.Add(this.ButtOkTime);
			this.groupBoxTimer.Controls.Add(this.label2);
			this.groupBoxTimer.Controls.Add(this.TxtBoxTimer);
			this.groupBoxTimer.Controls.Add(this.TrackBarTimer);
			this.groupBoxTimer.Controls.Add(this.CheckBoxMinutes);
			this.groupBoxTimer.Controls.Add(this.CheckBoxSeconds);
			this.groupBoxTimer.Location = new System.Drawing.Point(21, 161);
			this.groupBoxTimer.Name = "groupBoxTimer";
			this.groupBoxTimer.Size = new System.Drawing.Size(236, 115);
			this.groupBoxTimer.TabIndex = 10;
			this.groupBoxTimer.TabStop = false;
			this.groupBoxTimer.Text = "Timer";
			// 
			// ButtOkTime
			// 
			this.ButtOkTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ButtOkTime.Location = new System.Drawing.Point(76, 28);
			this.ButtOkTime.Name = "ButtOkTime";
			this.ButtOkTime.Size = new System.Drawing.Size(34, 29);
			this.ButtOkTime.TabIndex = 12;
			this.ButtOkTime.Text = "OK";
			this.ButtOkTime.UseVisualStyleBackColor = true;
			this.ButtOkTime.Click += new System.EventHandler(this.ButtOkTime_Click);
			// 
			// groupBoxWallpaperSelecteur
			// 
			this.groupBoxWallpaperSelecteur.Controls.Add(this.TxtBoxSelectedPath);
			this.groupBoxWallpaperSelecteur.Controls.Add(this.ButtOpenFileExplorer);
			this.groupBoxWallpaperSelecteur.Controls.Add(this.CheckBoxFile);
			this.groupBoxWallpaperSelecteur.Controls.Add(this.label1);
			this.groupBoxWallpaperSelecteur.Controls.Add(this.CheckBoxFolder);
			this.groupBoxWallpaperSelecteur.Location = new System.Drawing.Point(21, 12);
			this.groupBoxWallpaperSelecteur.Name = "groupBoxWallpaperSelecteur";
			this.groupBoxWallpaperSelecteur.Size = new System.Drawing.Size(465, 147);
			this.groupBoxWallpaperSelecteur.TabIndex = 11;
			this.groupBoxWallpaperSelecteur.TabStop = false;
			this.groupBoxWallpaperSelecteur.Text = "WallpaperSelecteur";
			// 
			// lblInformation
			// 
			this.lblInformation.Location = new System.Drawing.Point(290, 174);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(196, 57);
			this.lblInformation.TabIndex = 12;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 295);
			this.Controls.Add(this.lblInformation);
			this.Controls.Add(this.groupBoxWallpaperSelecteur);
			this.Controls.Add(this.groupBoxTimer);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Gui Valorant Wallpaer Changer";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.TrackBarTimer)).EndInit();
			this.groupBoxTimer.ResumeLayout(false);
			this.groupBoxTimer.PerformLayout();
			this.groupBoxWallpaperSelecteur.ResumeLayout(false);
			this.groupBoxWallpaperSelecteur.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Button ButtOpenFileExplorer;
		private TextBox TxtBoxSelectedPath;
		private Label label1;
		private CheckBox CheckBoxFolder;
		private CheckBox CheckBoxFile;
		private Label label2;
		private TrackBar TrackBarTimer;
		private CheckBox CheckBoxSeconds;
		private CheckBox CheckBoxMinutes;
		private TextBox TxtBoxTimer;
		private GroupBox groupBoxTimer;
		private GroupBox groupBoxWallpaperSelecteur;
		private Button ButtOkTime;
		private Label lblInformation;
	}
}