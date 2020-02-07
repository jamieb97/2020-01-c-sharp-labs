--system database
use master 
go

--create database
drop database if exists Users
go
create database Users
go
use Users
go

--Create users and categories
create table Categories(	
	CategoryID INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	CategoryName VARCHAR (50) NULL,
)

create table Users(
	UserID INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	UserName VARCHAR (50) NULL,
	DateOfBirth DATE NULL,
	isValid BIT NULL,
	CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
)
INSERT INTO Categories VALUES ('admin')
INSERT INTO Categories VALUES ('work')
INSERT INTO Categories VALUES ('personal')

INSERT INTO USERS VALUES ('Jimbob', '2020-10-10', 'true',1)
INSERT INTO USERS VALUES ('Lionel', '2020-4-10', 'true',1)
INSERT INTO USERS VALUES ('H', '2020-10-10', 'true',1)

select * from Users
SELECT * FROM Categories

--SQL JOIN SIMILAR TO LINQ
SELECT * FROM USERS
INNER JOIN Categories
ON Users.CategoryID = Categories.CategoryID

SELECT UserId, UserName, isValid, CategoryName from Users
INNER JOIN Categories
ON Users.CategoryID = Categories.CategoryID
