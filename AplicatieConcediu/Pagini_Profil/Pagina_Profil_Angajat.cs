using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using AplicatieConcediu.Pagini_Actiuni;
using AplicatieConcediu.Pagini_Profil;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using Azure;
using XD.Models;

namespace AplicatieConcediu
{
    public partial class Pagina_Profil_Angajat : Form
    {
        public Pagina_Profil_Angajat()
        {
            InitializeComponent();
        }


        //load
        private void Pagina_Profil_Angajat_Load(object sender, EventArgs e)
        {

            if (Globals.IsAdmin == true || Globals.IdManager == null)
            {
                buttonAprobareAngajatNou.Show();
                buttonAprobareConcedii.Show();
                buttonPromovareAngajati.Show();
                buttonAdaugareAngajat.Show();

            }
            else
            {

                buttonAprobareAngajatNou.Hide();
                buttonAprobareConcedii.Hide();
                buttonPromovareAngajati.Hide();
                buttonAdaugareAngajat.Hide();

            }
            if (Globals.IdManager == null && Globals.IsAdmin == false)
                buttonPromovareAngajati.Hide();


            //resetare label-uri date
            labelNume2.Text = "";
            labelPrenume2.Text = "";
            labelFunctie2.Text = "";
            labelDataAngajare2.Text = "";
            labelEmail2.Text = "";
            labelTelefon2.Text = "";
            labelDataNasterii2.Text = "";
            labelCnp2.Text = "";
            labelSerie2.Text = "";
            labelNumar2.Text = "";
            labelSalariu2.Text = "";
            //label eroare
            labelEditareNeefectuata.Visible = false;


            //text box-uri editare invizibile
            textBoxEditNume.Visible = false;
            textBoxEditPrenume.Visible = false;
            dateTimePickerDataAngajare.Visible = false;
            textBoxEditEmail.Visible = false;
            textBoxEditTelefon.Visible = false;
            dateTimePickerDataNastere.Visible = false;
            textBoxEditCnp.Visible = false;
            textBoxEditSerieCi.Visible = false;
            textBoxEditNumarCi.Visible = false;
            textBoxEditSalariu.Visible = false;
            //btn annulare invizible
            buttonAnulareEditare.Visible = false;



            string emailFolositLaSelect;
            //verifica daca avem emailUserViewed (adica daca utiliz al carui profil il accesez este vizualizat din lista de angajati sau nu)
            if (Globals.EmailUserViewed != "")
            {
                //ascundere date sensibile
                labelCnp1.Visible = false;
                labelSerie1.Visible = false;
                labelNumar1.Visible = false;
                labelSalariu1.Visible = false;
                labelCnp2.Visible = false;
                labelSerie2.Visible = false;
                labelNumar2.Visible = false;
                labelSalariu2.Visible = false;
                //ascunde butoane utilitare
                buttonConcediileSale.Visible = true;
                buttonConcediileMele.Visible = false;
                buttonCreazaCerereConcediu.Visible = false;
                //ascunde butonul de editare
                buttonEditProfil.Visible = false;//posibil sa editeze ca admin sau manager
            }


            XD.Models.Angajat a = Globals.AngajatLogatInAplicatie;

            //preluare date
            labelNume2.Text = a.Nume;
            labelPrenume2.Text = a.Prenume;
            if (a.EsteAdmin.Value)
            {
                labelFunctie2.Text = "Administrator";
            }
            else if (a.ManagerId == 0)
            {
                labelFunctie2.Text = "Manager";
            }
            else
            {
                labelFunctie2.Text = "Angajat";
            }
            if (a.DataAngajarii!=null)
            {
                    labelDataAngajare2.Text = a.DataAngajarii.ToString();
            }
            else
                {
                    labelDataAngajare2.Text = "Acest angajat nu a fost inca acceptat!";
                }
            labelEmail2.Text = a.Email;
            labelTelefon2.Text = a.Numartelefon;
            labelDataNasterii2.Text = a.DataNasterii.ToString();
            labelCnp2.Text = a.Cnp;
            labelSerie2.Text = a.SeriaNumarBuletin.Substring(0, 2);
            labelNumar2.Text = a.SeriaNumarBuletin.Substring(2);
            labelSalariu2.Text = a.Salariu.ToString();


            //preluare poza
            byte[] poza = { };
            bool isOk = true;
            if (a.Poza != null)
                poza = a.Poza;
            else
                isOk = false;
            if (isOk==true)
                pictureBoxPoza.Image = System.Drawing.Image.FromStream(new MemoryStream(poza));
        }


