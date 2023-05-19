﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    internal class ConvertOutil
    {
        public static void ConvertToWav(string inputFilePath, string outputFilePath)
        {
            using (var reader = new MediaFoundationReader(inputFilePath))
            {
                // Créer un nom de fichier sans caractères problématiques
                string sanitizedFileName = SanitizeFileName(Path.GetFileNameWithoutExtension(outputFilePath));

                // Supprimer les caractères spéciaux du nom de fichier
                string safeOutputFileName = Path.Combine(Path.GetDirectoryName(outputFilePath), sanitizedFileName + ".wav");

                WaveFileWriter.CreateWaveFile(safeOutputFileName, reader);
            }
        }
        private static string SanitizeFileName(string fileName)
        {
            // Supprimer les caractères non autorisés dans le nom de fichier
            string sanitizedFileName = Regex.Replace(fileName, @"[^\w\-. ]", "");

            return sanitizedFileName;
        }

    }
}
