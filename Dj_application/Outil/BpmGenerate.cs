using Dj_application.Controller;
using Dj_application.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Utf8Json;


namespace Dj_application.Outil
{
    internal class BpmGenerate
    {
        private const string command = ".\\lib\\streaming_extractor_music.exe";
        private static long id = 0;
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
            string name = System.IO.Path.GetFileNameWithoutExtension(url);
            string pathBmp = "lib\\" + name + "_"+(id++) + ".bpm";
            string arguments = "\"" + url + "\" \"" + pathBmp + "\"";

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
                process.Start();
                process.WaitForExit();
            }

            int bpm = 0;
            try
            {
                // Lecture du contenu du fichier JSON
                string json = File.ReadAllText(pathBmp);

                // Création d'un document JSON à partir de la chaîne JSON
                using (JsonDocument document = JsonDocument.Parse(json))
                {
                    // Accès à la propriété "bpm" dans la partie "rhythm" du JSON
                    JsonElement bpmElement = document.RootElement.GetProperty("rhythm").GetProperty("bpm");

                    // Vérification si la valeur est un nombre
                    if (bpmElement.ValueKind == JsonValueKind.Number)
                    {
                        bpm = (int)Math.Round(bpmElement.GetDouble());
                        MusicBpmDatabase.Instance.InsertBpm(url, bpm);
                    }
                    else
                    {
                        Console.WriteLine("La valeur BPM n'est pas un nombre valide.");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Une erreur s'est produite lors de la lecture du fichier : " + e.Message);
            }
            catch (JsonException e)
            {
                Console.WriteLine("Une erreur s'est produite lors de l'analyse du JSON : " + e.Message);
            }

            File.Delete(pathBmp);
            musique.bpm = bpm;

        }
    }
}
