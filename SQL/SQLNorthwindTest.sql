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

--1.7
SELECT COUNT(*) FROM Orders WHERE Freight > 100.00 AND ShipCountry in ('UK', 'USA')
--1.8
select od.OrderID, SUM((od.UnitPrice*od.Quantity) * (1-od.Discount)) as 'Yes' from [Order Details] od
group by od.OrderID
