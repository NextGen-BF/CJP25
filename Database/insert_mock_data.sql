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
) VALUES ( 2, 'Electricity', 2000.54, 43, '2025-01-01', '2025-02-01', '2025-01-30', 'El. bill', 0, 38), 
( 2, 'Water', 1000.53, 43, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 38),
( 3, 'Electricity', 1020.53, 43, '2025-01-01', '2025-02-01', '2025-01-29', 'El. bill', 0, 38),
( 3, 'Water', 1700.53, 43, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 38),
( 4, 'Electricity', 2300.54, 43, '2025-01-01', '2025-02-01', '2025-01-30', 'El. bill', 0, 38), 
( 4, 'Water', 1300.53, 43, '2025-01-01', '2025-02-01', '2025-01-31', 'Water bill', 0, 38);

INSERT INTO Property(
    BuildingId,
    PropertyNumber,
    Size,
    Floor,
    SizeOfIdealParts,
    PropertyTypeId,
    EntranceIsExternal
) VALUES ( 2, 1, 53.32, 1, 50.32, 26, 0), 
( 2, 2, 51.32, 1, 50.32, 26, 0), 
( 2, 3, 52.32, 1, 50.32, 26, 0), 
( 2, 4, 54.32, 2, 50.32, 26, 0), 
( 2, 5, 55.32, 2, 50.32, 26, 0), 
( 2, 6, 56.32, 2, 50.32, 26, 0),
( 3, 1, 53.32, 1, 50.32, 26, 0), 
( 3, 2, 51.32, 1, 50.32, 26, 0), 
( 3, 3, 52.32, 1, 50.32, 26, 0), 
( 3, 4, 54.32, 2, 50.32, 26, 0), 
( 3, 5, 55.32, 2, 50.32, 26, 0), 
( 3, 6, 56.32, 2, 50.32, 26, 0);

INSERT INTO PropertyResident(
    FirstName,
    LastName,
    ResidentTypeId,
    PropertyId
) VALUES ( 'Ivan', 'Ivanov', 24, 1), 
( 'Penka', 'Penkova', 24, 1), 
( 'Anton', 'Antonov', 24, 2), 
( 'Ivan', 'Georgiev', 24, 3), 
( 'Ivan', 'Antonov', 24, 4),
( 'Georgi', 'Ivanov', 24, 5), 
( 'Ivan', 'Ivanov', 23, 6), 
( 'Ivan', 'Dimitrov', 24, 7), 
( 'Georgi', 'Dimitrov', 23, 7), 
( 'Anton', 'Ivanov', 24, 7);