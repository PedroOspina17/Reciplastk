import { CommonModule, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RecivableViewModel } from '../../../models/ViewModel/RecivableViewModel';
import { ShipmentService } from '../../../services/shipment.service';
import { ShipmentMovementTypeEnum } from '../../../models/Enums';

@Component({
  selector: 'app-shipment-payable-receipt',
  standalone: true,
  imports: [CommonModule,RouterLink],
  providers: [DatePipe],
  templateUrl: './shipment-payable-receipt.component.html',
  styleUrl: './shipment-payable-receipt.component.css'
})
export class ShipmentPayableReceiptComponent {
  constructor(private aRoute: ActivatedRoute, private shipmentService: ShipmentService, private toastr: ToastrService) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  Receivable: RecivableViewModel = new RecivableViewModel;
  ShipmentMovement = ShipmentMovementTypeEnum;
  id: number;
  ngOnInit(): void {
    this.GetById();
  }
  GetById() {
    this.shipmentService.GetReceivableReceiptInfo(this.id).subscribe(r => {
      if (r.WasSuccessful) {
        this.Receivable = r.Data;
      } else {
        this.toastr.error(r.StatusMessage)
      }
    })
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
        WindowPrt.onload = () => {
          WindowPrt.focus();
          WindowPrt.print();
          WindowPrt.close();
        };
      }
    }
  }
}
