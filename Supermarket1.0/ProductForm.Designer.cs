
namespace Supermarket1._0
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDobavljac = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbProizvodjac = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBarkod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnIzmjeni = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.cbKategorija = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbCijena = new System.Windows.Forms.TextBox();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnZaposleni = new System.Windows.Forms.Button();
            this.btnKategorije = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.btnRacuni = new System.Windows.Forms.Button();
            this.btnProizvodjaci = new System.Windows.Forms.Button();
            this.btnDobavljaci = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.OrangeRed;
            this.exit.Location = new System.Drawing.Point(902, 9);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(21, 20);
            this.exit.TabIndex = 28;
            this.exit.Text = "X";
            this.exit.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.tbFilter);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbDobavljac);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbProizvodjac);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbBarkod);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dgvProizvodi);
            this.panel1.Controls.Add(this.btnObrisi);
            this.panel1.Controls.Add(this.btnIzmjeni);
            this.panel1.Controls.Add(this.btnDodaj);
            this.panel1.Controls.Add(this.cbKategorija);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbKolicina);
            this.panel1.Controls.Add(this.tbCijena);
            this.panel1.Controls.Add(this.tbNaziv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.Olive;
            this.panel1.Location = new System.Drawing.Point(124, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 521);
            this.panel1.TabIndex = 29;
            this.panel1.UseWaitCursor = true;
            // 
            // tbFilter
            // 
            this.tbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbFilter.Location = new System.Drawing.Point(531, 191);
            this.tbFilter.MaxLength = 13;
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(252, 26);
            this.tbFilter.TabIndex = 26;
            this.tbFilter.UseWaitCursor = true;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.OrangeRed;
            this.label10.Location = new System.Drawing.Point(420, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "Pretraga:";
            this.label10.UseWaitCursor = true;
            // 
            // cbDobavljac
            // 
            this.cbDobavljac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDobavljac.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbDobavljac.FormattingEnabled = true;
            this.cbDobavljac.Location = new System.Drawing.Point(99, 127);
            this.cbDobavljac.Name = "cbDobavljac";
            this.cbDobavljac.Size = new System.Drawing.Size(147, 28);
            this.cbDobavljac.TabIndex = 21;
            this.cbDobavljac.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.OrangeRed;
            this.label8.Location = new System.Drawing.Point(-1, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 24);
            this.label8.TabIndex = 20;
            this.label8.Text = "Dobavljač";
            this.label8.UseWaitCursor = true;
            // 
            // cbProizvodjac
            // 
            this.cbProizvodjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProizvodjac.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbProizvodjac.FormattingEnabled = true;
            this.cbProizvodjac.Location = new System.Drawing.Point(637, 93);
            this.cbProizvodjac.Name = "cbProizvodjac";
            this.cbProizvodjac.Size = new System.Drawing.Size(147, 28);
            this.cbProizvodjac.TabIndex = 19;
            this.cbProizvodjac.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(517, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "Proizvođač";
            this.label9.UseWaitCursor = true;
            // 
            // tbBarkod
            // 
            this.tbBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBarkod.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbBarkod.Location = new System.Drawing.Point(99, 63);
            this.tbBarkod.MaxLength = 13;
            this.tbBarkod.Name = "tbBarkod";
            this.tbBarkod.Size = new System.Drawing.Size(147, 26);
            this.tbBarkod.TabIndex = 9;
            this.tbBarkod.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(18, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "Barkod";
            this.label7.UseWaitCursor = true;
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.BackgroundColor = System.Drawing.Color.White;
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.Location = new System.Drawing.Point(3, 223);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.Size = new System.Drawing.Size(781, 295);
            this.dgvProizvodi.TabIndex = 27;
            this.dgvProizvodi.UseWaitCursor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.White;
            this.btnObrisi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnObrisi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObrisi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObrisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisi.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnObrisi.Location = new System.Drawing.Point(703, 151);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(80, 34);
            this.btnObrisi.TabIndex = 24;
            this.btnObrisi.Text = "OBRIŠI";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.UseWaitCursor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnIzmjeni
            // 
            this.btnIzmjeni.BackColor = System.Drawing.Color.White;
            this.btnIzmjeni.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIzmjeni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIzmjeni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIzmjeni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmjeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmjeni.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnIzmjeni.Location = new System.Drawing.Point(617, 151);
            this.btnIzmjeni.Name = "btnIzmjeni";
            this.btnIzmjeni.Size = new System.Drawing.Size(80, 34);
            this.btnIzmjeni.TabIndex = 23;
            this.btnIzmjeni.Text = "IZMJENI";
            this.btnIzmjeni.UseVisualStyleBackColor = false;
            this.btnIzmjeni.UseWaitCursor = true;
            this.btnIzmjeni.Click += new System.EventHandler(this.btnIzmjeni_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.White;
            this.btnDodaj.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDodaj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDodaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnDodaj.Location = new System.Drawing.Point(531, 151);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(80, 34);
            this.btnDodaj.TabIndex = 22;
            this.btnDodaj.Text = "DODAJ";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.UseWaitCursor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cbKategorija
            // 
            this.cbKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKategorija.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbKategorija.FormattingEnabled = true;
            this.cbKategorija.Location = new System.Drawing.Point(349, 93);
            this.cbKategorija.Name = "cbKategorija";
            this.cbKategorija.Size = new System.Drawing.Size(168, 28);
            this.cbKategorija.TabIndex = 17;
            this.cbKategorija.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.OrangeRed;
            this.label6.Location = new System.Drawing.Point(249, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kategorija";
            this.label6.UseWaitCursor = true;
            // 
            // tbKolicina
            // 
            this.tbKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbKolicina.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbKolicina.Location = new System.Drawing.Point(99, 95);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(147, 26);
            this.tbKolicina.TabIndex = 15;
            this.tbKolicina.UseWaitCursor = true;
            // 
            // tbCijena
            // 
            this.tbCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCijena.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbCijena.Location = new System.Drawing.Point(637, 61);
            this.tbCijena.Name = "tbCijena";
            this.tbCijena.Size = new System.Drawing.Size(147, 26);
            this.tbCijena.TabIndex = 13;
            this.tbCijena.UseWaitCursor = true;
            // 
            // tbNaziv
            // 
            this.tbNaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNaziv.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbNaziv.Location = new System.Drawing.Point(349, 61);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(168, 26);
            this.tbNaziv.TabIndex = 11;
            this.tbNaziv.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(9, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Količina";
            this.label5.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(562, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cijena";
            this.label4.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(277, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Naziv";
            this.label3.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(248, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "UPRAVLjANjE PROIZVODIMA";
            this.label2.UseWaitCursor = true;
            // 
            // btnZaposleni
            // 
            this.btnZaposleni.FlatAppearance.BorderSize = 0;
            this.btnZaposleni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZaposleni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnZaposleni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZaposleni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZaposleni.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnZaposleni.Location = new System.Drawing.Point(5, 55);
            this.btnZaposleni.Name = "btnZaposleni";
            this.btnZaposleni.Size = new System.Drawing.Size(113, 32);
            this.btnZaposleni.TabIndex = 1;
            this.btnZaposleni.Text = "Zaposleni";
            this.btnZaposleni.UseVisualStyleBackColor = true;
            this.btnZaposleni.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKategorije
            // 
            this.btnKategorije.FlatAppearance.BorderSize = 0;
            this.btnKategorije.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKategorije.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKategorije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKategorije.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKategorije.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnKategorije.Location = new System.Drawing.Point(0, 93);
            this.btnKategorije.Name = "btnKategorije";
            this.btnKategorije.Size = new System.Drawing.Size(113, 32);
            this.btnKategorije.TabIndex = 2;
            this.btnKategorije.Text = "Kategorije";
            this.btnKategorije.UseVisualStyleBackColor = true;
            this.btnKategorije.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOdjava
            // 
            this.btnOdjava.FlatAppearance.BorderSize = 0;
            this.btnOdjava.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOdjava.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOdjava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdjava.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnOdjava.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnOdjava.Location = new System.Drawing.Point(12, 512);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(101, 38);
            this.btnOdjava.TabIndex = 6;
            this.btnOdjava.Text = "Odjava";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnRacuni
            // 
            this.btnRacuni.FlatAppearance.BorderSize = 0;
            this.btnRacuni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRacuni.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRacuni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRacuni.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnRacuni.Location = new System.Drawing.Point(12, 131);
            this.btnRacuni.Name = "btnRacuni";
            this.btnRacuni.Size = new System.Drawing.Size(84, 32);
            this.btnRacuni.TabIndex = 3;
            this.btnRacuni.Text = "Računi";
            this.btnRacuni.UseVisualStyleBackColor = true;
            this.btnRacuni.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnProizvodjaci
            // 
            this.btnProizvodjaci.BackColor = System.Drawing.Color.Transparent;
            this.btnProizvodjaci.FlatAppearance.BorderSize = 0;
            this.btnProizvodjaci.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProizvodjaci.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProizvodjaci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProizvodjaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProizvodjaci.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnProizvodjaci.Location = new System.Drawing.Point(-4, 169);
            this.btnProizvodjaci.Name = "btnProizvodjaci";
            this.btnProizvodjaci.Size = new System.Drawing.Size(127, 32);
            this.btnProizvodjaci.TabIndex = 4;
            this.btnProizvodjaci.Text = "Proizvođači";
            this.btnProizvodjaci.UseVisualStyleBackColor = false;
            this.btnProizvodjaci.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnDobavljaci
            // 
            this.btnDobavljaci.BackColor = System.Drawing.Color.Transparent;
            this.btnDobavljaci.FlatAppearance.BorderSize = 0;
            this.btnDobavljaci.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDobavljaci.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDobavljaci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDobavljaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDobavljaci.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnDobavljaci.Location = new System.Drawing.Point(5, 207);
            this.btnDobavljaci.Name = "btnDobavljaci";
            this.btnDobavljaci.Size = new System.Drawing.Size(116, 32);
            this.btnDobavljaci.TabIndex = 5;
            this.btnDobavljaci.Text = "Dobavljači";
            this.btnDobavljaci.UseVisualStyleBackColor = false;
            this.btnDobavljaci.Click += new System.EventHandler(this.button8_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.OrangeRed;
            this.button10.Location = new System.Drawing.Point(-1, 236);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(122, 70);
            this.button10.TabIndex = 6;
            this.button10.Text = "Bivši zaposleni";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 562);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnProizvodjaci);
            this.Controls.Add(this.btnDobavljaci);
            this.Controls.Add(this.btnRacuni);
            this.Controls.Add(this.btnOdjava);
            this.Controls.Add(this.btnKategorije);
            this.Controls.Add(this.btnZaposleni);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnZaposleni;
        private System.Windows.Forms.Button btnKategorije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbCijena;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.ComboBox cbKategorija;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnIzmjeni;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.TextBox tbBarkod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRacuni;
        private System.Windows.Forms.Button btnProizvodjaci;
        private System.Windows.Forms.Button btnDobavljaci;
        private System.Windows.Forms.ComboBox cbDobavljac;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbProizvodjac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button10;
    }
}