using Dj_application.model;
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dj_application.View.Control
{
    public partial class LecteurAudioView : UserControl
    {
        LecteurAudio lecteurAudio;
        Boolean isPlay = false;
        private LineAnnotation positionMarker;
        private LineAnnotation loadingMarker;
        private RectangleAnnotation progressBarAnnotation;
        private PlotModel model;
        private static int lastCreate=1;
        private int numeroPiste;
        public LecteurAudioView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            numeroPiste = lastCreate++;
            lb_nbr_piste.Text = "Piste " + numeroPiste;

            loadingMarker = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                X = 0,
                Color = OxyColors.Blue, // Couleur du marqueur de chargement
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
            };
            model = new PlotModel();
            positionMarker = new LineAnnotation
            {
                Type = LineAnnotationType.Vertical,
                X = 0,
                Color = OxyColors.Red,
                StrokeThickness = 2,
                LineStyle = LineStyle.Solid,
            };
            progressBarAnnotation = new RectangleAnnotation
            {
                MinimumX = positionMarker.X, // Position actuelle du marqueur
                MaximumX = 0, // Valeur maximale de l'axe X
                MinimumY = -1, // Valeur minimale de l'axe Y
                MaximumY = +1, // Valeur maximale de l'axe Y
                Fill = OxyColor.FromArgb(100, 0, 0, 0), // Couleur de remplissage avec une opacité de 100
                Layer = AnnotationLayer.BelowAxes // Placez l'annotation sous les axes
            };
            model.Annotations.Add(progressBarAnnotation);

            model.Annotations.Add(loadingMarker);
            model.Annotations.Add(positionMarker);
            pv_graph.InvalidatePlot(false);

            model.PlotMargins = new OxyThickness(0); // Supprimer les marges
            model.Padding = new OxyThickness(0); // Supprimer le padding
            pv_graph.Model = model;

            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Maximum = 100,
                Minimum = 0,
            };
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 1,
                Minimum = -1,
            };
            pv_graph.Model.Axes.Add(yAxis);
            pv_graph.Model.Axes.Add(xAxis);

            setAudio("boss1.mp3");

        }

        public int getNumeroPiste()
        {
            return numeroPiste;
        }
        public void setMarker(LineAnnotation marker, double pourcentage)
        {
            if (positionMarker != null)
            {
                PlotModel plotModel = pv_graph.ActualModel;

                double sizeZone = plotModel.Axes[1].Maximum;

                double newPosition = pourcentage * sizeZone;

                marker.X = newPosition;

                progressBarAnnotation.MaximumX = newPosition; // Mettez à jour la nouvelle position du marqueur


                pv_graph.InvalidatePlot(false);
            }
        }


        public void setAudio(string url)
        {
            lecteurAudio = new LecteurAudio(url);
            lecteurAudio.PositionChanged += lecteurAudio_PositionChanged;
            lecteurAudio.FinishGraph += lecteurAudio_FinishGraph;
            lecteurAudio.LoadingPositionChanged += lecteurAudio_LoadingPositionChanged;
            lecteurAudio.clickOnModel += lecteurAudio_clickOnModel;
            lecteurAudio.Jouer();
            lecteurAudio.MettreEnPause();
            lb_name.Text = lecteurAudio.getName();
            lb_timeTotal.Text = "/ " + ((int)(lecteurAudio.getDureeTotalSeconde())).ToString();
            lb_timeNow.Text = ((int)(lecteurAudio.getPositionActuelleSecondes())).ToString();

            StartGeneratingPlotModel();
        }
        private void StartGeneratingPlotModel()
        {
            lecteurAudio.StartGeneratingPlotModel(pv_graph);
        }
        private void lecteurAudio_LoadingPositionChanged(object sender, double position)
        {
            setMarker(loadingMarker, position);
        }
        private void lecteurAudio_FinishGraph(object sender, bool e)
        {
            setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
            setMarker(loadingMarker, -1);
        }
        private void lecteurAudio_clickOnModel(object sender, double e)
        {
            pv_graph_MouseClick(pv_graph,new MouseEventArgs(MouseButtons.Left,1,(int)e,0,0));
        }
        private void lecteurAudio_PositionChanged(object sender, double position)
        {
            if(lecteurAudio==null) return;
            int etat = (int)(lecteurAudio.getPositionActuellePourcentage() * 1000);
            int currentSec = (int)lecteurAudio.getPositionActuelleSecondes();

            if (pv_graph.InvokeRequired)
            {
                pv_graph.Invoke((MethodInvoker)delegate
                {
                    lb_timeNow.Text = currentSec.ToString();
                    setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
                });
            }
            else
            {
                lb_timeNow.Text = currentSec.ToString();
                setMarker(positionMarker, lecteurAudio.getPositionActuellePourcentage());
            }
        }

        private void Reprendre()
        {
            if (lecteurAudio == null) return;
            lecteurAudio.Reprendre();
            isPlay = true;
            bt_play_pause.BackColor = Color.Red;
            bt_play_pause.Text = "Pause";
        }
        private void MettreEnPause()
        {
            lecteurAudio.MettreEnPause();
            isPlay = false;
            bt_play_pause.BackColor = Color.Green;
            bt_play_pause.Text = "Jouer";
        }

        private void bt_stop_Click(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            lecteurAudio.Recommencer();
            MettreEnPause();
        }

        private void pv_graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (lecteurAudio == null) return;
            if (e.Button == MouseButtons.Left)
            {
                int clickX = e.X;
                double totalWidth = pv_graph.Width;
                double clickPercentage = (double)clickX / totalWidth;
                double positionSeconds = clickPercentage * lecteurAudio.getDureeTotalSeconde();
                lecteurAudio.Deplacer(positionSeconds);
            }
        }

        private void bt_play_pause_Click(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            if (!isPlay)
            {
                Reprendre();
            }
            else
            {
                MettreEnPause();
            }
        }

        private void tb_volume_ValueChanged(object sender, EventArgs e)
        {
            if (lecteurAudio == null) return;
            lecteurAudio.setVolume(tb_volume.Value / 100.0f);
        }
    }
}
