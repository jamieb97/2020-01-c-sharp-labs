use master
go 

drop database if exists ToDoDatabase
go

create database ToDoDatabase
go


use ToDoDatabase
go
drop table if exists ToDoItems
go
drop table if exists Users
go
drop table if exists Categories
go

create table Users(
	UserID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserName VARCHAR(50) NULL
)
create table Categories(
	CategoryID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(50) NULL
)

create table ToDoItems(
	ToDoItemID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	ToDoItemName VARCHAR(50) NULL,
	StartDate DATE NULL,
	DONE BIT NULL,
	UserID INT NULL FOREIGN KEY REFERENCES Users(UserID),
	CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
)

INSERT INTO Users VALUES ('Wilder')
INSERT INTO Users VALUES ('Fury')
INSERT INTO Users VALUES ('Joshua')

INSERT INTO Categories VALUES ('Pow')
INSERT INTO Categories VALUES ('Thump')
INSERT INTO Categories VALUES ('Yeet')

INSERT INTO ToDoItems VALUES ('idk', '2020-01-23', 'true', 1, 1)
INSERT INTO ToDoItems VALUES ('maybe', '2020-01-23', 'true', 2, 2)
INSERT INTO ToDoItems VALUES ('nope', '2020-01-23', 'true', 3, 2)

ALTER TABLE Users ADD UserAge VARCHAR(50) NULL
ALTER TABLE Users ALTER COLUMN UserAge INT NULL
UPDATE Users SET UserAge = 22 WHERE UserID = 1  

select ToDoItemID, ToDoItemName, CategoryName, UserName, StartDate, case when DONE = 1 then 'True' else 'false' end as Completed, UserAge from ToDoItems
inner join Categories on ToDoItems.CategoryID = Categories.CategoryID
inner join Users on ToDoItems.UserID = Users.UserID

select * from INFORMATION_SCHEMA.COLUMNS