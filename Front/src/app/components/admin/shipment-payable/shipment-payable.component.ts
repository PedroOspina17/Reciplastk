import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReceivableModel } from '../../../models/ReceivableModel';
import { ShipmentService } from '../../../services/shipment.service';

@Component({
  selector: 'app-shipment-payable',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './shipment-payable.component.html',
  styleUrl: './shipment-payable.component.css'
})
export class ShipmentPayableComponent {
  constructor(private shipmentService: ShipmentService, private toastr: ToastrService, private aRoute: ActivatedRoute,) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  id: number
  ReceivableList: ReceivableModel[] = [];

  ngOnInit(): void {
    this.GetAllReceivables()
    console.log(this.id)
  }
  GetAllReceivables() {
    this.shipmentService.GetShipmentForPayments().subscribe(r => {
      if (r.wasSuccessful) {
        this.ReceivableList = r.data;
        console.log(r.data)
      } else {
        this.toastr.error(r.data)
      }
    })
  }
}
