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
    public partial class ProductForm : Form
    {

        List<Proizvod> trenutniPodaci;

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

        public ProductForm()
        {
            InitializeComponent();
            FillComboBox();
            trenutniPodaci = DbHciSupermarket.getProizvode();
            this.MouseDown += new MouseEventHandler(move_window);

            dgvProizvodi.ColumnCount = 8;

            dgvProizvodi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProizvodi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvProizvodi.AllowUserToAddRows = false;
            dgvProizvodi.RowHeadersVisible = false;
            dgvProizvodi.AllowUserToResizeRows = false;
            dgvProizvodi.AllowUserToDeleteRows = true;
            dgvProizvodi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            dgvProizvodi.Columns[0].Name = "Id";
            dgvProizvodi.Columns[0].Width = 25;
            dgvProizvodi.Columns[1].Name = "Barkod";
            dgvProizvodi.Columns[1].Width = 100;
            dgvProizvodi.Columns[2].Name = "Naziv";
            dgvProizvodi.Columns[3].Name = "Cijena";
            dgvProizvodi.Columns[3].Width = 60;
            dgvProizvodi.Columns[4].Name = "Količina";
            dgvProizvodi.Columns[4].Width = 60;
            dgvProizvodi.Columns[5].Name = "Kategorija";
            dgvProizvodi.Columns[6].Name = "Proizvođač";
            dgvProizvodi.Columns[7].Name = "Dobavljač";

            dgvProizvodi.ForeColor = Color.OrangeRed;
            FillGrid();
        }

        void FillGrid()
        {
            dgvProizvodi.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetProizvodeFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvProizvodi, p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kolicina, p.Kategorija.Naziv, p.Proizvodjac.Naziv, p.Dobavljac.Naziv);

                dgvProizvodi.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }


        void FillComboBox()
        {
            cbDobavljac.DataSource = DbHciSupermarket.GetDobavljaci();
            cbKategorija.DataSource = DbHciSupermarket.GetKategorije();
            cbProizvodjac.DataSource = DbHciSupermarket.GetProizvodjaci();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sellersForm = new SellerssForm();
            sellersForm.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form producerForm = new ProducerForm();
            producerForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form dF = new SupplierForm();
            dF.Show();
            this.Hide();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (tbBarkod.Text == "" || tbBarkod.Text.Length != 13)
            {
                MessageBox.Show("Niste popunili polje `Barkod`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbNaziv.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Naziv`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbCijena.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Cijena`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else if (tbKolicina.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Količina`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            

            else
            {
                /*decimal decValue;

            if (decimal.TryParse(strOrderID, out decValue)
            { this is a decimal 
                        }
                            else
                        {  not a decimal }
                        * */


                decimal number;
                bool result = decimal.TryParse(tbCijena.Text, out number);

                if (!result)
                {
                    MessageBox.Show("Niste pravilno popunili polje `Cijena`. Unesite decimalni broj u polje.", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }

                else
                {

                    decimal number1;
                    bool result1 = decimal.TryParse(tbKolicina.Text, out number1);

                    if (!result1)
                    {
                        MessageBox.Show("Niste pravilno popunili polje `Količina`. Unesite decmalni broj u polje.", "Upozorenje",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                    }

                    else
                    {


                        string barkod = tbBarkod.Text;
                        bool postoji = false;



                        for (int i = 0; i < trenutniPodaci.Count; i++)
                        {
                            if (trenutniPodaci[i].Barkod.Equals(barkod))
                            {
                                MessageBox.Show("Postoji proizvod sa istim barkodom", "Upozorenje",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                                postoji = true;
                                break;
                            }
                        }

                        if (!postoji)
                        {

                            var z = new Proizvod()
                            {
                                Barkod = tbBarkod.Text,
                                Naziv = tbNaziv.Text,
                                Cijena = decimal.Parse(tbCijena.Text),
                                Kolicina = decimal.Parse(tbKolicina.Text),
                                Kategorija = (Kategorija)cbKategorija.SelectedItem,
                                Proizvodjac = (Proizvodjac)cbProizvodjac.SelectedItem,
                                Dobavljac = (Dobavljac)cbDobavljac.SelectedItem
                            };




                            DbHciSupermarket.insertProizvod(z);
                            FillGrid();

                            trenutniPodaci = new List<Proizvod>();
                            trenutniPodaci = DbHciSupermarket.getProizvode();

                            tbBarkod.Text = "";
                            tbNaziv.Text = "";
                            tbCijena.Text = "";
                            tbKolicina.Text = "";
                        }
                    }
                }
            }
        }


        static string selectedId;
        static int selectedIdInt;

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProizvodi.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan red", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {

                int rowindex = dgvProizvodi.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvProizvodi.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                bool koristi = false;

                for (int i = 0; i < DbHciSupermarket.GetSveStavke().Count(); i++)
                {
                    if (DbHciSupermarket.GetSveStavke()[i].Proizvod.ProizvodId == selectedIdInt)
                    {
                        koristi = true;
                        break;
                    }
                }

                if (!koristi) 
                { 
                    DbHciSupermarket.DeleteProizvodById(selectedIdInt);
                    MessageBox.Show("Proizvod je obrisan!");
                    FillGrid();
                }

                else
                {
                    MessageBox.Show("Ne možete obrisati proizvod, jer postoji stavka računa koja koristi dati proizvod.", "Upozorenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
               
            }
        }

        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            int rowindex = dgvProizvodi.CurrentCell.RowIndex;
            int columnindex = 0;
            selectedId = dgvProizvodi.Rows[rowindex].Cells[columnindex].Value.ToString();
            selectedIdInt = Int32.Parse(selectedId);

            DataGridViewRow row = dgvProizvodi.Rows[rowindex];

            string kategorijaS = row.Cells[5].Value.ToString();
            string proizvodjacS = row.Cells[6].Value.ToString();
            string dobavljacS = row.Cells[7].Value.ToString();
            

            var z = new Proizvod()
            {
                ProizvodId = Int32.Parse(row.Cells[0].Value.ToString()),
                Barkod = row.Cells[1].Value.ToString(),
                Naziv = row.Cells[2].Value.ToString(),
                Cijena = decimal.Parse(row.Cells[3].Value.ToString()),
                Kolicina = decimal.Parse(row.Cells[4].Value.ToString()),
                Kategorija = DbHciSupermarket.GetKategorijaNaOsnovuNaziva(kategorijaS),
                Proizvodjac = DbHciSupermarket.GetProizvodjacNaOsnovuNaziva(proizvodjacS),
                Dobavljac = DbHciSupermarket.GetDobavljacNaOsnovuNaziva(dobavljacS)
            };

            Proizvod zz = new Proizvod();
            for (int i = 0; i < trenutniPodaci.Count; i++)
            {
                if (trenutniPodaci[i].ProizvodId == z.ProizvodId)
                {
                    zz = trenutniPodaci[i];
                    break;
                }
            }

            
            if (z.ProizvodId != zz.ProizvodId || !z.Barkod.Equals(zz.Barkod) || !z.Naziv.Equals(zz.Naziv) || !z.Kategorija.Equals(zz.Kategorija) || !z.Proizvodjac.Equals(zz.Proizvodjac) || !z.Dobavljac.Equals(zz.Dobavljac))
            {
                MessageBox.Show("Ne možete mijenjati ovaj podatak", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                FillGrid();
            }
            else
            {
                DbHciSupermarket.UpdateProizvoda(z);
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
