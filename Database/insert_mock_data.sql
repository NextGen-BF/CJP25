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
