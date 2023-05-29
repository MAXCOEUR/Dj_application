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

namespace Dj_application.View.Control
{
    public partial class ControlListAttante : UserControl
    {
        Musique musique;
        public event EventHandler<Musique> musiqueDelete;
        public event EventHandler<Musique> musiqueUp;
        public event EventHandler<Musique> musiqueDown;
        public ControlListAttante(Musique musique)
        {
            this.musique = musique;
            InitializeComponent();
            lb_titre.Text = musique.FileNameWithoutExtension;
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            musiqueDelete?.Invoke(this, musique);
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            musiqueDown?.Invoke(this, musique);
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            musiqueUp?.Invoke(this, musique);
        }
    }
}
