use master
go

drop database if exists gamedatabase
go

create database gamedatabase
go

use gamedatabase 
go

create table gametable(
	GameID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	GameName VARCHAR (50) NULL,
	GamePrice INT NULL,
	GameRating VARCHAR (10) NULL,
	GameBought BIT NULL,
)

insert into gametable values ('PUBG', 20, 'R', 1)

select * from gametable

