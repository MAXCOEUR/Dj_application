using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.model
{
    public class PalettesCouleur
    {
        public Color Principal { get; }
        public Color Accentuation { get; }
        public Color Mise_Evidence { get; }
        public Color Texte { get; }
        public Color Fond { get; }

        public PalettesCouleur(bool isDark=true)
        {
            if (isDark)
            {
                Principal = Color.FromArgb(18, 18, 18);
                Accentuation = Color.FromArgb(255, 64, 129);
                Mise_Evidence = Color.FromArgb(74, 144, 226);
                Texte = Color.White;
                Fond = Color.FromArgb(28, 28, 28);
            }
            else
            {
                Principal = Color.White;
                Accentuation = Color.FromArgb(255, 64, 129);
                Mise_Evidence = Color.FromArgb(74, 144, 226);
                Texte = Color.FromArgb(18, 18, 18);
                Fond = Color.FromArgb(245, 245, 245);
            }
        }
    }

}
