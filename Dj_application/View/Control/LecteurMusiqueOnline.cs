using Dj_application.model;
using NAudio.Wave;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Collections;

namespace Dj_application.View
{
    public partial class LecteurMusiqueOnline : UserControl
    {

        private MusiqueOnline musique;
        VlcControl vlc = new VlcControl();
        bool isPlay = true;
        public LecteurMusiqueOnline(MusiqueOnline musique)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.musique = musique;

            initDonne();
        }

        private async void initDonne()
        {
            lb_name.Text = await musique.GetTitreAsync();
            lb_temp.Text = (await musique.GetDureeAsync()).ToString();
            vlc.BeginInit();
            vlc.VlcLibDirectory = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");
            vlc.EndInit();

            vlc.Play(new Uri(await musique.GetUrlStream()));
            Play();
        }

        private void bt_playPause_Click(object sender, EventArgs e)
        {
            if (isPlay)
            {
                Pause();
            }
            else
            {
                Play();
            }
        }

        private void Play()
        {
            bt_playPause.Text = "Play";
            bt_playPause.BackColor = Color.Green;
            isPlay = true;
            vlc.Play();
        }
        private void Pause()
        {
            bt_playPause.Text = "Pause";
            bt_playPause.BackColor = Color.Red;
            isPlay = false;
            vlc.Pause();
        }

        private void tb_volume_ValueChanged(object sender, EventArgs e)
        {
            vlc.Audio.Volume = tb_volume.Value;
        }

    }
}
