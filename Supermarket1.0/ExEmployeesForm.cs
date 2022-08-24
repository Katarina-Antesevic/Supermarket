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
    public partial class ExEmployeesForm : Form
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

        public ExEmployeesForm()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(move_window);

            
            dgvExZaposleni.ColumnCount = 10;

            dgvExZaposleni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExZaposleni.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvExZaposleni.AllowUserToAddRows = false;
            dgvExZaposleni.RowHeadersVisible = false;
            dgvExZaposleni.AllowUserToResizeRows = false;
            dgvExZaposleni.AllowUserToDeleteRows = true;
            dgvExZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvExZaposleni.Columns[0].Name = "Id";
            dgvExZaposleni.Columns[0].Width = 25;
            dgvExZaposleni.Columns[1].Name = "JMB";

            dgvExZaposleni.Columns[1].Width = 90;
            dgvExZaposleni.Columns[2].Name = "Ime";
            dgvExZaposleni.Columns[3].Name = "Prezime";
            dgvExZaposleni.Columns[4].Name = "Telefon";
            dgvExZaposleni.Columns[5].Name = "Email";
            dgvExZaposleni.Columns[5].Width = 105;
            dgvExZaposleni.Columns[6].Name = "Plata";
            dgvExZaposleni.Columns[6].Width = 40;
            dgvExZaposleni.Columns[7].Name = "Korisničko ime";
            dgvExZaposleni.Columns[7].Width = 70;
            dgvExZaposleni.Columns[8].Name = "Lozinka";
            dgvExZaposleni.Columns[8].Width = 70;
            dgvExZaposleni.Columns[9].Name = "Tip naloga";
            dgvExZaposleni.Columns[9].Width = 65;

            // dgvZaposleni.Columns[11].DefaultCellStyle.NullValue = "";

            dgvExZaposleni.ForeColor = Color.OrangeRed;
            FillGrid();

        }

        void FillGrid()
        {
            dgvExZaposleni.Rows.Clear();
            foreach (var p in DbHciSupermarket.GetExZaposleneFilter(tbFilter.Text))
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dgvExZaposleni, p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata,  p.KorisnickoIme, p.Lozinka, p.VrstaZaposlenog.Naziv);

                dgvExZaposleni.Rows.Add(row);
                // dgvContacts.Rows.Add((p.LastName, p.FirstName, p.Phone, p.Group.Name);
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form dF = new SellerssForm();
            dF.Show();
            this.Hide();

        }

        static string selectedId;
        static int selectedIdInt;

        private void btnPogledaj_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvExZaposleni.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 1)
            {
                MessageBox.Show("Morate izabrati samo jednog bivšeg zaposlenog", "Upozorenje",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            else
            {
                int rowindex = dgvExZaposleni.CurrentCell.RowIndex;
                int columnindex = 0;
                selectedId = dgvExZaposleni.Rows[rowindex].Cells[columnindex].Value.ToString();
                selectedIdInt = Int32.Parse(selectedId);

                DataGridViewRow row = dgvExZaposleni.Rows[rowindex];

                Zaposleni z = new Zaposleni();
                int i = 0;
                for (; i < DbHciSupermarket.getZaposlene().Count(); i++)
                {
                    if (DbHciSupermarket.getZaposlene()[i].ZaposleniId == selectedIdInt)
                    {
                        break;
                    }
                }

                z = DbHciSupermarket.getZaposlene()[i];


                DbHciSupermarket.UpdateZaposlenogSadasnjegggg(z);
                FillGrid();



            }
        
        }
    }
}
