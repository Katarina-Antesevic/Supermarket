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
    public partial class SupplierForm : Form
    {
        List<Dobavljac> trenutniPodaci;

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


        public SupplierForm()
        {
            InitializeComponent();
            trenutniPodaci = DbHciSupermarket.GetDobavljaci();
            this.MouseDown += new MouseEventHandler(move_window);

            dgvDobavljaci.ColumnCount = 5;

            dgvDobavljaci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDobavljaci.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDobavljaci.AllowUserToAddRows = false;
            dgvDobavljaci.RowHeadersVisible = false;
            dgvDobavljaci.AllowUserToResizeRows = false;
            dgvDobavljaci.AllowUserToDeleteRows = true;
            dgvDobavljaci.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvDobavljaci.Columns[0].Name = "Id";
            dgvDobavljaci.Columns[0].Width = 25;
            dgvDobavljaci.Columns[1].Name = "JIB";
            dgvDobavljaci.Columns[1].Width = 100;
            dgvDobavljaci.Columns[2].Name = "Naziv";
            dgvDobavljaci.Columns[3].Name = "Telefon";
            dgvDobavljaci.Columns[4].Name = "Email";

            dgvDobavljaci.ForeColor = Color.OrangeRed;
            FillGrid();
        }

        void FillGrid()
        {
            dgvDobavljaci.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetDobavljaciFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvDobavljaci, p.DobavljacId, p.JIB, p.Naziv, p.BrojTelefona, p.Email);

                dgvDobavljaci.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }

        private void btnProizvodi_Click(object sender, EventArgs e)
        {
            Form productsForm = new ProductForm();
            productsForm.Show();
            this.Hide();
        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            Form sellersForm = new SellerssForm();
            sellersForm.Show();
            this.Hide();
        }

        private void btnRacuni_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }

        private void btnKategorije_Click(object sender, EventArgs e)
        {
            Form kategorijeForm = new CategoriesForm();
            kategorijeForm.Show();
            this.Hide();
        }

        private void btnProizvodjaci_Click(object sender, EventArgs e)
        {
            Form pF = new ProducerForm();
            pF.Show();
            this.Hide();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            Form startPageForm = new StartPageForm();
            startPageForm.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
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

                    string JIBDobavljaca = tbJIB.Text;
                    bool postoji = false;



                    for (int i = 0; i < trenutniPodaci.Count; i++)
                    {
                        if (trenutniPodaci[i].JIB.Equals(JIBDobavljaca))
                        {
                            MessageBox.Show("Postoji dobavljač sa istim JIB-om", "Upozorenje",
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
                            var p = new Dobavljac()
                            {
                                JIB = tbJIB.Text,
                                Naziv = tbNaziv.Text,
                                BrojTelefona = tbTelefon.Text,
                                Email = tbEmail.Text
                            };

                            DbHciSupermarket.insertDobavljac(p);
                            FillGrid();

                            trenutniPodaci = new List<Dobavljac>();
                            trenutniPodaci = DbHciSupermarket.GetDobavljaci();

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
            Int32 selectedRowCount = dgvDobavljaci.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan red", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvDobavljaci.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvDobavljaci.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);


                if (!DbHciSupermarket.ProizvodKoristiDobavljaca(selectedIdInt))
                {

                    DbHciSupermarket.DeleteDobavljacById(selectedIdInt);
                    MessageBox.Show("Dobavljač je obrisan!");
                    FillGrid();
                }
                else
                {
                    MessageBox.Show("Ne možete obrisati dobavljača, jer postoji proizvod sa datim dobavljačem.", "Upozorenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
        }

        private void bIzmjeni_Click(object sender, EventArgs e)
        {
            int rowindex = dgvDobavljaci.CurrentCell.RowIndex;
            int columnindex = 0;
            selectedId = dgvDobavljaci.Rows[rowindex].Cells[columnindex].Value.ToString();
            selectedIdInt = Int32.Parse(selectedId);

            DataGridViewRow row = dgvDobavljaci.Rows[rowindex];

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

            if (emaill != " " && !IsValidEmail(emaill))
            {
                MessageBox.Show("Niste pravilno napravili izmjenu polje Email-a.", "Upozorenje",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                FillGrid();
            }


            var p = new Dobavljac()
            {
                DobavljacId = Int32.Parse(row.Cells[0].Value.ToString()),
                JIB = row.Cells[1].Value.ToString(),
                Naziv = row.Cells[2].Value.ToString(),
                BrojTelefona = brojTelefonaa,
                Email = emaill
            };

            Dobavljac zz = new Dobavljac();
            for (int i = 0; i < trenutniPodaci.Count; i++)
            {
                if (trenutniPodaci[i].DobavljacId == p.DobavljacId)
                {
                    zz = trenutniPodaci[i];
                    break;
                }
            }

            //z je promijenjeni zaposleni, trebamo vidjeti da li je promijenjeno nesto sto se ne smije mijenjati
            if (p.Naziv != zz.Naziv || p.JIB != zz.JIB || p.DobavljacId != zz.DobavljacId)
            {
                MessageBox.Show("Ne možete mijenjati ovaj podatak", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                FillGrid();
            }
            else
            {
                DbHciSupermarket.UpdateDobavljac(p);
                FillGrid();
            }
        }

        private void tbFilter_TextChanged_1(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form dF = new ExEmployeesForm();
            dF.Show();
            this.Hide();
        }
    }
}
