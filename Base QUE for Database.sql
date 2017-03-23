--AlexAlexSofiaNiklas Database

use master;

drop database Sofia;

create database Sofia;

use Sofia;

CREATE TABLE Users
(
UserID int identity(1,1) Primary key,
Username varchar(50) NOT NULL,
UserPassword varchar(50) NOT NULL,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Street varchar(50) NOT NULL,
Zip varchar(50) NOT NULL CHECK (Zip LIKE '[0-9][0-9][0-9][0-9][0-9]'),
City varchar(50) NOT NULL,
Country varchar(50) NOT NULL,
PhoneNumber varchar(50) CHECK (PhoneNumber LIKE '[0][7][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
Email varchar(50),
isAdmin bit NOT NULL
);

--TODO fix bit and handling of users (password and username)

CREATE TABLE Orders
(
OrderID int identity(1,1) Primary key,
UserID int Foreign key references Users(UserID) NOT NULL,
OrderStatus varchar(50) NOT NULL,
OrderDate smalldatetime NOT NULL
);

CREATE TABLE Products
(
ProductID int identity(1,1) PRIMARY KEY,
Price int NOT NULL,
Stock int NOT NULL,
ShortDescription varchar(50) NOT NULL,
LongDescription varchar(1000) NOT NULL
);

CREATE TABLE ProductLists
(
ProductListID int identity(1,1) PRIMARY KEY, 
OrderID int FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
ProductID int FOREIGN KEY REFERENCES Products(ProductID) NOT NULL,
Quantity int NOT NULL,
Price int NOT NULL
);

GO

CREATE PROCEDURE CreateUser

@UserID int,
@Username nvarchar(50),
@PassWord nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Street nvarchar(50),
@City nvarchar(50),
@Zip nvarchar(50),
@PhoneNumber nvarchar(50),
@Email nvarchar(50),
@IsAdmin bit,
@OutputID int output
AS
insert into Users(UserID, Username, UserPassword, FirstName, LastName, Street, City, Zip, PhoneNumber, Email, IsAdmin) 
values (@UserID, @Username, @PassWord, @FirstName, @LastName, @Street, @City, @Zip, @PhoneNumber, @Email, @IsAdmin)

set @OutputID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE CreateOrder
--@OrderID int,
@UserID int,
@OrderStatus nvarchar(50),
@OrderDate smalldatetime,
@OutputOrderID int output
AS
insert into Orders(UserID, OrderStatus, OrderDate)
values (@UserID, @OrderStatus, @OrderDate)

set @OutputOrderID = SCOPE_IDENTITY();

GO

