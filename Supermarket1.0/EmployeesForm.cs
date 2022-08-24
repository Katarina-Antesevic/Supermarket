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

namespace Supermarket1._0
{
    public partial class SellerssForm : Form
    {
        List<Zaposleni> trenutniPodaci;

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

        static string selectedId;
        static int selectedIdInt;

        bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }

        public SellerssForm()
        {
            InitializeComponent();
            trenutniPodaci = DbHciSupermarket.getZaposlene();
            FillComboBox();
            this.MouseDown += new MouseEventHandler(move_window);

            tbKorisnickoIme.MaxLength = 13;
            tbLozinka.MaxLength = 13;
            tbJMB.MaxLength = 13;
            dgvZaposleni.ColumnCount = 11;

            dgvZaposleni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvZaposleni.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvZaposleni.AllowUserToAddRows = false;
            dgvZaposleni.RowHeadersVisible = false;
            dgvZaposleni.AllowUserToResizeRows = false;
            dgvZaposleni.AllowUserToDeleteRows = true;
            dgvZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvZaposleni.Columns[0].Name = "Id";
            dgvZaposleni.Columns[0].Width = 25;
            dgvZaposleni.Columns[1].Name = "JMB";

            dgvZaposleni.Columns[1].Width = 90;
            dgvZaposleni.Columns[2].Name = "Ime";
            dgvZaposleni.Columns[3].Name = "Prezime";
            dgvZaposleni.Columns[4].Name = "Telefon";
            dgvZaposleni.Columns[5].Name = "Email";
            dgvZaposleni.Columns[5].Width = 105;
            dgvZaposleni.Columns[6].Name = "Plata";
            dgvZaposleni.Columns[6].Width = 40;
            dgvZaposleni.Columns[7].Name = "Datum početka";
            dgvZaposleni.Columns[7].Width = 70;
            dgvZaposleni.Columns[8].Name = "Korisničko ime";
            dgvZaposleni.Columns[8].Width = 70;
            dgvZaposleni.Columns[9].Name = "Lozinka";
            dgvZaposleni.Columns[9].Width = 70;
            dgvZaposleni.Columns[10].Name = "Tip naloga";
            dgvZaposleni.Columns[10].Width = 65;

            dgvZaposleni.ForeColor = Color.OrangeRed;
            FillGrid();
        }


        void FillComboBox()
        {
            cbTipNaloga.DataSource = DbHciSupermarket.GetVrsteZaposlenog();
        }

        void FillGrid()
        {
            dgvZaposleni.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetZaposleneFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvZaposleni,p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata, p.DatumOd, p.KorisnickoIme, p.Lozinka, p.VrstaZaposlenog.Naziv);
                dgvZaposleni.Columns[7].DefaultCellStyle.Format = "dd'/'MM'/'yyyy";

