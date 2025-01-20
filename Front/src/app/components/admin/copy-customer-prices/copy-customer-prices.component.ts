import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { CustomerService } from '../../../services/customer.service';
import { CopyCustomerPricesViewModel } from '../../../models/CopyCustomerPricesViewModel';
import { ProductPriceService } from '../../../services/product-price.service';
import { ProductPriceModel } from '../../../models/ProductPriceModel';
import { ProductPriceInnerParams } from '../../../models/ProductPriceInnerParams';

@Component({
  selector: 'app-copy-customer-prices',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './copy-customer-prices.component.html',
  styleUrl: './copy-customer-prices.component.css'
})
export class CopyCustomerPricesComponent {
  constructor(private fb: FormBuilder, private toastr: ToastrService, private customerService: CustomerService, private productPriceService: ProductPriceService) {
    this.FormSelects = this.fb.group({
      CustomerToCopyId: [-1,],
      CustomerToAssignId: [-1]
    })

  }
  FormSelects: FormGroup;
  CustomerList: CustomerViewModel[] = [];
  filterList: ProductPriceInnerParams[] = [];
  ngOnInit(): void {
    this.GetCustomers();
  }
  GetCustomers() {
    this.customerService.GetAll().subscribe((r) => {
      if (r.wasSuccessful) {
        this.CustomerList = r.data;
      } else {
        this.toastr.info('No se encontron ningun cliente');
      }
    });
  }
  Filter() {
    const productPriceModel: ProductPriceModel = {
      customerid: this.FormSelects.value.CustomerToCopyId
    }
    this.productPriceService.Filter(productPriceModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.filterList = r.data;
      } else {
        this.toastr.error(r.data);
      }
    })
  }
  SaveInfo() {
    if (this.FormSelects.value.CustomerToCopyId == this.FormSelects.value.CustomerToAssignId) {
      this.toastr.error("El cliente a asignar no puede ser el mismo que el cliente a copiar");

      this.FormSelects.setValue({
        CustomerToCopyId: [-1,],
        CustomerToAssignId: [-1]
      })

    } else {
      const copyCustomerPricesViewModel: CopyCustomerPricesViewModel = {
        customerFrom: this.FormSelects.value.CustomerToCopyId,
        customerTo: this.FormSelects.value.CustomerToAssignId,
      }
      this.productPriceService.CopyPrices(copyCustomerPricesViewModel).subscribe(r => {
        if (r.wasSuccessful) {
          this.toastr.success(r.statusMessage);
          this.FormSelects.setValue({
            CustomerToCopyId: [-1,],
            CustomerToAssignId: [-1]
          })
        } else {
          this.toastr.error(r.data);
        }
      });
    }
  }
}
