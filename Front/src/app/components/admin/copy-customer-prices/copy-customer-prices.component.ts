import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { CustomerService } from '../../../services/customer.service';
import { CopyCustomerPricesViewModel } from '../../../models/CopyCustomerPricesViewModel';
import { ProductPriceService } from '../../../services/product-price.service';
import { CopyCustomerPricesParams } from '../../../models/CopyCustomerPricesParams';

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
  CopyCustomerPricesParams: CopyCustomerPricesParams[] = [];
  buttonSave: boolean = false;
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
  CustomerToChange(value: any) {
    /* const copyCustomerPricesViewModel: CopyCustomerPricesViewModel = {
      CustomerFrom: this.FormSelects.value.CustomerToCopyId
    }
    this.productPriceService.CopyPrices(copyCustomerPricesViewModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.CopyCustomerPricesParams = r.data;
        this.toastr.success(r.statusMessage);
        this.buttonSave = true;
      } else {
        this.toastr.error(r.data);
      }
    }) */
  }
  SaveInfo() {
    console.log(this.FormSelects.value)
    const copyCustomerPricesViewModel: CopyCustomerPricesViewModel = {
      CustomerFrom: this.FormSelects.value.CustomerToCopyId,
      CustomerTo: this.FormSelects.value.CustomerToAssignId,
    }
    console.log(copyCustomerPricesViewModel)
    this.productPriceService.CopyPrices(copyCustomerPricesViewModel).subscribe(r => {
      if (r.data) {
        this.CopyCustomerPricesParams = r.data;
        this.toastr.success(r.statusMessage);
        this.buttonSave = true;
      } else {
        this.toastr.error(r.data);
      }
    });
  }
}
