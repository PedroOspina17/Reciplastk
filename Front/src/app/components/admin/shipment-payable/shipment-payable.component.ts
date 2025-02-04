import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RecivableViewModel } from '../../../models/ViewModel/RecivableViewModel';
import { ShipmentService } from '../../../services/shipment.service';
import { ShipmentMovementTypeEnum } from '../../../models/Enums';

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
  ReceivableList: RecivableViewModel[] = [];
  ShipmentMovement = ShipmentMovementTypeEnum;
  ngOnInit(): void {
    this.GetAllReceivables(this.id)
  }
  GetAllReceivables(id: number) {
    this.shipmentService.GetShipmentForPayments(id).subscribe(r => {
      if (r.WasSuccessful) {
        this.ReceivableList = r.Data;
      } else {
        this.toastr.error(r.Data)
      }
    })
  }
}
