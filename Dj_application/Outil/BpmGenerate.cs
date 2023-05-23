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
            string pathBmp = "lib\\" + name + ".bpm";
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
            string libFolderPath = "lib";
            try
            {
                string[] bpmFiles = Directory.GetFiles(libFolderPath, "*.bpm");

                foreach (string bpmFile in bpmFiles)
                {
                    // Lecture du contenu du fichier JSON
                    string json = File.ReadAllText(bpmFile);

                    // Création d'un document JSON à partir de la chaîne JSON
                    using (JsonDocument document = JsonDocument.Parse(json))
                    {
                        // Accès à la propriété "metadata" dans le JSON
                        if (document.RootElement.TryGetProperty("metadata", out JsonElement metadataElement))
                        {
                            // Accès à la propriété "file_name" dans la partie "metadata" du JSON
                            if (metadataElement.GetProperty("tags").TryGetProperty("file_name", out JsonElement fileNameElement))
                            {
                                // Vérification si la valeur correspond à l'URL donnée
                                if (fileNameElement.GetString() == url)
                                {
                                    // Accès à la propriété "bpm" dans la partie "rhythm" du JSON
                                    if (document.RootElement.TryGetProperty("rhythm", out JsonElement rhythmElement))
                                    {
                                        if (rhythmElement.TryGetProperty("bpm", out JsonElement bpmElement))
                                        {
                                            // Vérification si la valeur est un nombre
                                            if (bpmElement.ValueKind == JsonValueKind.Number)
                                            {
                                                bpm = (int)Math.Round(bpmElement.GetDouble());
                                                MusicBpmDatabase.Instance.InsertBpm(url, bpm);
                                                File.Delete(bpmFile);
                                                break; // Sortir de la boucle si la correspondance est trouvée
                                            }
                                            else
                                            {
                                                Console.WriteLine("La valeur BPM n'est pas un nombre valide.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
            musique.bpm = bpm;

        }
    }
}
