using System;

namespace AplicatieConcediu.Pagini_Actiuni
{
    partial class Adaugare_Angajat_Nou
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adaugare_Angajat_Nou));
            this.button1 = new System.Windows.Forms.Button();
            this.Salariu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DataNastere = new System.Windows.Forms.DateTimePicker();
            this.SeriaNumarCI = new System.Windows.Forms.TextBox();
            this.Cnp = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Prenume = new System.Windows.Forms.TextBox();
            this.Nume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DataAngajarii = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Parola = new System.Windows.Forms.TextBox();
            this.btn_Adauga = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cbEchipe = new System.Windows.Forms.ComboBox();
            this.cbManageri = new System.Windows.Forms.ComboBox();
            this.NumarTelefon = new System.Windows.Forms.TextBox();
            this.labelEroareNume = new System.Windows.Forms.Label();
            this.labelEroarePrenume = new System.Windows.Forms.Label();
            this.labelEroareDataNastere = new System.Windows.Forms.Label();
            this.labelEroareEmail = new System.Windows.Forms.Label();
            this.labelEroareCnp = new System.Windows.Forms.Label();
            this.labelEroareSerieNumarCI = new System.Windows.Forms.Label();
            this.labelEroareNumarTelefon = new System.Windows.Forms.Label();
            this.labelDataAngajarii = new System.Windows.Forms.Label();
            this.labelEroareSalariu = new System.Windows.Forms.Label();
            this.labelEroareParola = new System.Windows.Forms.Label();
            this.EroareAdaugare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1026, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "⮌";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Salariu
            // 
            this.Salariu.Location = new System.Drawing.Point(756, 143);
            this.Salariu.Margin = new System.Windows.Forms.Padding(4);
            this.Salariu.MaxLength = 10;
            this.Salariu.Name = "Salariu";
            this.Salariu.Size = new System.Drawing.Size(129, 22);
            this.Salariu.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(13, 311);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 20);
            this.label9.TabIndex = 51;
            this.label9.Text = "Serie si numar CI:";
            // 
            // DataNastere
            // 
            this.DataNastere.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataNastere.Location = new System.Drawing.Point(216, 140);
            this.DataNastere.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataNastere.Name = "DataNastere";
            this.DataNastere.Size = new System.Drawing.Size(124, 22);
            this.DataNastere.TabIndex = 50;
            // 
            // SeriaNumarCI
            // 
            this.SeriaNumarCI.Location = new System.Drawing.Point(216, 310);
            this.SeriaNumarCI.Margin = new System.Windows.Forms.Padding(4);
            this.SeriaNumarCI.MaxLength = 6;
            this.SeriaNumarCI.Name = "SeriaNumarCI";
            this.SeriaNumarCI.Size = new System.Drawing.Size(123, 22);
            this.SeriaNumarCI.TabIndex = 47;
            // 
            // Cnp
            // 
            this.Cnp.Location = new System.Drawing.Point(216, 257);
            this.Cnp.Margin = new System.Windows.Forms.Padding(4);
            this.Cnp.MaxLength = 13;
            this.Cnp.Name = "Cnp";
            this.Cnp.Size = new System.Drawing.Size(123, 22);
            this.Cnp.TabIndex = 46;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(216, 195);
            this.Email.Margin = new System.Windows.Forms.Padding(4);
            this.Email.MaxLength = 30;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(123, 22);
            this.Email.TabIndex = 45;
            // 
            // Prenume
            // 
            this.Prenume.Location = new System.Drawing.Point(216, 84);
            this.Prenume.Margin = new System.Windows.Forms.Padding(4);
            this.Prenume.MaxLength = 50;
            this.Prenume.Name = "Prenume";
            this.Prenume.Size = new System.Drawing.Size(124, 22);
            this.Prenume.TabIndex = 44;
            // 
            // Nume
            // 
            this.Nume.Location = new System.Drawing.Point(216, 32);
            this.Nume.Margin = new System.Windows.Forms.Padding(4);
            this.Nume.MaxLength = 100;
            this.Nume.Name = "Nume";
            this.Nume.Size = new System.Drawing.Size(123, 22);
            this.Nume.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(20, 261);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "CNP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(528, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Parola:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(520, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Numar de telefon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(20, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(21, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Data nastere:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(20, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Prenume:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Nume:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(531, 32);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 20);
            this.label7.TabIndex = 60;
            this.label7.Text = "Data Angajarii :";
            // 
            // DataAngajarii
            // 
            this.DataAngajarii.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataAngajarii.Location = new System.Drawing.Point(756, 32);
            this.DataAngajarii.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataAngajarii.Name = "DataAngajarii";
            this.DataAngajarii.Size = new System.Drawing.Size(129, 22);
            this.DataAngajarii.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(531, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 63;
            this.label11.Text = "Salariu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(531, 82);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 64;
            this.label10.Text = "Manager:";
            // 
            // Parola
            // 
            this.Parola.Location = new System.Drawing.Point(756, 259);
            this.Parola.Margin = new System.Windows.Forms.Padding(4);
            this.Parola.MaxLength = 50;
            this.Parola.Name = "Parola";
            this.Parola.Size = new System.Drawing.Size(129, 22);
            this.Parola.TabIndex = 67;
            this.Parola.UseSystemPasswordChar = true;
            // 
            // btn_Adauga
            // 
            this.btn_Adauga.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.btn_Adauga.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.btn_Adauga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Adauga.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Adauga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.btn_Adauga.Location = new System.Drawing.Point(422, 418);
            this.btn_Adauga.Name = "btn_Adauga";
            this.btn_Adauga.Size = new System.Drawing.Size(195, 64);
            this.btn_Adauga.TabIndex = 68;
            this.btn_Adauga.Text = "Adauga Angajat";
            this.btn_Adauga.UseVisualStyleBackColor = true;
            this.btn_Adauga.Click += new System.EventHandler(this.btn_Adauga_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.Location = new System.Drawing.Point(524, 310);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 20);
            this.label13.TabIndex = 69;
            this.label13.Text = "Echipa:";
            // 
            // cbEchipe
            // 
            this.cbEchipe.FormattingEnabled = true;
            this.cbEchipe.Location = new System.Drawing.Point(756, 311);
            this.cbEchipe.Name = "cbEchipe";
            this.cbEchipe.Size = new System.Drawing.Size(129, 24);
            this.cbEchipe.TabIndex = 70;
            // 
            // cbManageri
            // 
            this.cbManageri.FormattingEnabled = true;
            this.cbManageri.Location = new System.Drawing.Point(756, 82);
            this.cbManageri.Name = "cbManageri";
            this.cbManageri.Size = new System.Drawing.Size(129, 24);
            this.cbManageri.TabIndex = 71;
            // 
            // NumarTelefon
            // 
            this.NumarTelefon.Location = new System.Drawing.Point(756, 194);
            this.NumarTelefon.MaxLength = 20;
            this.NumarTelefon.Name = "NumarTelefon";
            this.NumarTelefon.Size = new System.Drawing.Size(129, 22);
            this.NumarTelefon.TabIndex = 73;
            // 
            // labelEroareNume
            // 
            this.labelEroareNume.AutoSize = true;
            this.labelEroareNume.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareNume.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareNume.Location = new System.Drawing.Point(27, 52);
            this.labelEroareNume.Name = "labelEroareNume";
            this.labelEroareNume.Size = new System.Drawing.Size(121, 15);
            this.labelEroareNume.TabIndex = 74;
            this.labelEroareNume.Text = "labelEroareNume";
            // 
            // labelEroarePrenume
            // 
            this.labelEroarePrenume.AutoSize = true;
            this.labelEroarePrenume.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroarePrenume.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroarePrenume.Location = new System.Drawing.Point(12, 102);
            this.labelEroarePrenume.Name = "labelEroarePrenume";
            this.labelEroarePrenume.Size = new System.Drawing.Size(141, 15);
            this.labelEroarePrenume.TabIndex = 75;
            this.labelEroarePrenume.Text = "labelEroarePrenume";
            // 
            // labelEroareDataNastere
            // 
            this.labelEroareDataNastere.AutoSize = true;
            this.labelEroareDataNastere.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareDataNastere.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareDataNastere.Location = new System.Drawing.Point(12, 163);
            this.labelEroareDataNastere.Name = "labelEroareDataNastere";
            this.labelEroareDataNastere.Size = new System.Drawing.Size(164, 15);
            this.labelEroareDataNastere.TabIndex = 76;
            this.labelEroareDataNastere.Text = "labelEroareDataNastere";
            // 
            // labelEroareEmail
            // 
            this.labelEroareEmail.AutoSize = true;
            this.labelEroareEmail.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareEmail.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareEmail.Location = new System.Drawing.Point(1, 222);
            this.labelEroareEmail.Name = "labelEroareEmail";
            this.labelEroareEmail.Size = new System.Drawing.Size(123, 15);
            this.labelEroareEmail.TabIndex = 77;
            this.labelEroareEmail.Text = "labelEroareEmail";
            // 
            // labelEroareCnp
            // 
            this.labelEroareCnp.AutoSize = true;
            this.labelEroareCnp.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareCnp.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareCnp.Location = new System.Drawing.Point(1, 279);
            this.labelEroareCnp.Name = "labelEroareCnp";
            this.labelEroareCnp.Size = new System.Drawing.Size(109, 15);
            this.labelEroareCnp.TabIndex = 78;
            this.labelEroareCnp.Text = "labelEroareCnp";
            // 
            // labelEroareSerieNumarCI
            // 
            this.labelEroareSerieNumarCI.AutoSize = true;
            this.labelEroareSerieNumarCI.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareSerieNumarCI.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareSerieNumarCI.Location = new System.Drawing.Point(1, 331);
            this.labelEroareSerieNumarCI.Name = "labelEroareSerieNumarCI";
            this.labelEroareSerieNumarCI.Size = new System.Drawing.Size(175, 15);
            this.labelEroareSerieNumarCI.TabIndex = 79;
            this.labelEroareSerieNumarCI.Text = "labelEroareSerieNumarCI";
            // 
            // labelEroareNumarTelefon
            // 
            this.labelEroareNumarTelefon.AutoSize = true;
            this.labelEroareNumarTelefon.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareNumarTelefon.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareNumarTelefon.Location = new System.Drawing.Point(510, 222);
            this.labelEroareNumarTelefon.Name = "labelEroareNumarTelefon";
            this.labelEroareNumarTelefon.Size = new System.Drawing.Size(176, 15);
            this.labelEroareNumarTelefon.TabIndex = 80;
            this.labelEroareNumarTelefon.Text = "labelEroareNumarTelefon";
            // 
            // labelDataAngajarii
            // 
            this.labelDataAngajarii.AutoSize = true;
            this.labelDataAngajarii.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataAngajarii.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelDataAngajarii.Location = new System.Drawing.Point(532, 52);
            this.labelDataAngajarii.Name = "labelDataAngajarii";
            this.labelDataAngajarii.Size = new System.Drawing.Size(176, 15);
            this.labelDataAngajarii.TabIndex = 81;
            this.labelDataAngajarii.Text = "labelEroareDataAngajarii";
            // 
            // labelEroareSalariu
            // 
            this.labelEroareSalariu.AutoSize = true;
            this.labelEroareSalariu.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareSalariu.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareSalariu.Location = new System.Drawing.Point(521, 163);
            this.labelEroareSalariu.Name = "labelEroareSalariu";
            this.labelEroareSalariu.Size = new System.Drawing.Size(130, 15);
            this.labelEroareSalariu.TabIndex = 82;
            this.labelEroareSalariu.Text = "labelEroareSalariu";
            // 
            // labelEroareParola
            // 
            this.labelEroareParola.AutoSize = true;
            this.labelEroareParola.Font = new System.Drawing.Font("Rockwell", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEroareParola.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.labelEroareParola.Location = new System.Drawing.Point(521, 279);
            this.labelEroareParola.Name = "labelEroareParola";
            this.labelEroareParola.Size = new System.Drawing.Size(83, 15);
            this.labelEroareParola.TabIndex = 84;
            this.labelEroareParola.Text = "labelParola";
            // 
            // EroareAdaugare
            // 
            this.EroareAdaugare.AutoSize = true;
            this.EroareAdaugare.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EroareAdaugare.Image = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.EroareAdaugare.Location = new System.Drawing.Point(420, 502);
            this.EroareAdaugare.Name = "EroareAdaugare";
            this.EroareAdaugare.Size = new System.Drawing.Size(204, 24);
            this.EroareAdaugare.TabIndex = 85;
            this.EroareAdaugare.Text = "Eroare de adaugare";
            // 
            // Adaugare_Angajat_Nou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AplicatieConcediu.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1114, 599);
            this.Controls.Add(this.EroareAdaugare);
            this.Controls.Add(this.labelEroareParola);
            this.Controls.Add(this.labelEroareSalariu);
            this.Controls.Add(this.labelDataAngajarii);
            this.Controls.Add(this.labelEroareNumarTelefon);
            this.Controls.Add(this.labelEroareSerieNumarCI);
            this.Controls.Add(this.labelEroareCnp);
            this.Controls.Add(this.labelEroareEmail);
            this.Controls.Add(this.labelEroareDataNastere);
            this.Controls.Add(this.labelEroarePrenume);
            this.Controls.Add(this.labelEroareNume);
            this.Controls.Add(this.NumarTelefon);
            this.Controls.Add(this.cbManageri);
            this.Controls.Add(this.cbEchipe);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_Adauga);
            this.Controls.Add(this.Parola);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DataAngajarii);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Salariu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DataNastere);
            this.Controls.Add(this.SeriaNumarCI);
            this.Controls.Add(this.Cnp);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Prenume);
            this.Controls.Add(this.Nume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(183)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Adaugare_Angajat_Nou";
            this.Text = "Adaugare_Angajat_Nou";
            this.Load += new System.EventHandler(this.Adaugare_Angajat_Nou_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Salariu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DataNastere;
        private System.Windows.Forms.TextBox SeriaNumarCI;
        private System.Windows.Forms.TextBox Cnp;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Prenume;
        private System.Windows.Forms.TextBox Nume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker DataAngajarii;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Parola;
        private System.Windows.Forms.Button btn_Adauga;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbEchipe;
        private System.Windows.Forms.ComboBox cbManageri;
        private System.Windows.Forms.TextBox NumarTelefon;
        private EventHandler textBox7_TextChanged;
        private System.Windows.Forms.Label labelEroareNume;
        private System.Windows.Forms.Label labelEroarePrenume;
        private System.Windows.Forms.Label labelEroareDataNastere;
        private System.Windows.Forms.Label labelEroareEmail;
        private System.Windows.Forms.Label labelEroareCnp;
        private System.Windows.Forms.Label labelEroareSerieNumarCI;
        private System.Windows.Forms.Label labelEroareNumarTelefon;
        private System.Windows.Forms.Label labelDataAngajarii;
        private System.Windows.Forms.Label labelEroareSalariu;
        private System.Windows.Forms.Label labelEroareParola;
        private System.Windows.Forms.Label EroareAdaugare;
    }
}