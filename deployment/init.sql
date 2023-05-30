CREATE DATABASE [prod] ON
(
	NAME = prod_dat,
	FILENAME = 'C:\SQL OBJ\db\prod_dat.mdf',
	SIZE = 10,
	MAXSIZE = 50,
	FILEGROWTH = 5
)
LOG ON (
	NAME = prod_log,
	FILENAME = 'C:\SQL OBJ\db\prod_log.ldf',
	SIZE = 5 MB,
	MAXSIZE = 25 MB,
	FILEGROWTH = 5 MB
);