use supermarketdb;

insert into supermarketdb.vrstazaposlenog (VrstaZaposlenogId, Naziv) values (1, 'Admin');
insert into supermarketdb.vrstazaposlenog (VrstaZaposlenogId, Naziv) values (2, 'Prodavac');

insert into supermarketdb.zaposleni (ZaposleniId, JMB, Ime, Prezime, BrojTelefona, Email, Plata, DatumOd, KorisnickoIme, Lozinka, VrstaZaposlenogId, KrajRadnogOdnosa) 
values (1, '1234567890123', 'Katarina', 'Antesevic', '+387 66 568 246', 'katarina@gmail.com', 2000, '2022-07-28 15:37:00', 'katarina', 'katarina', 1, 'no');
insert into supermarketdb.zaposleni (ZaposleniId, JMB, Ime, Prezime, BrojTelefona, Email, Plata, DatumOd, KorisnickoIme, Lozinka, VrstaZaposlenogId, KrajRadnogOdnosa) 
values (2, '5687452165895', 'Marija', 'Jekic', '+387 66 589 542', 'maja@gmail.com', 1500, '2022-07-28 15:41:00', 'maja', 'maja', 2, 'no');
insert into supermarketdb.zaposleni (ZaposleniId, JMB, Ime, Prezime, BrojTelefona, Email, Plata, DatumOd, KorisnickoIme, Lozinka, VrstaZaposlenogId, KrajRadnogOdnosa) 
values (3, '1152448556565', 'Aleksamdra', 'Jekic', '+387 66 856 142', 'aca@gmail.com', 1500, '2022-07-28 15:49:00', 'aca', 'aca', 2, 'no');

insert into supermarketdb.kategorijaproizvoda (KategorijaProizvodaId, Naziv, Opis) values (1, 'Mlijecni proizvodi', 'Proizvodi od mlijeka');
insert into supermarketdb.kategorijaproizvoda (KategorijaProizvodaId, Naziv, Opis) values (2, 'Suhomesnati proizvodi', 'Proizvodi od susenog mesa');
insert into supermarketdb.kategorijaproizvoda (KategorijaProizvodaId, Naziv, Opis) values (3, 'Alkoholno pice', 'Pice koje sadrzi alkohol');
insert into supermarketdb.kategorijaproizvoda (KategorijaProizvodaId, Naziv, Opis) values (4, 'Bezalkoholno pice', 'Pice koje ne sadrzi alkohol');

insert into supermarketdb.dobavljac (DobavljacId, JIB, Naziv, BrojTelefona, Email) values 
(1, '8542658512547', 'Dobavljac 1', '+387 51 458 589', 'dobavljac1@gmail.com');
insert into supermarketdb.dobavljac (DobavljacId, JIB, Naziv, BrojTelefona, Email) values 
(2, '8954710265426', 'Dobavljac 2', '+387 51 120 352', 'dobavljac2@gmail.com');

insert into supermarketdb.proizvodjac (ProizvodjacId, JIB, Naziv, BrojTelefona, Email) values 
(1, '6542578965423', 'Proizvodjac 1', '+387 51 658 245', 'proizvodjac1@gmail.com');
insert into supermarketdb.proizvodjac (ProizvodjacId, JIB, Naziv, BrojTelefona, Email) values 
(2, '8569541203256', 'Proizvodjac 2', '+387 52 012 745', 'proizvodjac2@gmail.com');

insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('5895610235495', 'Mlijeko', 2.5, 50.0, 1, 1 , 1);
insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('0005624853589', 'Sir', 3.5, 50.0, 1, 1 , 1);
insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('1112025682955', 'Pavlaka', 1.0, 50.0, 1, 1 , 1);

insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('3365258524025', 'Cajna kobasica', 16.0, 30.0, 2, 2 , 1);
insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('2257852225588', 'Suseni vrat', 22.0, 30.0, 2, 2 , 1);

insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('8545215658745', 'Pivo', 1.5, 100.0, 3, 2 , 2);
insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('8545215658789', 'Crveno vino', 10.5, 100.0, 3, 2 , 2);

insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('8545215658777', 'Sok od jabuke', 2.45, 100.0, 4, 2 , 2);
insert into supermarketdb.proizvod (Barkod, Naziv, Cijena, Kolicina, KategorijaProizvodaId, DobavljacId, ProizvodjacId) 
values ('8545215658788', 'Koka kola', 2.5, 100.0, 4, 2 , 2);