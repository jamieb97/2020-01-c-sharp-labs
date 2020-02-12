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

--now add some some calculated columns
select ContactName, Products.ProductID, ProductName, orders.OrderID, o.Quantity,
o.UnitPrice, 
o.discount * 100 as 'Percentage discount',
o.UnitPrice*o.Quantity as 'Order Before Discount',
o.UnitPrice * o.Quantity * o.Discount as 'Discount',
(o.UnitPrice*o.Quantity) * (1-o.Discount) as 'Oder After discount'
from Customers
join Orders on Customers.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
where Customers.CustomerID = 'alfki'

--can we get totals
select SUM(o.Quantity),
SUM(o.UnitPrice*o.Quantity) as 'Order Before Discount',
SUM(o.UnitPrice * o.Quantity * o.Discount) as 'Discount',
SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)) as 'Order After discount'
from Customers
join Orders on Customers.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
where Customers.CustomerID = 'alfki'

--How to get this working for all customers
--Use group by condition which groups results by column 
--keep totals and group by customer ID
select 
c.CustomerID,
SUM(o.Quantity),
SUM(o.UnitPrice*o.Quantity) as 'Order Before Discount',
SUM(o.UnitPrice * o.Quantity * o.Discount) as 'Discount',
SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)) as 'Order After discount'
from Customers c
join Orders on c.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
group by c.CustomerID

--sort results by biggest spender
select 
c.CustomerID,
SUM(o.Quantity),
SUM(o.UnitPrice*o.Quantity) as 'Order Before Discount',
SUM(o.UnitPrice * o.Quantity * o.Discount) as 'Discount',
round(SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)),2) as 'Order After discount'
from Customers c
join Orders on c.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
group by c.CustomerID
order by [Order After discount] DESC

--filter where discount != 0
select 
c.CustomerID,
SUM(o.Quantity),
SUM(o.UnitPrice*o.Quantity) as 'Order Before Discount',
SUM(o.UnitPrice * o.Quantity * o.Discount) as 'Discount',
round(SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)),2) as 'Order After discount'
from Customers c
join Orders on c.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
where [Discount] > 0
group by c.CustomerID
order by [Order After discount] DESC

--having
select 
c.CustomerID,
SUM(o.Quantity),
SUM(o.UnitPrice*o.Quantity) as 'Order Before Discount',
SUM(o.UnitPrice * o.Quantity * o.Discount) as 'Discount',
round(SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)),2) as 'Order After discount'
from Customers c
join Orders on c.CustomerID = Orders.CustomerID
join [Order Details] as o on Orders.OrderID = o.OrderID
join Products on o.ProductID = Products.ProductID
where [Discount] > 0

group by c.CustomerID
having  SUM((o.UnitPrice*o.Quantity) * (1-o.Discount)) > 10000

order by [Order After discount] DESC

--### STRING MANIPULATION

--SUBSTRING from the first given index (1-based counting) and specify the number of letters to return 
SELECT SUBSTRING('VeryLongString',3,6) --from index 3 (3rd chaarcter) for 6 letters --ryLong
--CHARINDEX get the index where it is placed inside our long string
    --index is not zero based counting so return 6 where a = 6th character
SELECT CHARINDEX('a','verylangstrang') 
SELECT CHARINDEX(' ', 'SE16 3EG') -- splits up postcode
--LEFT/RIGHT return first / last end characters
SELECT LEFT('verylongstring', 4)
SELECT RIGHT('verylongstring', 4)
SELECT LEFT('SE16 3EG', CHARINDEX(' ', 'SE16 3EG')-1) --select SE16
--LTRIM/RTRIM
SELECT LTRIM('  some data with space in front   ')
SELECT LTRIM(RTRIM(('   some stuff goes here     ')))
--REPLACE
SELECT REPLACE('very long string', 'very', 'very very very extremly')
--UPPER/LOWER
SELECT UPPER('a long string in lower case')
--DATES

--TODAY
SELECT GETDATE()
SELECT CONCAT('Today is ', GETDATE())
SELECT CONCAT('Tomorrow is ', DATEADD(d,1,GETDATE()))
SELECT CONCAT('Yesterday was ', DATEADD(d,-1,GETDATE()))
--DATE DIFF
--d or dd or mm or yy or yyyy
SELECT DATEDIFF(yyyy, DATEADD(d,7,GETDATE()), GETDATE()) 

--Whats the longest shippin time?? subtract from orderdate and get max
SELECT OrderID, DATEDIFF(d, OrderDate, ShippedDate) as Times FROM Orders
ORDER BY Times desc

--Floor - Convert to integer
SELECT FLOOR(10.65)
SELECT CEILING(10.65)
SELECT ROUND(10.6582832,2)

-- CASE .. WHEN .. ELSE
SELECT CASE WHEN (10<11) THEN '10 IS SMALL' ELSE 'K' END AS 'IS 10 SMALL?'

SELECT * FROM Orders


--GROUP BY EXERCISES
--PRINT CUSTOMERS GROUPED BY COUNTRY
SELECT Count(Country), Country FROM Customers
GROUP BY Country 
--PRINT CUSTOMERS GROUPED BY CITY
SELECT Count(City), Country FROM Customers
GROUP BY City
--PRINT PRODUCTS GROUPED BY CATEGORY
SELECT COUNT(p.ProductName) as amount, CategoryName as cats FROM Products p
JOIN Categories on p.CategoryID = Categories.CategoryID
GROUP BY CategoryName 

SELECT * FROM Products ORDER BY CategoryID

---LEFT, RIGHT, INNER, OUTER JOINS
---INNER JOIN AND OUTER JOIN AND FULL JOIN
---INNER JOIN : ALL RECORDS FROM LEFT TABLE AND MATCHING FROM RIGHT TABLE 

---left join: all records from left table and matching from right
    --all customers and matching orders
---RIGHT JOIN: ALL ORDERS AND ANY MATCHING CUSTOMERS
---OUTER JOIN: EITHER LEFT JOIN OR RIGHT JOIN WHICH ARE DESCRIBED ABOVE 

SELECT COUNT(C.CompanyName) FROM Customers c
LEFT JOIN Orders o on c.CustomerID = o.CustomerID

SELECT COUNT(C.ContactName) FROM Customers c
RIGHT JOIN Orders o on c.CustomerID = o.CustomerID
where ContactName != NULL 

SELECT c.ContactName, o.OrderID FROM Customers c
FULL JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL
order by o.OrderID 

SELECT COUNT(*) FROM Customers c
INNER JOIN Orders o on c.CustomerID = o.CustomerID


