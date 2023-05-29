namespace Dj_application.View
{
    partial class ListeAttente
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
            dlp_table = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // dlp_table
            // 
            dlp_table.AutoScroll = true;
            dlp_table.Dock = DockStyle.Fill;
            dlp_table.Location = new Point(0, 0);
            dlp_table.Name = "dlp_table";
            dlp_table.Size = new Size(800, 450);
            dlp_table.TabIndex = 0;
            // 
            // ListeAttente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dlp_table);
            Name = "ListeAttente";
            Text = "ListeAttente";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel dlp_table;
    }
}