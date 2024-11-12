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

  print() {
    const printContent = document.getElementById('elementIdToPrint');
    if (printContent) {
      const WindowPrt = window.open('', '_blank');
      if (WindowPrt) {
        WindowPrt.document.write(`
        <html>
          <head>
            <title>Imprimir Factura</title>
            <link 
              rel="stylesheet" 
              href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"
              integrity="sha384-DyZ88mC6Up2uqSIXaGGQ4Z1AA8GLxnb7w5q6QpaJnYH3Uz5p4hKRBH35ZDJ7lo9l"
              crossorigin="anonymous"
            >
            <style>
              body {
                font-family: Arial, sans-serif;
                margin: 20px;
              }
            </style>
          </head>
          <body>${printContent.innerHTML}
          </body>
        </html>
        `);
  
        WindowPrt.document.close();
  
        // Asegúrate de esperar a que los estilos se carguen antes de imprimir
        WindowPrt.onload = () => {
          WindowPrt.focus();
          WindowPrt.print();
          WindowPrt.close();
        };
      }
    }
  }
  
}
