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
        int cod = 123;
        public Formular_Autentificare_2factori()
        {
            InitializeComponent();
            Email = Globals.EmailUserActual;
            //try
            //{
            //    MailMessage message = new MailMessage();
            //    SmtpClient smtp = new SmtpClient();
            //    message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
            //    message.To.Add(new MailAddress("cristi.dumitrescu@totalsoft.ro"));
            //    message.Subject = "Codul de confirmare este";
            //    message.IsBodyHtml = true; //to make message body as html  
            //    message.Body = "123";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("cristi.dumitrescu@totalsoft.ro");
                message.To.Add(new MailAddress("cristi.dumitrescu@totalsoft.ro"));
                message.Subject = "Codul de confirmare este";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "123";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (cod.ToString() == textBox1.Text)
            {
                Form pagina_profil = new Pagina_Profil_Angajat();
                this.Hide();
                pagina_profil.ShowDialog();
                this.Show();
            }
        }
    }
}
