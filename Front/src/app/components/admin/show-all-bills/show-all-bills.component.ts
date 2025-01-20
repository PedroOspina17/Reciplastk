import { Component } from '@angular/core';
import { WeightControlService } from '../../../services/weight-control-service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-show-all-bills',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './show-all-bills.component.html',
  styleUrl: './show-all-bills.component.css',
})
export class ShowAllBillsComponent {
  constructor(
    private weightcontrolservice: WeightControlService,
    private toastr: ToastrService
  ) {}
  BillsList: any[] = [];
  ngOnInit(): void {
    this.GetAllBills();
  }
  GetAllBills() {
    this.weightcontrolservice.GetAllReceipt().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.BillsList = r.data;
      } else {
        this.toastr.info('No se encontraron facturas de pago');
      }
    });
  }
}
