namespace Dj_application.View.Control
{
    partial class PageMix
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            tb_mixPiste = new WinFormHeritage.CustomTrackBar();
            cb_piste1 = new WinFormHeritage.CustomComboBox();
            cb_piste2 = new WinFormHeritage.CustomComboBox();
            explorateur = new Explorateur();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_mixPiste).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(explorateur);
            splitContainer1.Size = new Size(760, 442);
            splitContainer1.SplitterDistance = 483;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tableLayoutPanel1);
            splitContainer2.Size = new Size(483, 442);
            splitContainer2.SplitterDistance = 35;
            splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.1935482F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 51.6129036F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.1935482F));
            tableLayoutPanel1.Controls.Add(tb_mixPiste, 1, 0);
            tableLayoutPanel1.Controls.Add(cb_piste1, 0, 0);
            tableLayoutPanel1.Controls.Add(cb_piste2, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(483, 35);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tb_mixPiste
            // 
            tb_mixPiste.Dock = DockStyle.Fill;
            tb_mixPiste.Location = new Point(119, 3);
            tb_mixPiste.Maximum = 100;
            tb_mixPiste.Minimum = -100;
            tb_mixPiste.Name = "tb_mixPiste";
            tb_mixPiste.Size = new Size(243, 29);
            tb_mixPiste.TabIndex = 2;
            tb_mixPiste.TickStyle = TickStyle.None;
            tb_mixPiste.ValueChanged += tb_mixPiste_ValueChanged;
            // 
            // cb_piste1
            // 
            cb_piste1.Dock = DockStyle.Fill;
            cb_piste1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_piste1.FormattingEnabled = true;
            cb_piste1.Location = new Point(0, 0);
            cb_piste1.Margin = new Padding(0);
            cb_piste1.Name = "cb_piste1";
            cb_piste1.Size = new Size(116, 23);
            cb_piste1.TabIndex = 3;
            cb_piste1.SelectedIndexChanged += cb_piste1_SelectedIndexChanged;
            // 
            // cb_piste2
            // 
            cb_piste2.Dock = DockStyle.Fill;
            cb_piste2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_piste2.FormattingEnabled = true;
            cb_piste2.Location = new Point(365, 0);
            cb_piste2.Margin = new Padding(0);
            cb_piste2.Name = "cb_piste2";
            cb_piste2.Size = new Size(118, 23);
            cb_piste2.TabIndex = 4;
            cb_piste2.SelectedIndexChanged += cb_piste2_SelectedIndexChanged;
            // 
            // explorateur
            // 
            explorateur.BackColor = Color.FromArgb(28, 28, 28);
            explorateur.Dock = DockStyle.Fill;
            explorateur.ForeColor = Color.White;
            explorateur.Location = new Point(0, 0);
            explorateur.Name = "explorateur";
            explorateur.Size = new Size(273, 442);
            explorateur.TabIndex = 0;
            // 
            // PageMix
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "PageMix";
            Size = new Size(760, 442);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_mixPiste).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Explorateur explorateur;
        private SplitContainer splitContainer2;
        private TableLayoutPanel tableLayoutPanel1;
        private WinFormHeritage.CustomTrackBar tb_mixPiste;
        private WinFormHeritage.CustomComboBox cb_piste1;
        private WinFormHeritage.CustomComboBox cb_piste2;
    }
}
