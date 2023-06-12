using Dj_application.model;
using Dj_application.Singleton;
using Dj_application.View;
using Microsoft.Win32;
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

        ParametresForm parametresForm = ParametresForm.Instance;

        private const string command = ".\\lib\\tmpYoutube\\yt-dlp.exe";

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

        private string GetDefaultBrowser()
        {
            const string key = @"HTTP\shell\open\command";
            using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false))
            {
                if (registryKey != null)
                {
                    // Obtenir la valeur par défaut du sous-clé
                    string browserPath = registryKey.GetValue(null) as string;
                    if (!string.IsNullOrEmpty(browserPath))
                    {
                        // Extraire le chemin d'accès du navigateur
                        browserPath = browserPath.ToLower().Replace("\"", "");
                        if (browserPath.EndsWith(".exe"))
                        {
                            browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                        }

                        // Extraire le nom du navigateur à partir du chemin d'accès
                        string browserName = Path.GetFileNameWithoutExtension(browserPath);
                        return (browserName == "iexplore")?"edge":browserName;
                    }
                }
            }

            return "Navigateur par défaut non trouvé";
        }

        private void downloadYoutubeLink()
        {
            string userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string spotdlDirectory = Path.Combine(userDirectory, ".spotdl");
            string ffmpegPath = Path.Combine(spotdlDirectory, "ffmpeg.exe");

            string arguments = "-x --audio-format mp3";

            if (File.Exists(ffmpegPath))
            {
                arguments += " --ffmpeg-location \"" + ffmpegPath + "\"";
            }

            arguments += " --cookies-from-browser "+GetDefaultBrowser();

            arguments += " " + url;

            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetFullPath(".\\lib\\tmpYoutube")
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
            if (!output.Contains("[download]"))
            {
                Process.Start("cmd", $"/c start " + GetDefaultBrowser() + " https://music.youtube.com/");
            }
            string[] files = Directory.GetFiles(Path.GetFullPath(".\\lib\\tmpYoutube\\"));
            string target = Path.GetFullPath(".\\musique\\telechargement\\");
            foreach (string file in files)
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
