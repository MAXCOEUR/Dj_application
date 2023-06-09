﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace Dj_application.model
{
    using Dj_application.View;
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.WindowsForms;
    using System.Runtime.InteropServices;

    public class LecteurAudio
    {
        private WaveOutEvent sortieAudio;
        private AudioFileReader lecteurAudio;
        private VolumeSampleProvider lecteurAudioAvecVolume;

        private Musique musique;
        public event EventHandler<bool> FinishGraph;
        public event EventHandler<double> LoadingPositionChanged;
        public event EventHandler<OxyMouseDownEventArgs> clickOnModel;

        private Thread threadPlay;
        private bool isAvencementPlaying = true;
        private bool isPlaying = false;

        private object lockObject = new object();


        private ParametresForm parametresForm = ParametresForm.Instance;

        public LecteurAudio(Musique musique)
        {
            this.musique = musique;
            lecteurAudio = new AudioFileReader(musique.Path);
            lecteurAudioAvecVolume = new VolumeSampleProvider(lecteurAudio);
            sortieAudio = new WaveOutEvent();
            sortieAudio.Init(lecteurAudioAvecVolume);
        }

        public TimeSpan getTime()
        {
            return lecteurAudio.TotalTime;
        }

        public void delete()
        {
            Dispose();
        }
        public void Dispose()
        {
            isAvencementPlaying = false;
            lecteurAudio.Dispose();
            sortieAudio.Dispose();
        }
        public void Jouer()
        {
            sortieAudio.Play();
            lock (lockObject)
            {
                isPlaying = true;
            }
        }

        public void MettreEnPause()
        {
            lock (lockObject)
                isPlaying =false;
            sortieAudio.Pause();
        }

        public void Reprendre()
        {
            lock (lockObject)
                isPlaying = true;
            sortieAudio.Play();
        }

        public void Recommencer()
        {
            lecteurAudio.Position = 0;
        }
        
        public double getDureeTotalSeconde()
        {
            return getTime().TotalSeconds;
        }

        public double getPositionActuelleSecondes()
        {
            try
            {
                if(lecteurAudio== null)
                {
                    throw new Exception();
                }
                long positionActuelleEnOctets = lecteurAudio.Position;
                return (double)positionActuelleEnOctets / lecteurAudio.WaveFormat.AverageBytesPerSecond;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return 0;
            }

        }

        public double getPositionActuellePourcentage()
        {
            return getPositionActuelleSecondes() / getDureeTotalSeconde();
        }

        private DateTime lastVolumeUpdateTime = DateTime.MinValue;
        private float lastVolume = 0.0f;
        private System.Threading.Timer volumeUpdateTimer;

        public void setVolume(float volume)
        {
            lastVolume = volume;
            DateTime currentTime = DateTime.Now;

            if (currentTime.Subtract(lastVolumeUpdateTime).TotalSeconds >= 0.1)
            {
                UpdateVolume();
                lastVolumeUpdateTime = currentTime;
            }
            else
            {
                if (volumeUpdateTimer != null)
                {
                    volumeUpdateTimer.Dispose();
                }

                volumeUpdateTimer = new System.Threading.Timer(VolumeUpdateTimerCallback, null, 100, Timeout.Infinite);
            }
        }

        private void UpdateVolume()
        {
            lock (lockObject)
            {
                Thread tmp = new Thread(() =>
                {
                    try
                    {
                        lecteurAudioAvecVolume.Volume = lastVolume;
                        if (!isPlaying)
                        {
                            sortieAudio.Stop();
                            sortieAudio.Init(lecteurAudioAvecVolume);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                });
                tmp.Start();
            }
        }

        private void VolumeUpdateTimerCallback(object state)
        {
            UpdateVolume();
            lastVolumeUpdateTime = DateTime.Now;
        }
        public Musique getMusique()
        {
            return musique;
        }
        public void Deplacer(double positionEnSecondes)
        {
            lecteurAudio.Position = (long)(positionEnSecondes * lecteurAudio.WaveFormat.AverageBytesPerSecond);
        }

        public void StartGeneratingPlotModel(PlotView view)
        {
            Task.Run(() =>
            {
                GenerateGraph(view);
                FinishGraph?.Invoke(this, true);
            });
        }

        private float[] GetWaveformSamples(int sizeZone)
        {
            const int bufferSize = 8192; // Taille du tampon d'échantillons
            const int nbrDonneeParBuffer = 2;

            AudioFileReader lecteurAudioTmp = new AudioFileReader(lecteurAudio.FileName);
            int totalSamples = (int)(lecteurAudioTmp.TotalTime.TotalSeconds * lecteurAudioTmp.WaveFormat.SampleRate);
            




            var sampleAggregator = new SampleAggregator(lecteurAudio.WaveFormat.SampleRate);
            var buffer = new float[bufferSize];
            var waveform = new List<float>();
            int bytesRead;

            // Calcul du facteur de réduction
            


            long totalBytes = lecteurAudioTmp.Length;
            int oldPourcentage = 0;

            while ((bytesRead = lecteurAudioTmp.Read(buffer, 0, buffer.Length)) > 0)
            {
                sampleAggregator.AddSamples(buffer, 0, bytesRead);

                List<float> floats = sampleAggregator.GetSnapshot();
                int reduction = floats.Count / nbrDonneeParBuffer;
                for (int i = 0; i < floats.Count; i+= reduction)
                {
                    waveform.Add(floats[i]);
                }
                

                long currentPosition = lecteurAudioTmp.Position;
                double percentage = (double)currentPosition / totalBytes * 100;
                if((int)percentage > oldPourcentage)
                {
                    oldPourcentage = (int)percentage;
                    LoadingPositionChanged?.Invoke(this, oldPourcentage/100.0f);
                }

            }

            lecteurAudioTmp.Dispose(); // Assurez-vous de libérer les ressources du lecteur temporaire

            return waveform.ToArray();
        }


        private void GenerateGraph(PlotView view)
        {
            int sizeZone = view.Width;
            var lineSeries = new LineSeries();
            
            float[] waveform = GetWaveformSamples(sizeZone);

            for (int i = 0; i < waveform.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, waveform[i]));
            }

            view.Model.Axes.Clear();
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Maximum = waveform.Length,
                Minimum=0,
            };
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 1,
                Minimum = -1,
            };
            view.Model.Axes.Add(yAxis);
            view.Model.Axes.Add(xAxis);

            view.Model.Series.Clear();
            lineSeries.MouseDown += (sender, e) =>
            {
                
                clickOnModel?.Invoke(this, e);
            };
            view.Model.Series.Add(lineSeries);
            view.InvalidatePlot(false);
        }

        public void setSortieAudio(int deviceNumber)
        {
            Console.WriteLine(deviceNumber);
            if (sortieAudio.PlaybackState == PlaybackState.Playing)
            {
                MettreEnPause();
                sortieAudio.Stop();

                // Initialiser le périphérique de sortie avec le numéro de périphérique spécifié
                sortieAudio.DeviceNumber = deviceNumber;
                sortieAudio.Init(lecteurAudioAvecVolume);

                Jouer();
            }
            else
            {
                sortieAudio.Stop();
                sortieAudio.DeviceNumber = deviceNumber;
                sortieAudio.Init(lecteurAudioAvecVolume);
            }
            
        }




    }

}
