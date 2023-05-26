﻿using Dj_application.model;
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
    internal class DownloadYoutubeLink
    {
        Musique musique;
        string url;
        public event EventHandler<Musique> finDonwloadAndConvertion;
        string name;
        Window win;

        private const string command = ".\\lib\\yt-dlp.exe";

        public DownloadYoutubeLink(string url)
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
            string arguments = "-x --audio-format mp3 " + url;
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(".\\musique\\telechargement\\")
            };

            string output;
            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            string[] files = Directory.GetFiles(Path.GetDirectoryName(".\\musique\\telechargement\\"));

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);

                if (extension == ".webpm")
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
            win.StopLoading();
        }

        private void convertYoutubeWav(string oldPath)
        {
            string name = Path.GetFileNameWithoutExtension(oldPath);
            string newPath = "musique/telechargement/" + name + ".wav";
            ConvertOutil.ConvertToMp3(oldPath, newPath);
            File.Delete(oldPath);
            finDonwloadAndConvertion?.Invoke(this, new Musique(newPath));
        }

    }
}