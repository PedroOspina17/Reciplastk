CREATE TABLE payment(
	paymentid SERIAL PRIMARY KEY,
	employeid INT REFERENCES employee(employeeid) NOT NULL,
	totalweight INT NOT NULL,
	totalprice INT NOT NULL,
	date TIMESTAMP NOT NULL
);

CREATE TABLE paymentdetails(
	paymentsdetailid SERIAL PRIMARY KEY,
	paymentid INT REFERENCES payment(paymentid) NOT NULL,
	weightcontroldetailid INT REFERENCES weightcontroldetail(weightcontroldetailid),
	productprice INT NOT NULL
);