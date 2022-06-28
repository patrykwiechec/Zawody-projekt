
USE Zawody;

CREATE TABLE zawody(
	id_zawodow int IDENTITY(1,1) PRIMARY KEY,
	nazwa VARCHAR(50) NOT NULL,
	data_za DATE not null
	)

	CREATE TABLE trenerzy(
	id_trenera int IDENTITY(1,1) PRIMARY KEY,
	imie_t VARCHAR (20) NOT NULL,
	nazwisko_t VARCHAR (25) NOT NULL,
	data_ur_t DATE NOT NULL
	)

CREATE TABLE zawodnicy(
	id_zawodnika int IDENTITY(1,1) PRIMARY KEY,
	imie VARCHAR (20) NOT NULL,
	nazwisko VARCHAR (25) NOT NULL,
	kraj VARCHAR (20) NOT NULL,
	data_ur DATE NOT NULL,
	id_trenera int REFERENCES trenerzy(id_trenera)
	)

CREATE TABLE uczestnictwo(
	id_uczestnictwa int IDENTITY(1,1) PRIMARY KEY,
	id_zawodnika int REFERENCES zawodnicy(id_zawodnika),
	id_zawodow int REFERENCES zawody(id_zawodow)
)
