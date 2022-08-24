using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Supermarket1._0
{
    class DbHciSupermarket
    {
        private static readonly string connection_stringg = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;

        public static List<Zaposleni> trenutniPrijavljeniRadnik = new List<Zaposleni>() { new Zaposleni() }; 

        public static List<VrstaZaposlenog> GetVrsteZaposlenog()
        {
            List<VrstaZaposlenog> result = new List<VrstaZaposlenog>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT VrstaZaposlenogId, Naziv FROM `vrstazaposlenog` ORDER BY VrstaZaposlenogId";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new VrstaZaposlenog()
                {
                    VrstaZaposlenogId = reader.GetInt32(0),
                    Naziv = reader.GetString(1)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static VrstaZaposlenog GetVrstaZap(string naziv)
        {
            VrstaZaposlenog vz = new VrstaZaposlenog();
            List<VrstaZaposlenog> result = GetVrsteZaposlenog();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Naziv.Equals(naziv))
                {
                    vz = result[i];
                    break;
                }
            }

            return vz;
        }

        public static Kategorija GetKategorijaNaOsnovuNaziva(string naziv)
        {
            Kategorija k = new Kategorija();
            List<Kategorija> result = GetKategorije();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Naziv.Equals(naziv))
                {
                    k = result[i];
                    break;
                }
            }
            return k;
        }

        public static Proizvodjac GetProizvodjacNaOsnovuNaziva(string naziv)
        {
            Proizvodjac k = new Proizvodjac();
            List<Proizvodjac> result = GetProizvodjaci();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Naziv.Equals(naziv))
                {
                    k = result[i];
                    break;
                }
            }
            return k;
        }

        public static Dobavljac GetDobavljacNaOsnovuNaziva(string naziv)
        {
            Dobavljac k = new Dobavljac();
            List<Dobavljac> result = GetDobavljaci();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Naziv.Equals(naziv))
                {
                    k = result[i];
                    break;
                }
            }
            return k;
        }

        public static List<Zaposleni> getZaposlene()
        {
            List<Zaposleni> result = new List<Zaposleni>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT zaposleniid, z.JMB, z.ime, z.prezime, z.brojtelefona," +
                "z.email, z.plata, z.datumod, z.korisnickoime, z.lozinka, v.vrstazaposlenogid," +
                "v.naziv FROM `zaposleni` z inner join `vrstazaposlenog` v on z.vrstazaposlenogid = v.vrstazaposlenogid ORDER BY zaposleniid";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Zaposleni()
                {
                    ZaposleniId = reader.GetInt32(0),
                    JMB = reader.GetString(1),
                    Ime = reader.GetString(2),
                    Prezime = reader.GetString(3),
                    BrojTelefona = reader.GetString(4),
                    Email = reader.GetString(5),
                    Plata = reader.GetInt32(6),
                    DatumOd = reader.GetDateTime(7),
                    KorisnickoIme = reader.GetString(8),
                    Lozinka = reader.GetString(9),
                    VrstaZaposlenog = new VrstaZaposlenog()
                    {
                        VrstaZaposlenogId = reader.GetInt32(10),
                        Naziv = reader.GetString(11)
                    }
                });

            }
            reader.Close();
            conn.Close();

            return result;
        }

        public static void insertZaposleni(Zaposleni zaposleni)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO zaposleni(JMB, Ime, Prezime, BrojTelefona, Email, Plata, DatumOd, KorisnickoIme, Lozinka, VrstaZaposlenogId)
                  VALUES (@JMB, @Ime, @Prezime, @BrojTelefona, @Email, @Plata, @DatumOd, @KorisnickoIme, @Lozinka, @VrstaZaposlenogId)";
            cmd.Parameters.AddWithValue("@JMB", zaposleni.JMB);
            cmd.Parameters.AddWithValue("@Ime", zaposleni.Ime);
            cmd.Parameters.AddWithValue("@Prezime", zaposleni.Prezime);
            cmd.Parameters.AddWithValue("@BrojTelefona", zaposleni.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", zaposleni.Email);
            cmd.Parameters.AddWithValue("@Plata", zaposleni.Plata);
            cmd.Parameters.AddWithValue("@DatumOd", zaposleni.DatumOd);
            cmd.Parameters.AddWithValue("@KorisnickoIme", zaposleni.KorisnickoIme);
            cmd.Parameters.AddWithValue("@Lozinka", zaposleni.Lozinka);
            cmd.Parameters.AddWithValue("@VrstaZaposlenogId", zaposleni.VrstaZaposlenog.VrstaZaposlenogId);
            cmd.ExecuteNonQuery();
            zaposleni.ZaposleniId = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static List<Zaposleni> GetZaposleneFilter(string filter)
        {
            List<Zaposleni> result = new List<Zaposleni>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata, p.DatumOd, p.KorisnickoIme, p.Lozinka, 
                  g.VrstaZaposlenogId, g.Naziv, p.KrajRadnogOdnosa 
                  FROM zaposleni p
                  INNER JOIN `vrstazaposlenog` g ON g.VrstaZaposlenogId=p.VrstaZaposlenogId
                  WHERE (p.JMB LIKE @str OR p.Ime LIKE @str OR p.Prezime LIKE @str OR p.BrojTelefona LIKE @str OR p.Email LIKE @str OR p.Plata LIKE @str OR p.DatumOd LIKE @str OR p.KorisnickoIme LIKE @str OR p.Lozinka LIKE @str OR g.Naziv LIKE @str )
                   and KrajRadnogOdnosa like '%no%' 
                    ORDER BY p.ZaposleniId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Zaposleni()
                {
                    ZaposleniId = reader.GetInt32(0),
                    JMB = reader.GetString(1),
                    Ime = reader.GetString(2),
                    Prezime = reader.GetString(3),
                    BrojTelefona = reader.GetString(4),
                    Email = reader.GetString(5),
                    Plata = reader.GetInt32(6),
                    DatumOd = reader.GetDateTime(7),
                    KorisnickoIme = reader.GetString(8),
                    Lozinka = reader.GetString(9),
                    VrstaZaposlenog = new VrstaZaposlenog()
                    {
                        VrstaZaposlenogId = reader.GetInt32(10),
                        Naziv = reader.GetString(11)
                    },
                    KrajRadnogOdnosa = reader.GetString(12)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }


        /*****/ //ex zaposleni
        public static List<Zaposleni> GetExZaposleneFilter(string filter)
        {
            List<Zaposleni> result = new List<Zaposleni>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata, p.DatumOd, p.KorisnickoIme, p.Lozinka, 
                  g.VrstaZaposlenogId, g.Naziv, p.KrajRadnogOdnosa 
                  FROM zaposleni p
                  INNER JOIN `vrstazaposlenog` g ON g.VrstaZaposlenogId=p.VrstaZaposlenogId
                  WHERE (p.JMB LIKE @str OR p.Ime LIKE @str OR p.Prezime LIKE @str OR p.BrojTelefona LIKE @str OR p.Email LIKE @str OR p.Plata LIKE @str OR p.DatumOd LIKE @str OR p.KorisnickoIme LIKE @str OR p.Lozinka LIKE @str OR g.Naziv LIKE @str )
                   and KrajRadnogOdnosa like '%yes%' 
                    ORDER BY p.ZaposleniId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Zaposleni()
                {
                    ZaposleniId = reader.GetInt32(0),
                    JMB = reader.GetString(1),
                    Ime = reader.GetString(2),
                    Prezime = reader.GetString(3),
                    BrojTelefona = reader.GetString(4),
                    Email = reader.GetString(5),
                    Plata = reader.GetInt32(6),
                    DatumOd = reader.GetDateTime(7),
                    KorisnickoIme = reader.GetString(8),
                    Lozinka = reader.GetString(9),
                    VrstaZaposlenog = new VrstaZaposlenog()
                    {
                        VrstaZaposlenogId = reader.GetInt32(10),
                        Naziv = reader.GetString(11)
                    },
                    KrajRadnogOdnosa = reader.GetString(12)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static bool koristiSeKategorijaZaProizvod(int idKategorije)
        {
           bool zap = false;
            /*
            List<Zaposleni> result = getZaposlene();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ZaposleniId==id)
                {
                    zap = true;
                    break;
                }
            }
           */
            return zap;
        }



        public static void UpdateZaposlenog(Zaposleni zaposleni)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE zaposleni SET " + "BrojTelefona = @BrojTelefona,"
                + "Email= @Email," + "Plata=@Plata," +
                "KorisnickoIme= @KorisnickoIme," + "Lozinka=@" + "Lozinka" +
                " where ZaposleniId=@ZaposleniId";


            cmd.Parameters.AddWithValue("@BrojTelefona", zaposleni.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", zaposleni.Email);
            cmd.Parameters.AddWithValue("@Plata", zaposleni.Plata);
            cmd.Parameters.AddWithValue("@KorisnickoIme", zaposleni.KorisnickoIme);
            cmd.Parameters.AddWithValue("@Lozinka", zaposleni.Lozinka);
            cmd.Parameters.AddWithValue("@ZaposleniId", zaposleni.ZaposleniId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateZaposlenogSadasnjegggg(Zaposleni zaposleni)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE zaposleni SET " + "KrajRadnogOdnosa = 'no'," +
                " datumOd = now() " +
                 " where ZaposleniId=@ZaposleniId";

            cmd.Parameters.AddWithValue("@ZaposleniId", zaposleni.ZaposleniId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static void UpdateZaposlenogBivseg(Zaposleni zaposleni)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
           cmd.CommandText = "UPDATE zaposleni SET " + "KrajRadnogOdnosa = 'yes' "+
                " where ZaposleniId=@ZaposleniId";

            cmd.Parameters.AddWithValue("@ZaposleniId", zaposleni.ZaposleniId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteZaposleniById(int zId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM zaposleni WHERE ZaposleniId=@ZaposleniId";
            cmd.Parameters.AddWithValue("@ZaposleniId", zId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void insertKategoriju(Kategorija kategorija)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO kategorijaproizvoda(Naziv, Opis)
                  VALUES (@Naziv, @Opis)";
            cmd.Parameters.AddWithValue("@Naziv", kategorija.Naziv);
            cmd.Parameters.AddWithValue("@Opis", kategorija.Opis);
            cmd.ExecuteNonQuery();
            kategorija.KategorijaId = (int)cmd.LastInsertedId;
            conn.Close();
        }


        public static List<Kategorija> GetKategorijeFilter(string filter)
        {
            List<Kategorija> result = new List<Kategorija>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT KategorijaProizvodaId, Naziv, Opis
                  FROM kategorijaproizvoda
                  WHERE Naziv LIKE @str OR Opis LIKE @str 
                  ORDER BY KategorijaProizvodaId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Kategorija()
                {
                    KategorijaId = reader.GetInt32(0),
                    Naziv = reader.GetString(1),
                    Opis = reader.GetString(2)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void UpdateKategorije(Kategorija kategorija)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE kategorijaproizvoda SET " + "Opis = @Opis  where KategorijaProizvodaId=@KategorijaId";

            cmd.Parameters.AddWithValue("@Opis", kategorija.Opis);
            cmd.Parameters.AddWithValue("@KategorijaId", kategorija.KategorijaId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteKategorijaById(int kId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM kategorijaproizvoda WHERE KategorijaProizvodaId=@KategorijaId";
            cmd.Parameters.AddWithValue("@KategorijaId", kId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static List<Kategorija> GetKategorije()
        {
            List<Kategorija> result = new List<Kategorija>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `kategorijaproizvoda` ORDER BY KategorijaProizvodaId";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Kategorija()
                {
                    KategorijaId = reader.GetInt32(0),
                    Naziv = reader.GetString(1),
                    Opis = reader.GetString(2)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void insertProizvodjac(Proizvodjac proizvodjac)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO proizvodjac(JIB, Naziv, BrojTelefona, Email)
                  VALUES (@JIB, @Naziv, @BrojTelefona, @Email)";
            cmd.Parameters.AddWithValue("@JIB", proizvodjac.JIB);
            cmd.Parameters.AddWithValue("@Naziv", proizvodjac.Naziv);
            cmd.Parameters.AddWithValue("@BrojTelefona", proizvodjac.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", proizvodjac.Email);
            cmd.ExecuteNonQuery();
            proizvodjac.ProizvodjacId = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static List<Proizvodjac> GetProizvodjaci()
        {
            List<Proizvodjac> result = new List<Proizvodjac>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `proizvodjac`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvodjac()
                {
                    ProizvodjacId = reader.GetInt32(0),
                    JIB = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    BrojTelefona = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteProizvodjacById(int kId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM proizvodjac WHERE ProizvodjacId=@ProizvodjacId";
            cmd.Parameters.AddWithValue("@ProizvodjacId", kId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void UpdateProizvodjac(Proizvodjac proizvodjac)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE proizvodjac SET " + "BrojTelefona = @BrojTelefona, Email = @Email  where ProizvodjacId=@ProizvodjacId";

            cmd.Parameters.AddWithValue("@BrojTelefona", proizvodjac.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", proizvodjac.Email);
            cmd.Parameters.AddWithValue("@ProizvodjacId", proizvodjac.ProizvodjacId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public static List<Proizvodjac> GetProizvodjaciFilter(string filter)
        {
            List<Proizvodjac> result = new List<Proizvodjac>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT * FROM `proizvodjac`
                  WHERE JIB LIKE @str OR Naziv LIKE @str OR BrojTelefona LIKE @str OR Email LIKE @str 
                  ORDER BY ProizvodjacId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvodjac()
                {
                    ProizvodjacId = reader.GetInt32(0),
                    JIB = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    BrojTelefona = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void insertDobavljac(Dobavljac dobavljac)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO dobavljac(JIB, Naziv, BrojTelefona, Email)
                  VALUES (@JIB, @Naziv, @BrojTelefona, @Email)";
            cmd.Parameters.AddWithValue("@JIB", dobavljac.JIB);
            cmd.Parameters.AddWithValue("@Naziv", dobavljac.Naziv);
            cmd.Parameters.AddWithValue("@BrojTelefona", dobavljac.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", dobavljac.Email);
            cmd.ExecuteNonQuery();
            dobavljac.DobavljacId = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static List<Dobavljac> GetDobavljaci()
        {
            List<Dobavljac> result = new List<Dobavljac>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `dobavljac`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Dobavljac()
                {
                    DobavljacId = reader.GetInt32(0),
                    JIB = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    BrojTelefona = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteDobavljacById(int kId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM dobavljac WHERE DobavljacId=@DobavljacId";
            cmd.Parameters.AddWithValue("@DobavljacId", kId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateDobavljac(Dobavljac dobavljac)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE dobavljac SET " + "BrojTelefona = @BrojTelefona, Email = @Email  where DobavljacId=@DobavljacId";

            cmd.Parameters.AddWithValue("@BrojTelefona", dobavljac.BrojTelefona);
            cmd.Parameters.AddWithValue("@Email", dobavljac.Email);
            cmd.Parameters.AddWithValue("@DobavljacId", dobavljac.DobavljacId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Dobavljac> GetDobavljaciFilter(string filter)
        {
            List<Dobavljac> result = new List<Dobavljac>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT * FROM `dobavljac`
                  WHERE JIB LIKE @str OR Naziv LIKE @str OR BrojTelefona LIKE @str OR Email LIKE @str 
                  ORDER BY DobavljacId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Dobavljac()
                {
                    DobavljacId = reader.GetInt32(0),
                    JIB = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    BrojTelefona = reader.GetString(3),
                    Email = reader.GetString(4)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void insertProizvod(Proizvod proizvod)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO proizvod(Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId)
                  VALUES (@Barkod,@Naziv, @Cijena, @Kolicina, @KategorijaProizvodaId, @DobavljacId, @ProizvodjacId)";
            cmd.Parameters.AddWithValue("@Barkod", proizvod.Barkod);
            cmd.Parameters.AddWithValue("@Naziv", proizvod.Naziv);
            cmd.Parameters.AddWithValue("@Cijena", proizvod.Cijena);
            cmd.Parameters.AddWithValue("@Kolicina", proizvod.Kolicina);
            cmd.Parameters.AddWithValue("@KategorijaProizvodaId", proizvod.Kategorija.KategorijaId);
            cmd.Parameters.AddWithValue("@DobavljacId", proizvod.Dobavljac.DobavljacId);
            cmd.Parameters.AddWithValue("@ProizvodjacId", proizvod.Proizvodjac.ProizvodjacId);
            cmd.ExecuteNonQuery();
            proizvod.ProizvodId = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static List<Proizvod> GetProizvodeFilter(string filter)
        {
            List<Proizvod> result = new List<Proizvod>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kolicina, 
                  k.KategorijaProizvodaId, k.Naziv, k.Opis, 
                  pr.ProizvodjacId,  pr.JIB, pr.Naziv, pr.BrojTelefona, pr.Email,
                  d.DobavljacId, d.JIB, d.Naziv, d.BrojTelefona, d.Email
                  FROM proizvod p
                  INNER JOIN `kategorijaproizvoda` k ON k.KategorijaProizvodaId=p.KategorijaProizvodaId
                  INNER JOIN `proizvodjac` pr on pr.ProizvodjacId=p.ProizvodjacId 
                  INNER JOIN `dobavljac` d on d.DobavljacId=p.DobavljacId 
                  WHERE p.ProizvodId LIKE @str OR p.Barkod LIKE @str OR p.Naziv LIKE @str OR p.Cijena LIKE @str OR p.Kolicina LIKE @str OR k.Naziv LIKE @str OR pr.Naziv LIKE @str OR d.Naziv LIKE @str 
                  ORDER BY p.ProizvodId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvod()
                {
                    ProizvodId = reader.GetInt32(0),
                    Barkod = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    Cijena = reader.GetDecimal(3),
                    Kolicina = reader.GetDecimal(4),
                    Kategorija = new Kategorija()
                    {
                        KategorijaId =reader.GetInt32(5), 
                        Naziv = reader.GetString(6),
                        Opis = reader.GetString(7),
                    },
                    Proizvodjac = new Proizvodjac()
                    {
                        ProizvodjacId = reader.GetInt32(8),
                        JIB = reader.GetString(9),
                        Naziv = reader.GetString(10),
                        BrojTelefona = reader.GetString(11),
                        Email = reader.GetString(12),
                    },
                    Dobavljac = new Dobavljac()
                    {
                        DobavljacId = reader.GetInt32(13),
                        JIB = reader.GetString(14),
                        Naziv = reader.GetString(15),
                        BrojTelefona = reader.GetString(16),
                        Email = reader.GetString(17),
                    }
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void UpdateProizvoda(Proizvod proizvod)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE proizvod SET " + " Cijena = @Cijena, "
                + "Kolicina= @Kolicina" +
                " where ProizvodId=@ProizvodId";
            cmd.Parameters.AddWithValue("@Cijena", proizvod.Cijena);
            cmd.Parameters.AddWithValue("@Kolicina", proizvod.Kolicina);
            cmd.Parameters.AddWithValue("@ProizvodId", proizvod.ProizvodId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteProizvodById(int zId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM proizvod WHERE ProizvodId=@ProizvodId";
            cmd.Parameters.AddWithValue("@ProizvodId", zId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Proizvod> getProizvode()
        {
            List<Proizvod> result = new List<Proizvod>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kolicina, " +
                "k.KategorijaProizvodaId, k.Naziv, k.Opis, "+
                  "pr.ProizvodjacId,  pr.JIB, pr.Naziv, pr.BrojTelefona, pr.Email, "+
                  "d.DobavljacId, d.JIB, d.Naziv, d.BrojTelefona, d.Email "+
                  "FROM proizvod p "+
                  "INNER JOIN `kategorijaproizvoda` k ON k.KategorijaProizvodaId = p.KategorijaProizvodaId "+
                  "INNER JOIN `proizvodjac` pr on pr.ProizvodjacId = p.ProizvodjacId "+
                  "INNER JOIN `dobavljac` d on d.DobavljacId = p.DobavljacId  ORDER BY p.ProizvodId ";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvod()
                {
                    ProizvodId = reader.GetInt32(0),
                    Barkod = reader.GetString(1),
                    Naziv = reader.GetString(2),
                    Cijena = reader.GetDecimal(3),
                    Kolicina = reader.GetDecimal(4),
                    Kategorija = new Kategorija()
                    {
                        KategorijaId = reader.GetInt32(5),
                        Naziv = reader.GetString(6),
                        Opis = reader.GetString(7),
                    },
                    Proizvodjac = new Proizvodjac()
                    {
                        ProizvodjacId = reader.GetInt32(8),
                        JIB = reader.GetString(9),
                        Naziv = reader.GetString(10),
                        BrojTelefona = reader.GetString(11),
                        Email = reader.GetString(12),
                    },
                    Dobavljac = new Dobavljac()
                    {
                        DobavljacId = reader.GetInt32(13),
                        JIB = reader.GetString(14),
                        Naziv = reader.GetString(15),
                        BrojTelefona = reader.GetString(16),
                        Email = reader.GetString(17),
                    }
                });

            }
            reader.Close();
            conn.Close();

            return result;
        }

        public static bool ProizvodKoristiKategoriju (int idKategorije)
        {
            bool rez = false;
            List<Proizvod> sviProizvodi = getProizvode();
            for(int i = 0; i < sviProizvodi.Count; i++)
            {
                if (sviProizvodi[i].Kategorija.KategorijaId == idKategorije)
                {
                    rez = true;
                    break;
                }
            }
            return rez;
        }

        public static bool ProizvodKoristiProizvodjaca(int idProizvodjaca)
        {
            bool rez = false;
            List<Proizvod> sviProizvodi = getProizvode();
            for (int i = 0; i < sviProizvodi.Count; i++)
            {
                if (sviProizvodi[i].Proizvodjac.ProizvodjacId == idProizvodjaca)
                {
                    rez = true;
                    break;
                }
            }
            return rez;
        }

        public static bool ProizvodKoristiDobavljaca(int idDobavljaca)
        {
            bool rez = false;
            List<Proizvod> sviProizvodi = getProizvode();
            for (int i = 0; i < sviProizvodi.Count; i++)
            {
                if (sviProizvodi[i].Dobavljac.DobavljacId == idDobavljaca)
                {
                    rez = true;
                    break;
                }
            }
            return rez;
        }

        public static void insertRacun(Racun racun)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO racun(BrojRacuna, UkupnaCijena, ZaposleniId, RacunPath)
                  VALUES (@BrojRacuna,@UkupnaCijena, @ZaposleniId, @RacunPath);
                     ";
            cmd.Parameters.AddWithValue("@BrojRacuna", racun.BrojRacuna);
            cmd.Parameters.AddWithValue("@UkupnaCijena", racun.UkupnaCijena);
            cmd.Parameters.AddWithValue("@ZaposleniId", racun.Zaposleni.ZaposleniId);
            cmd.Parameters.AddWithValue("@RacunPath", racun.RacunPath);
            cmd.ExecuteNonQuery();
            racun.RacunId = (int)cmd.LastInsertedId;
            conn.Close();

            conn = new MySqlConnection(connection_stringg);
            conn.Open();
             cmd = conn.CreateCommand();
            cmd.CommandText = "update racun set DatumIzdavanja = now() where RacunId=@RacunId";
            cmd.Parameters.AddWithValue("@RacunId", racun.RacunId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteRacunByNumber(string num)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM racun WHERE BrojRacuna=@num";
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<Racun> GetSveRacune()
        {
            List<Racun> result = new List<Racun>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT r.RacunId, r.BrojRacuna, r.UkupnaCijena, r.DatumIzdavanja, " +
                "p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata, p.DatumOd, p.KorisnickoIme, p.Lozinka, "
+                 " g.VrstaZaposlenogId, g.Naziv,  " +
                        " r.RacunPath " +
                " FROM `racun` r inner join `zaposleni` p on r.ZaposleniId= p.ZaposleniId " +
                "inner join `vrstazaposlenog` g on p.VrstaZaposlenogId=g.VrstaZaposlenogId " +
                " order by r.RacunId";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Racun()
                {
                    RacunId = reader.GetInt32(0),
                    BrojRacuna = reader.GetString(1),
                    UkupnaCijena = reader.GetDecimal(2),
                    DatumIzdavanja = reader.GetDateTime(3),
                    Zaposleni = new Zaposleni
                    {
                        ZaposleniId = reader.GetInt32(4),
                        JMB = reader.GetString(5),
                        Ime = reader.GetString(6),
                        Prezime = reader.GetString(7),
                        BrojTelefona = reader.GetString(8),
                        Email = reader.GetString(9),
                        Plata = reader.GetInt32(10),
                        DatumOd = reader.GetDateTime(11),
                        KorisnickoIme = reader.GetString(12),
                        Lozinka = reader.GetString(13),
                        VrstaZaposlenog = new VrstaZaposlenog()
                        {
                            VrstaZaposlenogId = reader.GetInt32(14),
                            Naziv = reader.GetString(15)
                        }
                    },
                    RacunPath = reader.GetString(16)
                }); 
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Racun> GetRacuneFilter(string filter)
        {
            List<Racun> result = new List<Racun>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT r.RacunId, r.BrojRacuna, r.UkupnaCijena, r.DatumIzdavanja, " +
                "p.ZaposleniId, p.JMB, p.Ime, p.Prezime, p.BrojTelefona, p.Email, p.Plata, p.DatumOd, p.KorisnickoIme, p.Lozinka, "
                + " g.VrstaZaposlenogId, g.Naziv,  " +
                        " r.RacunPath " +
                " FROM `racun` r inner join `zaposleni` p on r.ZaposleniId= p.ZaposleniId " +
                "inner join `vrstazaposlenog` g on p.VrstaZaposlenogId=g.VrstaZaposlenogId "+

                 " WHERE r.BrojRacuna LIKE @str or p.Ime Like @str or r.DatumIzdavanja like @str " +
                "  ORDER BY r.RacunId";
            cmd.Parameters.AddWithValue("@str", filter + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Racun()
                {
                    RacunId = reader.GetInt32(0),
                    BrojRacuna = reader.GetString(1),
                    UkupnaCijena = reader.GetDecimal(2),
                    DatumIzdavanja = reader.GetDateTime(3),
                    Zaposleni = new Zaposleni
                    {
                        ZaposleniId = reader.GetInt32(4),
                        JMB = reader.GetString(5),
                        Ime = reader.GetString(6),
                        Prezime = reader.GetString(7),
                        BrojTelefona = reader.GetString(8),
                        Email = reader.GetString(9),
                        Plata = reader.GetInt32(10),
                        DatumOd = reader.GetDateTime(11),
                        KorisnickoIme = reader.GetString(12),
                        Lozinka = reader.GetString(13),
                        VrstaZaposlenog = new VrstaZaposlenog()
                        {
                            VrstaZaposlenogId = reader.GetInt32(14),
                            Naziv = reader.GetString(15)
                        }
                    },
                    RacunPath = reader.GetString(16)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<StavkaRacuna> GetStavkeNaOsnovuRacunId(int id)
        {
            List<StavkaRacuna> result = new List<StavkaRacuna>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT s.StavkaRacunaId,  s.Kolicina, 
                    p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kolicina, " +
                "k.KategorijaProizvodaId, k.Naziv, k.Opis, " +
                  "pr.ProizvodjacId,  pr.JIB, pr.Naziv, pr.BrojTelefona, pr.Email, " +
                  "d.DobavljacId, d.JIB, d.Naziv, d.BrojTelefona, d.Email, "+
                " r.RacunId, r.BrojRacuna, r.UkupnaCijena, r.DatumIzdavanja, " +
                "pp.ZaposleniId, pp.JMB, pp.Ime, pp.Prezime, pp.BrojTelefona, pp.Email, pp.Plata, pp.DatumOd, pp.KorisnickoIme, pp.Lozinka, "
                + " g.VrstaZaposlenogId, g.Naziv,  " +
                        " r.RacunPath, s.Cijena " +
                " FROM `stavkaracuna` s inner join `proizvod` p on s.ProizvodId= p.ProizvodId " +
               " INNER JOIN `kategorijaproizvoda` k ON k.KategorijaProizvodaId = p.KategorijaProizvodaId " +
                  "INNER JOIN `proizvodjac` pr on pr.ProizvodjacId = p.ProizvodjacId " +
                  "INNER JOIN `dobavljac` d on d.DobavljacId = p.DobavljacId "+
                  "inner join racun r on s.RacunId= r.RacunId "+
                "  inner join `zaposleni` pp on r.ZaposleniId = pp.ZaposleniId " +
                     "inner join `vrstazaposlenog` g on pp.VrstaZaposlenogId=g.VrstaZaposlenogId " +
                  " WHERE r.RacunId= @id " +
                "  ORDER BY r.RacunId";
            cmd.Parameters.AddWithValue("@id", id + "%");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new StavkaRacuna()
                {
                    StavkaRacunaId = reader.GetInt32(0),
                    Kolicina = reader.GetDecimal(1),
                    Proizvod = new Proizvod
                    {
                        ProizvodId = reader.GetInt32(2),
                        Barkod = reader.GetString(3),
                        Naziv = reader.GetString(4),
                        Cijena = reader.GetDecimal(5),
                        Kolicina = reader.GetDecimal(6),
                        Kategorija = new Kategorija()
                        {
                            KategorijaId = reader.GetInt32(7),
                            Naziv = reader.GetString(8),
                            Opis = reader.GetString(9),
                        },
                        Proizvodjac = new Proizvodjac()
                        {
                            ProizvodjacId = reader.GetInt32(10),
                            JIB = reader.GetString(11),
                            Naziv = reader.GetString(12),
                            BrojTelefona = reader.GetString(13),
                            Email = reader.GetString(14),
                        },
                        Dobavljac = new Dobavljac()
                        {
                            DobavljacId = reader.GetInt32(15),
                            JIB = reader.GetString(16),
                            Naziv = reader.GetString(17),
                            BrojTelefona = reader.GetString(18),
                            Email = reader.GetString(19),
                        }
                    },
                    
                    Racun = new Racun()
                    {
                        RacunId = reader.GetInt32(20),
                        BrojRacuna = reader.GetString(21),
                        UkupnaCijena = reader.GetDecimal(22),
                        DatumIzdavanja = reader.GetDateTime(23),
                        Zaposleni = new Zaposleni
                        {
                            ZaposleniId = reader.GetInt32(44),
                            JMB = reader.GetString(25),
                            Ime = reader.GetString(26),
                            Prezime = reader.GetString(27),
                            BrojTelefona = reader.GetString(28),
                            Email = reader.GetString(29),
                            Plata = reader.GetInt32(30),
                            DatumOd = reader.GetDateTime(31),
                            KorisnickoIme = reader.GetString(22),
                            Lozinka = reader.GetString(33),
                            VrstaZaposlenog = new VrstaZaposlenog()
                            {
                                VrstaZaposlenogId = reader.GetInt32(34),
                                Naziv = reader.GetString(35)
                            }
                        },
                        RacunPath = reader.GetString(36)
                    },
                    Cijena = reader.GetDecimal(37)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteStavkaRacunaByIdRacuna(int zId)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM stavkaracuna WHERE RacunId=@RacunId";
            cmd.Parameters.AddWithValue("@RacunId", zId);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static List<StavkaRacuna> GetSveStavke()
        {
            List<StavkaRacuna> result = new List<StavkaRacuna>();
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"SELECT s.StavkaRacunaId,  s.Kolicina, 

                    p.ProizvodId, p.Barkod, p.Naziv, p.Cijena, p.Kolicina, " +
                "k.KategorijaProizvodaId, k.Naziv, k.Opis, " +
                  "pr.ProizvodjacId,  pr.JIB, pr.Naziv, pr.BrojTelefona, pr.Email, " +
                  "d.DobavljacId, d.JIB, d.Naziv, d.BrojTelefona, d.Email, " +

                " r.RacunId, r.BrojRacuna, r.UkupnaCijena, r.DatumIzdavanja, " +
                "pp.ZaposleniId, pp.JMB, pp.Ime, pp.Prezime, pp.BrojTelefona, pp.Email, pp.Plata, " +
                "pp.DatumOd, pp.KorisnickoIme, pp.Lozinka, "
                + " g.VrstaZaposlenogId, g.Naziv,  " +
                        " r.RacunPath, " +
                        "" +
                        "s.Cijena " +

                " FROM `stavkaracuna` s inner join `proizvod` p on s.ProizvodId= p.ProizvodId " +
               " INNER JOIN `kategorijaproizvoda` k ON k.KategorijaProizvodaId = p.KategorijaProizvodaId " +
                  "INNER JOIN `proizvodjac` pr on pr.ProizvodjacId = p.ProizvodjacId " +
                  "INNER JOIN `dobavljac` d on d.DobavljacId = p.DobavljacId " +
                  "inner join racun r on s.RacunId= r.RacunId " +
                "  inner join `zaposleni` pp on r.ZaposleniId = pp.ZaposleniId " +
                     "inner join `vrstazaposlenog` g on pp.VrstaZaposlenogId=g.VrstaZaposlenogId " +

                     "order by s.StavkaRacunaId";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new StavkaRacuna()
                {
                    StavkaRacunaId = reader.GetInt32(0),
                    Kolicina = reader.GetDecimal(1),
                    Proizvod = new Proizvod
                    {
                        ProizvodId = reader.GetInt32(2),
                        Barkod = reader.GetString(3),
                        Naziv = reader.GetString(4),
                        Cijena = reader.GetDecimal(5),
                        Kolicina = reader.GetDecimal(6),
                        Kategorija = new Kategorija()
                        {
                            KategorijaId = reader.GetInt32(7),
                            Naziv = reader.GetString(8),
                            Opis = reader.GetString(9),
                        },
                        Proizvodjac = new Proizvodjac()
                        {
                            ProizvodjacId = reader.GetInt32(10),
                            JIB = reader.GetString(11),
                            Naziv = reader.GetString(12),
                            BrojTelefona = reader.GetString(13),
                            Email = reader.GetString(14),
                        },
                        Dobavljac = new Dobavljac()
                        {
                            DobavljacId = reader.GetInt32(15),
                            JIB = reader.GetString(16),
                            Naziv = reader.GetString(17),
                            BrojTelefona = reader.GetString(18),
                            Email = reader.GetString(19),
                        }
                    },

                    Racun = new Racun()
                    {
                        RacunId = reader.GetInt32(20),
                        BrojRacuna = reader.GetString(21),
                        UkupnaCijena = reader.GetDecimal(22),
                        DatumIzdavanja = reader.GetDateTime(23),
                        Zaposleni = new Zaposleni
                        {
                            ZaposleniId = reader.GetInt32(24),
                            JMB = reader.GetString(25),
                            Ime = reader.GetString(26),
                            Prezime = reader.GetString(27),
                            BrojTelefona = reader.GetString(28),
                            Email = reader.GetString(29),
                            Plata = reader.GetInt32(30),
                            DatumOd = reader.GetDateTime(31),
                            KorisnickoIme = reader.GetString(32),
                            Lozinka = reader.GetString(33),
                            VrstaZaposlenog = new VrstaZaposlenog()
                            {
                                VrstaZaposlenogId = reader.GetInt32(34),
                                Naziv = reader.GetString(35)
                            }
                        },
                        RacunPath = reader.GetString(36)
                    },
                    Cijena = reader.GetDecimal(37)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void insertStavka(StavkaRacuna stavkaRacuna)
        {
            MySqlConnection conn = new MySqlConnection(connection_stringg);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO stavkaracuna(Kolicina, ProizvodId, RacunId, Cijena)
                  VALUES (@Kolicina,@ProizvodId, @RacunId, @Cijena);
                     ";
            cmd.Parameters.AddWithValue("@Kolicina", stavkaRacuna.Kolicina);
            cmd.Parameters.AddWithValue("@ProizvodId", stavkaRacuna.Proizvod.ProizvodId);
            cmd.Parameters.AddWithValue("@RacunId", stavkaRacuna.Racun.RacunId);
            cmd.Parameters.AddWithValue("@Cijena", stavkaRacuna.Cijena);
            cmd.ExecuteNonQuery();
            stavkaRacuna.StavkaRacunaId = (int)cmd.LastInsertedId;
            conn.Close();
        }

    }
}
