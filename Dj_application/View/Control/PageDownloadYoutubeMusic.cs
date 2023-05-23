using Dj_application.Outil;
using Microsoft.Web.WebView2.Core;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Dj_application.View.Control
{
    public partial class PageDownloadYoutubeMusic : UserControl
    {

        public PageDownloadYoutubeMusic()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            wv_youtube.Source = new Uri("https://music.youtube.com/");
        }


        private void bt_dowload_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.ToString();
            url= url.Trim();
            url = url.Split('&')[0];
            Console.WriteLine(url);
            if (url.ToString().Contains("https://music.youtube.com/watch?") || url.ToString().Contains("https://music.youtube.com/playlist?"))
            {
                new DownloadYoutubeLinkWav(url);
            }
            else
            {
                MessageBox.Show("ce n'est pas une vidéo ou une playList youtube Music", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            wv_youtube.GoBack();
        }

        private void tb_url_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                tb_url.Text = "";
            }
        }
    }
}
