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
        private static Random rnd = new Random();
        private int cod = rnd.Next(0,10000);
        public Formular_Autentificare_2factori()
        {
            InitializeComponent();
            Email = Globals.EmailUserActual;

            //TODO: decomentat pentru a trimite mail de fiecare data

        }

        //buton retrimitere cod
        private void buttonRetrimitere_Click(object sender, EventArgs e)
        {
            //trimite mail
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
                message.To.Add(new MailAddress("andra.iancu@totalsoft.ro"));
                message.Subject = "Codul de confirmare este";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = cod.ToString();
                smtp.Port = 587;
                smtp.Host = "mailer14.totalsoft.local";//for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("cristi.dumitrescu@totalsoft.ro", "Telefon123$");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }

        //buton autentificare/verificare
        private void buttonValidareCod_Click(object sender, EventArgs e)
        {
            //verificare cod
            if (cod.ToString() == textBox1.Text)
            {
                Form pagina_profil = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
                this.Hide();
                this.Close();
                pagina_profil.ShowDialog();
            }
            else
            {
                labelEroareCod.Text = "* Cod gresit, verifica iar email-ul sau retrimite-l apasand pe buton!";
            }
        }


        //buton inapoi
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //label text =""
        private void Formular_Autentificare_2factori_Load(object sender, EventArgs e)
        {
            labelEroareCod.Text = "";

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
                message.To.Add(new MailAddress("andra.iancu@totalsoft.ro"));
                message.Subject = "Codul de confirmare este";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = cod.ToString();
                smtp.Port = 587;
                smtp.Host = "mailer14.totalsoft.local";//for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("cristi.dumitrescu@totalsoft.ro", "Telefon123$");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
