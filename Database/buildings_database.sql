CREATE TABLE Enums (
    EnumID INT PRIMARY KEY IDENTITY (1, 1),
    Description TEXT NOT NULL,
    Title VARCHAR(40) UNIQUE NOT NULL,
    Type VARCHAR(40) NOT NULL,
    Value INT NOT NULL,
);

CREATE TABLE Address (
    AddressID INT PRIMARY KEY IDENTITY (1, 1),
    StreetNumber INT NOT NULL,
    Entrance VARCHAR(255) NOT NULL,
    StreetName VARCHAR(255) NOT NULL,
    District VARCHAR(255) NOT NULL,
    PostalCode VARCHAR(255) NOT NULL,
    Country VARCHAR(255) NOT NULL,
);

CREATE TABLE Buildings(
    BuildingID INT PRIMARY KEY IDENTITY (1, 1),
    AddressID INT NOT NULL, -- FK -> Address
    Alias VARCHAR(255) NOT NULL,
    FloorNum INT NOT NULL,
    TotalBuildingSize DECIMAL(10, 2) NOT NULL,
    DateBuilt DATE NOT NULL,
    NumOfElevators INT NOT NULL,
    FOREIGN KEY (AddressID) REFERENCES Address(AddressID),
);

CREATE TABLE BuildingExpenses(
    BuildingExpenseID INT PRIMARY KEY IDENTITY (1, 1),
    BuildingID INT NOT NULL, -- FK -> Buildings
    Title VARCHAR(255) NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    SupplierID INT NOT NULL, -- FK -> Enums
    DateOpened DATE NOT NULL,
    DueDate DATE NOT NULL,
    PaymentDate DATE NOT NULL,
    Description TEXT NOT NULL,
    IsTemplate BIT NOT NULL,
    RepeatPeriodID INT NOT NULL, 
    InvoiceURL TEXT NOT NULL,
    FOREIGN KEY (BuildingID) REFERENCES Buildings(BuildingID),
    FOREIGN KEY (SupplierID) REFERENCES Enums(EnumID),
);


CREATE TABLE Property(
    PropertyID INT PRIMARY KEY IDENTITY (1, 1),
    BuildingID INT NOT NULL, --FK Buildings
    PropertyNumber INT NOT NULL,
    Size DECIMAL(10, 2) NOT NULL,
    Floor INT NOT NULL,
    SizeOfIdealParts DECIMAL(10, 2) NOT NULL,
    PropertyTypeID INT NOT NULL, -- FK Enums
    EntranceIsExternal BIT NOT NULL,
    FOREIGN KEY (BuildingID) REFERENCES Buildings(BuildingID),
    FOREIGN KEY (PropertyTypeID) REFERENCES Enums(EnumID),
);

CREATE TABLE PropertyResident(
    PropertyResidentID INT PRIMARY KEY IDENTITY (1, 1),
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    ResidentTypeID INT NOT NULL, -- FK -> Enums 
    PropertyID INT NOT NULL, -- FK
    EnterDate DATE NOT NULL,
    LeaveDate DATE NOT NULL,
);

CREATE TABLE PropertyExpenseTemplate (
    PropertyExpenseTemplateID INT PRIMARY KEY IDENTITY (1, 1),
    ExpenseTitle VARCHAR(40) NOT NULL,
    PerResident BIT NOT NULL,
    RepeatPeriodID INT NOT NULL, --FK Enums
    FOREIGN KEY (RepeatPeriodID) REFERENCES Enums(EnumID),
);

CREATE TABLE PropertyExpense (
    PropertyExpenseID INT PRIMARY KEY IDENTITY (1, 1),
    PropertyExpenseTemplateID INT NOT NULL, -- FK  PropertyExpenseTemplate
    RoleID INT, -- FK Roles
    Price DECIMAL(10, 2) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE, -- nullable
    Description TEXT NOT NULL, 
    FOREIGN KEY (PropertyExpenseTemplateID) REFERENCES PropertyExpenseTemplate(PropertyExpenseTemplateID),
);


CREATE TABLE PropertyPayments (
    PaymentID INT PRIMARY KEY IDENTITY (1, 1),
    PropertyID INT NOT NULL, -- FK Property
    AmountOwed DECIMAL(10, 2) NOT NULL,
    DateOpened DATE NOT NULL,
    DueDate DATE NOT NULL,
    PropertyExpenseID INT NOT NULL, --FK PropertyExpense
    StatusID INT NOT NULL, -- FK -> Enums 
    PaymentParentID INT, -- FK to the same table
    PaymentMethodID INT NOT NULL, -- FK -> Enums 
    FOREIGN KEY (PropertyID) REFERENCES Property(PropertyID),
    FOREIGN KEY (PropertyExpenseID) REFERENCES PropertyExpense(PropertyExpenseID),
    FOREIGN KEY (StatusID) REFERENCES Enums(EnumID),
    FOREIGN KEY (PaymentParentID) REFERENCES PropertyPayments(PaymentID),
    FOREIGN KEY (PaymentMethodID) REFERENCES Enums(EnumID),
);


CREATE TABLE UserBuildings (
    UserBuildingsID INT PRIMARY KEY IDENTITY (1, 1),
    UserID INT, -- FK Users
    BuildingID INT NOT NULL, --FK Buildings
    Approved BIT NOT NULL,
    RoleID INT, -- FK Roles
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    FOREIGN KEY (BuildingID) REFERENCES Buildings(BuildingID),
);

CREATE TABLE PropertyUsers (
    PropertyUsersID INT PRIMARY KEY IDENTITY (1, 1),
    PropertyID INT NOT NULL, -- FK Property
    UserID INT, -- FK Users
    RoleID INT, -- FK Roles,
    EffectiveDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    PercentOfApartmentOwned DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PropertyID) REFERENCES Property(PropertyID),
);

CREATE TABLE RepairRequests (
    RequestID INT PRIMARY KEY IDENTITY (1, 1),
    UserID INT, -- FK Users
    RequestDescription TEXT NOT NULL,
    RequestStatusID INT NOT NULL, -- FK Enums
    DateOpened DATE NOT NULL,
    DateSettled DATE NOT NULL,
    FOREIGN KEY (RequestStatusID) REFERENCES Enums(EnumID),
);


CREATE TABLE RequestNotes (
    NoteID INT PRIMARY KEY IDENTITY (1, 1),
    RequestID INT NOT NULL, -- FK RepairRequests
    NoteText TEXT NOT NULL, 
    CreateDate DATE NOT NULL,
    CreatedBy INT, -- FK Users
    FOREIGN KEY (RequestID) REFERENCES RepairRequests(RequestID),
);







