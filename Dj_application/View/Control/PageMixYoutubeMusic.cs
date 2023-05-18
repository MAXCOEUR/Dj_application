using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Dj_application.View.Control
{
    public partial class PageMixYoutubeMusic : UserControl
    {
        WebView2 piste1 = new WebView2();
        WebView2 piste2 = new WebView2();
        float volumePiste1;
        float volumePiste2;
        public PageMixYoutubeMusic()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();


            piste1.Source = new Uri("https://music.youtube.com/");
            piste1.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(piste1);

            piste2.Source = new Uri("https://music.youtube.com/");
            piste2.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(piste2);

        }

        private void tb_master_ValueChanged(object sender, EventArgs e)
        {
            int valeur = tb_master.Value;
            int valeur1 = 100;
            int valeur2 = 100;

            if (valeur > 0)
            {
                valeur1 = 100 - Math.Abs(valeur);
            }
            else if (valeur < 0)
            {
                valeur2 = 100 - Math.Abs(valeur);
            }

            if (piste1 != null)
            {
                float volumePiste1 = valeur1 / 100.0f;
                
            }

            if (piste2 != null)
            {
                float volumePiste2 = valeur2 / 100.0f;
            }
        }

    }
}
