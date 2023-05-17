using Dj_application.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    internal class DownloadYoutubeLinkWav
    {
        Musique musique;
        string url;
        public event EventHandler<Musique> finDonwloadAndConvertion;
        string name;

        private const string command = ".\\lib\\yt-dlp.exe";

        public DownloadYoutubeLinkWav(string url)
        {
            this.url = url;
            Task.Run(() =>
            {
                downloadYoutubeLink();
            });
        }

        private void downloadYoutubeLink()
        {
            string arguments = "-x --audio-format mp3 " + url;
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            string output;
            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            string[] lines = output.Split('\n');

            foreach(string line in lines )
            {
                if (line.Contains("[download] Destination: "))
                {
                    string tmpName;
                    tmpName = line.Replace("[download] Destination: ", "");
                    name = tmpName;
                }

            }
            try
            {
                convertYoutubeWav(name);
            }
            catch
            {
                MessageBox.Show("le lien n'est pas bon", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void convertYoutubeWav(string oldPath)
        {
            string name = Path.GetFileNameWithoutExtension(oldPath);
            string newPath = "musique/telechargement/" + name + ".wav";
            ConvertOutil.ConvertToWav(oldPath, newPath);
            File.Delete(oldPath);
            finDonwloadAndConvertion?.Invoke(this, new Musique(newPath));
        }

    }
}
