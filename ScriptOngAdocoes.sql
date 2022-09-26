create database ONG_Adocoes;

use ONG_Adocoes;

create table Pessoa(
	Nome varchar(50) not null,
	CPF varchar(20) not null,
	Sexo varchar(20) not null,
	DataNascimento varchar(10) not null,
	Telefone varchar(20) not null,
	Rua varchar(30) not null,
	Bairro varchar(30) not null,
	Cidade varchar(30) not null,
	SiglaEstado varchar(5) not null,
	Numero varchar(10) not null

    constraint PK_ID_PESSOAS primary key (CPF) 
);

create table Animal(
	CHIP int not null, 
	Familia varchar(25) not null,
	Raca varchar(20) not null,
	Sexo char(2) not null,
	Nome varchar(10),

    constraint PK_CHIP_ANIMAL primary key (CHIP) 
);

create table RegistroAdocao (
	NumeroRegistro int not null, 
	Adotante varchar(20) not null,
	Adotado int not null,

	foreign key(Adotante) references Pessoa(CPF),
	foreign key(Adotado) references Animal(Chip),
	constraint PK_NREGISTRO_REGISTROADOCAO primary key (NumeroRegistro) 
);
