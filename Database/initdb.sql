-- Create enums table
CREATE TABLE  Enums(
	EnumId INT PRIMARY KEY,  	
	Description TEXT NOT NULL,
	Title VARCHAR(40) UNIQUE NOT NULL,
	Type VARCHAR(40) NOT NULL, 
	Value INT
);
-- Create addresses table 
CREATE TABLE  Address (
	AddressId INT PRIMARY KEY IDENTITY(1,1),
	StreetNumber INT,
	--	look up possible entrances
	Entrance VARCHAR(5) NOT NULL,
	StreetName VARCHAR(40) NOT NULL,
	District VARCHAR(40) NOT NULL,
	City VARCHAR(40) NOT NULL,
    -- 12 is (maybe) the longest possible postcode length
	PostalCode VARCHAR(12) NOT NULL,
	Country VARCHAR(40) NOT NULL,
);
-- Create the buildings table
CREATE TABLE Buildings (
	BuildingId INT PRIMARY KEY IDENTITY(1,1),
	AddressId INT UNIQUE NOT NULL,
	Alias VARCHAR(40),
	FloorNum INT NOT NULL,
	TotalBuildingSize DECIMAL(5,2) NOT NULL,
	DateBuild DATE NOT NULL,
	NumOfElevators INT NOT null,
	FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
);
-- Create the buildings table
CREATE TABLE Property (
	PropertyId INT PRIMARY KEY IDENTITY(1,1),
	BuildingId INT NOT NULL,
	PropertyTypeId INT NOT NULL,
	PropertyNumber INT NOT NULL,
	Size DECIMAL(3,2) NOT NULL,
	Floor INT NOT NULL,
	SizeOfIdealParts DECIMAL(3,2) NOT NULL,
	EntranceIsExternal BIT NOT NULL,
	FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
	FOREIGN KEY (PropertyTypeId) REFERENCES Enums(EnumId)
);
-- Create the property residents table
CREATE TABLE PropertyResidents (
	PropertyResidentId INT PRIMARY KEY IDENTITY(1,1),
	ResidentTypeId INT NOT NULL,
	PropertyId INT NOT NULL,
	FirstName VARCHAR(40) NOT NULL,
	LastName VARCHAR(40) NOT NULL,
	Floor INT NOT NULL,
	EnterDate DATE NOT NULL,
	-- double check if nullable
	LeaveDate DATE,
	FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId),
	FOREIGN KEY (ResidentTypeId) REFERENCES Enums(EnumId)
);

CREATE TABLE BuildingExpenses (
	BuildingExpenseId INT PRIMARY KEY IDENTITY(1,1),
	BuildingId INT UNIQUE NOT NULL,
	Title VARCHAR(40),
	FloorNum INT NOT NULL,
	TotalAmount DECIMAL(10,2) NOT NULL,
	SupplierId INT UNIQUE NOT NULL,
	DateOpened DATE NOT NULL,
	DueDate DATE NOT NULL,
	PaymentDate DATE NOT NULL,
	Description TEXT NOT NULL,
	IsTemplate BIT NOT NULL,
	RepeatPeriodId INT NOT NULL,
	InvoiceURL TEXT NOT NULL,
	FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
	FOREIGN KEY (SupplierId) REFERENCES Enums(EnumId),
	FOREIGN KEY (RepeatPeriodId) REFERENCES Enums(EnumId)
);

CREATE TABLE PropertyExpense (
	PropertyExpenseId INT PRIMARY KEY IDENTITY(1,1),
	PropertyExpenseTemplateId INT NOT NULL,
	RepeatPeriodId INT NOT NULL,
    RoleId INT NOT NULL,
	Price DECIMAL(10,2),
    Description TEXT,
    StartDate DATE NOT NULL,
    EndDate DATE,
	FOREIGN KEY (RoleId) references Enums(EnumId),
	FOREIGN KEY (RepeatPeriodId) REFERENCES Enums(EnumId)
);

CREATE TABLE PropertyExpenseTemplate (
    PropertyExpenseTemplateId INT PRIMARY KEY IDENTITY(1,1),
	RepeatPeriodId INT NOT NULL,
    ExpenseTitle VARCHAR(40),
	PerResident BIT NOT NULL,
	FOREIGN KEY (RepeatPeriodId) REFERENCES Enums(EnumId)
);
--Create table for email templates
CREATE TABLE EmailTemplate (
    EmailTemplateId INT IDENTITY(1,1),
    Title VARCHAR(40) NOT NULL,
    Description TEXT NOT NULL,
    Body TEXT
);
--Ccreate table for payments
CREATE TABLE  PropertyPayments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    PropertyId INT NOT NULL,
    PropertyExpenseId INT NOT NULL,
    StatusId INT NOT NULL,
    PaymentMethodId INT NOT NULL,
    PaymentParentId INT,
    AmountOwed DECIMAL(10,2) NOT NULL,
    DateOpened DATE NOT NULL,
    DueDate DATE NOT NULL,
    FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId),
    FOREIGN KEY (PropertyExpenseId) REFERENCES PropertyExpense(PropertyExpenseId),
    FOREIGN KEY (StatusId) REFERENCES Enums(EnumId),
	FOREIGN KEY (PaymentMethodId) REFERENCES Enums(EnumId)
);