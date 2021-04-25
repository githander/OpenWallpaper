using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace OpenWallpaper
{
    /// <summary>
    /// Main video player.
    /// </summary>
    public partial class MediaPlayerForm : Form
    {
        public static LibVLC LibVLC;

        public WallpaperTemplate SourceTemplate;

        private VideoView view = new VideoView();

        public MediaPlayerForm(WallpaperTemplate src)
        {
            SourceTemplate = src;
            //Moves itself behind the icons on the desktop and makes it look like
            //real live wallpaper
            MoveToBack();

            InitializeComponent();

            //First-launch VLC initialization
            if (LibVLC == null)
            {
                LibVLC = new LibVLC("--input-repeat=65535", "--no-audio");
            }

            //Resize form to fit screen
            Rectangle screenBounds = Screen.FromPoint(Point.Empty).Bounds;
            Left = 0;
            Top = 0;
            Width = screenBounds.Width;
            Height = screenBounds.Height;

            //Adding player to form
            Controls.Add(view);

            //Resize player to fit screen
            view.Left = 0;
            view.Top = 0;
            view.Width = screenBounds.Width;
            view.Height = screenBounds.Height;

            //Media player setup
            view.MediaPlayer = new MediaPlayer(LibVLC);
            view.MediaPlayer.SetRate(src.Speed);

            Media media;
            if (src.SourceType == WallpaperTemplate.WallpaperSourceType.LocalFile)
            {
                media = new Media(LibVLC, Global.GetVideoSource(src));
            }
            else
            {
                media = new Media(LibVLC, Global.GetVideoSource(src), FromType.FromLocation);
                media.Parse(MediaParseOptions.ParseNetwork);
            }

            if (!Global.Settings.GPUAccelerationEnabled)
            {
                media.AddOption(":avcodec-hw=none");
            }
            media.AddOption(":input-repeat=65535");
            view.MediaPlayer.Media = media;
            view.MediaPlayer.EndReached += MediaEndReached;
        }

        private void MoveToBack()
        {
            IntPtr progman = Win32.FindWindow("Progman", null);
            IntPtr result = IntPtr.Zero;
            Win32.SendMessageTimeout(progman, 0x052C, new IntPtr(0), IntPtr.Zero, 0x0, 1000, out result);
            IntPtr workerw = IntPtr.Zero;

            Win32.EnumWindows(new Win32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = Win32.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero);

                if (p != IntPtr.Zero)
                {
                    workerw = Win32.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", IntPtr.Zero);
                }

                return true;
            }), IntPtr.Zero);

            Win32.SetParent(Handle, workerw);
        }

        private void Player_Load(object sender, EventArgs e)
        {
            view.MediaPlayer.Play();
        }

        public void Stop()
        {
            view.MediaPlayer.Stop();
            view.MediaPlayer = null;
            Close();
        }

        private void MediaEndReached(object sender, EventArgs args)
        {
            ThreadPool.QueueUserWorkItem((e) => view.MediaPlayer.Stop());
        }

        private Stream CreateStreamFromUrl(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            return resp.GetResponseStream();
        }
    }
}
