import { ShipmentDetailRequest } from './ShipmentDetailRequest';

export class ShipmentRequest {
  Id?: number;
  CustomerId: number = 0;  
  ShipmentTypeId: number = 0;
  TotalPrice: number = 0;
  Details: ShipmentDetailRequest[] = [];
}


