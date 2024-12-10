DELETE FROM public.weightcontroltype
	WHERE weightcontroltypeid != 1 and weightcontroltypeid != 2  ;
UPDATE public.weightcontroltype
	SET  name='Molido', isactive=true
	WHERE weightcontroltypeid = 1 ;
UPDATE public.weightcontroltype
	SET  name='Separado', isactive=true
	WHERE weightcontroltypeid = 2 ;
	