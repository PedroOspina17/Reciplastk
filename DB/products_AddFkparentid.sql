ALTER TABLE products DROP COLUMN parentid
ALTER TABLE products ADD parentid integer REFERENCES products(productid) DEFAULT(NULL)