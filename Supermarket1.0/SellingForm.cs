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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Supermarket1._0
{
    public partial class SellingForm : Form
    {

        List<Proizvod> trenutniPodaciProizvodi = new List<Proizvod>();
        List<Racun> trenutniRacuni = new List<Racun>();

        List<StavkaRacuna> stavkeTrenutnogRacuna = new List<StavkaRacuna>();

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

        public SellingForm()
        {
            InitializeComponent();
            
            this.MouseDown += new MouseEventHandler(move_window);
            trenutniPodaciProizvodi = DbHciSupermarket.getProizvode();
            dgvProizvodi.ColumnCount = 5;

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
            dgvProizvodi.Columns[2].Name = "Naziv";
            dgvProizvodi.Columns[3].Name = "Cijena";
            dgvProizvodi.Columns[3].Width = 70;
            dgvProizvodi.Columns[4].Name = "Kategorija";

            dgvProizvodi.ForeColor = Color.OrangeRed;

            dgvRacun.ColumnCount = 4;

            dgvRacun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRacun.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvRacun.AllowUserToAddRows = false;
            dgvRacun.RowHeadersVisible = false;
            dgvRacun.AllowUserToResizeRows = false;
            dgvRacun.AllowUserToDeleteRows = true;
            dgvRacun.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRacun.Columns[0].Name = "Barkod";
            dgvRacun.Columns[1].Name = "Naziv";
            dgvRacun.Columns[2].Name = "Kolicina";
            dgvRacun.Columns[3].Name = "Cijena";

            dgvRacun.ForeColor = Color.OrangeRed;

            tbUkupnaCijena.Text = "0.00";

            FillGridProducts();
        }

        void FillGridProducts()
        {
            dgvProizvodi.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetProizvodeFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvProizvodi, p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kategorija.Naziv, p.Kategorija);

                dgvProizvodi.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Da li ste sigurni da želite napusiti aplikaciju?", "Potvrdite napuštanje aplikacije", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ans.ToString() == "OK")
            {
                Application.Exit();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            Form billsForm = new BillsForm();
            billsForm.Show();
        }*/

        private void button7_Click(object sender, EventArgs e)
        {
            Form startPageForm = new StartPageForm();
            startPageForm.Show();
            this.Hide();
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if(tbFilter.Text.Equals("Unesite bar kod proizvoda"))
                tbFilter.Text = "";
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGridProducts();
        }

        static string selectedId;
        static int selectedIdInt;

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProizvodi.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan proizvod", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            else
            {
                int rowindex = dgvProizvodi.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvProizvodi.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                DataGridViewRow row = dgvProizvodi.Rows[rowindex];

                var odabraniProizvod = new Proizvod();

                int proizvodId = Int32.Parse(row.Cells[0].Value.ToString());

                int i = 0;

                for (; i < trenutniPodaciProizvodi.Count(); i++)
                {
                    if (trenutniPodaciProizvodi[i].ProizvodId == proizvodId)
                    {
                        odabraniProizvod = trenutniPodaciProizvodi[i];
                        break;
                    }
                }

                if (tbKolicinaProizvoda.Text.Equals(""))
                {
                    MessageBox.Show("Unesite količinu proizvoda!", "Upozorenje",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }

                else
                {
                    decimal value = Decimal.Parse(tbKolicinaProizvoda.Text);

                    if (value > odabraniProizvod.Kolicina)
                    {
                        MessageBox.Show("Unesena količina nije dobra! Trenutna količina proizvoda "+odabraniProizvod.Naziv+" je "+odabraniProizvod.Kolicina.ToString(), "Upozorenje",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                    }
                    else 
                    {
                        bool vecPostojiNaRacunu = false;

                        for(int m = 0; m < stavkeTrenutnogRacuna.Count(); m++)
                        {
                            if (stavkeTrenutnogRacuna[m].Proizvod.Barkod.Equals(odabraniProizvod.Barkod))
                            {
                                vecPostojiNaRacunu = true;
                                break;
                            }
                        }

                        if (!vecPostojiNaRacunu)
                        {
                            StavkaRacuna stavkaRacuna = new StavkaRacuna();
                            //int idStavke = DbHciSupermarket.GetSveStavke()[DbHciSupermarket.GetSveStavke().Count() - 1].StavkaRacunaId + 1;
                            stavkaRacuna.Proizvod = odabraniProizvod;

                            //stavkaRacuna.StavkaRacunaId = idStavke;
                            //stavkaRacuna.Racun = trenutniRacuni[trenutniRacuni.Count - 1];
                            stavkaRacuna.Kolicina = Decimal.Parse(tbKolicinaProizvoda.Text);
                            trenutniPodaciProizvodi[i].Kolicina -= Decimal.Parse(tbKolicinaProizvoda.Text);
                            stavkaRacuna.Cijena = odabraniProizvod.Cijena * Decimal.Parse(tbKolicinaProizvoda.Text);
                            stavkeTrenutnogRacuna.Add(stavkaRacuna);

                            DataGridViewRow noviRed = new DataGridViewRow();
                            noviRed.CreateCells(dgvRacun);
                            //noviRed.Cells[0].Value = stavkaRacuna.StavkaRacunaId;
                            noviRed.Cells[0].Value = stavkaRacuna.Proizvod.Barkod;
                            noviRed.Cells[1].Value = stavkaRacuna.Proizvod.Naziv;
                            noviRed.Cells[2].Value = tbKolicinaProizvoda.Text;
                            noviRed.Cells[3].Value = Math.Round(stavkaRacuna.Cijena, 2);
                            dgvRacun.Rows.Add(noviRed);

                            decimal trenutnaUkupnaCijena = 0;
                            if (!tbUkupnaCijena.Text.Equals("0.00"))
                            {
                                trenutnaUkupnaCijena = Decimal.Parse(tbUkupnaCijena.Text);
                            }
                            trenutnaUkupnaCijena += odabraniProizvod.Cijena * Decimal.Parse(tbKolicinaProizvoda.Text);

                            tbUkupnaCijena.Text = Math.Round(trenutnaUkupnaCijena, 2).ToString();
                        }
                        else
                        {
                            int b = 0;
                            for (; b < stavkeTrenutnogRacuna.Count(); b++)
                            {
                                if (stavkeTrenutnogRacuna[b].Proizvod.Barkod.Equals(odabraniProizvod.Barkod))
                                {
                                    break;
                                }
                            }

                            string brojRedova = dgvRacun.Rows.Count.ToString();

                            int brojRedovaInt = Int32.Parse(brojRedova);
                            int k = 0; //stavka na racunu 
                            
                            for (; k < brojRedovaInt; k++)
                            {
                                if (odabraniProizvod.Barkod.Equals(dgvRacun.Rows[k].Cells[0].Value.ToString()))
                                {
                                    break;
                                }
                            }

                            string ll = dgvRacun.Rows[k].Cells[2].Value.ToString();
                            decimal llD = decimal.Parse(ll);
                            llD += Decimal.Parse(tbKolicinaProizvoda.Text);
                            dgvRacun.Rows[k].Cells[2].Value = llD;

                            stavkeTrenutnogRacuna[b].Kolicina = llD;

                            //do sada radi sve okej

                            trenutniPodaciProizvodi[i].Kolicina -= Decimal.Parse(tbKolicinaProizvoda.Text);

                            decimal newCijena = odabraniProizvod.Cijena * decimal.Parse(tbKolicinaProizvoda.Text);
                            string staraCijena = dgvRacun.Rows[k].Cells[3].Value.ToString();

                            decimal sC = decimal.Parse(staraCijena);

                            dgvRacun.Rows[k].Cells[3].Value = Math.Round(newCijena + sC, 2);

                            stavkeTrenutnogRacuna[b].Cijena = newCijena + sC;

                            tbUkupnaCijena.Text = Math.Round((decimal.Parse(tbUkupnaCijena.Text) + newCijena), 2).ToString();


                        }

                        tbKolicinaProizvoda.Text = "";

                    }

                }
            }

        }

        public string selectedBarkod = "";
        
        private void btnBrisiSaRacuna_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProizvodi.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan proizvod", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            else
            {
                int rowindex = dgvRacun.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedBarkod = dgvRacun.Rows[rowindex].Cells[columnindex].Value.ToString();
                //selectedIdInt = Int32.Parse(selectedId);

                DataGridViewRow row = dgvRacun.Rows[rowindex];

                var odabranaStavka = new StavkaRacuna();

                string stavkaBarkod = row.Cells[0].Value.ToString();

                int i = 0;

                for (; i < stavkeTrenutnogRacuna.Count(); i++)
                {
                    if (stavkeTrenutnogRacuna[i].Proizvod.Barkod.Equals(stavkaBarkod))
                    {
                        odabranaStavka = stavkeTrenutnogRacuna[i];
                        break;
                    }
                }

                stavkeTrenutnogRacuna.RemoveAt(i); //brisi stavku

                string kolicina = dgvRacun.Rows[rowindex].Cells[2].Value.ToString();

                int j = 0;
                
                for (; j < trenutniPodaciProizvodi.Count(); j++)
                {
                    if (odabranaStavka.Proizvod.Barkod.Equals(trenutniPodaciProizvodi[j].Barkod))
                    {
                        trenutniPodaciProizvodi[j].Kolicina += Decimal.Parse(kolicina);
                        break;
                    }
                }

               // stavkeTrenutnogRacuna[i].Kolicina += Decimal.Parse(kolicina);//vracena kolicina,
                //jos ga obrisati iz reda i ukupnu cijenu korigovati

                string cijenaOdabranog = dgvRacun.Rows[rowindex].Cells[3].Value.ToString();

                tbUkupnaCijena.Text = Math.Round(Decimal.Parse(tbUkupnaCijena.Text) - Decimal.Parse(cijenaOdabranog), 2).ToString();

                dgvRacun.Rows.Remove(dgvRacun.CurrentRow);

            }

        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvProizvodi.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan proizvod", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }

            else
            {

                if (tbKolicinaProizvoda.Text.Equals(""))
                {
                    MessageBox.Show("Unesite novu količinu", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                }

                else
                {
                    int rowindex = dgvRacun.CurrentCell.RowIndex;
                    int columnindex = 1;
                    selectedBarkod = dgvRacun.Rows[rowindex].Cells[columnindex].Value.ToString();
                    // selectedIdInt = Int32.Parse(selectedId);

                    DataGridViewRow row = dgvRacun.Rows[rowindex];

                    var odabranaStavka = new StavkaRacuna();

                    string stavkaBarkod = row.Cells[0].Value.ToString();

                    decimal novaKolicina = decimal.Parse(tbKolicinaProizvoda.Text);

                    int m = 0;

                    for (; m < stavkeTrenutnogRacuna.Count(); m++)
                    {
                        if (stavkeTrenutnogRacuna[m].Proizvod.Barkod.Equals(stavkaBarkod))
                        {
                            odabranaStavka = stavkeTrenutnogRacuna[m];
                            break;
                        }
                    }

                    decimal staraKolicina = odabranaStavka.Kolicina;

                    int j = 0;
                    for (; j < trenutniPodaciProizvodi.Count(); j++)
                    {
                        if (odabranaStavka.Proizvod.Barkod.Equals(trenutniPodaciProizvodi[j].Barkod))
                        {

                            break;
                        }
                    }

                    decimal value = decimal.Parse(tbKolicinaProizvoda.Text);

                    if (value > trenutniPodaciProizvodi[j].Kolicina)
                    {
                        MessageBox.Show("Unesena količina nije dobra! Trenutna količina proizvoda " + trenutniPodaciProizvodi[j].Naziv + " je " + trenutniPodaciProizvodi[j].Kolicina.ToString(), "Upozorenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                        tbKolicinaProizvoda.Text = "";
                    }

                    else
                    {

                        dgvRacun.Rows[rowindex].Cells[2].Value = novaKolicina;

                        trenutniPodaciProizvodi[j].Kolicina += staraKolicina;

                        dgvRacun.Rows[rowindex].Cells[2].Value = tbKolicinaProizvoda.Text;
                        dgvRacun.Rows[rowindex].Cells[3].Value = Math.Round(novaKolicina * trenutniPodaciProizvodi[j].Cijena, 2);

                        string brojRedova = dgvRacun.Rows.Count.ToString();

                        int brojRedovaInt = Int32.Parse(brojRedova);

                        decimal brojUTextBoxuUkupno = Decimal.Parse(tbUkupnaCijena.Text);

                        trenutniPodaciProizvodi[j].Kolicina -= novaKolicina;

                        //azuriraj stavke na racunu
                        stavkeTrenutnogRacuna[m].Kolicina = novaKolicina;
                        stavkeTrenutnogRacuna[m].Cijena = novaKolicina * trenutniPodaciProizvodi[j].Cijena;

                        //sve dobro -> sada izracunati novu cijenu
                        decimal novaCijena = 0;
                        int k = 0;
                        for (; k < brojRedovaInt; k++)
                        {
                            if (k != rowindex)
                            {
                                string nc = dgvRacun.Rows[k].Cells[3].Value.ToString();
                                novaCijena += decimal.Parse(nc);
                            }
                        }

                        novaCijena += odabranaStavka.Proizvod.Cijena * decimal.Parse(tbKolicinaProizvoda.Text);

                        tbUkupnaCijena.Text = Math.Round(novaCijena, 2).ToString();

                        tbKolicinaProizvoda.Text = "";

                    }
                }
            }
        }

        private void btnNoviRacun_Click(object sender, EventArgs e)
        {
            stavkeTrenutnogRacuna = new List<StavkaRacuna>();
            tbUkupnaCijena.Text = "0.00";
            tbKolicinaProizvoda.Text = "";

            dgvRacun.Rows.Clear();
            dgvRacun.Refresh();

            trenutniPodaciProizvodi = DbHciSupermarket.getProizvode();

            Zaposleni z = DbHciSupermarket.trenutniPrijavljeniRadnik[0];
        }

        private void btnStampajRacun_Click(object sender, EventArgs e)
        {

            if (dgvRacun.Rows.Count == 0)
            {
                MessageBox.Show("Niste dodali ni jednu stavku na račun!", "Upozorenje",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }

            else
            {
                Racun racun = new Racun();
                decimal noviBrojRacuna=0;
                string stringBroja = "";
                int poslednjiRacun = 0;

                decimal brojProslogRacuna = 0;

                if (DbHciSupermarket.GetSveRacune().Count() != 0)
                {
                    poslednjiRacun = DbHciSupermarket.GetSveRacune()[DbHciSupermarket.GetSveRacune().Count() - 1].RacunId;
                    brojProslogRacuna = decimal.Parse(DbHciSupermarket.GetSveRacune()[DbHciSupermarket.GetSveRacune().Count() - 1].BrojRacuna)+1;

                    stringBroja = poslednjiRacun.ToString();
                    noviBrojRacuna = decimal.Parse(stringBroja) + 1;

                }
                string brR = "";

                for (int i = 0; i < (8 - noviBrojRacuna.ToString().Length); i++)
                {
                    brR += "0";
                }

                brR += brojProslogRacuna.ToString();

                if (brR.Length < 8)
                {
                    brR = "0" + brR;
                }

                racun.BrojRacuna = brR;
                racun.UkupnaCijena = Decimal.Parse(tbUkupnaCijena.Text);
                racun.Zaposleni = DbHciSupermarket.trenutniPrijavljeniRadnik[0];

                //path za racune***************
                string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName+"\\Racuni\\"+ brR+".pdf";

                racun.RacunPath = path;

                DbHciSupermarket.insertRacun(racun);

                for(int i = 0; i < stavkeTrenutnogRacuna.Count(); i++)
                {
                    stavkeTrenutnogRacuna[i].Racun = DbHciSupermarket.GetSveRacune()[DbHciSupermarket.GetSveRacune().Count() - 1];
                    DbHciSupermarket.insertStavka(stavkeTrenutnogRacuna[i]);
                }
                 //postavi nove kolicine
                List<Proizvod> stariPodaci = DbHciSupermarket.getProizvode();

                for(int i = 0; i < stariPodaci.Count(); i++)
                {
                    if (stariPodaci[i].Kolicina != trenutniPodaciProizvodi[i].Kolicina)
                    {
                        DbHciSupermarket.UpdateProizvoda(trenutniPodaciProizvodi[i]);
                    }
                }

                //sada napravi i otvori PDF

                string datum = DbHciSupermarket.GetSveRacune()[DbHciSupermarket.GetSveRacune().Count() - 1].DatumIzdavanja.ToString();

                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(racun.RacunPath, FileMode.Create));
                document.Open();
                Paragraph p = new Paragraph("SUPERMARKET");
                p.Alignment = Element.ALIGN_CENTER;
                p.Font.Size = 20;
                document.Add(p);
                Paragraph p1 = new Paragraph("  ");
                p1.Alignment = Element.ALIGN_CENTER;
                p1.Font.Size = 20;
                document.Add(p1);
                Paragraph p2 = new Paragraph("  ");
                p2.Alignment = Element.ALIGN_CENTER;
                p2.Font.Size = 20;
                document.Add(p2);

                Paragraph p3 = new Paragraph("Vrijeme izdavanja racuna: "+ datum);
                p3.Alignment = Element.ALIGN_LEFT;
                p3.Font.Size = 16;
                document.Add(p3);

                Paragraph p4 = new Paragraph("Prodavac: " + racun.Zaposleni.Ime + " " + racun.Zaposleni.Prezime);
                p4.Alignment = Element.ALIGN_LEFT;
                p4.Font.Size = 16;
                document.Add(p4);

                document.Add(p2);
                Paragraph p5 = new Paragraph("Stavke racuna:" );
                p5.Alignment = Element.ALIGN_LEFT;
                p5.Font.Size = 16;
                document.Add(p5);

                document.Add(p2);
                for (int i = 0; i < stavkeTrenutnogRacuna.Count(); i++)
                {
                    decimal originalnaCijena = 0;
                    for(int b = 0; b < DbHciSupermarket.GetSveStavke().Count(); b++)
                    {
                        if (DbHciSupermarket.GetSveStavke()[b].Proizvod.Barkod.Equals(stavkeTrenutnogRacuna[i].Proizvod.Barkod))
                        {
                            originalnaCijena = DbHciSupermarket.GetSveStavke()[b].Proizvod.Cijena;
                            break;
                        }
                    }
                    Paragraph pp = new Paragraph(stavkeTrenutnogRacuna[i].Proizvod.Naziv );
                    Paragraph ppp = new Paragraph(originalnaCijena + "      x " + stavkeTrenutnogRacuna[i].Kolicina + "     cijena: " + Math.Round(stavkeTrenutnogRacuna[i].Cijena, 2) + " KM");

                   pp.Alignment = Element.ALIGN_LEFT;
                    pp.Font.Size = 16;
                    ppp.Alignment = Element.ALIGN_LEFT;
                    ppp.Font.Size = 16;
                    document.Add(pp);
                    document.Add(ppp);
                }

                document.Add(p2);
                Paragraph p6 = new Paragraph("UKUPNO ZA PLATITI: " + racun.UkupnaCijena+" KM");
                p6.Alignment = Element.ALIGN_RIGHT;
                p6.Font.Size = 16;
                document.Add(p6);

                document.Close();

                System.Diagnostics.Process.Start(racun.RacunPath);
            }

        }
    }
}
