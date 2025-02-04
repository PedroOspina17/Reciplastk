import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CustomerViewModel } from '../../../models/ViewModel/CustomerViewModel';
import { CustomerService } from '../../../services/customer.service';
import { CopyCustomerPricesViewModel } from '../../../models/ViewModel/CopyCustomerPricesViewModel';
import { ProductPriceService } from '../../../services/product-price.service';
import { PriceTypeRequest } from '../../../models/Requests/PriceTypeRequest';
import { ProductPriceViewModel } from '../../../models/ViewModel/ProductPriceViewModel';

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
  filterList: ProductPriceViewModel[] = [];
  ngOnInit(): void {
    this.GetCustomers();
  }
  GetCustomers() {
    this.customerService.GetAll().subscribe((r) => {
      if (r.WasSuccessful) {
        this.CustomerList = r.Data;
      } else {
        this.toastr.info('No se encontron ningun cliente');
      }
    });
  }
  Filter() {
    const productPriceModel: PriceTypeRequest = {
      CustomerId: this.FormSelects.value.CustomerToCopyId
    }
    this.productPriceService.Filter(productPriceModel).subscribe(r => {
      if (r.WasSuccessful) {
        this.filterList = r.Data;
      } else {
        this.toastr.error(r.Data);
      }
    })
  }
  SaveInfo() {
    if (this.FormSelects.value.CustomerToCopyId == this.FormSelects.value.CustomerToAssignId) {
      this.toastr.error("El cliente a asignar no puede ser el mismo que el cliente a copiar");
      this.FormSelects.patchValue({
        CustomerToAssignId: -1 
      });
    } else {
      const copyCustomerPricesViewModel: CopyCustomerPricesViewModel = {
        CustomerFrom: this.FormSelects.value.CustomerToCopyId,
        CustomerTo: this.FormSelects.value.CustomerToAssignId,
      }
      this.productPriceService.CopyPrices(copyCustomerPricesViewModel).subscribe(r => {
        if (r.WasSuccessful) {
          this.toastr.success(r.StatusMessage);
          this.FormSelects.setValue({
            CustomerToCopyId: [-1,],
            CustomerToAssignId: [-1]
          })
        } else {
          this.toastr.error(r.Data);
        }
      });
    }
  }
}
