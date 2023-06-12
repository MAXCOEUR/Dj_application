using Dj_application.Controller;
using Dj_application.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utf8Json;


namespace Dj_application.Outil
{
    internal class BpmGenerate
    {
        private const string command = ".\\lib\\BPM_Detect.exe";
        static public event EventHandler<Musique> BpmTrouver;

        public void getBpm(Musique musique)
        {
            string url = musique.Path;
            Task.Run(() =>
            {
                musique.bpm = MusicBpmDatabase.Instance.GetBpm(url);
                if (musique.bpm == -1)
                {
                    Generate(musique);
                }
                BpmTrouver?.Invoke(this, musique);
            });
        }
        private void Generate(Musique musique)
        {
            string url = musique.Path;
            string arguments = "\"" + url + "\"";

            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,  // Activer la redirection de la sortie standard
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processInfo;
                process.Start();

                // Lire la sortie de la console
                string output = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                double bpmDouble;
                bool parseSuccess = double.TryParse(output, NumberStyles.Any, CultureInfo.InvariantCulture, out bpmDouble);

                int bpm = (int)Math.Round(bpmDouble);
                MusicBpmDatabase.Instance.InsertBpm(url, bpm);
                musique.bpm = bpm;
                // Utilisez la variable 'output' comme souhaité
                Console.WriteLine(output);  // Par exemple, afficher la sortie dans la console
            }

        }
    }
}
