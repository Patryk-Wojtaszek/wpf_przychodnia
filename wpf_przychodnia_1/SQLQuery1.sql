CREATE DATABASE Przychodnia
GO
USE Przychodnia
GO
CREATE TABLE dbo.Pracownicy
		(ID_pracownika int NOT NULL CONSTRAINT pk_prac PRIMARY KEY,
		Specjalizacja varchar(20) NOT NULL,
		Nazwisko varchar(20) NOT NULL,
		Imie varchar(30) NOT NULL,
		Data_urodzenia Date,
		Email varchar(30))
GO
	CREATE TABLE dbo.Pacjenci
		(ID_pacjenta int  NOT NULL CONSTRAINT  pk_pac PRIMARY KEY,
		Nazwisko varchar(30) NOT NULL,
		Imie varchar(20) NOT NULL,
		Data_urodzenia date,
		Pesel varchar(11))
GO
	CREATE TABLE dbo.Rejestracja
		(ID_rejestracji int  NOT NULL CONSTRAINT pk_rej PRIMARY KEY,
		Pacjenci_ID int CONSTRAINT ref_pac REFERENCES Pacjenci(ID_pacjenta),
		Termin DATE)
		GO
	CREATE TABLE dbo.Wizyta
		(ID_wizyty int  NOT NULL CONSTRAINT  pk_wiz PRIMARY KEY,
		Rejestracja_ID int CONSTRAINT ref_rez REFERENCES Rejestracja(ID_rejestracji),
		Pracownicy_ID int CONSTRAINT ref_prac REFERENCES Pracownicy(ID_pracownika),
		Pacjenci_ID int CONSTRAINT ref_pacj REFERENCES Pacjenci(ID_pacjenta),
		Kod_choroby varchar(20),
		Diagnoza varchar(80))
		GO
	    INSERT  dbo.Pracownicy (ID_pracownika, Specjalizacja, Nazwisko, Imie, data_urodzenia, Email) VALUES (1, 'Lekarz rodzinny', 'Dr_Hoffman', 'Eva', '1978-12-15', 'drhoffman@gmail.com');
		GO
		INSERT  dbo.Pracownicy (ID_pracownika, Specjalizacja, Nazwisko, Imie, data_urodzenia, Email) VALUES (2, 'Laryngolog', 'Dr_Zimmer', 'Hans', '1998-01-19', 'drhanszimmer@gmail.com');
		GO
		INSERT  dbo.Pracownicy (ID_pracownika, Specjalizacja, Nazwisko, Imie, data_urodzenia, Email) VALUES (3, 'Pediatra', 'Dr_Spielberg', 'Steven', '1967-11-06', 'drstevenspielberg@gmail.com');
		GO
		INSERT  dbo.Pracownicy (ID_pracownika, Specjalizacja, Nazwisko, Imie, data_urodzenia, Email) VALUES (4, 'Pielegniarka', 'Zackmen', 'Vanessa', '1982-07-12', 'vzackmen@gmail.com');	
		GO
		INSERT  dbo.Pracownicy (ID_pracownika, Specjalizacja, Nazwisko, Imie, data_urodzenia, Email) VALUES (5, 'Recepcjonistka', 'Allen', 'Leona', '1989-09-17', 'leonaallen@gmail.com');
		GO

		INSERT  dbo.Pacjenci VALUES (1, 'Dellarosa', 'Izabelle', '1999-10-12', '9032454589');
		GO
		INSERT  dbo.Pacjenci VALUES (2, 'Jacken', 'Marcus', '1988-12-24', '8900998900');
		GO
		INSERT  dbo.Pacjenci VALUES (3, 'Pacino', 'Al', '1997-02-18', '6909080809');
		GO
		INSERT  dbo.Pacjenci VALUES (4, 'Leroy', 'Patricia', '1964-12-01', '9090090999');
		GO
		INSERT  dbo.Pacjenci VALUES (5, 'Ford', 'Henry', '1978-05-15', '5690909880');
		GO

		INSERT  dbo.Rejestracja VALUES (1, 2, '2019-01-14');
		GO
		INSERT  dbo.Rejestracja VALUES (2, 2, '2019-01-14');
		GO
		INSERT  dbo.Rejestracja VALUES (3, 3, '2019-01-15');
		GO
		INSERT  dbo.Rejestracja VALUES (4, 1, '2019-01-15');
		GO
		INSERT  dbo.Rejestracja VALUES (5, 4, '2019-01-16');
		GO
		INSERT  dbo.Rejestracja VALUES (6, 3, '2019-01-17');
		GO

		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (1, 1, 1, 2, 'J10.0', 'GRYPA Z ZAPALENIEM PLUC WYWOLANA ZIDENTYFIKOWANYM WIRUSEM GRYPY');
		GO
		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (2, 2, 3, 2, 'B05.9', 'ODRA BEZ POWIKLAN');
		GO
		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (3, 3, 3, 3, 'H61.0', 'ZAPALENIE OCHRZESTNEJ UCHA ZEWNETRZNEGO ');
		GO
		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (4, 4, 4, 1, 'I21.1', 'OSTRY ZAWAL SERCA PELNOSCIENNY SCIANY DOLNEJ');	
		GO
		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (5, 5, 4, 4, 'J04', 'OSTRE ZAPALENIE KRTANI I TCHAWICY');
		GO
		INSERT  dbo.Wizyta (ID_wizyty, Rejestracja_ID, Pracownicy_ID, Pacjenci_ID, Kod_choroby, Diagnoza) VALUES (6, 6, 3, 3, 'B05.9', 'ODRA BEZ POWIKLAN');
		GO
