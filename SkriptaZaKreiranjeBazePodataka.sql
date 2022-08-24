-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema supermarketdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema supermarketdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `supermarketdb` DEFAULT CHARACTER SET utf8 ;
USE `supermarketdb` ;

-- -----------------------------------------------------
-- Table `supermarketdb`.`dobavljac`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`dobavljac` (
  `DobavljacId` INT NOT NULL AUTO_INCREMENT,
  `JIB` VARCHAR(13) NOT NULL,
  `Naziv` VARCHAR(45) NOT NULL,
  `BrojTelefona` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`DobavljacId`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`kategorijaproizvoda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`kategorijaproizvoda` (
  `KategorijaProizvodaId` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(45) NOT NULL,
  `Opis` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`KategorijaProizvodaId`))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`proizvodjac`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`proizvodjac` (
  `ProizvodjacId` INT NOT NULL AUTO_INCREMENT,
  `JIB` VARCHAR(13) NOT NULL,
  `Naziv` VARCHAR(45) NOT NULL,
  `BrojTelefona` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ProizvodjacId`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`proizvod`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`proizvod` (
  `ProizvodId` INT NOT NULL AUTO_INCREMENT,
  `Barkod` VARCHAR(45) NOT NULL,
  `Naziv` VARCHAR(45) NOT NULL,
  `Cijena` DECIMAL(6,2) NOT NULL,
  `Kolicina` DECIMAL(10,2) NOT NULL,
  `KategorijaProizvodaId` INT NOT NULL,
  `DobavljacId` INT NOT NULL,
  `ProizvodjacId` INT NOT NULL,
  PRIMARY KEY (`ProizvodId`),
  INDEX `fk_Proizvod_KategorijaProizvoda1_idx` (`KategorijaProizvodaId` ASC) VISIBLE,
  INDEX `fk_Proizvod_Dobavljac1_idx` (`DobavljacId` ASC) VISIBLE,
  INDEX `fk_Proizvod_Proizvodjac1_idx` (`ProizvodjacId` ASC) VISIBLE,
  CONSTRAINT `fk_Proizvod_Dobavljac1`
    FOREIGN KEY (`DobavljacId`)
    REFERENCES `supermarketdb`.`dobavljac` (`DobavljacId`),
  CONSTRAINT `fk_Proizvod_KategorijaProizvoda1`
    FOREIGN KEY (`KategorijaProizvodaId`)
    REFERENCES `supermarketdb`.`kategorijaproizvoda` (`KategorijaProizvodaId`),
  CONSTRAINT `fk_Proizvod_Proizvodjac1`
    FOREIGN KEY (`ProizvodjacId`)
    REFERENCES `supermarketdb`.`proizvodjac` (`ProizvodjacId`))
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`vrstazaposlenog`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`vrstazaposlenog` (
  `VrstaZaposlenogId` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`VrstaZaposlenogId`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`zaposleni`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`zaposleni` (
  `ZaposleniId` INT NOT NULL AUTO_INCREMENT,
  `JMB` VARCHAR(13) NOT NULL,
  `Ime` VARCHAR(45) NOT NULL,
  `Prezime` VARCHAR(45) NOT NULL,
  `BrojTelefona` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Plata` DECIMAL(7,2) NOT NULL,
  `DatumOd` DATETIME NOT NULL,
  `KorisnickoIme` VARCHAR(13) NOT NULL,
  `Lozinka` VARCHAR(13) NOT NULL,
  `VrstaZaposlenogId` INT NOT NULL,
  `KrajRadnogOdnosa` VARCHAR(4) NULL DEFAULT 'no',
  PRIMARY KEY (`ZaposleniId`),
  INDEX `fk_Zaposleni_VrstaZaposlenog_idx` (`VrstaZaposlenogId` ASC) VISIBLE,
  CONSTRAINT `fk_Zaposleni_VrstaZaposlenog`
    FOREIGN KEY (`VrstaZaposlenogId`)
    REFERENCES `supermarketdb`.`vrstazaposlenog` (`VrstaZaposlenogId`))
ENGINE = InnoDB
AUTO_INCREMENT = 17
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`racun`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`racun` (
  `RacunId` INT NOT NULL AUTO_INCREMENT,
  `BrojRacuna` VARCHAR(8) NOT NULL,
  `UkupnaCijena` DECIMAL(7,2) NULL DEFAULT NULL,
  `DatumIzdavanja` DATETIME NULL DEFAULT NULL,
  `ZaposleniId` INT NOT NULL,
  `RacunPath` VARCHAR(400) NULL DEFAULT NULL,
  PRIMARY KEY (`RacunId`),
  INDEX `fk_Racun_Zaposleni1_idx` (`ZaposleniId` ASC) VISIBLE,
  CONSTRAINT `fk_Racun_Zaposleni1`
    FOREIGN KEY (`ZaposleniId`)
    REFERENCES `supermarketdb`.`zaposleni` (`ZaposleniId`))
ENGINE = InnoDB
AUTO_INCREMENT = 30
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `supermarketdb`.`stavkaracuna`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `supermarketdb`.`stavkaracuna` (
  `StavkaRacunaId` INT NOT NULL AUTO_INCREMENT,
  `Kolicina` DECIMAL(6,2) NOT NULL,
  `ProizvodId` INT NOT NULL,
  `RacunId` INT NOT NULL,
  `Cijena` DECIMAL(7,2) NULL DEFAULT NULL,
  PRIMARY KEY (`StavkaRacunaId`),
  INDEX `fk_StavkaRacuna_Proizvod1_idx` (`ProizvodId` ASC) VISIBLE,
  INDEX `fk_StavkaRacuna_Racun1_idx` (`RacunId` ASC) VISIBLE,
  CONSTRAINT `fk_StavkaRacuna_Proizvod1`
    FOREIGN KEY (`ProizvodId`)
    REFERENCES `supermarketdb`.`proizvod` (`ProizvodId`),
  CONSTRAINT `fk_StavkaRacuna_Racun1`
    FOREIGN KEY (`RacunId`)
    REFERENCES `supermarketdb`.`racun` (`RacunId`))
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
