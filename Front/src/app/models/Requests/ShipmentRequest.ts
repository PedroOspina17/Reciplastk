import { ShipmentDetailModel } from '../ShipmentDetailModel';

export class ShipmentRequest {
  Id?: number;
  CustomerId: number = 0;  
  ShipmentTypeId: number = 0;
  TotalPrice: number = 0;
  Details: ShipmentDetailModel[] = [];
}


