using Dj_application.Outil;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dj_application.View.DownloadPage
{
    public partial class PageDownloadSpotify : UserControl
    {
        bool isMute = false;
        private ParametresForm parametresForm = ParametresForm.Instance;
        public PageDownloadSpotify()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            bt_back.BackColor = parametresForm.palettesCouleur.Mise_Evidence;
            wv_spotify.Source = new Uri("https://open.spotify.com/");
        }
        private void bt_dowload_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.ToString();
            url = url.Trim();
            if (url.ToString().Contains("https://open.spotify.com/playlist/") || url.ToString().Contains("https://open.spotify.com/track/") || url.ToString().Contains("https://open.spotify.com/album/"))
            {
                new DownloadSpotifyLink(url);
            }
            else
            {
                MessageBox.Show("ce n'est pas une vidéo, une playList ou un album spotify", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            wv_spotify.GoBack();
        }

        private void tb_url_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tb_url.Text = "";
            }
        }

        private void bt_mute_Click(object sender, EventArgs e)
        {
            isMute = !isMute;
            wv_spotify.CoreWebView2.IsMuted = isMute;
            bt_mute.BackColor = (isMute) ? Color.Red : Color.Green;
            bt_mute.BackgroundImage = (isMute) ? Resource.volume_mute : Resource.volume;
        }
    }
}
