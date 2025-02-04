import { RecivableViewModelDetails as RecivableViewModelDetails } from "./RecivableViewModelDetails";
export class RecivableViewModel {
  ShipmentId: number = -1;
  ShipmentType: number = -1;
  ShipmentTypeName: string = '';
  EmployeeName: string = '';
  CustomerName: string = '';
  Date: string = '';
  TotalPrice: number = -1;
  Details: RecivableViewModelDetails [] = [];
}
