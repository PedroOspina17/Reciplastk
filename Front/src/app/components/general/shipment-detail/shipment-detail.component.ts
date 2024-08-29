import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { ProviderCustomerSelectionComponent } from '../provider-customer-selection/provider-customer-selection.component';

@Component({
  selector: 'app-shipment-detail',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule, HttpClientModule, ProviderCustomerSelectionComponent],
  templateUrl: './shipment-detail.component.html',
  styleUrl: './shipment-detail.component.css'
})
export class ShipmentDetailComponent {
  @ViewChild(ProviderCustomerSelectionComponent, { static: false }) selection!: ProviderCustomerSelectionComponent;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService
  ) {}
  ngAfterViewInit(): void {
    console.log(this.selection.id)
  }
}
