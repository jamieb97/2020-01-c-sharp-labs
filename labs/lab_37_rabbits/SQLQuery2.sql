use master
go
 
drop database if exists newrabbitdatabase
go

create database newrabbitdatabase
go

use newrabbitdatabase
go

create table rabbittable(
    RabbitTableID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
    RabbitName VARCHAR (50) NULL,
    RabbitAge INT NULL,
    RabbitDOB DATE NULL,
    [RabbitIsActive]  BIT NULL,
    [RabbitType] VARCHAR(50) NULL, 
)


insert into rabbittable values ('Beyonce',1, '2020-01-01', 1, 'Bee')
insert into rabbittable values ('Jay-Z', 3, '2018-06-12', 1, 'NY')
insert into rabbittable values ('Kanye', 2, '2019-11-02', 1, 'Chicago')


select * from rabbittable