CREATE TABLE weightcontroldetail (
    WeightControlDetailId SERIAL PRIMARY KEY,
    WeightControlId INT REFERENCES weightcontrol(WeightControlId),
    ProductId INT REFERENCES products(productid),
    Weight FLOAT NOT NULL
);