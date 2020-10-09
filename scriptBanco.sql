CREATE TABLE GENERO (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Codigo INT NOT NULL,
    Nome VARCHAR (150) NOT NULL
);

CREATE TABLE FILME (
    Id INT PRIMARY KEY IDENTITY (1, 1),
	GeneroId INT NOT NULL,
	Ano INT NOT NULL,
	Diretor VARCHAR(200) NOT NULL,
	Titulo VARCHAR(200) NOT NULL,
	Sinopse VARCHAR(2000) NOT NULL,
    FOREIGN KEY (GeneroId) REFERENCES GENERO (Id)
);

INSERT INTO GENERO (Codigo,Nome) VALUES(1,'Terror')
INSERT INTO GENERO (Codigo,Nome) VALUES(2,'Suspense')
INSERT INTO GENERO (Codigo,Nome) VALUES(3,'Comédia')

INSERT INTO FILME (GeneroId,Ano,Diretor,Titulo,Sinopse) VALUES(1,1980,'Sean S. Cunningham','Sexta feira 13','A história do homicído em Crystal Lake não impede que os instrutores montem um acampamento de verão no bosque.')

