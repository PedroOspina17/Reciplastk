CREATE TABLE PriceType (
	pricetypeid SERIAL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	description VARCHAR(150) NOT NULL,
	creationdate TIMESTAMP NOT NULL,
	updatedate TIMESTAMP NOT NULL,
	isactive BOOL NOT NULL
);
CREATE TABLE ProductPrice (
	productpriceid SERIAL PRIMARY KEY,
	productid INT NOT NULL REFERENCES public.products(productid),
	customerid INT NOT NULL REFERENCES public.customer(customerid),
	pricetypeid INT NOT NULL REFERENCES public.pricetype(pricetypeid),
	employeeid INT NOT NULL REFERENCES public.employee(employeeid),
	price DOUBLE PRECISION NOT NULL,
	creationdate TIMESTAMP NOT NULL,
	updatedate TIMESTAMP NOT NULL,
	isactive BOOL NOT NULL
);


