using Dj_application.model;
using Dj_application.View.Control;
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
    public partial class ListeAttente : Form
    {
        List<Musique> musiques;

        public ListeAttente(List<Musique> musiques)
        {
            this.musiques = musiques;
            InitializeComponent();

            update();

        }

        public new DialogResult ShowDialog()
        {
            update();
            return base.ShowDialog();
        }

        public void update()
        {
            dlp_table.Controls.Clear();
            foreach (Musique m in musiques)
            {
                ControlListAttante li = new ControlListAttante(m);
                li.Size = new Size(ClientRectangle.Width, li.Size.Height);
                li.musiqueDelete += ControlListAttante_musiqueDelete;
                li.musiqueDown += ControlListAttante_musiqueDown;
                li.musiqueUp += ControlListAttante_musiqueUp;

                dlp_table.Controls.Add(li);
            }
        }

        public void ControlListAttante_musiqueDelete(object sender, Musique musique)
        {
            musiques.Remove(musique);
            update();
        }
        public void ControlListAttante_musiqueDown(object sender, Musique musique)
        {
            int index = musiques.IndexOf(musique);
            if (index < musiques.Count - 1)
            {
                musiques.RemoveAt(index);
                musiques.Insert(index + 1, musique);
                update(); // Mettre à jour l'affichage après le déplacement
            }
        }

        public void ControlListAttante_musiqueUp(object sender, Musique musique)
        {
            int index = musiques.IndexOf(musique);
            if (index > 0)
            {
                musiques.RemoveAt(index);
                musiques.Insert(index - 1, musique);
                update(); // Mettre à jour l'affichage après le déplacement
            }
        }

    }
}
