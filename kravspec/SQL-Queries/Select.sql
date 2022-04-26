SELECT Orders.OrdersID, Orders.CustomerID, Customer.Contact_InformaitionID, 
	   Employee.DepartmentID , Orders.EmployeeID, Orders.Delivery_ServiceID, Orderline.OrderLineID ,
	   Orders.Delivery_Date, Orders.Payment_Date, Orders.Shipment_Date,  
	   Delivery.Courier_Name, Orderline.Ammount, Orderline.Price, Orderline.ProductID
FROM Orders AS Orders

      INNER JOIN Customer AS Customer ON Orders.CustomerID = Customer.CustomerID
      INNER JOIN Employee AS Employee ON Orders.EmployeeID = Employee.EmployeeID
      INNER JOIN Delivery_Service AS Delivery ON Orders.Delivery_ServiceID = Delivery.Delivery_ServiceID
      LEFT JOIN OrderLine AS Orderline ON Orders.OrdersID = Orderline.OrdersID

ORDER BY Orders.OrdersID, Customer.CustomerID, Employee.EmployeeID, Delivery.Delivery_ServiceID

