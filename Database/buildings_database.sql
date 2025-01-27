CREATE TABLE Enums (
    EnumId INT PRIMARY KEY IDENTITY (1, 1),
    Description TEXT NOT NULL,
    Title VARCHAR(50) UNIQUE NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Value INT,
);

CREATE TABLE Address (
    AddressId INT PRIMARY KEY IDENTITY (1, 1),
    StreetNumber INT NOT NULL,
    Entrance VARCHAR(5),
    StreetName VARCHAR(50) NOT NULL,
    District VARCHAR(50) NOT NULL,
    PostalCode VARCHAR(12) NOT NULL,
    Country VARCHAR(50) NOT NULL,
);

CREATE TABLE Buildings(
    BuildingId INT PRIMARY KEY IDENTITY (1, 1),
    AddressId INT UNIQUE NOT NULL, -- FK -> Address
    Alias VARCHAR(50),
    FloorNum INT NOT NULL,
    TotalBuildingSize DECIMAL(6, 2) NOT NULL,
    DateBuilt DATE NOT NULL,
    NumOfElevators INT NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Address(AddressId),
);

CREATE TABLE BuildingExpenses(
    BuildingExpenseId INT PRIMARY KEY IDENTITY (1, 1),
    BuildingId INT NOT NULL, -- FK -> Buildings
    Title VARCHAR(50) NOT NULL,
    TotalAmount DECIMAL(6, 2) NOT NULL,
    SupplierId INT NOT NULL, -- FK -> Enums
    DateOpened DATE NOT NULL,
    DueDate DATE NOT NULL,
    PaymentDate DATE NOT NULL,
    Description TEXT NOT NULL,
    IsTemplate BIT NOT NULL,
    RepeatPeriodId INT NOT NULL, 
    InvoiceURL TEXT,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
    FOREIGN KEY (SupplierId) REFERENCES Enums(EnumId),
    FOREIGN KEY (RepeatPeriodId) REFERENCES Enums(EnumId),
);


CREATE TABLE Property(
    PropertyId INT PRIMARY KEY IDENTITY (1, 1),
    BuildingId INT NOT NULL, --FK Buildings
    PropertyNumber INT NOT NULL,
    Size DECIMAL(6, 2) NOT NULL,
    Floor INT NOT NULL,
    SizeOfIdealParts DECIMAL(6, 2) NOT NULL,
    PropertyTypeId INT NOT NULL, -- FK Enums
    EntranceIsExternal BIT NOT NULL,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
    FOREIGN KEY (PropertyTypeId) REFERENCES Enums(EnumId),
);

CREATE TABLE PropertyResident(
    PropertyResidentId INT PRIMARY KEY IDENTITY (1, 1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    ResidentTypeId INT NOT NULL, -- FK -> Enums 
    PropertyId INT NOT NULL, -- FK Property
    EnterDate DATE DEFAULT GETDATE(),
    LeaveDate DATE,
    FOREIGN KEY (ResidentTypeId) REFERENCES Enums(EnumId),
    FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId),
);

CREATE TABLE PropertyExpenseTemplate (
    PropertyExpenseTemplateId INT PRIMARY KEY IDENTITY (1, 1),
    ExpenseTitle VARCHAR(50) NOT NULL,
    PerResident BIT NOT NULL,
    RepeatPeriodId INT NOT NULL, --FK Enums
    FOREIGN KEY (RepeatPeriodId) REFERENCES Enums(EnumId),
);

CREATE TABLE PropertyExpense (
    PropertyExpenseId INT PRIMARY KEY IDENTITY (1, 1),
    PropertyExpenseTemplateId INT NOT NULL, -- FK  PropertyExpenseTemplate
    RoleId INT, -- FK Roles
    Price DECIMAL(6, 2) NOT NULL,
    StartDate DATE DEFAULT GETDATE(),
    EndDate DATE, -- nullable
    Description TEXT NOT NULL, 
    FOREIGN KEY (PropertyExpenseTemplateId) REFERENCES PropertyExpenseTemplate(PropertyExpenseTemplateId),
);


CREATE TABLE PropertyPayments (
    PaymentId INT PRIMARY KEY IDENTITY (1, 1),
    PropertyId INT NOT NULL, -- FK Property
    AmountOwed DECIMAL(6, 2) NOT NULL,
    DateOpened DATE DEFAULT GETDATE(),
    DueDate DATE NOT NULL,
    PropertyExpenseId INT NOT NULL, --FK PropertyExpense
    StatusId INT NOT NULL, -- FK -> Enums 
    PaymentParentId INT, -- FK to the same table
    PaymentMethodId INT NOT NULL, -- FK -> Enums 
    FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId),
    FOREIGN KEY (PropertyExpenseId) REFERENCES PropertyExpense(PropertyExpenseId),
    FOREIGN KEY (StatusId) REFERENCES Enums(EnumId),
    FOREIGN KEY (PaymentParentId) REFERENCES PropertyPayments(PaymentId),
    FOREIGN KEY (PaymentMethodId) REFERENCES Enums(EnumId),
);


CREATE TABLE UserBuildings (
    UserBuildingsId INT PRIMARY KEY IDENTITY (1, 1),
    UserId INT, -- FK Users
    BuildingId INT NOT NULL, --FK Buildings
    Approved BIT DEFAULT 0,
    RoleId INT, -- FK Roles
    StartDate DATE DEFAULT GETDATE(),
    EndDate DATE,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
);

CREATE TABLE PropertyUsers (
    PropertyUsersId INT PRIMARY KEY IDENTITY (1, 1),
    PropertyId INT NOT NULL, -- FK Property
    UserId INT, -- FK Users
    RoleId INT, -- FK Roles,
    EffectiveDate DATE DEFAULT GETDATE(),
    EndDate DATE,
    PercentOfApartmentOwned DECIMAL(6, 2) NOT NULL,
    FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId),
);

CREATE TABLE RepairRequests (
    RequestId INT PRIMARY KEY IDENTITY (1, 1),
    UserId INT, -- FK Users
    BuildingId INT NOT NULL, -- FK Buildings
    RequestDescription TEXT NOT NULL,
    RequestStatusId INT NOT NULL, -- FK Enums
    DateOpened DATE DEFAULT GETDATE(),
    DateSettled DATE,
    FOREIGN KEY (RequestStatusId) REFERENCES Enums(EnumId),
    FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId),
);


CREATE TABLE RequestNotes (
    NoteId INT PRIMARY KEY IDENTITY (1, 1),
    RequestId INT NOT NULL, -- FK RepairRequests
    NoteText TEXT NOT NULL, 
    CreateDate DATE DEFAULT GETDATE(),
    CreatedBy INT, -- FK Users
    FOREIGN KEY (RequestId) REFERENCES RepairRequests(RequestId),
);







