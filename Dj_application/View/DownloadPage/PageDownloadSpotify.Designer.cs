namespace Dj_application.View.DownloadPage
{
    partial class PageDownloadSpotify
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            bt_back = new Button();
            splitContainer1 = new SplitContainer();
            wv_spotify = new Microsoft.Web.WebView2.WinForms.WebView2();
            bt_mute = new Button();
            tb_url = new TextBox();
            bt_dowload = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wv_spotify).BeginInit();
            SuspendLayout();
            // 
            // bt_back
            // 
            bt_back.BackgroundImage = Resource.retour;
            bt_back.BackgroundImageLayout = ImageLayout.Zoom;
            bt_back.Location = new Point(3, 3);
            bt_back.Name = "bt_back";
            bt_back.Size = new Size(94, 23);
            bt_back.TabIndex = 2;
            bt_back.UseVisualStyleBackColor = true;
            bt_back.Click += bt_back_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(wv_spotify);
            splitContainer1.Panel1.Controls.Add(bt_mute);
            splitContainer1.Panel1.Controls.Add(bt_back);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tb_url);
            splitContainer1.Panel2.Controls.Add(bt_dowload);
            splitContainer1.Size = new Size(920, 536);
            splitContainer1.SplitterDistance = 639;
            splitContainer1.TabIndex = 0;
            // 
            // wv_spotify
            // 
            wv_spotify.AllowExternalDrop = true;
            wv_spotify.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wv_spotify.CreationProperties = null;
            wv_spotify.DefaultBackgroundColor = Color.White;
            wv_spotify.Location = new Point(0, 29);
            wv_spotify.Name = "wv_spotify";
            wv_spotify.Size = new Size(636, 507);
            wv_spotify.TabIndex = 5;
            wv_spotify.ZoomFactor = 1D;
            // 
            // bt_mute
            // 
            bt_mute.BackColor = Color.Green;
            bt_mute.BackgroundImage = Resource.volume;
            bt_mute.BackgroundImageLayout = ImageLayout.Zoom;
            bt_mute.Location = new Point(103, 3);
            bt_mute.Name = "bt_mute";
            bt_mute.Size = new Size(94, 23);
            bt_mute.TabIndex = 4;
            bt_mute.UseVisualStyleBackColor = false;
            bt_mute.Click += bt_mute_Click;
            // 
            // tb_url
            // 
            tb_url.Dock = DockStyle.Top;
            tb_url.Location = new Point(0, 0);
            tb_url.Name = "tb_url";
            tb_url.Size = new Size(277, 23);
            tb_url.TabIndex = 1;
            tb_url.Text = "url musique ou playlist";
            tb_url.MouseClick += tb_url_MouseClick;
            // 
            // bt_dowload
            // 
            bt_dowload.BackColor = Color.Lime;
            bt_dowload.BackgroundImage = Resource.telecharger;
            bt_dowload.BackgroundImageLayout = ImageLayout.Zoom;
            bt_dowload.Dock = DockStyle.Fill;
            bt_dowload.Location = new Point(0, 0);
            bt_dowload.Margin = new Padding(50);
            bt_dowload.Name = "bt_dowload";
            bt_dowload.Padding = new Padding(5);
            bt_dowload.Size = new Size(277, 536);
            bt_dowload.TabIndex = 0;
            bt_dowload.UseVisualStyleBackColor = false;
            bt_dowload.Click += bt_dowload_Click;
            // 
            // PageDownloadSpotify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PageDownloadSpotify";
            Size = new Size(920, 536);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wv_spotify).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button bt_dowload;
        private TextBox tb_url;
        private Button bt_mute;
        private Button bt_back;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv_spotify;
    }
}
