-- Create enums table
CREATE TABLE  Enums(
	enum_id INT PRIMARY KEY,  	
	description TEXT,
	title VARCHAR(40) UNIQUE NOT NULL,
	type VARCHAR(40) NOT NULL, 
	value INT
);
-- Create addresses table 
CREATE TABLE  Address (
	address_id INT PRIMARY KEY IDENTITY(1,1),
	street_number INT,
	--	look up possible entrances
	entrance VARCHAR(5) NOT NULL,
	street_name VARCHAR(255) NOT NULL,
	district VARCHAR(40) NOT NULL,
	city VARCHAR(40) NOT NULL,
    --12 is (maybe) the longest possible postcode length
	postal_code VARCHAR(12) NOT NULL,
	country VARCHAR(255) NOT NULL,
);
-- Create the buildings table
CREATE TABLE Buildings (
	building_id INT PRIMARY KEY IDENTITY(1,1),
	address_id INT UNIQUE NOT NULL,
	alias VARCHAR(40),
	floor_num INT NOT NULL,
	total_building_size decimal(10,2) NOT NULL,
	date_built DATE NOT NULL,
	num_of_elevators INT NOT null,
	FOREIGN KEY (address_id) REFERENCES Addresses(address_id)
);
-- Create the buildings table
CREATE TABLE Property (
	property_id INT PRIMARY KEY IDENTITY(1,1),
	building_id INT NOT NULL,
	property_type_id INT NOT NULL,
	property_number INT NOT NULL,
	size DECIMAL(10,3) NOT NULL,
	floor INT NOT NULL,
	size_of_ideal_parts DECIMAL(10,3) NOT NULL,
	entrance_is_external BIT not NULL,
	FOREIGN KEY (building_id) REFERENCES Buildings(building_id),
	FOREIGN KEY (property_type_id) REFERENCES Enums(enum_id)
);
-- Create the property residents table
CREATE TABLE PropertyResidents (
	property_resident_id INT PRIMARY KEY IDENTITY(1,1),
	resident_type_id INT NOT NULL,
	property_id INT NOT NULL,
	first_name VARCHAR(40),
	last_name VARCHAR(40),
	floor INT NOT NULL,
	enter_date DATE NOT NULL,
	-- double check if nullable
	leave_date DATE,
	FOREIGN KEY (property_id) REFERENCES Property(property_id),
	FOREIGN KEY (resident_type_id) REFERENCES Enums(enum_id)
);

CREATE TABLE BuildingExpenses (
	building_expense_id INT PRIMARY KEY IDENTITY(1,1),
	address_id INT UNIQUE NOT NULL,
	alias VARCHAR(40),
	floor_num INT NOT NULL,
	total_building_size decimal(10,2) NOT NULL,
	date_built DATE NOT NULL,
	num_of_elevators INT NOT null,
	FOREIGN KEY (address_id) REFERENCES Addresses(address_id)
);

CREATE TABLE PropertyExpenseTemplate (
	property_expense_template_id INT PRIMARY KEY IDENTITY(1,1),
	repeat_period_id INT NOT NULL,
    role_id INT NOT NULL,
	price DECIMAL(10,2),
    description TEXT,
    start_date DATE NOT NULL,
    end_date DATE,
	FOREIGN KEY (role_id) references Enums(enum_id)
);

CREATE TABLE PropertyExpense (
	property_expense_id INT PRIMARY KEY IDENTITY(1,1),
    property_expense_template_id INT NOT NULL,
	repeat_period_id INT NOT NULL,
    expense_title VARCHAR(40),
	per_resident BIT NOT NULL,
	FOREIGN KEY (repeat_period_id) REFERENCES Enums(enum_id)
);
--Create table for email templates
CREATE TABLE EmailTemplate (
    email_template_id INT IDENTITY(1,1),
    title VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    body TEXT
);
--Ccreate table for payments
CREATE TABLE  PropertyPayments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    propery_id INT NOT NULL,
    property_expense_id INT NOT NULL,
    status_id INT NOT NULL,
    payment_method INT NOT NULL,
    payment_parent_id INT,
    amount_owed DECIMAL(10,2) NOT NULL,
    date_opened DATE NOT NULL,
    due_date DATE NOT NULL,
    FOREIGN KEY (propery_id) REFERENCES Property(property_id),
    FOREIGN KEY (property_expense_id) REFERENCES PropertyExpense(property_expense_id),
    FOREIGN KEY (status_id) REFERENCES Enums(enum_id) 
);