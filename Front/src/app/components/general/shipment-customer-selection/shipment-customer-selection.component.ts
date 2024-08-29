import { AfterViewInit, Component, Input, ViewChild } from '@angular/core';
import { ShipmentDetailComponent } from '../shipment-detail/shipment-detail.component';
import { Router, RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-shipment-customer-selection',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule, HttpClientModule, ShipmentDetailComponent],
  templateUrl: './shipment-customer-selection.component.html',
  styleUrl: './shipment-customer-selection.component.css',
})
export class ShipmentCustomerSelectionComponent implements AfterViewInit {
  @ViewChild(ShipmentDetailComponent, { static: false }) shipmentDetail!: ShipmentDetailComponent;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService
  ) {}
  ngAfterViewInit(): void {
    console.log(this.shipmentDetail.id)
  }
}
