create database receptkonyv
go
use receptkonyv
go
create table kategoria
(
	id int identity(1,1),
	nev varchar(20) not null,
	primary key(id)
)
go
create table recept
(
	id int identity(1,1),
	nev varchar(30) not null,
	kat_id int not null,
	kep_eleresi_ut varchar(MAX) not null,

	datum date default(cast(getdate() as date)) not null,
	leiras varchar(MAX) not null,
	primary key(id)
)
go

alter table recept
add foreign key(kat_id) references kategoria(id)