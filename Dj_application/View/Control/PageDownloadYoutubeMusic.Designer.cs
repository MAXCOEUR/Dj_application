namespace Dj_application.View.Control
{
    partial class PageDownloadYoutubeMusic
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
            Button bt_back;
            splitContainer1 = new SplitContainer();
            wv_youtube = new Microsoft.Web.WebView2.WinForms.WebView2();
            tb_url = new TextBox();
            bt_dowload = new Button();
            bt_back = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wv_youtube).BeginInit();
            SuspendLayout();
            // 
            // bt_back
            // 
            bt_back.Location = new Point(3, 3);
            bt_back.Name = "bt_back";
            bt_back.Size = new Size(75, 23);
            bt_back.TabIndex = 2;
            bt_back.Text = "retour";
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
            splitContainer1.Panel1.Controls.Add(bt_back);
            splitContainer1.Panel1.Controls.Add(wv_youtube);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tb_url);
            splitContainer1.Panel2.Controls.Add(bt_dowload);
            splitContainer1.Size = new Size(920, 536);
            splitContainer1.SplitterDistance = 639;
            splitContainer1.TabIndex = 0;
            // 
            // wv_youtube
            // 
            wv_youtube.AllowExternalDrop = true;
            wv_youtube.CreationProperties = null;
            wv_youtube.DefaultBackgroundColor = Color.White;
            wv_youtube.Dock = DockStyle.Fill;
            wv_youtube.Location = new Point(0, 0);
            wv_youtube.Name = "wv_youtube";
            wv_youtube.Size = new Size(639, 536);
            wv_youtube.TabIndex = 0;
            wv_youtube.ZoomFactor = 1D;
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
            bt_dowload.Dock = DockStyle.Fill;
            bt_dowload.Location = new Point(0, 0);
            bt_dowload.Margin = new Padding(50);
            bt_dowload.Name = "bt_dowload";
            bt_dowload.Padding = new Padding(5);
            bt_dowload.Size = new Size(277, 536);
            bt_dowload.TabIndex = 0;
            bt_dowload.Text = "Download";
            bt_dowload.UseVisualStyleBackColor = false;
            bt_dowload.Click += bt_dowload_Click;
            // 
            // PageDownload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PageDownload";
            Size = new Size(920, 536);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wv_youtube).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button bt_dowload;
        private Microsoft.Web.WebView2.WinForms.WebView2 wv_youtube;
        private TextBox tb_url;
    }
}
