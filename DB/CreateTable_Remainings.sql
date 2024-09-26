CREATE TABLE remainings(
	remainingid SERIAL PRIMARY KEY,
	weightcontrolid INT REFERENCES weightcontrol(weightcontrolid),
	productid INT NOT NULL,
	weight FLOAT NOT NULL,
	creationdate TIMESTAMP NOT NULL,
	updatedate TIMESTAMP NOT NULL,
	isactive BOOLEAN NOT NULL
)