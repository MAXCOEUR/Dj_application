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

        private const string command = ".\\lib\\spotdl.exe";

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
                WorkingDirectory = Path.GetDirectoryName(".\\lib")
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

            string target = Path.GetFullPath(Path.GetDirectoryName(".\\musique\\telechargement\\"));
            string[] filesLib = Directory.GetFiles(Path.GetDirectoryName(".\\"));

            foreach (string file in filesLib)
            {
                string extension = Path.GetExtension(file);

                if (extension == ".webpm")
                {
                    string fileName = Path.GetFileName(file);
                    try
                    {
                        convertYoutubeMp3(fileName);
                    }
                    catch
                    {
                        MessageBox.Show("le lien n'est pas bon", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }else if (extension == ".mp3")
                {
                    try
                    {
                        File.Move(Path.GetFullPath(file), target + "/" + file);
                    }
                    catch(Exception ex){  }
                }
            }
            win.StopLoading();

        }

        private void convertYoutubeMp3(string oldPath)
        {
            string name = Path.GetFileNameWithoutExtension(oldPath);
            string newPath = "musique/telechargement/" + name + ".mp3";
            ConvertOutil.ConvertToMp3(oldPath, newPath);
            File.Delete(oldPath);
            finDonwloadAndConvertion?.Invoke(this, new Musique(newPath));
        }
    }
}
