export class CustomerViewModel{
    customerid?: number;
    customertypeid: number = -1;
    customertypename?: string = "";
    nit: string = "";
    name: string = "";
    lastname: string = "";
    address: string = "";
    cell: string = "";  
    clientsince?: Date;
    needspickup?: boolean = false;
}