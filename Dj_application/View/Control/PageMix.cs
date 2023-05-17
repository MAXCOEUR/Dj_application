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
    public partial class PageMix : UserControl
    {
        List<LecteurAudioView> lecteurAudioViews = new List<LecteurAudioView>();
        TableLayoutPanel tableLayout = new TableLayoutPanel();
        private const int maxPiste = 6;
        private int nbrPisteCurrent = 0;

        LecteurAudioView piste1;
        LecteurAudioView piste2;
        int indexPiste1 = 0;
        int indexPiste2 = 0;

        public PageMix()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            tableLayout.Dock = DockStyle.Fill;
            tableLayout.ColumnCount = 1;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            explorateur.musiqueSelected += explorateur_musiqueSelected;

            for (int i = 0; i < maxPiste; i++)
            {
                LecteurAudioView view = new LecteurAudioView();
                view.Dock = DockStyle.Fill;
                lecteurAudioViews.Add(view);
            }
            splitContainer2.Panel2.Controls.Add(tableLayout);

        }

        public void setNumberPist(int nbr)
        {
            nbrPisteCurrent = nbr;
            tableLayout.Controls.Clear();
            tableLayout.RowCount = 0;
            cb_piste1.Items.Clear();
            cb_piste2.Items.Clear();
            cb_piste1.Items.Add("");
            cb_piste2.Items.Add("");
            for (int i = 0; i < nbr; i++)
            {
                tableLayout.RowCount++;
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                // Ajouter la vue du lecteur audio à la nouvelle cellule du tableau
                tableLayout.Controls.Add(lecteurAudioViews[i], 0, tableLayout.RowCount - 1);
                cb_piste1.Items.Add(i + 1);
                cb_piste2.Items.Add(i + 1);
            }
            cb_piste1.SelectedIndex = indexPiste1;
            cb_piste2.SelectedIndex = indexPiste2;
        }

        private void explorateur_musiqueSelected(object sender, Musique e)
        {
            for (int i = 0; i < nbrPisteCurrent; i++)
            {
                if (!lecteurAudioViews[i].isPlaying())
                {
                    lecteurAudioViews[i].setAudio(e);
                    break;
                }
            }
        }

        public void delete()
        {
            foreach (LecteurAudioView lec in lecteurAudioViews)
            {
                lec.delete();
            }

            Dispose();
        }

        private void tb_mixPiste_ValueChanged(object sender, EventArgs e)
        {
            int valeur = tb_mixPiste.Value;
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
                piste1.setvolume(valeur1);
            }
            if (piste2 != null)
            {
                piste2.setvolume(valeur2);
            }

        }

        private void cb_piste1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valeur = cb_piste1.SelectedItem;
            if (piste1 != null)
            {
                piste1.setvolume(100);
            }
            if (valeur == "")
            {
                indexPiste1 = 0;
                piste1 = null;
            }
            else
            {
                indexPiste1 = cb_piste1.SelectedIndex;
                piste1 = lecteurAudioViews[cb_piste1.SelectedIndex - 1];
            }
            tb_mixPiste_ValueChanged(this, new EventArgs());
        }

        private void cb_piste2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valeur = cb_piste2.SelectedItem;

            if (piste2 != null)
            {
                piste2.setvolume(100);
            }
            if (valeur == "")
            {
                indexPiste2 = 0;
                piste2 = null;
            }
            else
            {
                indexPiste2 = cb_piste2.SelectedIndex;
                piste2 = lecteurAudioViews[cb_piste2.SelectedIndex - 1];
            }
            tb_mixPiste_ValueChanged(this, new EventArgs());
        }
    }


}
