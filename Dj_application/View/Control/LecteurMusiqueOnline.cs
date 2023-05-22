using Dj_application.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dj_application.View
{
    public partial class LecteurMusiqueOnline : UserControl
    {

        private MusiqueOnline musique;
        public LecteurMusiqueOnline(MusiqueOnline musique)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.musique = musique;

            //lb_name.Text = musique.GetTitreAsync().Result;
            //lb_temp.Text = musique.GetDureeAsync().Result.ToString();
        }
    }
}
