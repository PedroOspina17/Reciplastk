CREATE TABLE customertype (
	customertypeid SERIAL PRIMARY KEY,
	name varchar (50) NOT NULL,
	creationdate TIMESTAMP NOT NULL,
	enddate TIMESTAMP NOT NULL,
	isactive BOOL NOT NULL
)

ALTER TABLE Customer
ADD COLUMN CustomerTypeId INT;

ALTER TABLE Customer
ADD CONSTRAINT fk_customer_type
FOREIGN KEY (CustomerTypeId)
REFERENCES CustomerType (CustomerTypeId)
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE public.customertype
ADD COLUMN description VARCHAR(100);

ALTER TABLE public.customertype
ADD COLUMN updatedate TIMESTAMP;

ALTER TABLE public.customertype
DROP COLUMN enddate;