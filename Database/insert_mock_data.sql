INSERT INTO Enums(
    Description,
    Title,
    Type,
    Value
) VALUES ('Residents exempt from paying building taxes and such', 'Exempt', 'ResidentType', NULL), 
('Pets', 'Pet', 'ResidentType', NULL),
('Residents paying taxes and such', 'Paying', 'ResidentType', NULL),
('', 'None', 'ResidentType', NULL),
('Apartments', 'Apartment', 'PropertyType', NULL),
('Shopping', 'Shop', 'PropertyType', NULL),
('Ground floor garages', 'Garage', 'PropertyType', NULL),
('Storerooms', 'Storeroom', 'PropertyType', NULL),
('Offices', 'Office', 'PropertyType', NULL),
('Small apartments without a garage', 'Atelier', 'PropertyType', NULL),
('Credit/Debit card', 'Card', 'PaymentMethod', NULL),
('Bank Transfer', 'Bank Transfer', 'PaymentMethod', NULL),
('Digital wallet', 'Digital wallet', 'PaymentMethod', NULL),
('Still pending', 'Pending', 'RequestStatus', NULL),
('Request has been resolved', 'Resolved', 'RequestStatus', NULL),
('Reviewed by the managers', 'Reviewed', 'RequestStatus', NULL),
('Every month', 'Every month', 'RepeatPeriod', 1),
('Every 2 months', 'Every 2 months', 'RepeatPeriod', 2),
('Every quarter', 'Every quarter', 'RepeatPeriod', 3),
('Twice a year', 'Twice a year', 'RepeatPeriod', 6),
('Every year', 'Every year', 'RepeatPeriod', 12),
('General supplier', 'Placeholder supplier', 'Supplier', NULL);

INSERT INTO Address(
    StreetNumber,
    Entrance,
    StreetName,
    District,
    PostalCode,
    Country
) VALUES ( 47, 'B', 'Mocked Street', 'Mocked Distr.', '9000', 'Bulgaria' ), 
( 47, 'A', 'Mocked Street', 'Mocked Distr.', '9000', 'Bulgaria' ),
( 49, 'A', 'Mocked Street', 'Mocked Distr.', '9000', 'Bulgaria' );

INSERT INTO Buildings(
    AddressId,
    Alias,
    FloorNum,
    TotalBuildingSize,
    DateBuilt,
    NumOfElevators
) VALUES ( 1, 'Aunt Penka''s Ap. Block', 5, 1523.32, '2003-01-01', 1 ), 
( 2, 'Aunt Penka''s Ap. Block', 5, 1123.32, '2003-01-01', 1 ),
( 3, 'New m str building', 7, 1723.32, '2025-01-01', 1 );

INSERT INTO BuildingExpenses(
    BuildingId,
    Title,
    TotalAmount,
    SupplierId,
    DateOpened,
    DueDate,
    PaymentDate,
    Description,
    IsTemplate,
    RepeatPeriodId
) VALUES ( 1, 'Electricity', 2000.54, 21, '2025-01-01', '2025-02-01', '2025-01-30', 'El. bill', 0, 16), 
( 1, 'Water', 1000.53, 21, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 16),
( 2, 'Electricity', 1020.53, 21, '2025-01-01', '2025-02-01', '2025-01-29', 'El. bill', 0, 16),
( 2, 'Water', 1700.53, 21, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 16),
( 3, 'Electricity', 2300.54, 21, '2025-01-01', '2025-02-01', '2025-01-30', 'El. bill', 0, 16), 
( 3, 'Water', 1300.53, 21, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 16);

