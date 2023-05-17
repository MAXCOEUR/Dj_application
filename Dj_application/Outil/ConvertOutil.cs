using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    internal class ConvertOutil
    {
        public static void ConvertToWav(string inputFilePath, string outputFilePath)
        {
            using (var reader = new MediaFoundationReader(inputFilePath))
            {
                WaveFileWriter.CreateWaveFile(outputFilePath, reader);
            }
        }

    }
}
