SELECT conInfo.First_Name , conInfo.Last_Name , pos.City, conInfo.Email, contype.Contact_Type FROM Employee 
JOIN Department dep ON Employee.DepartmentID = dep.DepartmentID
JOIN Contact con ON Employee.ContactID = con.ContactID
JOIN Contact_Informaition conInfo ON con.ContactID = conInfo.ContactID
JOIN Addrese  addr ON conInfo.AddreseID = addr.AddreseID
JOIN PostalCodes  pos ON addr.PostalCode = pos.PostalCode
JOIN Contact_Type contype ON con.Contact_TypeID = contype.Contact_TypeID;

SELECT * FROM OrderLine
JOIN Product ON OrderLine.ProductID = Product.ProductID;


SELECT * FROM Employee;