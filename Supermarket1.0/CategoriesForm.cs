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
    public partial class CategoriesForm : Form
    {
        List<Kategorija> trenutniPodaci;

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
        public CategoriesForm()
        {
            InitializeComponent();
            trenutniPodaci = DbHciSupermarket.GetKategorije();
            this.MouseDown += new MouseEventHandler(move_window);

            dgvKategorije.ColumnCount = 3;

            dgvKategorije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategorije.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvKategorije.AllowUserToAddRows = false;
            dgvKategorije.RowHeadersVisible = false;
            dgvKategorije.AllowUserToResizeRows = false;
            dgvKategorije.AllowUserToDeleteRows = true;
            dgvKategorije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvKategorije.Columns[0].Name = "Id";
            dgvKategorije.Columns[0].Width = 25;
            dgvKategorije.Columns[1].Name = "Naziv";
            dgvKategorije.Columns[1].Width = 150;
            dgvKategorije.Columns[2].Name = "Opis";

            dgvKategorije.ForeColor = Color.OrangeRed;
            FillGrid();
        }

        void FillGrid()
        {
            dgvKategorije.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetKategorijeFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvKategorije, p.KategorijaId, p.Naziv, p.Opis);

                dgvKategorije.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form sellersForm = new SellerssForm();
            sellersForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form startPageForm = new StartPageForm();
            startPageForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            if (tbNaziv.Text == "")
            {
                MessageBox.Show("Niste popunili polje `Naziv`", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                string nazivKategorije = tbNaziv.Text;
                bool postoji = false;

                for(int i=0; i<trenutniPodaci.Count; i++)
                {
                    if (trenutniPodaci[i].Naziv.Equals(nazivKategorije))
                    {
                        MessageBox.Show("Postoji kategorija sa istim nazivom", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        postoji = true;
                        break;
                    }
                }

                if (!postoji)
                {
                    var k = new Kategorija()
                    {
                        Naziv = tbNaziv.Text,
                        Opis = tbOpis.Text
                    };

                    DbHciSupermarket.insertKategoriju(k);
                    FillGrid();

                    trenutniPodaci = new List<Kategorija>();
                    trenutniPodaci = DbHciSupermarket.GetKategorije();

                    tbNaziv.Text = "";
                    tbOpis.Text = "";

                }
            }
        }

        static string selectedId;
        static int selectedIdInt;

        private void bObrisi_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvKategorije.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan red", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvKategorije.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvKategorije.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                if (!DbHciSupermarket.ProizvodKoristiKategoriju(selectedIdInt))
                {

                    DbHciSupermarket.DeleteKategorijaById(selectedIdInt);
                    MessageBox.Show("Kategorija je obrisana!");
                    FillGrid();
                }
                else
                {
                    MessageBox.Show("Ne možete obrisati kategoriju, jer postoji proizvod sa datim kategorijom.", "Upozorenje",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
        }

        private void bIzmjeni_Click(object sender, EventArgs e)
        {
            int rowindex = dgvKategorije.CurrentCell.RowIndex;
            int columnindex = 0;
            selectedId = dgvKategorije.Rows[rowindex].Cells[columnindex].Value.ToString();
            selectedIdInt = Int32.Parse(selectedId);

            DataGridViewRow row = dgvKategorije.Rows[rowindex];

            string opiss="";
            if (row.Cells[2].Value==null)
            {
                opiss = " ";
            }
            else
            {
                opiss = row.Cells[2].Value.ToString();
            }

            var k = new Kategorija()
            {
                KategorijaId = Int32.Parse(row.Cells[0].Value.ToString()),
                Naziv = row.Cells[1].Value.ToString(),
                
                Opis = opiss,
            };

            Kategorija zz = new Kategorija();
            for (int i = 0; i < trenutniPodaci.Count; i++)
            {
                if (trenutniPodaci[i].KategorijaId == k.KategorijaId)
                {
                    zz = trenutniPodaci[i];
                    break;
                }
            }

            //z je promijenjeni zaposleni, trebamo vidjeti da li je promijenjeno nesto sto se ne smije mijenjati
            if (k.Naziv != zz.Naziv || k.KategorijaId!= zz.KategorijaId)
            {
                MessageBox.Show("Ne možete mijenjati ovaj podatak", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                FillGrid();
            }
            else
            {
                DbHciSupermarket.UpdateKategorije(k);
                FillGrid();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form dF = new SupplierForm();
            dF.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form producerForm = new ProducerForm();
            producerForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form dF = new ExEmployeesForm();
            dF.Show();
            this.Hide();
        }
    }
}
