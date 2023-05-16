﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace Dj_application.model
{
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.WindowsForms;

    public class LecteurAudio
    {
        private WaveOutEvent sortieAudio;
        private AudioFileReader lecteurAudio;
        private Musique musique;
        public event EventHandler<double> PositionChanged;
        public event EventHandler<bool> FinishGraph;
        public event EventHandler<double> LoadingPositionChanged;
        public event EventHandler<double> clickOnModel;

        private Thread threadPlay;
        private bool isPlaying = true;

        public LecteurAudio(Musique musique)
        {
            this.musique = musique;
            lecteurAudio = new AudioFileReader(musique.Path);
            sortieAudio = new WaveOutEvent();
            sortieAudio.Init(lecteurAudio);
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
            lecteurAudio.Dispose();
            sortieAudio.Dispose();
            isPlaying = false;
        }

        private void OnPositionChanged(double position)
        {
            PositionChanged?.Invoke(this, position);
        }

        private void UpdatePosition()
        {
            OnPositionChanged(getPositionActuelleSecondes());
        }

        public void Jouer()
        {
            sortieAudio.Play();
            Thread threadPlay = new Thread(() =>
            {
                double lastTime = -1;
                while (isPlaying)
                {
                    double currentTime = getPositionActuelleSecondes();
                    if (currentTime != lastTime)
                    {
                        UpdatePosition();
                        lastTime = currentTime;
                    }

                    Thread.Sleep(100); // Attendre 100 millisecondes
                }
            });

            threadPlay.Start();
        }

        public void MettreEnPause()
        {
            sortieAudio.Pause();
        }

        public void Reprendre()
        {
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
            long positionActuelleEnOctets = lecteurAudio.Position;
            return (double)positionActuelleEnOctets / lecteurAudio.WaveFormat.AverageBytesPerSecond;
        }

        public double getPositionActuellePourcentage()
        {
            return getPositionActuelleSecondes() / getDureeTotalSeconde();
        }

        public void setVolume(float volume)
        {
            sortieAudio.Volume = volume;
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

            AudioFileReader lecteurAudioTmp = new AudioFileReader(lecteurAudio.FileName);

            var sampleAggregator = new SampleAggregator(lecteurAudio.WaveFormat.SampleRate);
            var buffer = new float[bufferSize];
            var waveform = new List<float>();
            int bytesRead;

            // Calcul du facteur de réduction
            int totalSamples = (int)(lecteurAudioTmp.TotalTime.TotalSeconds * lecteurAudioTmp.WaveFormat.SampleRate);
            int reductionFactor = Math.Max(1, totalSamples / sizeZone);

            long totalBytes = lecteurAudioTmp.Length;
            int oldPourcentage = 0;

            while ((bytesRead = lecteurAudioTmp.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < bytesRead; i += reductionFactor)
                {
                    sampleAggregator.AddSamples(buffer, 0, bytesRead);
                    waveform.Add(sampleAggregator.GetSnapshot().Last());
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
            int sizeZone = view.Height;
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
                clickOnModel?.Invoke(this, e.Position.X);
            };
            view.Model.Series.Add(lineSeries);
            view.InvalidatePlot(false);
        }


    }

}
