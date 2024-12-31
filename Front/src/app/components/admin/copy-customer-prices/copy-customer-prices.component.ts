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
    const copyCustomerPricesViewModel: CopyCustomerPricesViewModel = {
      CustomerFrom: this.FormSelects.value.CustomerToCopyId,
      CustomerTo: this.FormSelects.value.CustomerToAssignId,
    }
    this.productPriceService.CopyPrices(copyCustomerPricesViewModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage);
        setTimeout(() => {
          window.location.reload();
        }, 1000);
      } else {
        this.toastr.error(r.data);
      }
    });
  }
}
