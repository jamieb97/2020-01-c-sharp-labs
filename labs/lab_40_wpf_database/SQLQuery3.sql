use master
go

drop database if exists basketdatabase
go

create database basketdatabase
go

use basketdatabase 
go

create table baskettable(
	GameID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	GameName VARCHAR (50) NULL,
	GamePrice INT NULL,
	GameRating VARCHAR (10) NULL,
	GameBought BIT NULL,
)

select * from baskettable