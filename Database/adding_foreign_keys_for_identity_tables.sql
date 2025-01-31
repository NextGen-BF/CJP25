ALTER TABLE UserBuildings 
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE PropertyUsers
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE RepairRequests
ADD FOREIGN KEY (UserId) REFERENCES Users(UserId);

ALTER TABLE PropertyExpense
ADD FOREIGN KEY (RoleId) REFERENCES Roles(RoleId);

ALTER TABLE UserBuildings 
ADD FOREIGN KEY (RoleId) REFERENCES Roles(RoleId);

ALTER TABLE PropertyUsers
ADD FOREIGN KEY (RoleId) REFERENCES Roles(RoleId);

-- adding scripts for adding information about who deleted

ALTER TABLE Enums
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE Address
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE Buildings
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE BuildingExpenses
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE Property
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE PropertyResident
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE PropertyExpenseTemplate
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE PropertyExpense
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE PropertyPayments
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE UserBuildings
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE PropertyUsers
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE RepairRequests
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);

ALTER TABLE RequestNotes
ADD FOREIGN KEY (DeletedBy) REFERENCES Users(UserId);