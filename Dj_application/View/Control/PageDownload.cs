using Dj_application.Outil;
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
    public partial class PageDownload : UserControl
    {
        public PageDownload()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            webV_youtube.Source = new Uri("https://www.youtube.com/");
        }

        private void bt_dowload_Click(object sender, EventArgs e)
        {
            Console.WriteLine(webV_youtube.Source.ToString());
            new DownloadYoutubeLinkWav(webV_youtube.Source.ToString());
        }
    }
}
