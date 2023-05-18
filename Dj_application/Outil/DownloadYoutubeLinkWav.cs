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
    internal class DownloadYoutubeLinkWav
    {
        Musique musique;
        string url;
        public event EventHandler<Musique> finDonwloadAndConvertion;
        string name;
        Window win;

        private const string command = ".\\lib\\yt-dlp.exe";

        public DownloadYoutubeLinkWav(string url)
        {
            this.url = url;
            win = SingletonWindow.getInstance().window;
            win.StartLoading();
            Task.Run(() =>
            {
                downloadYoutubeLink();
            });
        }

        private void downloadYoutubeLink()
        {
            string arguments = "-x --audio-format wav " + url;
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

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);

                if (extension == ".wav" || extension == ".webpm")
                {
                    // Faites quelque chose avec le fichier correspondant à l'extension spécifiée
                    // Par exemple, vous pouvez stocker le nom du fichier dans une liste ou l'afficher dans la console
                    string fileName = Path.GetFileName(file);
                    try
                    {
                        convertYoutubeWav(fileName);
                    }
                    catch
                    {
                        MessageBox.Show("le lien n'est pas bon", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            
        }

        private void convertYoutubeWav(string oldPath)
        {
            string name = Path.GetFileNameWithoutExtension(oldPath);
            string newPath = "musique/telechargement/" + name + ".wav";
            ConvertOutil.ConvertToWav(oldPath, newPath);
            File.Delete(oldPath);
            finDonwloadAndConvertion?.Invoke(this, new Musique(newPath));
            win.StopLoading();
        }

    }
}
