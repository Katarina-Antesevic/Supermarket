using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Supermarket1._0
{
    public partial class StartPageForm : Form
    {
        private static readonly string connection_stringg = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;



        public static StartPageForm instance;

        public string getTbKorisnickoIme()
        {
            string korIme = tbKorisnickoIme.Text.ToString();
            return korIme;   
        }

        public string getTbLozinka()
        {
            string loz = tbLozinka.Text.ToString();
            return loz;
        }


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int LPAR);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void move_window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public StartPageForm()
        {
            InitializeComponent();
            FillComboBox();
            tbLozinka.UseSystemPasswordChar = true;
            this.MouseDown += new MouseEventHandler(move_window);


        }

        void FillComboBox()
        {
            cbVrstaZaposlenog.DataSource = DbHciSupermarket.GetVrsteZaposlenog();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbLozinka.UseSystemPasswordChar = false;
            }

            else
            {
                tbLozinka.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbKorisnickoIme.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Korisničko ime`", "Upozorenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            else if (tbLozinka.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Lozinka`", "Upozorenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            else {

                List<VrstaZaposlenog> vrste = DbHciSupermarket.GetVrsteZaposlenog();
                string vrstaNaloga = cbVrstaZaposlenog.Text;
                
                int idVrs = 0;
                for(int i=0; i< vrste.Count; i++)
                {
                    if (vrste[i].Naziv.Equals(vrstaNaloga))
                    {
                        idVrs = vrste[i].VrstaZaposlenogId;
                    }
                }


                String query = "select count(*) from `zaposleni` where KorisnickoIme = @KorisnickoIme and Lozinka=@Lozinka collate utf8mb4_sv_0900_as_cs and VrstaZaposlenogId=@id and KrajRadnogOdnosa like '%no'";
                MySqlConnection conn = new MySqlConnection(connection_stringg);
                
                int rezultat = 0;


                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();


                cmd.Parameters.AddWithValue("@KorisnickoIme", tbKorisnickoIme.Text);
                cmd.Parameters.AddWithValue("@Lozinka", tbLozinka.Text);
                cmd.Parameters.AddWithValue("@id", idVrs);

                rezultat = Convert.ToInt32(cmd.ExecuteScalar());

                string textVrsteNaloga = cbVrstaZaposlenog.SelectedItem.ToString();


               
                if (rezultat > 0) 
                {
                    List<Zaposleni> sviZaposleni = DbHciSupermarket.getZaposlene();
                    string imeZaposlenog = "";

                    for(int i = 0; i < sviZaposleni.Count(); i++)
                    {
                        if (sviZaposleni[i].KorisnickoIme.Equals(tbKorisnickoIme.Text))
                        {
                            imeZaposlenog = sviZaposleni[i].Ime;
                        }
                    }

                    //string ime = tbKorisnickoIme.Text;
                    MessageBox.Show(String.Format("Dobro došli, "+imeZaposlenog+"!"), "",
                            MessageBoxButtons.OK);

                    if (textVrsteNaloga.Equals("Admin"))
                    {
                        Form employee = new SellerssForm();
                        employee.Show();
                        this.Hide();
                    }
                    else if(textVrsteNaloga.Equals("Prodavac"))
                    {
                        Form selling = new SellingForm();
                        selling.Show();
                        this.Hide();
                    }

                    Zaposleni zaposleni = new Zaposleni();
                    DbHciSupermarket.trenutniPrijavljeniRadnik = new List<Zaposleni>();

                   // List<Zaposleni> sviZaposleni = DbHciSupermarket.getZaposlene();
                    for(int i = 0; i < sviZaposleni.Count(); i++)
                    {
                        if(sviZaposleni[i].KorisnickoIme.Equals(tbKorisnickoIme.Text) && sviZaposleni[i].Lozinka.Equals(tbLozinka.Text))
                        {
                            zaposleni = sviZaposleni[i];
                            break;
                        }
                    }

                    DbHciSupermarket.trenutniPrijavljeniRadnik.Add(zaposleni);

                }
                else
                {
                    MessageBox.Show("Uneseni podaci nisu ispravni!", "Upozorenje",
                               MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
}
    }
}
