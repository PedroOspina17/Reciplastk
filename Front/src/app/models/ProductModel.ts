export class ProductModel{
  productid?: number;
  shortname: string = "";
  name: string = "";
  description: string = "";
  code: string = "";
  buyprice: number = 0;
  sellprice: number = 0;
  parentid?: number = 0;
  subtypeProductList?: ProductModel[] = [];
}