                dgvZaposleni.Rows.Add(row);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form productsForm = new ProductForm();
            productsForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form categoriesForm = new CategoriesForm();
            categoriesForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form startPageForm = new StartPageForm();
            startPageForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e) //dodaj
        {
            if (tbJMB.Text == "" )
            {
                MessageBox.Show("Niste popunili polje `JMB`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            if (tbIme.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Ime`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbPrezime.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Prezime`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbTelefon.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Broj telefona`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Email`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbPlata.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Plata`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbKorisnickoIme.Text == "")
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

            else
            {
                int number;
                bool result = Int32.TryParse(tbPlata.Text, out number);

                if (!result)
                {
                    MessageBox.Show("Niste pravilno popunili polje `Plata`. Unesite broj u polje.", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }

                else if(tbJMB.Text.Length != 13)
                {
                    MessageBox.Show("Polje `JMB` mora sadržati 13 karaktera. Unesite broj u polje.", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }

                else
                {

                    if (!IsValidEmail(tbEmail.Text))
                    {
                        MessageBox.Show("Niste pravilno popunili polje `Email`.", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    }

                    else
                    {

                        string jmb = tbJMB.Text;
                        bool postoji = false;

                        for (int i = 0; i < trenutniPodaci.Count; i++)
                        {
                            if (trenutniPodaci[i].JMB.Equals(jmb))
                            {
                                MessageBox.Show("Postoji zaposleni sa istim JMB-om", "Upozorenje",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                                postoji = true;
                                break;
                            }
                        }

                        string username = tbKorisnickoIme.Text;
                        bool postojiUsername = false;
                        for (int i = 0; i < trenutniPodaci.Count; i++)
                        {
                            if (trenutniPodaci[i].KorisnickoIme.Equals(username))
                            {
                                MessageBox.Show("Postoji zaposleni sa istim korisničkim imenom", "Upozorenje",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                                postojiUsername = true;
                                break;
                            }
                        }

                        if (!postoji && !postojiUsername)
                        {

                            var z = new Zaposleni()
                            {
                                JMB = tbJMB.Text,
                                Ime = tbIme.Text,
                                Prezime = tbPrezime.Text,
                                BrojTelefona = tbTelefon.Text,
                                Email = tbEmail.Text,
                                Plata = Int32.Parse(tbPlata.Text),
                                KorisnickoIme = tbKorisnickoIme.Text,
                                Lozinka = tbLozinka.Text,
                                DatumOd = dateTime.Value,
                                VrstaZaposlenog = (VrstaZaposlenog)cbTipNaloga.SelectedItem
                            };

                            DbHciSupermarket.insertZaposleni(z);
                            FillGrid();

                            trenutniPodaci = new List<Zaposleni>();
                            trenutniPodaci = DbHciSupermarket.getZaposlene();

                            tbJMB.Text = "";
                            tbEmail.Text = "";
                            tbIme.Text = "";
                            tbKorisnickoIme.Text = "";
                            tbLozinka.Text = "";
                            tbPlata.Text = "";
                            tbPrezime.Text = "";
                            tbTelefon.Text = "";
                        }
                    }
                }
                FillGrid();
            }

        }

        private void button6_Click(object sender, EventArgs e) //brisi
        {
            Int32 selectedRowCount = dgvZaposleni.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan red", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvZaposleni.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvZaposleni.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                bool koristi = false;

                for(int i = 0; i < DbHciSupermarket.GetSveRacune().Count(); i++)
                {
                    if (DbHciSupermarket.GetSveRacune()[i].Zaposleni.ZaposleniId == selectedIdInt)
                    {
                        koristi = true;
                        break;
                    }
                }

                if (!koristi)
                {
                    DbHciSupermarket.DeleteZaposleniById(selectedIdInt);
                    MessageBox.Show("Zaposleni je obrisan!");
                    FillGrid();
                }

                else
                {
                    MessageBox.Show("Ne možete obrisati zaposlenog, jer postoji račun sa datim zaposlenim.", "Upozorenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }


        }

        
        private void button5_Click(object sender, EventArgs e) //izmjeni
        {
            int rowindex = dgvZaposleni.CurrentCell.RowIndex;
            int columnindex = 0;
            selectedId = dgvZaposleni.Rows[rowindex].Cells[columnindex].Value.ToString();
            selectedIdInt = Int32.Parse(selectedId);

            DataGridViewRow row = dgvZaposleni.Rows[rowindex];
            

            string vzString = row.Cells[10].Value.ToString();

            var datum = row.Cells[7].Value.ToString();

            DataGridViewRow roww = dgvZaposleni.Rows[rowindex];
            Zaposleni z1 = new Zaposleni();
            z1.ZaposleniId = Int32.Parse(roww.Cells[0].Value.ToString());
            z1.JMB = roww.Cells[1].Value.ToString();
            z1.Ime = roww.Cells[2].Value.ToString();
            z1.Prezime = roww.Cells[3].Value.ToString();
            z1.VrstaZaposlenog = new VrstaZaposlenog();
            z1.VrstaZaposlenog.Naziv= roww.Cells[10].Value.ToString();

            string datumm= roww.Cells[7].Value.ToString();


            //***
            Zaposleni zz = new Zaposleni();
            for (int i = 0; i < trenutniPodaci.Count; i++)
            {
                if (trenutniPodaci[i].ZaposleniId == z1.ZaposleniId)
                {
                    zz = trenutniPodaci[i];
                    break;
                }
            }

            if (z1.ZaposleniId != zz.ZaposleniId || z1.JMB != zz.JMB || z1.Ime != zz.Ime || z1.Prezime != zz.Prezime || !z1.VrstaZaposlenog.Naziv.Equals(zz.VrstaZaposlenog.Naziv) || !datumm.Equals(zz.DatumOd.ToString()))
            {
                MessageBox.Show("Ne možete mijenjati ovaj podatak", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                FillGrid();
            }
            else
            {

                var z = new Zaposleni()
                {
                    ZaposleniId = Int32.Parse(row.Cells[0].Value.ToString()),
                    JMB = row.Cells[1].Value.ToString(),
                    Ime = row.Cells[2].Value.ToString(),
                    Prezime = row.Cells[3].Value.ToString(),
                    BrojTelefona = row.Cells[4].Value.ToString(),
                    Email = row.Cells[5].Value.ToString(),
                    Plata = Int32.Parse(row.Cells[6].Value.ToString()),
                    KorisnickoIme = row.Cells[8].Value.ToString(),
                    Lozinka = row.Cells[9].Value.ToString(),
                    DatumOd = DateTime.Parse(datum),
                    VrstaZaposlenog = DbHciSupermarket.GetVrstaZap(vzString)
                };
                DbHciSupermarket.UpdateZaposlenog(z);
                FillGrid();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form producerForm = new ProducerForm();
            producerForm.Show();
            this.Hide();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form dF = new SupplierForm();
            dF.Show();
            this.Hide();
        }

        private void krajRadnogOdnosa_Click(object sender, EventArgs e)
        {

            Int32 selectedRowCount = dgvZaposleni.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jednog zaposlenog", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {

                int rowindex = dgvZaposleni.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvZaposleni.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                DataGridViewRow row = dgvZaposleni.Rows[rowindex];


                string vzString = row.Cells[10].Value.ToString();

                var datum = row.Cells[7].Value.ToString();

               

                    var z = new Zaposleni()
                    {
                        ZaposleniId = Int32.Parse(row.Cells[0].Value.ToString()),
                        JMB = row.Cells[1].Value.ToString(),
                        Ime = row.Cells[2].Value.ToString(),
                        Prezime = row.Cells[3].Value.ToString(),
                        BrojTelefona = row.Cells[4].Value.ToString(),
                        Email = row.Cells[5].Value.ToString(),
                        Plata = Int32.Parse(row.Cells[6].Value.ToString()),
                        KorisnickoIme = row.Cells[8].Value.ToString(),
                        Lozinka = row.Cells[9].Value.ToString(),
                        DatumOd = DateTime.Parse(datum),
                        VrstaZaposlenog = DbHciSupermarket.GetVrstaZap(vzString),
                        KrajRadnogOdnosa = "yes"
                    };
                    DbHciSupermarket.UpdateZaposlenogBivseg(z);
                    FillGrid();
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form dF = new ExEmployeesForm();
            dF.Show();
            this.Hide();
            
        }
    }
}
