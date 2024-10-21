
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

CREATE TABLE productPrice(
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
	issubtype BOOL DEFAULT(FALSE) NOT NULL,
    	creationDate TIMESTAMP NOT NULL DEFAULT(NOW()),
    	updateDate TIMESTAMP NOT NULL DEFAULT(NOW()),
	isActive BOOL DEFAULT(TRUE) NOT NULL
	parentid INTERGER)

7. ELIMINAR TABLAS - DROP TABLE NameTable
DROP: Eliminar objetos de base de datos
ejm:
DROP TABLE table_name
Ejm 
DROP TABLE Products 

8. INSERTAR COLUMNAS
ALTER: para modificar objetos de base de datos. 
ADD para ingresar una columna

ALTER TABLE table_name ADD COLUMN column_name datatype.

ejem para anexar una columna a la tabla clientes:
ALTER TABLE Clients ADD Address nvarchar(250)
ejemplo2: anexar columna tabla2

CREAR FOREKEY

Para crear una foreing key se pone al campo:
REFERENCE tabla (pk_tabla)

ejemplo
productId integer REFERENCES product(id)

CREAR COLUMNA CON FOREKEY
ALTER TABLE products ADD parentid integer NULL REFERENCES products(id) 

9 ELIMINAR COLUMNAS
ALTER TABLE table_name DROP COLUMN column_name

Ejemplo 
ALTER TABLE products DROP COLUMN parentid



Ejemplos TABLE PRODUCTS

SELECT * FROM products
DELETE FROM products WHERE name = 'Poliesetireno';
DELETE FROM products WHERE name = 'PET';

INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ('PPBaja', 'polietileno baja densidad', 'Material conocido como plástico soplado', '0001', 1500, 2000, 500)

INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ('PPAlta', 'polietileno Alta Densidad', 'Se hace plástico burbujas, bolsas, papel film, etc', '0002', 1000, 1200, 200)

INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ('pasta', 'polipropileno', 'Esta en tapas envases, recipientes, canastas, etc', '0003', 1200, 1800, 600)


INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ('Plastico', 'poliesetireno', 'se fabrican envases de comida rápida, yogures, etc', '0004', 1100, 1500, 600)

INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ('PET', 'Polietileno Tereftalato', 'usado en envase de agua, refrescos, etc.', '0005', 800, 1000, 200)

INSERT INTO products(shortname, name, description, code, buyprice, sellprice, margin)
VALUES ( 'vidrio gueso', 'usado en envase de vidrio, refrescos, etc.', '0006', 800, 1000, 200)



