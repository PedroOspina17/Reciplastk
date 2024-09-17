DROP TABLE IF EXISTS weightcontrol CASCADE;

CREATE TABLE weightcontrol (
    WeightControlId SERIAL PRIMARY KEY,
    EmployeeId INT REFERENCES employee(employeeid),
    WeightControlTypeId INT REFERENCES weightcontroltype(weightcontroltypeid),
    IsPaid boolean NOT NULL,
    DateStart timestamp NOT NULL,
    DateEnd timestamp NOT NULL,
    CreationDate timestamp NOT NULL,
    UpdateDate timestamp NOT NULL,
    IsActive boolean NOT NULL
);
