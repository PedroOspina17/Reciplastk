
CREATE TABLE Products(
	productid SERIAL PRIMARY KEY, 
	shortName VARCHAR(20) NOT NULL,
	name VARCHAR(50) NOT NULL,
	description VARCHAR(150) NOT NULL,
	code VARCHAR(10) NOT NULL,
	buyprice DECIMAL NOT NULL,
    	sellprice DECIMAL NOT NULL,
    	margin DECIMAL NOT NULL,
	issubtype BOOL DEFAULT(FALSE) NOT NULL,
    	creationDate TIMESTAMP NOT NULL DEFAULT(NOW()),
    	updateDate TIMESTAMP NOT NULL DEFAULT(NOW()),
	isActive BOOL DEFAULT(TRUE) NOT NULL
	parentid INTERGER)

CREATE TABLE productPrice (
    productpriceid SERIAL PRIMARY KEY, 
    productid INTEGER NOT NULL REFERENCES products(productid),
    customerid INTEGER NOT NULL REFERENCES customer(customerid),
    shortName VARCHAR(20) NOT NULL,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(50) NOT NULL,
    code VARCHAR(10) NOT NULL,
    buyprice DECIMAL NOT NULL,
    sellprice DECIMAL NOT NULL,
    margin DECIMAL NOT NULL,
    issubtype BOOL DEFAULT FALSE NOT NULL,
    creationDate TIMESTAMP NOT NULL DEFAULT NOW(),
    updateDate TIMESTAMP NOT NULL DEFAULT NOW(),
    isActive BOOL DEFAULT TRUE NOT NULL,
    parentid INTEGER
);


