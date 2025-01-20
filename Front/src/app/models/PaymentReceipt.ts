import { PaymentReceiptDetail } from './PaymentReceipDetail';

export class PaymentReceipt {
  employeeName: string = '';
  employeeId: number = -1;
  date: string = '';
  totalWeight: number = 0;
  totalToPay: number = 0;
  products: PaymentReceiptDetail[] = [];
}
