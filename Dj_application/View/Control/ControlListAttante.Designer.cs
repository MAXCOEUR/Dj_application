namespace Dj_application.View.Control
{
    partial class ControlListAttante
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
            lb_titre = new Label();
            bt_remove = new Button();
            bt_up = new Button();
            bt_down = new Button();
            SuspendLayout();
            // 
            // lb_titre
            // 
            lb_titre.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lb_titre.Location = new Point(3, 27);
            lb_titre.Name = "lb_titre";
            lb_titre.Size = new Size(171, 19);
            lb_titre.TabIndex = 0;
            lb_titre.Text = "label1";
            // 
            // bt_remove
            // 
            bt_remove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_remove.BackgroundImage = Resource.supprimer;
            bt_remove.BackgroundImageLayout = ImageLayout.Zoom;
            bt_remove.Location = new Point(342, 23);
            bt_remove.Name = "bt_remove";
            bt_remove.Size = new Size(75, 23);
            bt_remove.TabIndex = 1;
            bt_remove.UseVisualStyleBackColor = true;
            bt_remove.Click += bt_remove_Click;
            // 
            // bt_up
            // 
            bt_up.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_up.BackgroundImage = Resource.up;
            bt_up.BackgroundImageLayout = ImageLayout.Zoom;
            bt_up.Location = new Point(180, 23);
            bt_up.Name = "bt_up";
            bt_up.Size = new Size(75, 23);
            bt_up.TabIndex = 2;
            bt_up.UseVisualStyleBackColor = true;
            bt_up.Click += bt_up_Click;
            // 
            // bt_down
            // 
            bt_down.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bt_down.BackgroundImage = Resource.down;
            bt_down.BackgroundImageLayout = ImageLayout.Zoom;
            bt_down.Location = new Point(261, 23);
            bt_down.Name = "bt_down";
            bt_down.Size = new Size(75, 23);
            bt_down.TabIndex = 3;
            bt_down.UseVisualStyleBackColor = true;
            bt_down.Click += bt_down_Click;
            // 
            // ControlListAttante
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bt_down);
            Controls.Add(bt_up);
            Controls.Add(bt_remove);
            Controls.Add(lb_titre);
            Name = "ControlListAttante";
            Size = new Size(420, 69);
            ResumeLayout(false);
        }

        #endregion

        private Label lb_titre;
        private Button bt_remove;
        private Button bt_up;
        private Button bt_down;
    }
}
