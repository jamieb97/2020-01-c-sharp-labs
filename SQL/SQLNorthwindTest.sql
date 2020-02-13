--1.1
select CustomerID, CompanyName, Customers.Address, City from Customers where City = 'London' OR City = 'Paris' 
--1.2
select * from Products
select * from Products where QuantityPerUnit LIKE '%bottle%'
--1.3
select ProductID, ProductName, Products.SupplierID, Suppliers.Country from Products
JOIN Suppliers on Products.SupplierID = Suppliers.SupplierID
where QuantityPerUnit LIKE '%bottle%'
--1.4
SELECT COUNT(c.CategoryName) as Amount, c.CategoryName FROM Products p
JOIN Categories c on p.CategoryID = c.CategoryID
GROUP BY c.CategoryName
--1.5
select CONCAT(TitleOfCourtesy, FirstName,' ', LastName) as yes from Employees e
--1.6
SELECT ROUND(COUNT(od.Quantity),2) AS [TOTAL SALES] FROM [Order Details] OD
JOIN Orders o ON OD.OrderID = o.OrderID
JOIN EmployeeTerritories et ON o.EmployeeID = et.EmployeeID
JOIN Territories t ON et.TerritoryID = t.TerritoryID
JOIN Region r ON t.RegionID = r.RegionID
where OD.Quantity > 1000000
--1.7
SELECT COUNT(*) FROM Orders WHERE Freight > 100.00 AND ShipCountry in ('UK', 'USA')
--1.8
select od.OrderID, SUM((od.UnitPrice*od.Quantity) * (1-od.Discount)) as 'Yes' from [Order Details] od
group by od.OrderID


--CREATE TABLE Spartans(
--	SpartanID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
--	SpartanName VARCHAR NULL,
--	SpartanUni VARCHAR NULL,
--	SpartanCourse VARCHAR NULL,
--	SpartanGrade INT NULL
--)

--INSERT INTO Spartans VALUES ('Jamie', 'Anglia Ruskin', 'Computer Science', 2)

--SELECT * FROM Spartans

--DROP TABLE Spartans


SELECT DISTINCT City FROM Customers

SELECT MAX(UnitPrice) AS MaxPrice, MIN(UnitPrice) AS MinPrice FROM Products p

SELECT CategoryName, COUNT(p.ProductID) FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName
HAVING COUNT(p.UnitsInStock) > 0

SELECT * FROM Customers c
LEFT JOIN Orders o ON o.CustomerID = c.CustomerID

SELECT * FROM Employees
WHERE Region IS NULL

SELECT * FROM Employees
WHERE Region IS NOT NULL

SELECT * FROM Products p WHERE p.ProductName LIKE 'p%'
