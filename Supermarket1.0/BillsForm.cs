using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket1._0
{
    public partial class BillsForm : Form
    {
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

        public BillsForm()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(move_window);

            dgvRacini.ColumnCount = 3;

            dgvRacini.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRacini.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvRacini.AllowUserToAddRows = false;
            dgvRacini.RowHeadersVisible = false;
            dgvRacini.AllowUserToResizeRows = false;
            dgvRacini.AllowUserToDeleteRows = true;
            dgvRacini.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRacini.Columns[0].Name = "Broj računa";
            dgvRacini.Columns[1].Name = "Prodavac";
            dgvRacini.Columns[2].Name = "Datum kreiranja";

            FillGrid();

        }

        void FillGrid()
        {
            dgvRacini.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetRacuneFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvRacini, p.BrojRacuna, p.Zaposleni.Ime + " " + p.Zaposleni.Prezime, p.DatumIzdavanja);

                dgvRacini.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        string brojRacuna = "";

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvRacini.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan racun", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvRacini.CurrentCell.RowIndex;
                int columnindex = 0;
                brojRacuna = dgvRacini.Rows[rowindex].Cells[columnindex].Value.ToString();

                

                int idRacuna=0;

                for(int i = 0; i < DbHciSupermarket.GetSveRacune().Count(); i++)
                {
                    if (DbHciSupermarket.GetSveRacune()[i].BrojRacuna.Equals(brojRacuna))
                    {
                        idRacuna = DbHciSupermarket.GetSveRacune()[i].RacunId;
                        break;
                    }
                }

                

                DialogResult ans = MessageBox.Show("Da li ste sigurni da želite obrisati račun?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ans.ToString() == "OK")
                {

                    List<StavkaRacuna> stavkeRacuna = DbHciSupermarket.GetSveStavke();

                    int i = 0;

                    for (; i < stavkeRacuna.Count(); i++)
                    {
                        if (stavkeRacuna[i].Racun.RacunId == idRacuna)
                        {
                            DbHciSupermarket.DeleteStavkaRacunaByIdRacuna(idRacuna);
                            break;
                        }
                    }

                   // DbHciSupermarket.DeleteRacunByNumber(brojRacuna);


                    string pathRacuna = "";

                    for (i = 0; i < DbHciSupermarket.GetSveRacune().Count(); i++)
                    {
                        if (DbHciSupermarket.GetSveRacune()[i].BrojRacuna.Equals(brojRacuna))
                        {
                            pathRacuna = DbHciSupermarket.GetSveRacune()[i].RacunPath;
                            break;
                        }
                    }


                    File.Delete(@pathRacuna);

                    i = 0;

                    for (; i < stavkeRacuna.Count(); i++)
                     {
                         if (stavkeRacuna[i].Racun.RacunId == idRacuna)
                         {
                             DbHciSupermarket.DeleteStavkaRacunaByIdRacuna(idRacuna);
                             break;
                         }
                     }

                     DbHciSupermarket.DeleteRacunByNumber(brojRacuna);

                }

                //File.Delete(Path.Combine(rootFolder, authorsFile)); 

                FillGrid();

            }
        }

        private void btnPogledaj_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvRacini.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jedan racun", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvRacini.CurrentCell.RowIndex;
                int columnindex = 0;
                brojRacuna = dgvRacini.Rows[rowindex].Cells[columnindex].Value.ToString();

                string pathRacuna = "";

                for (int i = 0; i < DbHciSupermarket.GetSveRacune().Count(); i++)
                {
                    if (DbHciSupermarket.GetSveRacune()[i].BrojRacuna.Equals(brojRacuna))
                    {
                        pathRacuna = DbHciSupermarket.GetSveRacune()[i].RacunPath;
                        break;
                    }
                }

                System.Diagnostics.Process.Start(pathRacuna);

            }   
        }
    }
}
