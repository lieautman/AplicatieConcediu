namespace AplicatieConcediu
{
    partial class Pagina_start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagina_start));
            this.buttonInregistrare = new System.Windows.Forms.Button();
            this.buttonAutentificare = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonInchidere = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInregistrare
            // 
            this.buttonInregistrare.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonInregistrare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInregistrare.BackgroundImage")));
            this.buttonInregistrare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonInregistrare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInregistrare.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInregistrare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonInregistrare.Location = new System.Drawing.Point(532, 437);
            this.buttonInregistrare.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInregistrare.Name = "buttonInregistrare";
            this.buttonInregistrare.Size = new System.Drawing.Size(168, 57);
            this.buttonInregistrare.TabIndex = 0;
            this.buttonInregistrare.Text = "Inregistrare";
            this.buttonInregistrare.UseVisualStyleBackColor = false;
            this.buttonInregistrare.Click += new System.EventHandler(this.buttonInregistrare_Click);
            // 
            // buttonAutentificare
            // 
            this.buttonAutentificare.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAutentificare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAutentificare.BackgroundImage")));
            this.buttonAutentificare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonAutentificare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutentificare.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAutentificare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonAutentificare.Location = new System.Drawing.Point(287, 436);
            this.buttonAutentificare.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutentificare.Name = "buttonAutentificare";
            this.buttonAutentificare.Size = new System.Drawing.Size(171, 58);
            this.buttonAutentificare.TabIndex = 1;
            this.buttonAutentificare.Text = "Autentificare";
            this.buttonAutentificare.UseVisualStyleBackColor = false;
            this.buttonAutentificare.Click += new System.EventHandler(this.buttonAutentificare_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.BackgroundImage")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(287, 15);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(413, 386);
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonInchidere
            // 
            this.buttonInchidere.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonInchidere.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonInchidere.BackgroundImage")));
            this.buttonInchidere.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonInchidere.FlatAppearance.BorderSize = 0;
            this.buttonInchidere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInchidere.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInchidere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonInchidere.Location = new System.Drawing.Point(988, 4);
            this.buttonInchidere.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInchidere.Name = "buttonInchidere";
            this.buttonInchidere.Size = new System.Drawing.Size(76, 48);
            this.buttonInchidere.TabIndex = 3;
            this.buttonInchidere.Text = "X";
            this.buttonInchidere.UseVisualStyleBackColor = false;
            this.buttonInchidere.Click += new System.EventHandler(this.buttonInchidere_Click);
            // 
            // Pagina_start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonInchidere);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonAutentificare);
            this.Controls.Add(this.buttonInregistrare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pagina_start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagina_start";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInregistrare;
        private System.Windows.Forms.Button buttonAutentificare;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonInchidere;
    }
}