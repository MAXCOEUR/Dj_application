using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.Outil
{
    internal class Convertion
    {
        public static void ConvertToWav(string audioFilePath, string wavFilePath)
        {
            using (var reader = new MediaFoundationReader(audioFilePath))
            {
                WaveFileWriter.CreateWaveFile(wavFilePath, reader);
            }
        }
    }
}
