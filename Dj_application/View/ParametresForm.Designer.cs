namespace Dj_application.View
{
    partial class ParametresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label2 = new Label();
            lb_casqueSortie = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            cb_audioStandard = new ComboBox();
            bt_close = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            numericUpDown_timeClignotement = new NumericUpDown();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label4 = new Label();
            cb_BrowserYTMusic = new ComboBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label5 = new Label();
            numericUpDown_timelunchMusic = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timeClignotement).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timelunchMusic).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(bt_close, 0, 5);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 0, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel5, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(lb_casqueSortie);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 38);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(794, 15);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(218, 15);
            label2.TabIndex = 0;
            label2.Text = "sortie audio casque (sortie par default) : ";
            // 
            // lb_casqueSortie
            // 
            lb_casqueSortie.AutoSize = true;
            lb_casqueSortie.Location = new Point(227, 0);
            lb_casqueSortie.Name = "lb_casqueSortie";
            lb_casqueSortie.Size = new Size(96, 15);
            lb_casqueSortie.TabIndex = 1;
            lb_casqueSortie.Text = "sortie par default";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(cb_audioStandard);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(794, 29);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 0;
            label1.Text = "sortie audio standard : ";
            // 
            // cb_audioStandard
            // 
            cb_audioStandard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_audioStandard.FormattingEnabled = true;
            cb_audioStandard.Location = new Point(136, 3);
            cb_audioStandard.Name = "cb_audioStandard";
            cb_audioStandard.Size = new Size(374, 23);
            cb_audioStandard.TabIndex = 1;
            cb_audioStandard.SelectedIndexChanged += cb_audioStandard_SelectedIndexChanged;
            // 
            // bt_close
            // 
            bt_close.BackColor = Color.Lime;
            bt_close.Dock = DockStyle.Fill;
            bt_close.Location = new Point(3, 164);
            bt_close.Name = "bt_close";
            bt_close.Size = new Size(794, 44);
            bt_close.TabIndex = 3;
            bt_close.Text = "fermer";
            bt_close.UseVisualStyleBackColor = false;
            bt_close.Click += bt_close_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(numericUpDown_timeClignotement);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 59);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(794, 29);
            flowLayoutPanel3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(259, 15);
            label3.TabIndex = 0;
            label3.Text = "clignotement quand il reste moins de (seconde)";
            // 
            // numericUpDown_timeClignotement
            // 
            numericUpDown_timeClignotement.Location = new Point(268, 3);
            numericUpDown_timeClignotement.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown_timeClignotement.Name = "numericUpDown_timeClignotement";
            numericUpDown_timeClignotement.Size = new Size(120, 23);
            numericUpDown_timeClignotement.TabIndex = 1;
            numericUpDown_timeClignotement.ValueChanged += numericUpDown_timeClignotement_ValueChanged;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.Controls.Add(label4);
            flowLayoutPanel4.Controls.Add(cb_BrowserYTMusic);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(3, 129);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(794, 29);
            flowLayoutPanel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(254, 15);
            label4.TabIndex = 0;
            label4.Text = "choix navigateur ou connnecter youtubeMusic";
            // 
            // cb_BrowserYTMusic
            // 
            cb_BrowserYTMusic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cb_BrowserYTMusic.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_BrowserYTMusic.FormattingEnabled = true;
            cb_BrowserYTMusic.Items.AddRange(new object[] { "Edge", "Chrome", "FireFox" });
            cb_BrowserYTMusic.Location = new Point(263, 3);
            cb_BrowserYTMusic.Name = "cb_BrowserYTMusic";
            cb_BrowserYTMusic.Size = new Size(247, 23);
            cb_BrowserYTMusic.TabIndex = 1;
            cb_BrowserYTMusic.SelectedIndexChanged += cb_BrowserYTMusic_SelectedIndexChanged;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.AutoSize = true;
            flowLayoutPanel5.Controls.Add(label5);
            flowLayoutPanel5.Controls.Add(numericUpDown_timelunchMusic);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.Location = new Point(3, 94);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(794, 29);
            flowLayoutPanel5.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(277, 15);
            label5.TabIndex = 0;
            label5.Text = "temp avant lancement musique d'apres (seconde) :";
            // 
            // numericUpDown_timelunchMusic
            // 
            numericUpDown_timelunchMusic.Location = new Point(286, 3);
            numericUpDown_timelunchMusic.Name = "numericUpDown_timelunchMusic";
            numericUpDown_timelunchMusic.Size = new Size(120, 23);
            numericUpDown_timelunchMusic.TabIndex = 1;
            numericUpDown_timelunchMusic.ValueChanged += numericUpDown_timelunchMusic_ValueChanged;
            // 
            // ParametresForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "ParametresForm";
            Text = "ParametresForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timeClignotement).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timelunchMusic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox cb_audioStandard;
        private Button bt_close;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private NumericUpDown numericUpDown_timeClignotement;
        private Label lb_casqueSortie;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label4;
        private ComboBox cb_BrowserYTMusic;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label5;
        private NumericUpDown numericUpDown_timelunchMusic;
    }
}