/*
Query to create tables: 
CREATE TABLE <<TABLENAME>>(
	<<FIELD_NAME>> <<DATA_TYPE>> <<CONSTRAINTS>>
	Name VARCHAR(50) NOT NULL
);
*/

CREATE TABLE Test(
	TestId SERIAL PRIMARY KEY, /*To create numeric and autoincrement fields*/
	Name VARCHAR(50) NOT NULL, /*Not null fields*/
	LastName VARCHAR(50)
);

CREATE TABLE SecondaryTableTest(
	SecondaryTableTestId SERIAL PRIMARY KEY,
	TestId INT REFERENCES Test(TestId), /*To create foreign keys*/
	Description VARCHAR(50) NOT NULL, 
	IsActive BOOL DEFAULT(TRUE), /*To create FIELDS with DEFAULT values*/
	CreatedDate TIMESTAMP NOT NULL DEFAULT(NOW()) /*To create fields with complex default values*/
);

/*
Query to inster information to the table: 
INSERT INTO <<TABLE_NAME>>(<<FIELDS>) VALUES(<<VALUES>>)
INSERT INTO Test (Name,LastName) VALUES ('Pedro','Ospina');
*/

INSERT INTO Test (Name,LastName) VALUES ('Pedro','Ospina'); /*use ; to execute multiple commands*/
INSERT INTO Test (Name,LastName) VALUES ('David','Ossa');
INSERT INTO Test (Name,LastName) VALUES ('Elizabeth','Ospina');
INSERT INTO Test (Name,LastName) VALUES ('Andrea','Ospina');
INSERT INTO Test (Name,LastName) VALUES ('Testing','Row');

INSERT INTO SecondaryTableTest(TestId,Description) VALUES (1, 'System Engineer');
INSERT INTO SecondaryTableTest(TestId,Description) VALUES (2, 'Student');
INSERT INTO SecondaryTableTest(TestId,Description) VALUES (3, 'Lawyer');
/*
Query to view the information from the table: 
SELECT * 
FROM <<TABLE_NAME>>
WHERE <<CONDITIONALS>>;
*/
SELECT * FROM Test;
SELECT * FROM SecondaryTableTest;

/*
Query to change the information from the table: 
UPDATE <<TABLE_NAME>>
SET <<FIELD>> = <<VALUE>>
WHERE <<CONDITIONALS>>
*/

UPDATE Test
SET LastName = 'Ospina Graciano'
WHERE LastName = 'Ospina'

SELECT * FROM Test
WHERE LastName = 'Ospina Graciano'

UPDATE SecondaryTableTest
SET description = 'Independent Lawyer'
WHERE TestId = 3

SELECT * FROM SecondaryTableTest
WHERE TestId = 3

/*
Query to Delete information from the table:
DELETE FROM <<TABLE_NAME>> WHERE <<CONDITIONALS>>
*/

DELETE FROM Test 
WHERE testid = 6

/*
Delete the entire table 
DROP TABLE <<TABLE_NAME>>
*/
DROP TABLE Test ;
