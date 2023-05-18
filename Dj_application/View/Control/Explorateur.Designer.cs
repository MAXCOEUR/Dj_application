namespace Dj_application.View.Control
{
    partial class Explorateur
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
            dgv_listMusique = new DataGridView();
            treev_arbreFolder = new TreeView();
            spCon_explorateur = new SplitContainer();
            panel2 = new Panel();
            panel1 = new Panel();
            bt_source = new Button();
            splitContainer1 = new SplitContainer();
            bt_download = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listMusique).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spCon_explorateur).BeginInit();
            spCon_explorateur.Panel1.SuspendLayout();
            spCon_explorateur.Panel2.SuspendLayout();
            spCon_explorateur.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv_listMusique
            // 
            dgv_listMusique.AllowUserToAddRows = false;
            dgv_listMusique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listMusique.Dock = DockStyle.Fill;
            dgv_listMusique.Location = new Point(0, 0);
            dgv_listMusique.MinimumSize = new Size(100, 0);
            dgv_listMusique.Name = "dgv_listMusique";
            dgv_listMusique.RowTemplate.Height = 25;
            dgv_listMusique.Size = new Size(682, 492);
            dgv_listMusique.TabIndex = 1;
            dgv_listMusique.CellDoubleClick += dgv_listMusique_CellDoubleClick_1;
            dgv_listMusique.KeyDown += dgv_listMusique_KeyDown;
            // 
            // treev_arbreFolder
            // 
            treev_arbreFolder.Dock = DockStyle.Fill;
            treev_arbreFolder.Location = new Point(0, 0);
            treev_arbreFolder.Name = "treev_arbreFolder";
            treev_arbreFolder.Size = new Size(209, 442);
            treev_arbreFolder.TabIndex = 2;
            treev_arbreFolder.AfterSelect += treev_arbreFolder_AfterSelect;
            // 
            // spCon_explorateur
            // 
            spCon_explorateur.Dock = DockStyle.Fill;
            spCon_explorateur.Location = new Point(0, 0);
            spCon_explorateur.Name = "spCon_explorateur";
            // 
            // spCon_explorateur.Panel1
            // 
            spCon_explorateur.Panel1.Controls.Add(panel2);
            spCon_explorateur.Panel1.Controls.Add(panel1);
            spCon_explorateur.Panel1MinSize = 150;
            // 
            // spCon_explorateur.Panel2
            // 
            spCon_explorateur.Panel2.Controls.Add(dgv_listMusique);
            spCon_explorateur.Panel2MinSize = 150;
            spCon_explorateur.Size = new Size(895, 492);
            spCon_explorateur.SplitterDistance = 209;
            spCon_explorateur.TabIndex = 3;
            spCon_explorateur.SizeChanged += splitContainer1_SizeChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(treev_arbreFolder);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(209, 442);
            panel2.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(209, 50);
            panel1.TabIndex = 3;
            // 
            // bt_source
            // 
            bt_source.BackColor = Color.Lime;
            bt_source.Dock = DockStyle.Fill;
            bt_source.Location = new Point(0, 0);
            bt_source.Name = "bt_source";
            bt_source.Size = new Size(102, 50);
            bt_source.TabIndex = 2;
            bt_source.Text = "Source";
            bt_source.UseVisualStyleBackColor = false;
            bt_source.Click += bt_source_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bt_source);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(bt_download);
            splitContainer1.Size = new Size(209, 50);
            splitContainer1.SplitterDistance = 102;
            splitContainer1.TabIndex = 3;
            // 
            // bt_download
            // 
            bt_download.Dock = DockStyle.Fill;
            bt_download.Location = new Point(0, 0);
            bt_download.Name = "bt_download";
            bt_download.Size = new Size(103, 50);
            bt_download.TabIndex = 0;
            bt_download.Text = "telechargement";
            bt_download.UseVisualStyleBackColor = true;
            bt_download.Click += bt_download_Click;
            // 
            // Explorateur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(spCon_explorateur);
            Name = "Explorateur";
            Size = new Size(895, 492);
            ((System.ComponentModel.ISupportInitialize)dgv_listMusique).EndInit();
            spCon_explorateur.Panel1.ResumeLayout(false);
            spCon_explorateur.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spCon_explorateur).EndInit();
            spCon_explorateur.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgv_listMusique;
        private TreeView treev_arbreFolder;
        private SplitContainer spCon_explorateur;
        private Button bt_source;
        private Panel panel2;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private Button bt_download;
    }
}
