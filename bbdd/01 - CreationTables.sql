CREATE TABLE [User] (
	[UserId] VARCHAR(500) PRIMARY KEY,
	[State] BIT NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100)
);

CREATE TABLE [Customer] (
	[CustomerId] VARCHAR(500) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[LastName] VARCHAR(100) NOT NULL,
	[DNI] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[PhoneNumber] VARCHAR(100) NOT NULL
);

CREATE TABLE [RatingScale] (
	[RatingScaleId] TINYINT PRIMARY KEY IDENTITY(1,1),
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
	[Description] VARCHAR(500),
	[DepartureDate] DATE NOT NULL,
	[ReturnDate] DATE NOT NULL,
	[Price] FLOAT NOT NULL,
	[Stock] INT NOT NULL,
	[DocumentationDes] VARCHAR(350),
	[State] BIT NOT NULL,
	[BookingTypeId] TINYINT NOT NULL REFERENCES [BookingType]([BookingTypeId]),
	[OriginId] INT NOT NULL REFERENCES [Origin]([OriginId]),
	[DestinationId] INT NOT NULL REFERENCES [Destination]([DestinationId]),
	[HotelId] INT NOT NULL REFERENCES [Hotel]([HotelId])
);

CREATE TABLE [ProductTransport] (
	[ProductTransportId] INT PRIMARY KEY IDENTITY(1,1),
	[Order] TINYINT NOT NULL,
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
	[OfferPrice] FLOAT NOT NULL,
	[CreationDate] DATE NOT NULL,
	[State] BIT NOT NULL,
	[BannerText] VARCHAR(100),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId])
);

CREATE TABLE [Favorite] (
	[FavoriteId] INT PRIMARY KEY IDENTITY(1,1),
	[ProductId] INT REFERENCES [Product]([ProductId]),
	[CustomerId] VARCHAR(500) NOT NULL REFERENCES [Customer]([CustomerId]),
);

CREATE TABLE [Order] (
	[OrderId] INT PRIMARY KEY IDENTITY(1,1),
	[Quantity] INT NOT NULL,
	[UnitPricePaid] FLOAT NOT NULL,
	[Total] FLOAT NOT NULL,
	[DateOrder] DATE NOT NULL,
	[State] BIT NOT NULL DEFAULT(1),
	[ProductId] INT NOT NULL REFERENCES [Product]([ProductId]),
	[CustomerId] VARCHAR(500) NOT NULL REFERENCES [Customer]([CustomerId]),
	[RatingScaleId] TINYINT NULL REFERENCES [RatingScale]([RatingScaleId])
);