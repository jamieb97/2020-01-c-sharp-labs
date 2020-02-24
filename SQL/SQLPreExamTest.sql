SELECT DISTINCT City FROM Customers


SELECT TOP 1 UnitPrice, ProductName FROM Products
ORDER BY UnitPrice DESC

SELECT TOP 1 UnitPrice, ProductName FROM Products
ORDER BY UnitPrice 


SELECT CategoryName, COUNT(p.ProductID) FROM Categories c
JOIN Products p ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName


