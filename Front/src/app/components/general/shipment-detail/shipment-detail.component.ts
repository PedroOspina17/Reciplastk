import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';
import { CustomerViewModel } from '../../../models/CustomerViewModel';
import { CustomerService } from '../../../services/customer.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ShipmentService } from '../../../services/shipment.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shipment-detail',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule, HttpClientModule],
  templateUrl: './shipment-detail.component.html',
  styleUrl: './shipment-detail.component.css',
})
export class ShipmentDetailComponent {
  ShowProvider: boolean = true;
  id: number = -1;
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

  CustomerProviderSelect(ingreso: string) {
    if (ingreso == 'Ingreso') {
      this.ShowProvider = true;
      this.shipmentService.ShowAllProviders().subscribe((resultProvider) => {
        if (resultProvider.wasSuccessful == true) {
          this.ProviderList = resultProvider.data;
          console.log('ProviderList: ', resultProvider.data);
        } else {
          this.toastr.info('No se encontro ningun proveedor');
        }
      });
    } else if (ingreso == 'Salida') {
      this.ShowProvider = false;
      this.customerService.ShowAllCustomers().subscribe((resultCustomer) => {
        if (resultCustomer.wasSuccessful == true) {
          this.CustomerList = resultCustomer.data;
          console.log('CustomerList: ', resultCustomer.data);
        } else {
          this.toastr.info('No se encontron ningun customer');
        }
      });
    }
  }
}
