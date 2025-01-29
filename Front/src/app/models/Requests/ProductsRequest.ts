export class ProductsRequest{
  Id?: number;
  ShortName: string = "";
  Name: string = "";
  Description: string = "";
  Code: string = "";
  BuyPrice: number = 0;
  SellPrice: number = 0;
  ParentId?: number = 0;
  SubTypeProductList?: ProductsRequest[] = [];
}
