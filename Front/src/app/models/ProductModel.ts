export class ProductModel{
  productid?: number;
  shortname: string = "";
  name: string = "";
  description: string = "";
  code: string = "";
  issubtype: boolean = false;
  parentid?: number = 0;
  SubtypeProductList?: ProductModel[] = [];
}
