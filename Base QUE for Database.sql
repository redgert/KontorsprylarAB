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

CREATE TABLE Vat
(
VatID int identity(1,1) Primary key,

TagOfficeSupply int NOT NULL,
TagBooks int NOT NULL
);




CREATE TABLE Products
(
ProductID int identity(1,1) PRIMARY KEY,
Price int NOT NULL,
VatTag int FOREIGN KEY references Vat(VatID),
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

create procedure getUser
@username varchar(50),
@password varchar(50)
as
select * from Users, Orders, ProductLists 
where Users.Username=@username AND Users.UserPassword=@password
Go


Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('KungG','Gurra16', 'Karl Gustav','Bernadotte','Slottet','Stockholm','11111', 'Sweden', '0701111111','Kalle@kungahuset.se',0)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('Redgert','hemligtord', 'Niklas','Redgert','Hagendalsvägen 15D','Kumla','69231', 'Sweden', '0702862125','niklas@redgert.com',1)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('Ichurep','lösenord', 'Alexander','Arana','Virebergsvägen 5','Stockholm','16931', 'Sweden', '0763353850','arana.alexander@gmail.com',1)
Insert into  Users (Username, UserPassword, FirstName, LastName, Street, City, Zip, Country, PhoneNumber, Email, IsAdmin) 
values ('pattzor','gillarintejava', 'Patrik','Jönsson','Storgatan','Malmö','00000', 'Skåneland', '0702222222','patrik@pattzor.se',0)

--insert into Vat (TagOfficeSupply, TagBooks) values (1,2)


--insert into Products (Price,Stock,VatTag, ShortDescription,LongDescription) values (150,30,2,'Bibeln','Världens mest sålda bok, men typ den minst lästa')
--insert into Products (Price,Stock,VatTag, ShortDescription,LongDescription) values (10,5000,1,'Blått gem','dåligt, blått plastgem')
--insert into Products (Price,Stock,VatTag, ShortDescription,LongDescription) values (25,300,1,'Röd penna','Röd transparant penna')
--insert into Products (Price,Stock,VatTag, ShortDescription,LongDescription) values (3500,0,1,'HP-skärm','väldigt medelmåttig skärm från HP')
--insert into Products (Price,Stock,VatTag, ShortDescription,LongDescription) values (2000,2,1,'HP-skrivare','totalt värdelös skrivare från HP')



--select * from  Users
--select* from Orders
--select * from Products

