export class CustomerViewModel{
    Id?: number;
    CustomerTypeId: number = -1;
    CustomerTypeName?: string = "";
    Nit: string = "";
    Name: string = "";
    LastName: string = "";
    Address: string = "";
    Cell: string = "";  
    ClientSince?: Date;
    NeedsPickUp?: boolean = false;
}