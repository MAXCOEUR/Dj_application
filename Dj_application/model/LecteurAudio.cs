using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace Dj_application.model
{
    using NAudio.Wave;
    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.WindowsForms;

    public class LecteurAudio
    {
        private WaveOutEvent sortieAudio;
        private AudioFileReader lecteurAudio;
        private string name;
        private string path;
        

        public event EventHandler<double> PositionChanged;

        public LecteurAudio(string cheminFichierAudio)
        {
            path = cheminFichierAudio;
            name= Path.GetFileNameWithoutExtension(cheminFichierAudio);
            lecteurAudio = new AudioFileReader(cheminFichierAudio);
            sortieAudio = new WaveOutEvent();
            sortieAudio.Init(lecteurAudio);
        }

        public TimeSpan getTime()
        {
            return lecteurAudio.TotalTime;
        }

        ~LecteurAudio()
        {
            lecteurAudio.Dispose();
            sortieAudio.Dispose();
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
            Task.Run(async () =>
            {
                double lastTime = -1;
                while (true)
                {
                    double currentTime = getPositionActuelleSecondes();
                    if (currentTime!= lastTime)
                    {
                        UpdatePosition();
                        lastTime=currentTime;
                    }
                    

                    await Task.Delay(100); // Attendre 1% de la durée totale
                }
            });
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
        public string getName()
        {
            return name;
        }
        public void Deplacer(double positionEnSecondes)
        {
            lecteurAudio.Position = (long)(positionEnSecondes * lecteurAudio.WaveFormat.AverageBytesPerSecond);
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

            while ((bytesRead = lecteurAudioTmp.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < bytesRead; i += reductionFactor)
                {
                    sampleAggregator.AddSamples(buffer, 0, bytesRead);
                    waveform.Add(sampleAggregator.GetSnapshot().Last());
                }
            }

            lecteurAudioTmp.Dispose(); // Assurez-vous de libérer les ressources du lecteur temporaire

            return waveform.ToArray();
        }


        public PlotModel GetPlotModel(int sizeZone, out LineAnnotation positionMarker)
        {
            var model = new PlotModel();
            var lineSeries = new LineSeries();
            float[] waveform = GetWaveformSamples(sizeZone);

            for (int i = 0; i < waveform.Length; i++)
            {
                lineSeries.Points.Add(new DataPoint(i, waveform[i]));
            }
            positionMarker = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                X = -500,
                Color = OxyColors.Red,
                StrokeThickness = 1
            };
            model.Series.Add(lineSeries);
            model.Annotations.Add(positionMarker);


            model.PlotMargins = new OxyThickness(0); // Supprimer les marges
            model.Padding = new OxyThickness(0); // Supprimer le padding


            return model;
        }

    }

}
