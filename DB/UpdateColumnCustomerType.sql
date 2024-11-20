UPDATE public.customer
	SET customertypeid=1
	WHERE customertypeid IS NULL;

ALTER TABLE public.customer
ALTER COLUMN customertypeid SET NOT NULL;