namespace AplicatieConcediu
{
    partial class Formular_Autentificare
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formular_Autentificare));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.buttonAutentificare = new System.Windows.Forms.Button();
            this.labelNume = new System.Windows.Forms.Label();
            this.labelParola = new System.Windows.Forms.Label();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.labelEroareEmail = new System.Windows.Forms.Label();
            this.labelEroareParola = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(400, 98);
            this.textBoxNume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(227, 22);
            this.textBoxNume.TabIndex = 2;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Location = new System.Drawing.Point(400, 148);
            this.textBoxParola.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.Size = new System.Drawing.Size(227, 22);
            this.textBoxParola.TabIndex = 3;
            this.textBoxParola.UseSystemPasswordChar = true;
            // 
            // buttonAutentificare
            // 
            this.buttonAutentificare.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.buttonAutentificare.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonAutentificare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutentificare.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAutentificare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonAutentificare.Location = new System.Drawing.Point(319, 290);
            this.buttonAutentificare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAutentificare.Name = "buttonAutentificare";
            this.buttonAutentificare.Size = new System.Drawing.Size(171, 41);
            this.buttonAutentificare.TabIndex = 4;
            this.buttonAutentificare.Text = "Autentificare";
            this.buttonAutentificare.UseVisualStyleBackColor = true;
            this.buttonAutentificare.Click += new System.EventHandler(this.buttonAutentificare_Click);
            // 
            // labelNume
            // 
            this.labelNume.AutoSize = true;
            this.labelNume.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelNume.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.labelNume.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelNume.Location = new System.Drawing.Point(180, 98);
            this.labelNume.Name = "labelNume";
            this.labelNume.Size = new System.Drawing.Size(172, 24);
            this.labelNume.TabIndex = 5;
            this.labelNume.Text = "Nume utilizator:";
            // 
            // labelParola
            // 
            this.labelParola.AutoSize = true;
            this.labelParola.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.labelParola.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelParola.Location = new System.Drawing.Point(271, 148);
            this.labelParola.Name = "labelParola";
            this.labelParola.Size = new System.Drawing.Size(81, 24);
            this.labelParola.TabIndex = 6;
            this.labelParola.Text = "Parola:";
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.buttonInapoi.FlatAppearance.BorderSize = 0;
            this.buttonInapoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInapoi.Font = new System.Drawing.Font("Rockwell", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInapoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonInapoi.Location = new System.Drawing.Point(745, 0);
            this.buttonInapoi.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(55, 59);
            this.buttonInapoi.TabIndex = 7;
            this.buttonInapoi.Text = "⮌";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInchidere_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // labelEroareEmail
            // 
            this.labelEroareEmail.AutoSize = true;
            this.labelEroareEmail.Font = new System.Drawing.Font("Rockwell", 7.75F, System.Drawing.FontStyle.Bold);
            this.labelEroareEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.labelEroareEmail.Image = ((System.Drawing.Image)(resources.GetObject("labelEroareEmail.Image")));
            this.labelEroareEmail.Location = new System.Drawing.Point(181, 122);
            this.labelEroareEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEroareEmail.Name = "labelEroareEmail";
            this.labelEroareEmail.Size = new System.Drawing.Size(123, 15);
            this.labelEroareEmail.TabIndex = 34;
            this.labelEroareEmail.Text = "labelEroareEmail";
            // 
            // labelEroareParola
            // 
            this.labelEroareParola.AutoSize = true;
            this.labelEroareParola.Font = new System.Drawing.Font("Rockwell", 7.75F, System.Drawing.FontStyle.Bold);
            this.labelEroareParola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.labelEroareParola.Image = ((System.Drawing.Image)(resources.GetObject("labelEroareParola.Image")));
            this.labelEroareParola.Location = new System.Drawing.Point(272, 172);
            this.labelEroareParola.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEroareParola.Name = "labelEroareParola";
            this.labelEroareParola.Size = new System.Drawing.Size(126, 15);
            this.labelEroareParola.TabIndex = 35;
            this.labelEroareParola.Text = "labelEroareParola";
            // 
            // Formular_Autentificare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelEroareParola);
            this.Controls.Add(this.labelEroareEmail);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.labelParola);
            this.Controls.Add(this.labelNume);
            this.Controls.Add(this.buttonAutentificare);
            this.Controls.Add(this.textBoxParola);
            this.Controls.Add(this.textBoxNume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formular_Autentificare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificare";
            this.Load += new System.EventHandler(this.Formular_Autentificare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Button buttonAutentificare;
        private System.Windows.Forms.Label labelNume;
        private System.Windows.Forms.Label labelParola;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label labelEroareParola;
        private System.Windows.Forms.Label labelEroareEmail;
    }
}