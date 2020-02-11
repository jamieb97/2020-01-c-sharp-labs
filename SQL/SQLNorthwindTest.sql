--1.1
select CustomerID, CompanyName, Customers.Address, City from Customers where City = 'London' OR City = 'Paris' 
--1.2
select * from Products
select * from Products where QuantityPerUnit LIKE '%bottle%'
--1.3
select ProductID, ProductName, Products.SupplierID, Suppliers.Country from Products
JOIN Suppliers on Products.SupplierID = Suppliers.SupplierID
--1.4
select count(CategoryID), ProductName  from Products group by ProductName
--1.5
select CONCAT(CustomerID,', ', Country,', ', City) as yes from Customers