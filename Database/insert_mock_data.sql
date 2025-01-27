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
) VALUES (1, 600.00, NULL, '2023-04-05', 'Mocked Description 1'),
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
) VALUES (1, 450.00, NULL, '2025-03-01', 1, 1, NULL, 1),
(2, 600.00, '2025-01-10', '2025-04-01', 2, 1, 1, 2),
(3, 330.50, '2024-12-12', '2025-03-01', 1, 2, NULL, 2);

INSERT INTO UserBuildings (
    BuildingId,
    Approved,
    StartDate,
    EndDate
) VALUES (1, 0, NULL, '2025-03-05'),
(2, 1, '2025-01-03', '2025-03-01'),
(3, 0, NULL, '2025-03-20');

INSERT INTO PropertyUsers (
    PropertyId,
    EffectiveDate,
    EndDate,
    PercentOfApartmentOwned
) VALUES (1, '2024-12-18', '2025-02-02', 60.00),
(2, NULL, '2025-02-22', 55.50),
(3, '2025-01-05', '2025-02-01', 30.00);

INSERT INTO RepairRequests (
    BuildingId,
    RequestDescription,
    RequestStatusId,
    DateOpened,
    DateSettled
) VALUES (1, 'Mocked Request Description 1', 1, '2025-01-09', '2025-01-27'),
(2, 'Mocked Request Description 2', 2, '2024-12-21', '2025-01-11'),
(3, 'Mocked Request Description 3', 1, NULL, '2025-01-04');


INSERT INTO RequestNotes (
    RequestId,
    NoteText,
    CreateDate,
    CreatedBy
) VALUES (1, 'Mocked Note Text 1', '2025-01-07', 1),
(2, 'Mocked Note Text 2', '2024-12-10', 2),
(3, 'Mocked Note Text 3', NULL, 1);

