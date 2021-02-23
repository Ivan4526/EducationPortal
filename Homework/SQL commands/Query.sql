select EmployeeID, LastName, FirstName from Employees where City = 'London'

select top 1 count(EmployeeID) as val, EmployeeID from Orders group by EmployeeID ORDER BY val DESC

select ShipCountry, ShipCity from Orders where ShipCity in (select ShipCity from Orders where count(ShipCity) > 1 group by ShipCity)

select max(UnitPrice) from Products inner join Categories on CategoryName = 'Seafood'

select Customers.CustomerID, ContactName from Customers inner join Orders on Customers.CustomerID = Orders.CustomerID where City != ShipCity


