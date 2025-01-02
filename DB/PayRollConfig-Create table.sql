CREATE TABLE payrollconfig (
payrollconfigid int PRIMARY KEY NOT NULL,
productid INTEGER REFERENCES public.products(productid) NOT NULL,
employeeid INTEGER REFERENCES public.employee(employeeid) NOT NULL,
priceperkilo DOUBLE PRECISION NOT NULL,
iscurrentprice BOOLEAN NOT NULL,
creationdate TIMESTAMP NOT NULL,
updatedate TIMESTAMP NOT NULL,
isactive BOOLEAN NOT NULL
);