INSERT INTO Property(
    BuildingId,
    PropertyNumber,
    Size,
    Floor,
    SizeOfIdealParts,
    PropertyTypeId,
    EntranceIsExternal
) VALUES ( 2, 1, 53.32, 1, 50.32, 4, 0), 
( 2, 2, 51.32, 1, 50.32, 4, 0), 
( 2, 3, 52.32, 1, 50.32, 4, 0), 
( 2, 4, 54.32, 2, 50.32, 4, 0), 
( 2, 5, 55.32, 2, 50.32, 4, 0), 
( 2, 6, 56.32, 2, 50.32, 4, 0),
( 3, 1, 53.32, 1, 50.32, 4, 0), 
( 3, 2, 51.32, 1, 50.32, 4, 0), 
( 3, 3, 52.32, 1, 50.32, 4, 0), 
( 3, 4, 54.32, 2, 50.32, 4, 0), 
( 3, 5, 55.32, 2, 50.32, 4, 0), 
( 3, 6, 56.32, 2, 50.32, 4, 0);

INSERT INTO PropertyResident(
    FirstName,
    LastName,
    ResidentTypeId,
    PropertyId
) VALUES ( 'Ivan', 'Ivanov', 2, 7), 
( 'Penka', 'Penkova', 2, 7), 
( 'Anton', 'Antonov', 2, 8), 
( 'Ivan', 'Georgiev', 2, 9), 
( 'Ivan', 'Antonov', 2, 7),
( 'Georgi', 'Ivanov', 2, 7), 
( 'Ivan', 'Ivanov', 2, 8), 
( 'Ivan', 'Dimitrov', 2, 8), 
( 'Georgi', 'Dimitrov', 2, 7), 
( 'Anton', 'Ivanov', 2, 7);

INSERT INTO PropertyExpenseTemplate (
    ExpenseTitle,
    PerResident,
    RepeatPeriodId
) VALUES ('Mocked Expense Title 1', 0, 1),
('Mocked Expense Title 2', 1, 2),
('Mocked Expense Title 3', 0, 2);

INSERT INTO PropertyExpense (
    PropertyExpenseTemplateId, 
    Price,
    StartDate,
    EndDate,
    Description
) VALUES (1, 600.00, '2024-12-12', '2025-04-05', 'Mocked Description 1'),
(2, 450.50, '2024-12-09', '2025-03-11', 'Mocked Description 2'),
(3, 300.50, '2025-01-05', '2025-04-10', 'Mocked Description 3');

INSERT INTO PropertyPayments (
    PropertyId,
    AmountOwed,
    DateOpened,
    DueDate,
    PropertyExpenseId,
    StatusId,
    PaymentParentId,
    PaymentMethodId
) VALUES (7, 450.00, '2025-01-15', '2025-03-01', 1, 1, NULL, 1),
(8, 600.00, '2025-01-10', '2025-04-01', 2, 1, NULL, 2),
(9, 330.50, '2024-12-12', '2025-03-01', 1, 2, NULL, 2);

INSERT INTO UserBuildings (
    BuildingId,
    Approved,
    StartDate,
    EndDate
) VALUES (1, 0, '2025-01-23', '2025-03-05'),
(2, 1, '2025-01-03', '2025-03-01'),
(3, 0, '2025-01-13', '2025-03-20');

INSERT INTO PropertyUsers (
    PropertyId,
    EffectiveDate,
    EndDate,
    PercentOfApartmentOwned
) VALUES (7, '2024-12-18', '2025-02-02', 60.00),
(8, '2025-01-19', '2025-02-22', 55.50),
(9, '2025-01-05', '2025-02-01', 30.00);

INSERT INTO RepairRequests (
    BuildingId,
    RequestDescription,
    RequestStatusId,
    DateOpened,
    DateSettled
) VALUES (1, 'Mocked Request Description 1', 1, '2025-01-09', '2025-01-27'),
(2, 'Mocked Request Description 2', 2, '2024-12-21', '2025-01-11'),
(3, 'Mocked Request Description 3', 1, '2024-12-16', '2025-01-04');


INSERT INTO RequestNotes (
    RequestId,
    NoteText,
    CreateDate,
    CreatedBy
) VALUES (1, 'Mocked Note Text 1', '2025-01-07', 1),
(2, 'Mocked Note Text 2', '2024-12-10', 2),
(3, 'Mocked Note Text 3', '2024-12-18', 1);

