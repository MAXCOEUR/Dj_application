using Dj_application.model;
using Dj_application.Singleton;
using Dj_application.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    internal class DownloadSpotifyLink
    {
        Musique musique;
        string url;
        public event EventHandler<Musique> finDonwloadAndConvertion;
        string name;
        Window win;

        ParametresForm parametresForm = ParametresForm.Instance;

        private const string command = ".\\lib\\tmpSpotify\\spotdl.exe";

        public DownloadSpotifyLink(string url)
        {
            this.url = url;
            win = SingletonWindow.getInstance().window;
            win.StartLoading();
            Task.Run(() =>
            {
                downloadSpotifyLink();
            });
        }
        private void downloadSpotifyLink()
        {
            string arguments = "--user-auth "+ url;
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetFullPath(".\\lib\\tmpSpotify")
            };

            string output;
            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            Console.WriteLine(output);
            if (!output.Contains("Downloaded") && !output.Contains("Skipping"))
            {
                MessageBox.Show("La ou les musiques n'a pas pu etre telecharger", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string target = Path.GetFullPath(".\\musique\\telechargement\\");
            string[] filesLib = Directory.GetFiles(Path.GetFullPath(".\\lib\\tmpSpotify"));

            foreach (string file in filesLib)
            {
                string extention = Path.GetExtension(file);
                if (extention == ".mp3")
                {
                    try
                    {
                        File.Move(file, target + "/" + Path.GetFileName(file));
                    }
                    catch (Exception ex) { }
                }
            }
            win.StopLoading();

        }
    }
}
