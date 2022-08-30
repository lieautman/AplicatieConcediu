using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace AplicatieConcediu
{
    public partial class Formular_Autentificare : Form
    {
        public Formular_Autentificare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verifica daca valorile email si parola sunt in baza de date si daca sunt corecte
            //de facut!
            string userEmail = "dumi_cristi@yahoo.com"; // de preluat din formular si validat 


            //de trimis email cu codul de validare (de 6 cifre)
            int nrTrimis = 123454;
            string stringTrimis = nrTrimis.ToString();

            MailMessage mail = new MailMessage("", userEmail);
            mail.Subject = "Cod validare aplicatie HR";
            mail.Body = stringTrimis;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential();
            smtp.Credentials = nc;
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Formular_Autentificare_Load(object sender, EventArgs e)
        {

        }
    }
}
