using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenWallpaper
{
    /// <summary>
    /// All optimization trash
    /// ("optimize my ass", i could probably make this part of MediaPlayerForm.cs
    /// but as some wise man said - "If its working, don't touch")
    /// </summary>
    public static class OptimizationWorker
    {
        private static Thread runThread;
        private static MediaPlayer currentPlayer;
        public static bool IsRunning = false;

        public static void Start(MediaPlayer player)
        {
            currentPlayer = player;
            IsRunning = true;
            runThread = new Thread(() => { while (IsRunning) OptLoop(); });
            runThread.Start();
        }

        public static void Stop()
        {
            IsRunning = false;
            currentPlayer = null;
        }

        private static void OptLoop()
        {
            //Delay
            Thread.Sleep(100);
            if (currentPlayer == null) return;

            currentPlayer.SetPause(!IsBackgroundVisible());
        }

        private static bool IsBackgroundVisible()
        {
            //Check if maximized
            var handle = Win32.GetForegroundWindow();
            if (handle == IntPtr.Zero)
                return true;

            var plc = Win32.GetPlacement(handle);
            if (plc.length <= 0)
                return true;

            //Or if fullscreen
            Win32.RECT rect = new Win32.RECT();
            Win32.GetWindowRect(new HandleRef(null, handle), ref rect);
            
            return (plc.showCmd != Win32.ShowWindowCommands.Maximized) || new Rectangle(0, 0, rect.right - rect.left, rect.bottom - rect.top).Contains(Screen.PrimaryScreen.Bounds);
        }
    }
}
