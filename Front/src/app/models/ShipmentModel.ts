import { ShipmentDetailModel } from './ShipmentDetailModel';

export class ShipmentModel {
  shipmentid?: number;
  customerid: number = 0;  
  shipmenttypeid: number = 0;
  details: ShipmentDetailModel[] = [];
}

// customer: Customer;
// employee: Employee;
// shipmenttype: Shipmenttype;
