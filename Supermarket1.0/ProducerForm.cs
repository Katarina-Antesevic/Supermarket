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
    public partial class ProducerForm : Form
    {

        List<Proizvodjac> trenutniPodaci;

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

        public ProducerForm()
        {
            InitializeComponent();
            trenutniPodaci = DbHciSupermarket.GetProizvodjaci();
            this.MouseDown += new MouseEventHandler(move_window);

            dgvProizvodjaci.ColumnCount = 5;

            dgvProizvodjaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProizvodjaci.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvProizvodjaci.AllowUserToAddRows = false;
            dgvProizvodjaci.RowHeadersVisible = false;
            dgvProizvodjaci.AllowUserToResizeRows = false;
            dgvProizvodjaci.AllowUserToDeleteRows = true;
            dgvProizvodjaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvProizvodjaci.Columns[0].Name = "Id";
            dgvProizvodjaci.Columns[0].Width = 25;
            dgvProizvodjaci.Columns[1].Name = "JIB";
            dgvProizvodjaci.Columns[1].Width = 100;
            dgvProizvodjaci.Columns[2].Name = "Naziv";
            dgvProizvodjaci.Columns[3].Name = "Telefon";
            dgvProizvodjaci.Columns[4].Name = "Email";

            dgvProizvodjaci.ForeColor = Color.OrangeRed;
            FillGrid();
        }

        void FillGrid()
        {
            dgvProizvodjaci.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetProizvodjaciFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvProizvodjaci, p.ProizvodjacId, p.JIB, p.Naziv, p.BrojTelefona, p.Email);

                dgvProizvodjaci.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form startPageForm = new StartPageForm();
            startPageForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form productsForm = new ProductForm();
            productsForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sellersForm = new SellerssForm();
            sellersForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)//dobavljaci
        {
            Form dF = new SupplierForm();
            dF.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form kategorijeForm = new CategoriesForm();
            kategorijeForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

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

        private void bDodaj_Click(object sender, EventArgs e)
        {
            if (tbJIB.Text == "")
            {
                MessageBox.Show("Niste popunili polje `JIB`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbNaziv.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Naziv`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbTelefon.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Telefon`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbEmail.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Email`", "Upozorenje",
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

                    string JIBProizvodjaca = tbJIB.Text;
                    bool postoji = false;



                    for (int i = 0; i < trenutniPodaci.Count; i++)
                    {
                        if (trenutniPodaci[i].JIB.Equals(JIBProizvodjaca))
                        {
                            MessageBox.Show("Postoji proizvodjac sa istim JIB-om", "Upozorenje",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                            postoji = true;
                            break;
                        }
                    }

                    if (!postoji)
                    {

                        if (tbJIB.Text.Length != 13)
                        {
                            MessageBox.Show("Polje `JIB` mora sadržati 13 karaktera. Unesite broj u polje.", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        }


                        else
                        {



                            var p = new Proizvodjac()
                            {
                                JIB = tbJIB.Text,
                                Naziv = tbNaziv.Text,
                                BrojTelefona = tbTelefon.Text,
                                Email = tbEmail.Text
                            };

                            DbHciSupermarket.insertProizvodjac(p);
                            FillGrid();

                            trenutniPodaci = new List<Proizvodjac>();
                            trenutniPodaci = DbHciSupermarket.GetProizvodjaci();

                            tbNaziv.Text = "";
                            tbEmail.Text = "";
                            tbJIB.Text = "";
                            tbTelefon.Text = "";

                        }
                    }
                }
            }
            
        }

        static string selectedId;
        static int selectedIdInt;

        private void bObrisi_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProizvodjaci.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan red", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvProizvodjaci.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvProizvodjaci.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                if (!DbHciSupermarket.ProizvodKoristiProizvodjaca(selectedIdInt))
                {
                    DbHciSupermarket.DeleteProizvodjacById(selectedIdInt);
                    MessageBox.Show("Proizvođač je obrisan!");
                    FillGrid();
                }

                else
                {
                    MessageBox.Show("Ne možete obrisati proizvođača, jer postoji proizvod sa datim proizvođačem.", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                }
            }

        }

        private void bIzmjeni_Click(object sender, EventArgs e)
        {
            int rowindex = dgvProizvodjaci.CurrentCell.RowIndex;
            int columnindex = 0;
            selectedId = dgvProizvodjaci.Rows[rowindex].Cells[columnindex].Value.ToString();
            selectedIdInt = Int32.Parse(selectedId);

            DataGridViewRow row = dgvProizvodjaci.Rows[rowindex];

            string brojTelefonaa;
            string emaill;
            if (row.Cells[3].Value == null)
            {
                brojTelefonaa = " ";
            }
            else
            {
                brojTelefonaa = row.Cells[3].Value.ToString();
            }
            if (row.Cells[4].Value == null)
            {
                emaill = " ";
            }
            else
            {
                emaill = row.Cells[4].Value.ToString();
            }

            if (emaill!=" " && !IsValidEmail(emaill))
            {
                MessageBox.Show("Niste pravilno napravili izmjenu polje Email-a.", "Upozorenje",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                FillGrid();
            }

            else
            {
                var p = new Proizvodjac()
                {
                    ProizvodjacId = Int32.Parse(row.Cells[0].Value.ToString()),
                    JIB = row.Cells[1].Value.ToString(),
                    Naziv = row.Cells[2].Value.ToString(),
                    BrojTelefona = brojTelefonaa,
                    Email = emaill
                };

                Proizvodjac zz = new Proizvodjac();
                for (int i = 0; i < trenutniPodaci.Count; i++)
                {
                    if (trenutniPodaci[i].ProizvodjacId == p.ProizvodjacId)
                    {
                        zz = trenutniPodaci[i];
                        break;
                    }
                }

                //z je promijenjeni zaposleni, trebamo vidjeti da li je promijenjeno nesto sto se ne smije mijenjati
                if (p.Naziv != zz.Naziv || p.JIB != zz.JIB || p.ProizvodjacId != zz.ProizvodjacId)
                {
                    MessageBox.Show("Ne možete mijenjati ovaj podatak", "Upozorenje",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    FillGrid();
                }
                else
                {
                    DbHciSupermarket.UpdateProizvodjac(p);
                    FillGrid();
                }
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
