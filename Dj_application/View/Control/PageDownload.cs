﻿using Dj_application.Outil;
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

namespace Dj_application.View.Control
{
    public partial class PageDownload : UserControl
    {
        public PageDownload()
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();

            LecteurMusiqueOnline lecteur = new LecteurMusiqueOnline(new model.MusiqueOnline("https://www.youtube.com/watch?v=GkdJNTt4H5E"));
            splitContainer1.Panel1.Controls.Add(lecteur);
        }


        private void bt_dowload_Click(object sender, EventArgs e)
        {

        }
    }
}
