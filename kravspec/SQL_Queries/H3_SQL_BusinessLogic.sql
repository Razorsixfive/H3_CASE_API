CREATE DATABASE H3_API_BACKEND;
USE H3_API_BACKEND;

-- CONTACT SIDE START

-- EXCEL IMPORT
CREATE TABLE PostalCodes(
PostalCode INT PRIMARY KEY IDENTITY(1,1),
City       NVARCHAR(100)
);
-- EXCEL IMPORT END

CREATE TABLE Contact_Type(
	Contact_TypeID INT PRIMARY KEY IDENTITY(1,1),
	Contact_Type   NVARCHAR(255),
);

CREATE TABLE Contact(
	ContactID       INT PRIMARY KEY IDENTITY(1,1),
	Contact_TypeID  INT FOREIGN KEY REFERENCES Contact_Type(Contact_TypeID),
);

CREATE TABLE Telephone(
	TelephoneID   INT PRIMARY KEY IDENTITY(1,1),
	Phone_Number  NVARCHAR(255),
	Mobile_Number NVARCHAR(255),
);

CREATE TABLE Addrese(
	AddreseID   INT PRIMARY KEY IDENTITY(1,1),
	PostalCode  INT FOREIGN KEY REFERENCES PostalCodes(PostalCode),
	Addrese     NVARCHAR(255),
);

CREATE TABLE Contact_Informaition(
	Contact_InformaitionID  INT PRIMARY KEY IDENTITY(1,1),
	ContactID    INT FOREIGN KEY REFERENCES Contact(ContactID),
	TelephoneID  INT FOREIGN KEY REFERENCES Telephone(TelephoneID),
	AddreseID    INT FOREIGN KEY REFERENCES Addrese(AddreseID),
	Email        NVARCHAR(255),
	First_Name   NVARCHAR(255),
	Last_Name    NVARCHAR(255),
);

-- CONTACT SIDE END



-- COMPANY SIDE START
CREATE TABLE Department(
	DepartmentID INT PRIMARY KEY IDENTITY(1,1),
	ContactID    INT FOREIGN KEY REFERENCES Contact(ContactID),
);

CREATE TABLE Warehouse(
	WarehouseID  INT PRIMARY KEY IDENTITY(1,1),
	DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID),
	ContactID    INT FOREIGN KEY REFERENCES Contact(ContactID),
);

CREATE TABLE Employee(
	EmployeeID   INT PRIMARY KEY IDENTITY(1,1),
	DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID),
	ContactID    INT FOREIGN KEY REFERENCES Contact(ContactID),
);
-- COMPANY SIDE END



-- PRODUCT SIDE START

CREATE TABLE Manufactor(
	ManufactorID    INT PRIMARY KEY IDENTITY(1,1),
	Manufactor_Name NVARCHAR(75),
);

CREATE TABLE Category(
	CategoryID    INT PRIMARY KEY IDENTITY(1,1),
	Category_Name NVARCHAR(75),
);

CREATE TABLE Product(
	ProductID     INT PRIMARY KEY IDENTITY(1,1),
	CategoryID    INT FOREIGN KEY REFERENCES Category(CategoryID),
	ManufactorID  INT FOREIGN KEY REFERENCES Manufactor(ManufactorID),
	Product_Description   NVARCHAR(255),
	Product_Name          NVARCHAR(255),
	In_Price      FLOAT,
	Out_Price     FLOAT,
	);
CREATE TABLE Product_Stock(
	Product_StockID  INT PRIMARY KEY IDENTITY(1,1),
	ProductID        INT FOREIGN KEY REFERENCES Product(ProductID),
	WarehouseID      INT FOREIGN KEY REFERENCES Warehouse(WarehouseID),
	Ammount          INT,
);

-- PRODUCT SIDE END



-- BUSINESS SIDE START
CREATE TABLE Customer(
	CustomerID   INT PRIMARY KEY IDENTITY(1,1),
	First_Name NVARCHAR(75),
	Last_Name NVARCHAR(75),
);

CREATE TABLE Delivery_Service(
	Delivery_ServiceID INT PRIMARY KEY IDENTITY(1,1),
	Courier_Name       NVARCHAR(255),
);



CREATE TABLE Orders(
	OrdersID           INT PRIMARY KEY IDENTITY(1,1),
	ContactID          INT FOREIGN KEY REFERENCES Contact(ContactID),
	EmployeeID         INT FOREIGN KEY REFERENCES Employee(EmployeeID),
	Delivery_ServiceID INT FOREIGN KEY REFERENCES Delivery_Service(Delivery_ServiceID),
	AddreseID          INT,
	Payment_Date  DATE,
	Shipment_Date DATE,
	Delivery_Date DATE,
);

CREATE TABLE OrderLine(
	OrderLineID  INT PRIMARY KEY IDENTITY(1,1),
	OrdersID     INT FOREIGN KEY REFERENCES Orders(OrdersID),
	ProductID    INT FOREIGN KEY REFERENCES Product(ProductID),
	Ammount      INT,
	Price        FLOAT,
);
-- BUSINESS SIDE END







CREATE TABLE Name_Table(
	Name_TableID INT PRIMARY KEY IDENTITY(1,1),
	First_Name   NVARCHAR(50),
	Last_Name    NVARCHAR(50),
	Email        NVARCHAR(100),
);