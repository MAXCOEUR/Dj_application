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

namespace Dj_application.View.Control
{
    public partial class PageDownloadYoutube : UserControl
    {

        bool isMute = false;
        public PageDownloadYoutube()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            wv_youtube.Source = new Uri("https://youtube.com/");
            wv_youtube.CoreWebView2InitializationCompleted += Wv_youtube_CoreWebView2InitializationCompleted;
        }

        private void Wv_youtube_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                // CoreWebView2 est prêt, vous pouvez maintenant accéder à sa propriété et effectuer les opérations nécessaires
                wv_youtube.CoreWebView2.IsMuted = isMute;
            }
            else
            {
                // Gérer les erreurs d'initialisation de CoreWebView2
                MessageBox.Show("Erreur d'initialisation de CoreWebView2.");
            }
        }



        private void bt_download_Click(object sender, EventArgs e)
        {
            string url = wv_youtube.Source.ToString();
            string[] partUrl = url.Split('?');
            url = partUrl[0];
            if (url.ToString().Contains("https://www.youtube.com/watch"))
            {
                string[] arguments = partUrl[1].Split('&');
                string liste = null;
                string v = "";
                foreach (string part in arguments)
                {
                    if (part.Contains("v="))
                    {
                        v = part;
                    }
                    else if (part.Contains("list="))
                    {
                        liste = part;
                    }
                }


                string newUrl;
                if (liste != null)
                {
                    DialogResult result = MessageBox.Show("Voulez-vous télécharger toute la playlist ? repondre oui sinon juste la musique ? repondre non", "Téléchargement de musique", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        newUrl = url + "?" + liste;
                    }
                    else
                    {
                        newUrl = url + "?" + v;
                    }
                }
                else
                {
                    newUrl = url + "?" + v;
                }
                new DownloadYoutubeLink(newUrl);

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

        private void bt_mute_Click(object sender, EventArgs e)
        {
            isMute = !isMute;
            wv_youtube.CoreWebView2.IsMuted = isMute;
            bt_mute.BackColor = (isMute) ? Color.Green : Color.Red;
        }
    }
}
