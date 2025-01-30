export class PriceTypeRequest{
    Id?: number = -1;
    CustomerId?: number;
    PriceTypeId?: number = -1;
    Price?: number= -1;
    CreateOrChangeCrice?: boolean;
    ShowHistory?: boolean;
}