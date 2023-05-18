using Dj_application.View;
using Dj_application.Singleton;
using Dj_application.model;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Runtime.InteropServices;
using System;
using System.IO;
using Dj_application.Outil;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace Dj_application
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //new DownloadYoutubeLinkWav("https://www.youtube.com/watch?v=VHoT4N43jK8");

            Dj_application.View.Window window = SingletonWindow.getInstance().window;
            window.ShowDialog();
        }
    }
}