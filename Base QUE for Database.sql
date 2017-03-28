--AlexAlexSofiaNiklas Database

use master;

GO

drop database Sofia;

GO

create database Sofia;

GO

use Sofia;

GO 
CREATE TABLE Users
(
UserID int identity(1,1) Primary key,
Username varchar(50) NOT NULL,
UserPassword varchar(50) NOT NULL,
FirstName varchar(50) NOT NULL,
LastName varchar(50) NOT NULL,
Street varchar(50) NOT NULL,
Zip varchar(50) NOT NULL, --CHECK (Zip LIKE '[0-9][0-9][0-9][0-9][0-9]'),
City varchar(50) NOT NULL,
Country varchar(50) NOT NULL,
PhoneNumber varchar(50), --CHECK (PhoneNumber LIKE '[0][7][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
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

--Drop Table Vat
--GO
CREATE TABLE Vat
(
VatID int identity(1,1) Primary key,
VatTagMoney money --IMPORTANT TO USE MONEY!!! 
);


CREATE TABLE Products
(
ProductID int identity(1,1) PRIMARY KEY,
Price money NOT NULL,
VatTag int FOREIGN KEY references Vat(VatID),
Stock int NOT NULL,
ShortDescription varchar(50) NOT NULL,
LongDescription varchar(1000) NOT NULL,
URL varchar(100) NOT NULL,
Active bit default 'true' NOT NULL
);

CREATE TABLE ProductLists
(
ProductListID int identity(1,1) PRIMARY KEY, 
OrderID int FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
ProductID int FOREIGN KEY REFERENCES Products(ProductID) NOT NULL,
Quantity int NOT NULL
);

GO



CREATE PROCEDURE CreateUser

@Username nvarchar(50),
@PassWord nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Street nvarchar(50),
@City nvarchar(50),
@Zip nvarchar(50),
@Country nvarchar(50),
@PhoneNumber nvarchar(50),
@Email nvarchar(50),
@IsAdmin bit,
@OutputID int output
AS

insert into Users(Username, UserPassword, FirstName, LastName, Street, City, Zip,Country, PhoneNumber, Email, IsAdmin) 
values (@Username, @PassWord, @FirstName, @LastName, @Street, @City, @Zip, @Country, @PhoneNumber, @Email, @IsAdmin)

set @OutputID = SCOPE_IDENTITY();
GO

CREATE PROCEDURE GetProduct
@ProductID int
AS
Select * from Products where Products.ProductID = @ProductID
GO

CREATE PROCEDURE getUser
@Username varchar(50),
@PassWord varchar(50)

as
select * from Users, Orders, ProductLists 
where Users.Username=@username AND Users.UserPassword=@password
Go

CREATE PROCEDURE GetUserByID
@UserID int
AS
Select * from Users, Orders, ProductLists
where Users.UserID = @UserID
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

CREATE PROCEDURE CreateProduct
@Price money,
@VatTag int,
@Stock int,
@ShortDescription varchar(50),
@LongDescription varchar(1000),
@URL varchar(100),
@OutputID int output
AS
insert into Products(Price, VatTag, Stock, ShortDescription, LongDescription, URL, Active)
values (@Price, @VatTag, @Stock, @ShortDescription, @LongDescription, @URL, 'true')

SET @OutputID = SCOPE_IDENTITY();
GO


CREATE PROCEDURE RemoveProduct
@ProductID int
AS
UPDATE Products set Active = 'false' where ProductID = @ProductID
GO


CREATE PROCEDURE UpdateProduct
@ProductID int,
@Price money,
@VatTag int,
@Stock int,
@ShortDescription varchar(50),
@LongDescription varchar(1000),
@URL varchar(100)
AS
UPDATE
	Products
set
	Price = ISNULL(@Price, Price),
	VatTag = ISNULL(@VatTag, VatTag),
	Stock = ISNULL(@Stock, Stock),
	ShortDescription = ISNULL(@ShortDescription, ShortDescription),
	LongDescription = ISNULL(@LongDescription, LongDescription),
	URL = ISNULL(@URL, URL)
where
	ProductID = @ProductID

--Select * from Products where ProductID = @ProductID
GO


CREATE PROCEDURE UpdateUser
@UserID int,
@Username nvarchar(50),
@PassWord nvarchar(50),
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Street nvarchar(50),
@City nvarchar(50),
@Zip nvarchar(50),
@Country nvarchar(50),
@PhoneNumber nvarchar(50),
@Email nvarchar(50),
@IsAdmin bit
AS
Update
	Users
set
	Username = ISNULL(@Username, Username),
	UserPassword = ISNULL(@Password, UserPassword),
	FirstName = ISNULL(@FirstName, FirstName),
	LastName = ISNULL(@LastName, LastName),
	Street = ISNULL(@Street, Street),
	City = ISNULL(@City, City),
	Zip = ISNULL(@Zip, Zip),
	Country = ISNULL(@Country, Country),
	PhoneNumber = ISNULL(@PhoneNumber, PhoneNumber),
	Email = ISNULL(@Email, Email),
	isAdmin = ISNULL(@IsAdmin, isAdmin)
where
	UserID = @UserID

GO

CREATE PROCEDURE CreateProductList
@OrderID int,
@ProductID int,
@Quantity int


as
insert into ProductLists (OrderID,ProductID,Quantity)
values (@OrderID,@ProductID, @Quantity)

GO


CREATE PROCEDURE GetProductList
@ProductListID int

AS

Select * from FullOverView where FullOverView.ProductListID = ProductListID

GO

------------------------------------------------------



Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('KungG','Gurra16', 'Karl Gustav','Bernadotte','Slottet','Stockholm','11111', 'Sweden', '0701111111','Kalle@kungahuset.se',0)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('Redgert','hemligtord', 'Niklas','Redgert','Hagendalsvägen 15D','Kumla','69231', 'Sweden', '0702862125','niklas@redgert.com',1)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('Ichurep','lösenord', 'Alexander','Arana','Virebergsvägen 5','Stockholm','16931', 'Sweden', '0763353850','arana.alexander@gmail.com',1)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('pattzor','gillarintejava', 'Patrik','Jönsson','Storgatan','Malmö','00000', 'Skåneland', '0702222222','patrik@pattzor.se',0)


insert into Vat (VatTagMoney) values (0.25)
insert into Vat (VatTagMoney) values (0.12)
--Update Vat set VatTagMoney = 0.12 where VatID = 2
--GO

insert into Orders (UserID, OrderStatus, OrderDate) values (2, 'Received', '2017-03-24 11:09:05')


insert into Products (Price, Stock, VatTag, ShortDescription, LongDescription) values (150,30,2,'Bibeln','Världens mest sålda bok, men typ den minst lästa')
insert into Products (Price, Stock, VatTag, ShortDescription, LongDescription) values (10,5000,1,'Blått gem','dåligt, blått plastgem')
insert into Products (Price, Stock, VatTag, ShortDescription, LongDescription) values (25,300,1,'Röd penna','Röd transparant penna')
insert into Products (Price, Stock, VatTag, ShortDescription, LongDescription) values (3500,0,1,'HP-skärm','väldigt medelmåttig skärm från HP')
insert into Products (Price, Stock, VatTag, ShortDescription, LongDescription) values (2000,2,1,'HP-skrivare','totalt värdelös skrivare från HP')

insert into ProductLists (OrderID, ProductID, Quantity) values (1, 1, 2)



select * from  Users
select* from Orders
select * from Products
select * from Vat
select p.Price as Pris, (Price + Price*v.VatTagMoney) as PrisMedMoms  from Products as p, Vat as v where p.VatTag=v.VatID

GO

CREATE VIEW [dbo].[FullOverView]
AS
SELECT        dbo.Products.*, dbo.Vat.*, dbo.Users.UserID, dbo.Users.FirstName, dbo.Users.LastName, dbo.Users.Street, dbo.Users.Zip, dbo.Users.City, dbo.Users.Country, dbo.Users.PhoneNumber, dbo.Users.Email,
 dbo.Users.isAdmin, dbo.ProductLists.ProductListID, dbo.ProductLists.Quantity, dbo.Orders.OrderID, dbo.Orders.OrderStatus, dbo.Orders.OrderDate
FROM            dbo.Orders INNER JOIN
                         dbo.ProductLists ON dbo.Orders.OrderID = dbo.ProductLists.OrderID INNER JOIN
                         dbo.Products ON dbo.ProductLists.ProductID = dbo.Products.ProductID INNER JOIN
                         dbo.Users ON dbo.Orders.UserID = dbo.Users.UserID INNER JOIN
                         dbo.Vat ON dbo.Products.VatTag = dbo.Vat.VatID

GO

Select * from FullOverView

GO


CREATE PROCEDURE GetOrders
@UserID int
AS
Select * from FullOverView where FullOverView.UserID = @UserID
GO

Execute GetOrders 2

GO

EXECUTE getUser 'redgert','hemligtord'


AS

Select * from FullOverView where FullOverView.ProductListID = ProductListID

GO

Execute GetProductList 1
