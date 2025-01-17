ALTER TABLE public.shipment
ADD COLUMN totalprice DOUBLE PRECISION;

UPDATE public.shipment
SET totalprice = 0.0; 

ALTER TABLE public.shipment
ALTER COLUMN totalprice SET NOT NULL;
-------
ALTER TABLE public.shipmentdetail
ADD COLUMN subtotal DOUBLE PRECISION,
ADD COLUMN productprice DOUBLE PRECISION;

UPDATE public.shipmentdetail
SET subtotal = 0.0; 
UPDATE public.shipmentdetail
SET productprice = 0.0; 

ALTER TABLE public.shipmentdetail
ALTER COLUMN subtotal SET NOT NULL;
ALTER TABLE public.shipmentdetail
ALTER COLUMN productprice SET NOT NULL;