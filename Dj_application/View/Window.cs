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
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            cb_nbrPiste.SelectedIndex = 0;
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            pageMix1.delete();
        }

        private void cb_nbrPiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageMix1.setNumberPist(int.Parse((string)cb_nbrPiste.SelectedItem));
        }
    }
}
