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


        }

        public void setNumberPist(int nbr)
        {
            nbrPisteCurrent = nbr;
            tableLayout.Controls.Clear();
            tableLayout.RowCount = 0;
            for (int i=0;i< nbr;i++)
            {
                tableLayout.RowCount++;
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

                // Ajouter la vue du lecteur audio à la nouvelle cellule du tableau
                tableLayout.Controls.Add(lecteurAudioViews[i], 0, tableLayout.RowCount - 1);
            }

            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel1.Controls.Add(tableLayout);
        }

        private void explorateur_musiqueSelected(object sender, Musique e)
        {
            for(int i = 0;i < nbrPisteCurrent;i++)
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
            foreach(LecteurAudioView lec in lecteurAudioViews)
            {
                lec.delete();
            }
            
            Dispose();
        }
    }

 
}