        //adaugare poza
        private async void pictureBoxPoza_Click(object sender, EventArgs e)
        {
            if (Globals.EmailUserViewed == "")
            {
                //deschidere file explorer pt a citi o poza
                using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fileName = openFileDialog1.FileName;
                        byte[] bytes = File.ReadAllBytes(fileName);
                        string contentType = "";
                        //Set the contenttype based on File Extension

                        switch (Path.GetExtension(fileName))
                        {
                            case ".jpg":
                                contentType = "image/jpeg";
                                break;
                            case ".png":
                                contentType = "image/png";
                                break;
                            case ".gif":
                                contentType = "image/gif";
                                break;
                            case ".bmp":
                                contentType = "image/bmp";
                                break;
                        }

                        //trimite poza new
                        HttpClient httpClient = new HttpClient();
                        XD.Models.Angajat angajat1 = new XD.Models.Angajat();
                        angajat1.Email = Globals.EmailUserActual;
                        angajat1.Poza = bytes;
                        angajat1.Cnp = "";
                        angajat1.Nume = "";
                        angajat1.Prenume = "";

                        string jsonString = JsonConvert.SerializeObject(angajat1);
                        StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostIncarcarePoza", stringContent);
                        response.EnsureSuccessStatusCode();

                        pictureBoxPoza.Image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                        Globals.AngajatLogatInAplicatie.Poza = bytes;
                    }
                }
            }


        }

        //buton vizualizare profil
        private void buttonVizualizareProfil_Click(object sender, EventArgs e)
        {
            Form profilul_meu = new Pagina_Profil_Angajat();

            this.Hide();
            this.Close();
            Globals.EmailUserViewed = "";
            profilul_meu.ShowDialog();
        }
        //buton pagina cu toate echipele
        private void buttonToateEchipele_Click(object sender, EventArgs e)
        {
            AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele form = new AplicatieConcediu.Pagini_Profil.PaginaCuTotateEchipele();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        //buton vizualizare angajati
        private void buttonVizualizareAngajati_Click(object sender, EventArgs e)
        {
            Form TotiAngajatii = new TotiAngajatii();

            this.Hide();
            TotiAngajatii.ShowDialog();
            this.Show();

        }
        //buton pagina creare concediu
        private void buttonCreareConcediu_Click(object sender, EventArgs e)
        {
            Form creare_concediu = new Pagina_CreareConcediu();
            this.Hide();
            creare_concediu.ShowDialog();
            this.Show();
        }
        //buton aprobare concedii
        private void buttonAprobareConcedii_Click(object sender, EventArgs e)
        {
            Form aprobare_concediu = new Aprobare_Concediu();
            this.Hide();
            aprobare_concediu.ShowDialog();
            this.Show();
        }
        //buton promovare angajat
        private void buttonPromovareAngajat_Click(object sender, EventArgs e)
        {
            Form promovare = new Promovare_Angajat();
            this.Hide();
            promovare.ShowDialog();
            this.Show();

        }
        //buton aprobare angajat
        private void buttonAprobareAngajat_Click(object sender, EventArgs e)
        {
            Form adaugareangajatnou = new Adaugare_Angajat_Nou();
            adaugareangajatnou.ShowDialog();
            this.Show();

          
        }
        //buton adaugare angajat  nou
        private void buttonAngajatNou_Click(object sender, EventArgs e)
        {
            Form adaugare_angajat = new Aprobare_Angajare();
            this.Hide();
            adaugare_angajat.ShowDialog();
            this.Show();
        }


        //delogare
        private void buttonDelogare_Click(object sender, EventArgs e)
        {
            Form delogare = new Pagina_start();
            this.Hide();
            delogare.ShowDialog();
            this.Show();
            this.Close();
            System.Environment.Exit(1);

        }



        //buton creare concediu
        private void buttonCreareConcediu2_Click(object sender, EventArgs e)
        {
            Form creareconcediu = new Pagina_CreareConcediu();
            this.Hide();
            creareconcediu.ShowDialog();
            this.Show();
        }
        //buton concediile mele
        private void buttonConcediileMele_Click(object sender, EventArgs e)
        {
            Form concedii = new Pagina_ConcediileMele();
            this.Hide();
            concedii.ShowDialog();
            this.Show();
        }
        //buton concediile sale
        private void buttonConcediileSale_Click(object sender, EventArgs e)
        {
            Pagina_ConcediileMele concediilemele = new Pagina_ConcediileMele();
            this.Hide();
            concediilemele.ShowDialog();
            this.Show();
        }
        private bool editeaza = false;
        //buton editeaza profil
        private async void buttonEditProfil_Click(object sender, EventArgs e)
        {
            if (!editeaza)
            {
                //preluare date din label in textbox-uri
                textBoxEditNume.Text = labelNume2.Text;
                textBoxEditPrenume.Text = labelPrenume2.Text;
                if(Globals.AngajatLogatInAplicatie.DataAngajarii!=null)
                    dateTimePickerDataAngajare.Value = (DateTime)Globals.AngajatLogatInAplicatie.DataAngajarii;
                textBoxEditEmail.Text = labelEmail2.Text;
                textBoxEditTelefon.Text = labelTelefon2.Text;
                if (Globals.AngajatLogatInAplicatie.DataNasterii != null)
                    dateTimePickerDataNastere.Value = (DateTime)Globals.AngajatLogatInAplicatie.DataNasterii;
                textBoxEditCnp.Text = labelCnp2.Text;
                textBoxEditSerieCi.Text = labelSerie2.Text;
                textBoxEditNumarCi.Text = labelNumar2.Text;
                textBoxEditSalariu.Text = labelSalariu2.Text;

                //ascunde label-uri
                labelNume2.Visible = false;
                labelPrenume2.Visible = false;
                labelFunctie2.Visible = false;
                labelDataAngajare2.Visible = false;
                labelEmail2.Visible = false;
                labelTelefon2.Visible = false;
                labelDataNasterii2.Visible = false;
                labelCnp2.Visible = false;
                labelSerie2.Visible = false;
                labelNumar2.Visible = false;
                labelSalariu2.Visible = false;

                //arata textbox-uri
                textBoxEditNume.Visible = true;
                textBoxEditPrenume.Visible = true;
                dateTimePickerDataAngajare.Visible = true;
                textBoxEditEmail.Visible = true;
                textBoxEditTelefon.Visible = true;
                dateTimePickerDataNastere.Visible = true;
                textBoxEditCnp.Visible = true;
                textBoxEditSerieCi.Visible = true;
                textBoxEditNumarCi.Visible = true;
                textBoxEditSalariu.Visible = true;

                //btn anulare vizibil
                buttonAnulareEditare.Visible = true;


                //modifica numele in salveaza
                buttonEditProfil.Text = "Salveaza!";

            }
            else
            {


                HttpClient httpClient = new HttpClient();
                string jsonString = System.Text.Json.JsonSerializer.Serialize<XD.Models.Angajat>(Globals.AngajatLogatInAplicatie);
                StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://localhost:5107/Angajat/PostEditareDateAngajat", stringContent);

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    //reset label-uri
                    labelNume2.Text = Globals.AngajatLogatInAplicatie.Nume;
                    labelPrenume2.Text = Globals.AngajatLogatInAplicatie.Prenume;
                    labelDataAngajare2.Text = Globals.AngajatLogatInAplicatie.DataAngajarii.ToString();
                    labelEmail2.Text = Globals.AngajatLogatInAplicatie.Email;
                    labelTelefon2.Text = Globals.AngajatLogatInAplicatie.Numartelefon;
                    labelDataNasterii2.Text = Globals.AngajatLogatInAplicatie.DataNasterii.ToString();
                    labelCnp2.Text = Globals.AngajatLogatInAplicatie.Cnp;
                    labelSerie2.Text = Globals.AngajatLogatInAplicatie.SeriaNumarBuletin.Substring(0, 2);
                    labelNumar2.Text = Globals.AngajatLogatInAplicatie.SeriaNumarBuletin.Substring(2);
                    labelSalariu2.Text = Globals.AngajatLogatInAplicatie.Salariu.ToString();

                    //salvare shimbari in backend si in globals
                    //trebuie check-uri
                    Globals.AngajatLogatInAplicatie.Nume = textBoxEditNume.Text;
                    Globals.AngajatLogatInAplicatie.Prenume = textBoxEditPrenume.Text;
                    Globals.AngajatLogatInAplicatie.DataAngajarii = dateTimePickerDataAngajare.Value.Date;
                    Globals.AngajatLogatInAplicatie.Email = textBoxEditEmail.Text;
                    Globals.AngajatLogatInAplicatie.Numartelefon = textBoxEditTelefon.Text;
                    Globals.AngajatLogatInAplicatie.DataNasterii = dateTimePickerDataNastere.Value.Date;
                    Globals.AngajatLogatInAplicatie.Cnp = textBoxEditCnp.Text;
                    Globals.AngajatLogatInAplicatie.SeriaNumarBuletin = textBoxEditSerieCi.Text + textBoxEditNumarCi.Text;
                    Decimal salariuLocal;
                    Decimal.TryParse(textBoxEditSalariu.Text, out salariuLocal);
                    Globals.AngajatLogatInAplicatie.Salariu = salariuLocal;


                    //arata label-uri
                    labelNume2.Visible = true;
                    labelPrenume2.Visible = true;
                    labelDataAngajare2.Visible = true;
                    labelEmail2.Visible = true;
                    labelTelefon2.Visible = true;
                    labelDataNasterii2.Visible = true;
                    labelCnp2.Visible = true;
                    labelSerie2.Visible = true;
                    labelNumar2.Visible = true;
                    labelSalariu2.Visible = true;

                    //ascunde textbox-uri                
                    textBoxEditNume.Visible = false;
                    textBoxEditPrenume.Visible = false;
                    dateTimePickerDataAngajare.Visible = false;
                    textBoxEditEmail.Visible = false;
                    textBoxEditTelefon.Visible = false;
                    dateTimePickerDataNastere.Visible = false;
                    textBoxEditCnp.Visible = false;
                    textBoxEditSerieCi.Visible = false;
                    textBoxEditNumarCi.Visible = false;
                    textBoxEditSalariu.Visible = false;

                    //btn anulare invizibil
                    buttonAnulareEditare.Visible = false;
                }
                else
                {
                    labelEditareNeefectuata.Visible = true;
                }

                //modifica numele innapoi din
                buttonEditProfil.Text = "Editeaza profilul";
            }
            editeaza = !editeaza;
        }
        //buton anulare editare
        private void buttonAnulareEditare_Click(object sender, EventArgs e)
        {
            //arata label-uri
            labelNume2.Visible = true;
            labelPrenume2.Visible = true;
            labelFunctie2.Visible = true;
            labelDataAngajare2.Visible = true;
            labelEmail2.Visible = true;
            labelTelefon2.Visible = true;
            labelDataNasterii2.Visible = true;
            labelCnp2.Visible = true;
            labelSerie2.Visible = true;
            labelNumar2.Visible = true;
            labelSalariu2.Visible = true;

            //ascunde textbox-uri                
            textBoxEditNume.Visible = false;
            textBoxEditPrenume.Visible = false;
            dateTimePickerDataAngajare.Visible = false;
            textBoxEditEmail.Visible = false;
            textBoxEditTelefon.Visible = false;
            dateTimePickerDataNastere.Visible = false;
            textBoxEditCnp.Visible = false;
            textBoxEditSerieCi.Visible = false;
            textBoxEditNumarCi.Visible = false;
            textBoxEditSalariu.Visible = false;

            //btn anulare invizibil
            buttonAnulareEditare.Visible = false;


            //modifica numele innapoi din
            buttonEditProfil.Text = "Editeaza profilul";
            labelEditareNeefectuata.Visible = false;

            editeaza = false;
        }


        //buton inchidere
        private void buttonInchidere_Click(object sender, EventArgs e)
        {
            Globals.EmailUserViewed = "";
            this.Close();
        }



        //afisare butoane sau nu
        int count = 1;
        private void buttonLogo_Click(object sender, EventArgs e)
        {
            count++;
            if (count % 2 != 0)
            {
                buttonVizualizareEchipe.Show();
                buttonVizualizareAngajati.Show();
                buttonVizualizareProfil.Show();
                buttonCreareCerereConcediu.Show();
                button13.Show();

                if (Globals.IsAdmin == true || Globals.IdManager == null)
                {
                    buttonVizualizareEchipe.Show();
                    buttonAprobareConcedii.Show();
                    buttonPromovareAngajati.Show();
                    buttonAprobareAngajatNou.Show();
                    buttonAdaugareAngajat.Show();
                    buttonCreareCerereConcediu.Show();
                }
                if (Globals.IdManager == null && Globals.IsAdmin == false)
                    buttonPromovareAngajati.Hide();

            }
            else
            {
                buttonVizualizareEchipe.Hide();
                buttonAdaugareAngajat.Hide();
                buttonAprobareConcedii.Hide();
                buttonPromovareAngajati.Hide();
                buttonAprobareAngajatNou.Hide();
                buttonVizualizareAngajati.Hide();
                buttonVizualizareProfil.Hide();
                button13.Hide();
                buttonCreareCerereConcediu.Hide();

            }

        }

    }
}
