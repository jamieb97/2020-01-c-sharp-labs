select top 5 * from Customers
select top 5 * from Customers order by CustomerID desc

select * from Customers where City = 'London'

--select * from INFORMATION_SCHEMA.COLUMNS where table_name = 'ContactTitle'
select distinct TitleOfCourtesy from Employees
select Count(distinct TitleOfCourtesy) from Employees

select * from Employees where TitleOfCourtesy = 'Dr.'
 
select Count(Discontinued) from Products where Discontinued = 'true'

--offset = skip
--first 5 customers
select top (5) * from Customers
--next 5 customers
select * from Customers order by CustomerID offset 5 rows fetch next 5 rows only
--next 5 customers
select * from Customers order by CustomerID offset 10 rows fetch next 5 rows only

--how many products with categoryid = 1 and discontinued
select COUNT(*) from Products where CategoryID = '1' AND Discontinued = 'true'
--how many products with items in stock and unitprice > 29.99
select * from Products where UnitsInStock > 0 AND UnitPrice > 29.99 order by UnitPrice desc
--how many distinct countries exists in customer tables
select COUNT(distinct Country) from Customers
select COUNT(distinct City) from Customers

--LIKE
--% is a wildcard for anything %a% contains a
--                              a% starts with
--                             %a  ends with

--_ is a wildcard for ONE CHARACTER
--how many products contain'ch'
select * from Products where ProductName LIKE '%ch%'
select COUNT(*) from Products where ProductName LIKE '%ch%'

--how many regions contain the letter a in customers
select COUNT(*) from Customers where Region LIKE '%a%'
--how many regions start with a
select COUNT(*) from Customers where Region LIKE 'a%'
--how many regions end with
select COUNT(*) from Customers where Region LIKE '%a'
--NOT LIKE reverses the query
select COUNT(*) from Customers where Region NOT LIKE '%a'
--How many products to not contain ch
select COUNT(*) from Products where ProductName NOT LIKE '%ch%'
--using _ to represent single character wildcard
--how many regions have 'A' as second letter 
select Region, * from Customers where Region LIKE '_a%'
--OR but for long lists use IN for a shorter version
select Region, * from Customers where Region IN ('wa','ca')
--BETWEEN NUMBERIC RANGES
--how many products which are not discontinued have unitprice between 10.00 and 40.00
select UnitPrice, * from Products where Discontinued = 0 and UnitPrice between 10.00 and 40.00
--how many start with b,s or t
select COUNT(*) from Products where ProductName LIKE ('B%') OR ProductName LIKE ('S%')

select * from Products 
join Categories
on Products.CategoryID = Categories.CategoryID
where Categories.CategoryName LIKE 'C%' OR CategoryName Like 'S%'

--concatenation
--select customers but join 'city and country' into one column eg 'lives in'
select *, CONCAT (city, ', ', country) as livesin from Customers

--customer => order => details of order (order_detail)
--select orders for ALFKI customer
select * from Orders where CustomerID = 'ALFKI'
--have a look at order details as well
select * from Orders
join [Order Details] on Orders.OrderID = [Order Details].OrderID
where CustomerID = 'alfki'

--create a query to have oderid, productname and quantity
select orderID, productName, Quantity from Products
join [Order Details] on [Order Details].ProductID = Products.ProductID

--filter by customer 'alkfi'
select CustomerID, Orders.OrderID, ProductName, Quantity, o.UnitPrice from Orders
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
where CustomerID = 'alfki' order by UnitPrice desc

--goal is to list, for any given customer, the order details
--remember to get to the order details we have to go first through orders table 
--  customer ==> order ==> order_details
--                          productid bought, quantity, price and discount
--note : customerid is already in orders table

--get customer name and all orders for customerid = 'alfki'
select Customers.CustomerID, ContactName, OrderID from Customers
join Orders on Customers.CustomerID = Orders.CustomerID
where Customers.CustomerID = 'alfki'

--develop to show product id as well (include order details table)
select Customers.CustomerID, ContactName, Products.ProductID, ProductName, orders.OrderID from Orders
join [Order Details] as o on Orders.OrderID = o.OrderID
join Customers on Orders.CustomerID = Customers.CustomerID
join Products on o.ProductID = Products.ProductID
where Customers.CustomerID = 'alfki'