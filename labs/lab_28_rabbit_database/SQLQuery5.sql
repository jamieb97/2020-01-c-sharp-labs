use master
go

drop database if exists rabbitdatabase
go

create database rabbitdatabase
go

use rabbitdatabase
go

create table rabbittable(
	RabbitTableID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	RabbitName VARCHAR (50) NULL,
	RabbitAge INT NULL 
)

insert into rabbittable values ('Jim', 1)
insert into rabbittable values ('Jeff', 0)
insert into rabbittable values ('Steve', 1)
insert into rabbittable values ('Bob', 4)
insert into rabbittable values ('Gregory', 2)

select * from rabbittable