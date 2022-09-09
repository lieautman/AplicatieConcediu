namespace AplicatieConcediu.Pagini_De_Start
{
    partial class Formular_Autentificare_2factori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formular_Autentificare_2factori));
            this.labelIntroducetiCodVerificare = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonValidareCod = new System.Windows.Forms.Button();
            this.buttonRetrimitere = new System.Windows.Forms.Button();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelEroareCod = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelIntroducetiCodVerificare
            // 
            this.labelIntroducetiCodVerificare.AutoSize = true;
            this.labelIntroducetiCodVerificare.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.labelIntroducetiCodVerificare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.labelIntroducetiCodVerificare.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelIntroducetiCodVerificare.Location = new System.Drawing.Point(289, 125);
            this.labelIntroducetiCodVerificare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIntroducetiCodVerificare.Name = "labelIntroducetiCodVerificare";
            this.labelIntroducetiCodVerificare.Size = new System.Drawing.Size(470, 24);
            this.labelIntroducetiCodVerificare.TabIndex = 0;
            this.labelIntroducetiCodVerificare.Text = "Introduceti codul de verificare trimis pe email:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(364, 234);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 22);
            this.textBox1.TabIndex = 1;
            // 
            // buttonValidareCod
            // 
            this.buttonValidareCod.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.buttonValidareCod.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonValidareCod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValidareCod.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.buttonValidareCod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonValidareCod.Location = new System.Drawing.Point(255, 340);
            this.buttonValidareCod.Margin = new System.Windows.Forms.Padding(4);
            this.buttonValidareCod.Name = "buttonValidareCod";
            this.buttonValidareCod.Size = new System.Drawing.Size(171, 41);
            this.buttonValidareCod.TabIndex = 2;
            this.buttonValidareCod.Text = "Validare cod";
            this.buttonValidareCod.UseVisualStyleBackColor = true;
            this.buttonValidareCod.Click += new System.EventHandler(this.buttonValidareCod_Click);
            // 
            // buttonRetrimitere
            // 
            this.buttonRetrimitere.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.buttonRetrimitere.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.buttonRetrimitere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRetrimitere.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.buttonRetrimitere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonRetrimitere.Location = new System.Drawing.Point(620, 340);
            this.buttonRetrimitere.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRetrimitere.Name = "buttonRetrimitere";
            this.buttonRetrimitere.Size = new System.Drawing.Size(171, 41);
            this.buttonRetrimitere.TabIndex = 3;
            this.buttonRetrimitere.Text = "Retrimitere";
            this.buttonRetrimitere.UseVisualStyleBackColor = true;
            this.buttonRetrimitere.Click += new System.EventHandler(this.buttonRetrimitere_Click);
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.buttonInapoi.FlatAppearance.BorderSize = 0;
            this.buttonInapoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInapoi.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInapoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.buttonInapoi.Location = new System.Drawing.Point(1011, 0);
            this.buttonInapoi.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(55, 59);
            this.buttonInapoi.TabIndex = 8;
            this.buttonInapoi.Text = "⮌";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelEroareCod
            // 
            this.labelEroareCod.AutoSize = true;
            this.labelEroareCod.Font = new System.Drawing.Font("Rockwell", 7.75F, System.Drawing.FontStyle.Bold);
            this.labelEroareCod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.labelEroareCod.Image = ((System.Drawing.Image)(resources.GetObject("labelEroareCod.Image")));
            this.labelEroareCod.Location = new System.Drawing.Point(318, 260);
            this.labelEroareCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEroareCod.Name = "labelEroareCod";
            this.labelEroareCod.Size = new System.Drawing.Size(108, 15);
            this.labelEroareCod.TabIndex = 36;
            this.labelEroareCod.Text = "labelEroareCod";
            // 
            // Formular_Autentificare_2factori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.labelEroareCod);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.buttonRetrimitere);
            this.Controls.Add(this.buttonValidareCod);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelIntroducetiCodVerificare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Formular_Autentificare_2factori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formular_Autentificare_2factori";
            this.Load += new System.EventHandler(this.Formular_Autentificare_2factori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIntroducetiCodVerificare;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonValidareCod;
        private System.Windows.Forms.Button buttonRetrimitere;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label labelEroareCod;
    }
}