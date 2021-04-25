namespace OpenWallpaper
{
    partial class OpenWallpaper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenWallpaper));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.templateSourceFile = new System.Windows.Forms.Button();
            this.sourceNameText = new System.Windows.Forms.Label();
            this.templateSourceUrl = new System.Windows.Forms.TextBox();
            this.templateSpeed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.templateSource = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.templateName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.templateList = new System.Windows.Forms.ListBox();
            this.mainLayout = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OWTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpuAccelerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToAutorunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateSpeed)).BeginInit();
            this.mainLayout.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.templateSourceFile);
            this.tabPage2.Controls.Add(this.sourceNameText);
            this.tabPage2.Controls.Add(this.templateSourceUrl);
            this.tabPage2.Controls.Add(this.templateSpeed);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.templateSource);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.templateName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.templateList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(831, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wallpapers";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(701, 370);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 46);
            this.button3.TabIndex = 17;
            this.button3.Text = "Set as Wallpaper";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SetAsWallpaperButton);
            // 
            // templateSourceFile
            // 
            this.templateSourceFile.Location = new System.Drawing.Point(408, 154);
            this.templateSourceFile.Name = "templateSourceFile";
            this.templateSourceFile.Size = new System.Drawing.Size(75, 23);
            this.templateSourceFile.TabIndex = 15;
            this.templateSourceFile.Text = "Select File";
            this.templateSourceFile.UseVisualStyleBackColor = true;
            this.templateSourceFile.Visible = false;
            this.templateSourceFile.Click += new System.EventHandler(this.FromFileButton);
            // 
            // sourceNameText
            // 
            this.sourceNameText.AutoSize = true;
            this.sourceNameText.Enabled = false;
            this.sourceNameText.Location = new System.Drawing.Point(405, 139);
            this.sourceNameText.Name = "sourceNameText";
            this.sourceNameText.Size = new System.Drawing.Size(29, 13);
            this.sourceNameText.TabIndex = 14;
            this.sourceNameText.Text = "URL";
            this.sourceNameText.Visible = false;
            // 
            // templateSourceUrl
            // 
            this.templateSourceUrl.Location = new System.Drawing.Point(408, 157);
            this.templateSourceUrl.Name = "templateSourceUrl";
            this.templateSourceUrl.Size = new System.Drawing.Size(173, 20);
            this.templateSourceUrl.TabIndex = 13;
            this.templateSourceUrl.Visible = false;
            this.templateSourceUrl.TextChanged += new System.EventHandler(this.FromURLTextBoxTextChanged);
            // 
            // templateSpeed
            // 
            this.templateSpeed.DecimalPlaces = 1;
            this.templateSpeed.Enabled = false;
            this.templateSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.templateSpeed.Location = new System.Drawing.Point(282, 240);
            this.templateSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.templateSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.templateSpeed.Name = "templateSpeed";
            this.templateSpeed.Size = new System.Drawing.Size(120, 20);
            this.templateSpeed.TabIndex = 12;
            this.templateSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.templateSpeed.ValueChanged += new System.EventHandler(this.TemplateSpeedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(278, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Template Speed";
            // 
            // templateSource
            // 
            this.templateSource.Enabled = false;
            this.templateSource.Items.AddRange(new object[] {
            "From File",
            "From URL",
            "(Experemental) From YouTube"});
            this.templateSource.Location = new System.Drawing.Point(281, 156);
            this.templateSource.Name = "templateSource";
            this.templateSource.Size = new System.Drawing.Size(121, 21);
            this.templateSource.TabIndex = 9;
            this.templateSource.SelectedIndexChanged += new System.EventHandler(this.TemplateSourceChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(278, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Template Source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(278, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Template Name";
            // 
            // templateName
            // 
            this.templateName.Enabled = false;
            this.templateName.Location = new System.Drawing.Point(281, 76);
            this.templateName.Name = "templateName";
            this.templateName.Size = new System.Drawing.Size(209, 20);
            this.templateName.TabIndex = 5;
            this.templateName.Text = "New Template 1";
            this.templateName.TextChanged += new System.EventHandler(this.TemplateNameChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Wallpaper Templates";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete Template";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RemoveTemplateButton);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create Template";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CreateTemplateButton);
            // 
            // templateList
            // 
            this.templateList.FormattingEnabled = true;
            this.templateList.Location = new System.Drawing.Point(8, 25);
            this.templateList.Name = "templateList";
            this.templateList.Size = new System.Drawing.Size(196, 368);
            this.templateList.TabIndex = 1;
            this.templateList.SelectedIndexChanged += new System.EventHandler(this.TemplateListNewSelection);
            // 
            // mainLayout
            // 
            this.mainLayout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainLayout.Controls.Add(this.linkLabel1);
            this.mainLayout.Controls.Add(this.label2);
            this.mainLayout.Controls.Add(this.label1);
            this.mainLayout.Location = new System.Drawing.Point(4, 22);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(3);
            this.mainLayout.Size = new System.Drawing.Size(831, 429);
            this.mainLayout.TabIndex = 0;
            this.mainLayout.Text = "General";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(232, 287);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(367, 24);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/0xC34E/OpenWallpaper";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubIssuesLinkClicked);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(48, 194);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(734, 144);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(751, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to OpenWallpaper, open-source live wallpaper engine! ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainLayout);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 455);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            // 
            // OWTrayIcon
            // 
            this.OWTrayIcon.Text = "OpenWallpaper";
            this.OWTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIconClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuClicked);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.addToAutorunToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gpuAccelerationToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // gpuAccelerationToolStripMenuItem
            // 
            this.gpuAccelerationToolStripMenuItem.Name = "gpuAccelerationToolStripMenuItem";
            this.gpuAccelerationToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.gpuAccelerationToolStripMenuItem.Text = "GPU Acceleration";
            this.gpuAccelerationToolStripMenuItem.Click += new System.EventHandler(this.GPUAccelerationMenuClicked);
            // 
            // addToAutorunToolStripMenuItem
            // 
            this.addToAutorunToolStripMenuItem.Name = "addToAutorunToolStripMenuItem";
            this.addToAutorunToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addToAutorunToolStripMenuItem.Text = "Add to Autorun";
            this.addToAutorunToolStripMenuItem.Click += new System.EventHandler(this.AddToAutorunMenuClicked);
            // 
            // OpenWallpaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 482);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "OpenWallpaper";
            this.Text = "OpenWallpaper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CancelClosing);
            this.Load += new System.EventHandler(this.OpenWallpaperLoad);
            this.Shown += new System.EventHandler(this.OpenWallpaperShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateSpeed)).EndInit();
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        public System.Windows.Forms.NotifyIcon OWTrayIcon;

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage mainLayout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox templateList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox templateName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox templateSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown templateSpeed;
        private System.Windows.Forms.TextBox templateSourceUrl;
        private System.Windows.Forms.Label sourceNameText;
        private System.Windows.Forms.Button templateSourceFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gpuAccelerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToAutorunToolStripMenuItem;
    }
}

