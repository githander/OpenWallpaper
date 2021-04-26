using IWshRuntimeLibrary;
using LibVLCSharp.Shared;
using OpenWallpaper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace OpenWallpaper
{
    public partial class OpenWallpaper : Form
    {
        public static WallpaperTemplate SelectedTemplate = null;
        public static List<WallpaperTemplate> Templates = new List<WallpaperTemplate>();


        private int selectedIndex = 0;
        private MediaPlayerForm player;
        private bool forceExit = false;
        private LibVLC libVlc = new LibVLC("--input-repeat=65535", "--no-audio");

        public OpenWallpaper()
        {
            InitializeComponent();

            Global.Settings = Settings.Load();

            //Creating save config if doesn't exist
            if (!File.Exists(Settings.SETTINGS_PATH))
            {
                Global.Settings.GPUAccelerationEnabled = true;
                Global.Settings.DefaultWallpaper = "-1";
                Global.Settings.Save();
            }

            Debug.WriteLine($"{Global.Settings.GPUAccelerationEnabled}");
            gpuAccelerationToolStripMenuItem.Checked = Global.Settings.GPUAccelerationEnabled;

            OWTrayIcon.Icon = Resources.Icon;
            OWTrayIcon.ContextMenu = new ContextMenu();
            OWTrayIcon.ContextMenu.MenuItems.Add("Show", ShowAppContextItem);
            OWTrayIcon.ContextMenu.MenuItems.Add("Close", CloseAppContextItem);

            Text = $"OpenWallpaper {Global.VERSION}";
        }

        private void OpenWallpaperLoad(object sender, EventArgs e)
        {
            LoadTemplates();

            //Finding last wallpaper
            IEnumerable<WallpaperTemplate> wList = Templates.Where(w => w.Name == Global.Settings.DefaultWallpaper);

            if (wList.Count() > 0)
            {
                if (player != null)
                {
                    player.Stop();
                }

                player = new MediaPlayerForm(wList.FirstOrDefault());
                player.Show();
            }
        }

        private void OpenWallpaperShown(object sender, EventArgs e)
        {
            //If its startup then hiding self in the tray ;)
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 2 && args[1] == "--tray")
            {
                Hide();
                OWTrayIcon.Visible = true;
            }
        }

        private void GithubIssuesLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/0xC34E/OpenWallpaper/");
        }

        private void TemplateSourceChanged(object sender, EventArgs e)
        {
            //Make sure that there is selected template!
            if (SelectedTemplate == null)
            {
                return;
            }

            //Changing current source type
            SelectedTemplate.SourceType = (WallpaperTemplate.WallpaperSourceType)templateSource.SelectedIndex;

            //Save changes
            SelectedTemplate.SaveTemplate();

            //Hiding url textbox if source is from file
            if (SelectedTemplate.SourceType == WallpaperTemplate.WallpaperSourceType.LocalFile)
            {
                sourceNameText.Text = "File";
                templateSourceUrl.Visible = false;
                templateSourceFile.Visible = true;
                templateSourceUrl.Text = "";
            }
            else
            {
                sourceNameText.Text = "URL";
                templateSourceUrl.Visible = true;
                templateSourceFile.Visible = false;
                templateSourceUrl.Text = SelectedTemplate.Source;
            }
        }

        private void TemplateListNewSelection(object sender, EventArgs e)
        {
            UpdateSelections();
        }

        private void LoadTemplates()
        {
            //Scans template folder
            foreach (string file in Directory.GetFiles(Global.SAVES_PATH, "*template.json", SearchOption.AllDirectories))
            {
                //Trying to parse its content
                string templateJsonText = File.ReadAllText(file);

                WallpaperTemplate template = WallpaperTemplate.FromJson(templateJsonText);
                Templates.Add(template);
                templateList.Items.Add(template.Name);
            }
        }

        private void TemplateNameChanged(object sender, EventArgs e)
        {
            SelectedTemplate.Name = templateName.Text;
            templateList.Items[selectedIndex] = templateName.Text;
            templateList.Refresh();
            SelectedTemplate.SaveTemplate();
        }

        private void CreateTemplateButton(object sender, EventArgs e)
        {
            WallpaperTemplate newTemplate = new WallpaperTemplate
            {
                Name = $"New Template {Templates.Count}"
            };
            Templates.Add(newTemplate);
            templateList.Items.Add(newTemplate.Name);
            SelectedTemplate = Templates[Templates.Count - 1];
            SelectedTemplate.SaveTemplate();

            UpdateSelections();
        }

        private void RemoveTemplateButton(object sender, EventArgs e)
        {
            DeleteTemplate();
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteTemplate();
            }
        }

        private void DeleteTemplate()
        {
            //Again, check if template exists
            if (SelectedTemplate == null)
            {
                return;
            }

            if (player != null && player.SourceTemplate.Name == SelectedTemplate.Name)
            {
                player.Stop();
                player = null;
            }

            SelectedTemplate.DeleteTemplate();
            SelectedTemplate = null;
            Templates.RemoveAt(selectedIndex);
            templateList.Items.RemoveAt(selectedIndex);

            UpdateSelections();
        }


        private void UpdateSelections()
        {
            if (Templates.Count > 0)
            {
                if (templateList.SelectedIndex != -1)
                {
                    selectedIndex = templateList.SelectedIndex;
                }

                if (selectedIndex >= Templates.Count)
                {
                    selectedIndex = Templates.Count - 1;
                }

                SelectedTemplate = Templates[selectedIndex];

                templateName.Text = SelectedTemplate.Name;
                templateSource.SelectedIndex = (int)SelectedTemplate.SourceType;
                templateSpeed.Value = (decimal)SelectedTemplate.Speed;

                //Hiding url textbox if source is from file
                if (SelectedTemplate.SourceType == WallpaperTemplate.WallpaperSourceType.LocalFile)
                {
                    sourceNameText.Text = "File";
                    templateSourceUrl.Visible = false;
                    templateSourceFile.Visible = true;
                    templateSourceUrl.Text = "";
                }
                else
                {
                    sourceNameText.Text = "URL";
                    templateSourceUrl.Visible = true;
                    templateSourceFile.Visible = false;
                    templateSourceUrl.Text = SelectedTemplate.Source;
                }
            }

            //Total mess ;-)
            if (SelectedTemplate == null)
            {
                templateSpeed.Enabled = templateSource.Enabled = templateName.Enabled =
                label5.Enabled = label6.Enabled = label7.Enabled = sourceNameText.Visible
                = templateSourceFile.Visible = templateSourceUrl.Visible = false;
            }
            else
            {
                templateSpeed.Enabled = templateSource.Enabled = templateName.Enabled =
                label5.Enabled = label6.Enabled = label7.Enabled = sourceNameText.Visible
                 = true;
            }
        }

        private void SetAsWallpaperButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedTemplate.Source))
            {
                return;
            }

            if (player != null)
            {
                player.Stop();
            }

            Global.Settings.DefaultWallpaper = SelectedTemplate.Name;
            Global.Settings.Save();

            player = new MediaPlayerForm(SelectedTemplate);
            player.Show();
        }

        private void FromFileButton(object sender, EventArgs e)
        {
            if (SelectedTemplate.SourceType != WallpaperTemplate.WallpaperSourceType.LocalFile)
            {
                return;
            }

            OpenFileDialog d = new OpenFileDialog();

            if (d.ShowDialog() == DialogResult.OK)
            {
                SelectedTemplate.Source = d.FileName;
                SelectedTemplate.SaveTemplate();
            }
        }

        private void FromURLTextBoxTextChanged(object sender, EventArgs e)
        {
            if (SelectedTemplate.SourceType == WallpaperTemplate.WallpaperSourceType.LocalFile)
            {
                return;
            }

            SelectedTemplate.Source = templateSourceUrl.Text;
            SelectedTemplate.SaveTemplate();
        }

        private void TemplateSpeedChanged(object sender, EventArgs e)
        {
            SelectedTemplate.Speed = (float)templateSpeed.Value;
            SelectedTemplate.SaveTemplate();
        }

        private void CancelClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            OWTrayIcon.Visible = true;

            //Cancelling event
            if (!forceExit)
            {
                OWTrayIcon.ShowBalloonTip(1000, "", "OpenWallpaper is running on the background!\r\nClick the icon in system tray to bring window back!", ToolTipIcon.None);
                e.Cancel = true;
            }
        }

        private void TrayIconClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                Focus();
                OWTrayIcon.Visible = false;
            }
        }

        private void CloseAppContextItem(object sender, EventArgs e)
        {
            player.Close();
            OptimizationWorker.Stop();
            forceExit = true;
            Application.Exit();
        }

        private void ShowAppContextItem(object sender, EventArgs e)
        {
            Show();
            Focus();
            OWTrayIcon.Visible = false;
        }

        private void ExitMenuClicked(object sender, EventArgs e)
        {
            player.Close();
            OptimizationWorker.Stop();
            forceExit = true;
            Application.Exit();
        }

        private void GPUAccelerationMenuClicked(object sender, EventArgs e)
        {
            gpuAccelerationToolStripMenuItem.Checked = !gpuAccelerationToolStripMenuItem.Checked;

            Global.Settings.GPUAccelerationEnabled = gpuAccelerationToolStripMenuItem.Checked;
            Global.Settings.Save();

            MessageBox.Show("To apply changes, OpenWallpaper will be restarted.");

            forceExit = true;
            Application.Restart();
        }

        private void AddToAutorunMenuClicked(object sender, EventArgs e)
        {
            WshShell wshShell = new WshShell();
            IWshShortcut shortcut;
            string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            Console.WriteLine(startUpFolderPath);
            shortcut = (IWshShortcut)wshShell.CreateShortcut(Path.Combine(startUpFolderPath, "OpenWallpaper.lnk"));
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Arguments = "--tray";
            shortcut.Save();
        }
    }
}
