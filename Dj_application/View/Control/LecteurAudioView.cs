using Dj_application.model;
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using OxyPlot;
using OxyPlot.Annotations;
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
        public LecteurAudioView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            setAudio("boss1.mp3");
        }
        public void setMarker(double pourcentage)
        {
            if (positionMarker != null)
            {
                PlotModel plotModel = pv_graph.ActualModel;

                double sizeZone = plotModel.Axes[0].ActualMaximum;
                double newPosition = pourcentage * sizeZone;
                positionMarker.X = newPosition + plotModel.Axes[0].ActualMinimum;
                pv_graph.InvalidatePlot(false);
            }
        }


        public void setAudio(string url)
        {
            lecteurAudio = new LecteurAudio(url);
            lecteurAudio.PositionChanged += lecteurAudio_PositionChanged;
            lecteurAudio.Jouer();
            lecteurAudio.MettreEnPause();
            lb_name.Text = lecteurAudio.getName();
            lb_timeTotal.Text = "/ " + ((int)(lecteurAudio.getDureeTotalSeconde())).ToString();
            lb_timeNow.Text = ((int)(lecteurAudio.getPositionActuelleSecondes())).ToString();

            pv_graph.Model = lecteurAudio.GetPlotModel(pv_graph.Height, out positionMarker);
        }

        private void lecteurAudio_PositionChanged(object sender, double position)
        {
            int etat = (int)(lecteurAudio.getPositionActuellePourcentage() * 1000);
            int currentSec = (int)lecteurAudio.getPositionActuelleSecondes();

            if (pv_graph.InvokeRequired)
            {
                pv_graph.Invoke((MethodInvoker)delegate
                {
                    lb_timeNow.Text = currentSec.ToString();
                    setMarker(lecteurAudio.getPositionActuellePourcentage());
                });
            }
            else
            {
                lb_timeNow.Text = currentSec.ToString();
                setMarker(lecteurAudio.getPositionActuellePourcentage());
            }
        }

        private void bt_play_pause_Click(object sender, EventArgs e)
        {
            if (!isPlay)
            {
                Reprendre();
            }
            else
            {
                MettreEnPause();
            }
        }

        private void Reprendre()
        {
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
            lecteurAudio.Recommencer();
            MettreEnPause();
        }

        private void sb_son_Scroll(object sender, EventArgs e)
        {
            lecteurAudio.setVolume(sb_son.Value / 100.0f);
        }

        private void pv_graph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int clickX = e.X;
                double totalWidth = pv_graph.Width;
                double clickPercentage = (double)clickX / totalWidth;
                double positionSeconds = clickPercentage * lecteurAudio.getDureeTotalSeconde();
                lecteurAudio.Deplacer(positionSeconds);
            }
        }
    }
}
