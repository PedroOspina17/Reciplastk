import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';
import { CustomerViewModel } from '../../../models/CustomerViewModel';
import { CustomerService } from '../../../services/customer.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ShipmentService } from '../../../services/shipment.service';
import { ToastrService } from 'ngx-toastr';
import { ShipmentCustomerSelectionComponent } from "../shipment-customer-selection/shipment-customer-selection.component";

@Component({
  selector: 'app-shipment-detail',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule, HttpClientModule, ReactiveFormsModule, FormsModule, ShipmentCustomerSelectionComponent],
  templateUrl: './shipment-detail.component.html',
  styleUrl: './shipment-detail.component.css',
})
export class ShipmentDetailComponent {
  ShowProvider: boolean = true;
  id: number = -1;
  type: number = 1;
  loader: boolean = false;
  CustomerList: CustomerViewModel[] = [];
  ProviderList: any[] = [];
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private customerService: CustomerService,
    private shipmentService: ShipmentService,
    private toastr: ToastrService
  ) {}
  ngOnInit(): void {
    this.CustomerProviderSelect('Ingreso');
  }
  CustomerProviderSelect(value: any) {
    this.loader = true;
    if (this.type == 1) {
      this.ShowProvider = true;
      this.shipmentService.ShowAllProviders().subscribe((resultProvider) => {
        if (resultProvider.wasSuccessful == true) {
          this.ProviderList = resultProvider.data;
        } else {
          this.toastr.info('No se encontro ningun proveedor');
        }
      });
    } else if (this.type == 2) {
      this.ShowProvider = false;
      this.customerService.ShowAllCustomers().subscribe((resultCustomer) => {
        if (resultCustomer.wasSuccessful == true) {
          this.CustomerList = resultCustomer.data;
        } else {
          this.toastr.info('No se encontron ningun customer');
        }
      });
    }
    this.loader = false;
  }
  onProviderChange(value:any){
    console.log(this.id)
  }
}