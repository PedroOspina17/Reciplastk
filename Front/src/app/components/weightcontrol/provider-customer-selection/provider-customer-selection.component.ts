import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { CustomerViewModel } from '../../../models/ViewModel/CustomerViewModel';
import { CustomerService } from '../../../services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { ShipmentDetailComponent } from '../shipment-detail/shipment-detail.component';
import Swal from 'sweetalert2';
import { CustomerTypeEnum } from '../../../models/Enums';

@Component({
  selector: 'app-provider-customer-selection',
  standalone: true,
  imports: [
    CommonModule,
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
  showShipmentDetail: boolean = false;
  edit: boolean = false;
  CustomerEnum = CustomerTypeEnum;
  constructor(
    private customerService: CustomerService,
    private toastr: ToastrService
  ) { }
  ngOnInit(): void {
    this.CustomerProviderSelect('Ingreso');
  }
  edittype() {
    this.edit = true;
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'Esto borrara todos los datos previamente almacenados en la tabla.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FFA500 ',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Sí, habilitar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.edit = true;
        this.Clear();
      } else {
        this.edit = false;
      }
    });
  }

  CustomerProviderSelect(value: any) {
    this.loader = true;
    if (this.type == this.CustomerEnum.Provider) {
      this.ShowProvider = true;
      this.customerService.GetAllProviders().subscribe((resultProvider) => {
        if (resultProvider.WasSuccessful == true) {
          this.CustomerList = resultProvider.Data;
        } else {
          this.toastr.info('No se encontro ningun proveedor');
        }
      });
    } else if (this.type == this.CustomerEnum.Customer) {
      this.ShowProvider = false;
      this.customerService.GetAllCustomer().subscribe((resultCustomer) => {
        if (resultCustomer.WasSuccessful == true) {
          this.CustomerList = resultCustomer.Data;
        } else {
          this.toastr.info('No se encontron ningun cliente');
        }
      });
    }
    this.loader = false;
  }
  onProviderChange(value: any) {
    this.id = value.target.value;
    this.edit = false;

    this.personname = this.CustomerList.find(
      (p) => p.Id == this.id
    )?.Name;

    if (this.id != -1) {
      this.showShipmentDetail = true;
    } else {
      this.showShipmentDetail = false;
    }
  }
  Clear() {
    this.id = -1;
    this.showShipmentDetail = false;
  }
}
