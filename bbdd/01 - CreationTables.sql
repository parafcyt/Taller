CREATE TABLE [User] (
	[UserId] INT PRIMARY KEY IDENTITY(1,1),
	[LoginName] VARCHAR(100) NOT NULL,
	[Password] VARCHAR(MAX) NOT NULL,
	[Active] BIT NOT NULL,
	[Name] VARCHAR(100),
	[LastName] VARCHAR(100),
	[Email] VARCHAR(100),
	[CreatedDate] DATETIME NOT NULL
);

CREATE TABLE [RegistrationMethod] (
	[RegistrationMethodId] TINYINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(100) NOT NULL
);

CREATE TABLE [Customer] (
	[CustomerId] INT PRIMARY KEY IDENTITY(1,1),
	[CustomerSourceId] VARCHAR(500) NOT NULL,
	[Name] VARCHAR(100),
	[LastName] VARCHAR(100),
	[DNI] VARCHAR(50),
	[Email] VARCHAR(100),
	[Birthdate] DATE,
	[PhoneNumber] VARCHAR(100),
	[RegistrationCompleted] BIT NOT NULL DEFAULT(0),
	[CreatedDate] DATETIME NOT NULL,
	[RegistrationMethodId] TINYINT NOT NULL REFERENCES [RegistrationMethod]([RegistrationMethodId])
);

CREATE TABLE [RatingScale] (
	[RatingScaleId] TINYINT PRIMARY KEY IDENTITY(0,1),
	[Name] VARCHAR(350) NOT NULL
);

CREATE TABLE [Transport] (
	[TransportId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL
);

CREATE TABLE [BookingType] (
	[BookingTypeId] TINYINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL
);

CREATE TABLE [Origin] (
	[OriginId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL
);

CREATE TABLE [Destination] (
	[DestinationId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL,
	[Description] VARCHAR(500) 
);

CREATE TABLE [Hotel] (
	[HotelId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL,
	[Description] VARCHAR(500),
	[DestinationId] INT NOT NULL REFERENCES [Destination]([DestinationId])
);

CREATE TABLE [HotelPhoto] (
	[HotelPhotoId] INT PRIMARY KEY IDENTITY(1,1),
	[URL] VARCHAR(MAX) NOT NULL,
	[Description] VARCHAR(500),
	[HotelId] INT NOT NULL REFERENCES [Hotel]([HotelId])
);

CREATE TABLE [DestinationPhoto] (
	[DestinationPhotoId] INT PRIMARY KEY IDENTITY(1,1),
	[URL] VARCHAR(MAX) NOT NULL,
	[Description] VARCHAR(500),
	[DestinationId] INT NOT NULL REFERENCES [Destination]([DestinationId])
);

CREATE TABLE [Excursion] (
	[ExcursionId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL,
	[Description] VARCHAR(500),
	[DestinationId] INT NOT NULL REFERENCES [Destination]([DestinationId])
);

CREATE TABLE [Product] (
	[ProductId] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL,
	[DepartureDate] DATE NOT NULL,
	[ReturnDate] DATE NOT NULL,
	[Price] FLOAT NOT NULL CHECK(Price >= 0),
	[Stock] INT NOT NULL CHECK(Stock >= 0),
	[DocumentationDes] VARCHAR(350),
	[Active] BIT NOT NULL DEFAULT(0),
	[CreatedDate] DATETIME NOT NULL,
	[BookingTypeId] TINYINT NOT NULL REFERENCES [BookingType]([BookingTypeId]),
	[OriginId] INT NOT NULL REFERENCES [Origin]([OriginId]),
	[DestinationId] INT NOT NULL REFERENCES [Destination]([DestinationId]),
	[HotelId] INT NOT NULL REFERENCES [Hotel]([HotelId])
);

CREATE TABLE [ProductTransport] (
	[ProductTransportId] INT PRIMARY KEY IDENTITY(1,1),
	[Order] TINYINT NOT NULL CHECK([Order] >= 0),
	[Information] VARCHAR(500),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId]),
	[TransportId] INT NOT NULL REFERENCES [Transport]([TransportId])
);

CREATE TABLE [ProductExcursion] (
	[ProductExcursionId] INT PRIMARY KEY IDENTITY(1,1),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId]),
	[ExcursionId] INT NOT NULL REFERENCES [Excursion]([ExcursionId])
);

CREATE TABLE [Offer] (
	[OfferId] INT PRIMARY KEY IDENTITY(1,1),
	[OfferPrice] FLOAT NOT NULL CHECK(OfferPrice >= 0),
	[StartDate] DATETIME NOT NULL,
	[EndtDate] DATETIME NOT NULL,
	[Active] BIT NOT NULL,
	[BannerText] VARCHAR(100),
	[CreatedtDate] DATETIME NOT NULL,
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId])
);

CREATE TABLE [Favorite] (
	[FavoriteId] INT PRIMARY KEY IDENTITY(1,1),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId]),
	[CustomerId] INT NOT NULL REFERENCES [Customer]([CustomerId]),
	[CreatedtDate] DATETIME NOT NULL
);

CREATE TABLE [OrderState] (
	[OrderStateId] TINYINT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(350) NOT NULL
);

CREATE TABLE [Payment] (
	[PaymentId] INT PRIMARY KEY IDENTITY(1,1),
	[SourceId] INT NOT NULL,
	[CreatedtDate] DATETIME NOT NULL,
	[ApprovedDate] DATETIME NOT NULL,
	[PaymentMethodId] VARCHAR(100) NOT NULL,
	[PaymentTypeId] VARCHAR(100) NOT NULL,
	[Status] VARCHAR(100) NOT NULL
);

CREATE TABLE [Order] (
	[OrderId] INT PRIMARY KEY IDENTITY(1,1),
	[Quantity] INT NOT NULL CHECK(Quantity > 0),
	[UnitPrice] FLOAT NOT NULL CHECK(UnitPrice >= 0),
	[TotalPrice] FLOAT NOT NULL CHECK(TotalPrice >= 0),
	[Discount] FLOAT,
	[CreatedDate] DATETIME NOT NULL,
	[OrderStateId] TINYINT NOT NULL REFERENCES [OrderState]([OrderStateId]),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId]),
	[CustomerId] INT NOT NULL REFERENCES [Customer]([CustomerId]),
	[RatingScaleId] TINYINT NOT NULL REFERENCES [RatingScale]([RatingScaleId]) DEFAULT(0),
	[PaymentId] INT NOT NULL REFERENCES [Payment]([PaymentId])
);

