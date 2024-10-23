CREATE TABLE WeightControlType (
    WeightControlTypeId SERIAL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Description VARCHAR(50),
    CreationDate TIMESTAMP NOT NULL,
    UpdateDate TIMESTAMP NOT NULL,
    IsActive BOOLEAN NOT NULL
);