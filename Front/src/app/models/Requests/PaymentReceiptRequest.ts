import { PaymentReceiptDetailRequest } from './PaymentReceiptDetailRequest';

export class PaymentReceiptRequest {
  EmployeeName: string = '';
  EmployeeId: number = -1;
  Date: string = '';
  TotalWeight: number = 0;
  TotalToPay: number = 0;
  Products: PaymentReceiptDetailRequest[] = [];
}
