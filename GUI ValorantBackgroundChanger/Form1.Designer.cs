namespace GUI_ValorantBackgroundChanger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.ButOpenFileExplorer = new System.Windows.Forms.Button();
			this.CheckBoxFile = new System.Windows.Forms.CheckBox();
			this.CheckBoxFolder = new System.Windows.Forms.CheckBox();
			this.lblFileExplorer = new System.Windows.Forms.Label();
			this.txtBoxSelectedPath = new System.Windows.Forms.TextBox();
			this.TrackBarTimer = new System.Windows.Forms.TrackBar();
			this.lblTimer = new System.Windows.Forms.Label();
			this.TxtBoxTimer = new System.Windows.Forms.TextBox();
			this.CheckBoxSeconds = new System.Windows.Forms.CheckBox();
			this.CheckBoxMinutes = new System.Windows.Forms.CheckBox();
			this.lblCreatedby = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.TrackBarTimer)).BeginInit();
			this.SuspendLayout();
			// 
			// ButOpenFileExplorer
			// 
			this.ButOpenFileExplorer.AutoSize = true;
			this.ButOpenFileExplorer.Location = new System.Drawing.Point(15, 31);
			this.ButOpenFileExplorer.Margin = new System.Windows.Forms.Padding(6);
			this.ButOpenFileExplorer.Name = "ButOpenFileExplorer";
			this.ButOpenFileExplorer.Size = new System.Drawing.Size(44, 34);
			this.ButOpenFileExplorer.TabIndex = 0;
			this.ButOpenFileExplorer.Text = "...";
			this.ButOpenFileExplorer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.ButOpenFileExplorer.UseVisualStyleBackColor = true;
			this.ButOpenFileExplorer.Click += new System.EventHandler(this.ButOpenFileExplorer_Click);
			// 
			// CheckBoxFile
			// 
			this.CheckBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckBoxFile.AutoCheck = false;
			this.CheckBoxFile.AutoSize = true;
			this.CheckBoxFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxFile.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CheckBoxFile.Location = new System.Drawing.Point(397, 71);
			this.CheckBoxFile.Name = "CheckBoxFile";
			this.CheckBoxFile.Size = new System.Drawing.Size(51, 24);
			this.CheckBoxFile.TabIndex = 3;
			this.CheckBoxFile.Text = "File";
			this.CheckBoxFile.UseVisualStyleBackColor = true;
			this.CheckBoxFile.Click += new System.EventHandler(this.CheckBoxFile_Click);
			// 
			// CheckBoxFolder
			// 
			this.CheckBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckBoxFolder.AutoCheck = false;
			this.CheckBoxFolder.AutoSize = true;
			this.CheckBoxFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.CheckBoxFolder.Checked = true;
			this.CheckBoxFolder.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxFolder.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CheckBoxFolder.Location = new System.Drawing.Point(378, 41);
			this.CheckBoxFolder.Name = "CheckBoxFolder";
			this.CheckBoxFolder.Size = new System.Drawing.Size(70, 24);
			this.CheckBoxFolder.TabIndex = 4;
			this.CheckBoxFolder.Text = "Folder";
			this.CheckBoxFolder.UseVisualStyleBackColor = true;
			this.CheckBoxFolder.Click += new System.EventHandler(this.CheckBoxFolder_Click);
			// 
			// lblFileExplorer
			// 
			this.lblFileExplorer.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
			this.lblFileExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFileExplorer.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFileExplorer.Location = new System.Drawing.Point(334, 9);
			this.lblFileExplorer.Name = "lblFileExplorer";
			this.lblFileExplorer.Size = new System.Drawing.Size(114, 24);
			this.lblFileExplorer.TabIndex = 5;
			this.lblFileExplorer.Text = "File explorer";
			// 
			// txtBoxSelectedPath
			// 
			this.txtBoxSelectedPath.Font = new System.Drawing.Font("Microsoft PhagsPa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxSelectedPath.Location = new System.Drawing.Point(68, 19);
			this.txtBoxSelectedPath.Multiline = true;
			this.txtBoxSelectedPath.Name = "txtBoxSelectedPath";
			this.txtBoxSelectedPath.ReadOnly = true;
			this.txtBoxSelectedPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtBoxSelectedPath.Size = new System.Drawing.Size(243, 101);
			this.txtBoxSelectedPath.TabIndex = 6;
			this.txtBoxSelectedPath.Text = "Your File/Folder path\r\n   will be show here ";
			this.txtBoxSelectedPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// TrackBarTimer
			// 
			this.TrackBarTimer.Location = new System.Drawing.Point(10, 160);
			this.TrackBarTimer.Maximum = 600;
			this.TrackBarTimer.Name = "TrackBarTimer";
			this.TrackBarTimer.Size = new System.Drawing.Size(104, 45);
			this.TrackBarTimer.TabIndex = 7;
			this.TrackBarTimer.TickFrequency = 100;
			this.TrackBarTimer.Value = 60;
			this.TrackBarTimer.Scroll += new System.EventHandler(this.TrackBarTimer_Scroll);
			// 
			// lblTimer
			// 
			this.lblTimer.AutoSize = true;
			this.lblTimer.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimer.Location = new System.Drawing.Point(11, 126);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new System.Drawing.Size(58, 24);
			this.lblTimer.TabIndex = 10;
			this.lblTimer.Text = "Timer";
			// 
			// TxtBoxTimer
			// 
			this.TxtBoxTimer.Location = new System.Drawing.Point(138, 160);
			this.TxtBoxTimer.MaxLength = 4;
			this.TxtBoxTimer.Name = "TxtBoxTimer";
			this.TxtBoxTimer.Size = new System.Drawing.Size(67, 32);
			this.TxtBoxTimer.TabIndex = 11;
			this.TxtBoxTimer.Text = "15";
			this.TxtBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtBoxTimer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBoxTimer_KeyDown);
			this.TxtBoxTimer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBoxTimer_KeyPress);
			// 
			// CheckBoxSeconds
			// 
			this.CheckBoxSeconds.AutoCheck = false;
			this.CheckBoxSeconds.AutoSize = true;
			this.CheckBoxSeconds.Checked = true;
			this.CheckBoxSeconds.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CheckBoxSeconds.Location = new System.Drawing.Point(82, 126);
			this.CheckBoxSeconds.Name = "CheckBoxSeconds";
			this.CheckBoxSeconds.Size = new System.Drawing.Size(56, 28);
			this.CheckBoxSeconds.TabIndex = 13;
			this.CheckBoxSeconds.Text = "sec";
			this.CheckBoxSeconds.UseVisualStyleBackColor = true;
			this.CheckBoxSeconds.Click += new System.EventHandler(this.CheckBoxSeconds_Click);
			// 
			// CheckBoxMinutes
			// 
			this.CheckBoxMinutes.AutoCheck = false;
			this.CheckBoxMinutes.AutoSize = true;
			this.CheckBoxMinutes.Location = new System.Drawing.Point(144, 126);
			this.CheckBoxMinutes.Name = "CheckBoxMinutes";
			this.CheckBoxMinutes.Size = new System.Drawing.Size(61, 28);
			this.CheckBoxMinutes.TabIndex = 14;
			this.CheckBoxMinutes.Text = "min";
			this.CheckBoxMinutes.UseVisualStyleBackColor = true;
			this.CheckBoxMinutes.Click += new System.EventHandler(this.CheckBoxMinutes_Click);
			// 
			// lblCreatedby
			// 
			this.lblCreatedby.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCreatedby.AutoSize = true;
			this.lblCreatedby.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCreatedby.Location = new System.Drawing.Point(402, 176);
			this.lblCreatedby.Name = "lblCreatedby";
			this.lblCreatedby.Size = new System.Drawing.Size(46, 42);
			this.lblCreatedby.TabIndex = 17;
			this.lblCreatedby.Text = "Created\r\nby \r\nAmelie";
			this.lblCreatedby.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(460, 227);
			this.Controls.Add(this.lblFileExplorer);
			this.Controls.Add(this.CheckBoxFolder);
			this.Controls.Add(this.CheckBoxFile);
			this.Controls.Add(this.CheckBoxMinutes);
			this.Controls.Add(this.CheckBoxSeconds);
			this.Controls.Add(this.TxtBoxTimer);
			this.Controls.Add(this.lblTimer);
			this.Controls.Add(this.TrackBarTimer);
			this.Controls.Add(this.txtBoxSelectedPath);
			this.Controls.Add(this.ButOpenFileExplorer);
			this.Controls.Add(this.lblCreatedby);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::GUI_ValorantBackgroundChanger.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Location = global::GUI_ValorantBackgroundChanger.Properties.Settings.Default.Location;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Gui ";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Leave += new System.EventHandler(this.Form1_Leave);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.TrackBarTimer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButOpenFileExplorer;
        private System.Windows.Forms.CheckBox CheckBoxFile;
        private System.Windows.Forms.CheckBox CheckBoxFolder;
        private System.Windows.Forms.Label lblFileExplorer;
        private System.Windows.Forms.TextBox txtBoxSelectedPath;
        private System.Windows.Forms.TrackBar TrackBarTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox TxtBoxTimer;
        private System.Windows.Forms.CheckBox CheckBoxSeconds;
        private System.Windows.Forms.CheckBox CheckBoxMinutes;
        private System.Windows.Forms.Label lblCreatedby;
    }
}

