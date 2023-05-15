using Dj_application.model;
using NAudio.Gui;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using OxyPlot;
using OxyPlot.Annotations;
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
        int i = 0;
        public LecteurAudioView()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            setAudio("boss1.mp3");
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

            pv_graph.Model=lecteurAudio.GetPlotModel(pv_graph.Height);
        }

        private void lecteurAudio_PositionChanged(object sender, double position)
        {
            int etat = (int)(lecteurAudio.getPositionActuellePourcentage() * 1000);
            int currentSec = (int)lecteurAudio.getPositionActuelleSecondes();

            if (pb_progress.InvokeRequired)
            {
                pb_progress.Invoke((MethodInvoker)delegate
                {
                    pb_progress.Value = etat;
                    lb_timeNow.Text = currentSec.ToString();
                    lecteurAudio.setMarker(lecteurAudio.getPositionActuellePourcentage(), pv_graph.Height);
                });
            }
            else
            {
                pb_progress.Value = etat;
                lb_timeNow.Text = currentSec.ToString();
                lecteurAudio.setMarker(lecteurAudio.getPositionActuellePourcentage(), pv_graph.Height);
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

        private void pb_progress_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int clickX = e.X;
                int totalWidth = pb_progress.Width;
                double clickPercentage = (double)clickX / totalWidth;
                double positionSeconds = clickPercentage * lecteurAudio.getDureeTotalSeconde();
                lecteurAudio.Deplacer(positionSeconds);
                Console.WriteLine("Position cliquée en secondes : " + positionSeconds);
            }
        }
    }
}
