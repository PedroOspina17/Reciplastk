import { Component, Input } from '@angular/core';
import { PaymentReceipt } from '../../../models/PaymentReceipt';
import { CommonModule, DatePipe } from '@angular/common';
import { WeightControlService } from '../../../services/weight-control-service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-payment-receipt',
  standalone: true,
  imports: [CommonModule],
  providers: [DatePipe],
  templateUrl: './payment-receipt.component.html',
  styleUrl: './payment-receipt.component.css',
})
export class PaymentReceiptComponent {
  constructor(
    private weightcontrolservice: WeightControlService,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService,
    private datePipe: DatePipe
  ) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  fromBillList: boolean = false;
  id: number;
  @Input() BillInfo!: PaymentReceipt;
  ngOnInit(): void {
    console.log('BillInfo', this.BillInfo);
    this.GetReceipt(this.id);
  }
  GetReceipt(id: number) {
    this.weightcontrolservice.GetReceipt(id).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.fromBillList = true;
        this.BillInfo = r.data;
        console.log('data', r.data);
        console.log('BillInfo', this.BillInfo);
      } else {
        console.log(r.statusMessage);
      }
    });
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
