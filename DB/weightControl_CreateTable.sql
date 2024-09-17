DROP TABLE IF EXISTS weightcontrol CASCADE;

CREATE TABLE weightcontrol (
    WeightControlId SERIAL PRIMARY KEY,
    EmployeeId INT REFERENCES employee(employeeid),
    WeightControlTypeId INT REFERENCES weightcontroltype(weightcontroltypeid),
    IsPaid boolean NOT NULL DEFAULT false,
    DateStart timestamp NOT NULL,
    DateEnd timestamp NOT NULL,
    CreationDate timestamp NOT NULL DEFAULT now(),
    UpdateDate timestamp NOT NULL DEFAULT now(),
    IsActive boolean NOT NULL DEFAULT true
);
