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

namespace Dj_application
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string command = ".\\lib\\streaming_extractor_music.exe";
            string arguments = "boss1.mp3 boss1.bpm";

            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                Console.WriteLine("start");
                process.Start();
                process.WaitForExit();

                Console.WriteLine("finish");
            }




            Dj_application.View.Window window = SingletonWindow.getInstance().window;
            window.ShowDialog();
        }
    }
}