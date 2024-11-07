import { Component, Input } from '@angular/core';
import { PaymentReceipt } from '../../../models/PaymentReceipt';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-payment-receipt',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './payment-receipt.component.html',
  styleUrl: './payment-receipt.component.css',
})
export class PaymentReceiptComponent {
  @Input() BillInfo!: PaymentReceipt;
  ngOnInit(): void {
    console.log('BillInfo', this.BillInfo);
  }
}
