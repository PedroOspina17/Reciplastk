import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { CustomerService } from '../../../services/customer.service';
import { ShipmentService } from '../../../services/shipment.service';
import { ToastrService } from 'ngx-toastr';
import { ShipmentDetailComponent } from '../shipment-detail/shipment-detail.component';

@Component({
  selector: 'app-provider-customer-selection',
  standalone: true,
  imports: [
    RouterLink,
    LoaderComponent,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ShipmentDetailComponent,
  ],
  templateUrl: './provider-customer-selection.component.html',
  styleUrl: './provider-customer-selection.component.css',
})
export class ProviderCustomerSelectionComponent {
  personname?: string;
  ShowProvider: boolean = true;
  id: number = -1;
  type: number = 1;
  loader: boolean = false;
  CustomerList: CustomerViewModel[] = [];
  ProviderList: any[] = [];
  showShipmentDetail: boolean = false;
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
          this.toastr.info('No se encontron ningun cliente');
        }
      });
    }
    this.loader = false;
  }
  onProviderChange(value: any) {
    if (this.type == 1) {
      this.personname = this.ProviderList.find((p) => p.id == this.id)?.name;
    } else {
      this.personname = this.CustomerList.find(
        (p) => p.customerid == this.id
      )?.name;
    }
    if (this.id != -1) {
      this.showShipmentDetail = true;
    } else {
      this.showShipmentDetail = false;
    }
  }
  onSave() {
    this.id = -1;
    this.showShipmentDetail = false;
  }
}
