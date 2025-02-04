import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from '@angular/router';
import { PaymentsService } from '../../../services/payments.service';

@Component({
  selector: 'app-show-all-bills',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './show-all-bills.component.html',
  styleUrl: './show-all-bills.component.css',
})
export class ShowAllBillsComponent {
  constructor(
    private paymentsService: PaymentsService,
    private toastr: ToastrService
  ) {}
  BillsList: any[] = [];
  ngOnInit(): void {
    this.GetAllBills();
  }
  GetAllBills() {
    this.paymentsService.GetAllReceipt().subscribe((r) => {
      if (r.WasSuccessful) {
        this.BillsList = r.Data;
        console.log(r.Data);
      } else {
        this.toastr.info('No se encontraron facturas de pago');
      }
    });
  }
}
