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
using System.Text.Json;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace Dj_application
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            initFolder();
            Dj_application.View.Window window = SingletonWindow.getInstance().window;
            window.ShowDialog();





            void initFolder()
            {
                string musiqueFolderPath = "./musique";
                string telechargementFolderPath = "./musique/telechargement";

                // V�rifier si le dossier "./musique" existe
                if (!Directory.Exists(musiqueFolderPath))
                {
                    // Cr�er le dossier "./musique"
                    Directory.CreateDirectory(musiqueFolderPath);
                    Console.WriteLine("Le dossier {0} a �t� cr��.", musiqueFolderPath);
                }

                // V�rifier si le dossier "./musique/telechargement" existe
                if (!Directory.Exists(telechargementFolderPath))
                {
                    // Cr�er le dossier "./musique/telechargement"
                    Directory.CreateDirectory(telechargementFolderPath);
                    Console.WriteLine("Le dossier {0} a �t� cr��.", telechargementFolderPath);
                }
            }
        }
    }
}