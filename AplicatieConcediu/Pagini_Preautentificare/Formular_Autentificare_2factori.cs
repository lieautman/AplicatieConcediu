using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AplicatieConcediu.Pagini_De_Start
{
    public partial class Formular_Autentificare_2factori : Form
    {
        string Email;
        //trebuie randomizat
        int cod = 123;
        public Formular_Autentificare_2factori()
        {
            InitializeComponent();
            Email = Globals.EmailUserActual;

            //TODO: decomentat pentru a trimite mail de fiecare data

            //try
            //{
            //    MailMessage message = new MailMessage();
            //    SmtpClient smtp = new SmtpClient();
            //    message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
            //    message.To.Add(new MailAddress("cristi.dumitrescu@totalsoft.ro"));
            //    message.Subject = "Codul de confirmare este";
            //    message.IsBodyHtml = true; //to make message body as html  
            //    message.Body = cod.ToString();
            //    smtp.Port = 587;
            //    smtp.Host = "mailer14.totalsoft.local";//for gmail host  
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Credentials = new NetworkCredential("cristi.dumitrescu@totalsoft.ro", "Pantof123$");
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.Send(message);
            //}
            //catch (Exception) { }
        }

        //buton retrimitere cod
        private void button2_Click(object sender, EventArgs e)
        {
            //trimite mail
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
                message.To.Add(new MailAddress("cristi.dumitrescu@totalsoft.ro"));
                message.Subject = "Codul de confirmare este";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = cod.ToString();
                smtp.Port = 587;
                smtp.Host = "mailer14.totalsoft.local";//for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("cristi.dumitrescu@totalsoft.ro", "Pantof123$");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }

        //buton autentificare/verificare
        private void button1_Click(object sender, EventArgs e)
        {
            //verificare cod
            if (cod.ToString() == textBox1.Text)
            {
                Form pagina_profil = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
                this.Hide();
                pagina_profil.ShowDialog();
                this.Show();
                errorProvider1.SetError(button1, "");
                errorProvider1.SetError(button2, "");
            }
            else
            {
                errorProvider1.SetError(button1, "Cod gresit, verifica iar email-ul!");
                errorProvider1.SetError(button2, "Poati retrimite codul apasand acest buton!");
            }
        }


        //buton inapoi
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
