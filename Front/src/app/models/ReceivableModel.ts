import { ReceivableDetails } from "./ReceivableDetails";
export class ReceivableModel {
  shipmentid: number = -1;
  shipmenttype: number = -1;
  shipmenttypename: string = '';
  employeename: string = '';
  customername: string = '';
  date: string = '';
  totalprice: number = -1;
  details: ReceivableDetails [] = [];
}
