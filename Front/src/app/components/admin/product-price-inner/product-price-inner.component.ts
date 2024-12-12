import { Component, Input, SimpleChanges } from '@angular/core';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { CustomerService } from '../../../services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ProductPriceModel } from '../../../models/ProductPriceModel';
import { ProductPriceInnerParams } from '../../../models/ProductPriceInnerParams';
import { ProductPriceService } from '../../../services/product-price.service';

@Component({
  selector: 'app-product-price-inner',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './product-price-inner.component.html',
  styleUrl: './product-price-inner.component.css'
})
export class ProductPriceInnerComponent {

  constructor(private fb: FormBuilder, private customerService: CustomerService, private productPriceService: ProductPriceService, private toastr: ToastrService) {
    this.formSelects = this.fb.group({
      customer: [-1],
      price: [0]
    })
  }
  @Input() productPriceTypeId: any;
  @Input() productid: number = -1;
  @Input() isCreate: boolean = false;
  @Input() customerid?: number = -1;

  filterList: ProductPriceInnerParams[] = [];
  formSelects: FormGroup;
  CustomerList: CustomerViewModel[] = [];
  /*   customerid: number = -1;*/
  ngOnInit(): void {
    this.filter();
    this.GetCustomers(this.productPriceTypeId);
    console.log('productPriceTypeId', this.productPriceTypeId)
    console.log('productid', this.productid)
    console.log('isCreate', this.isCreate)
    console.log('customer', this.customerid)
  }
  ngOnChanges(changes: SimpleChanges) {
    /* for (const propName in changes) {
      const chng = changes[propName];
      const cur = JSON.stringify(chng.currentValue);
      const prev = JSON.stringify(chng.previousValue);
      console.log(`${propName}: currentValue = ${cur}, previousValue = ${prev}`);
    } */
    this.filter();
  }
  filter() {
    const productPriceModel: ProductPriceModel = {
      pricetypeid: this.productPriceTypeId,
      productid: this.productid,
      customerid: this.customerid
    }
    console.log('productPriceModel', productPriceModel)
    this.productPriceService.Filter(productPriceModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.filterList = r.data.reverse();
        console.log('filterList', this.filterList);
      } else {
        this.toastr.info("No se encontraron productos con los filtros aplicados")
      }
    })
  }
  GetCustomers(id: number) {
    if (id == 1) {
      this.customerService.GetAllProviders().subscribe((r) => {
        if (r.wasSuccessful) {
          this.CustomerList = r.data;
          console.log(this.CustomerList)
        } else {
          this.toastr.info('No se encontro ningun proveedor');
        }
      });
    } else if (id == 2) {
      this.customerService.GetAllCustomer().subscribe((r) => {
        if (r.wasSuccessful) {
          this.CustomerList = r.data;
        } else {
          this.toastr.info('No se encontron ningun cliente');
        }
      });
    }
  }
  CustomerChange(value: any) {
    this.customerid = value.target.value;
    console.log(this.customerid)
    this.filter();
  }
  CreateProductPrice() {
    const productPriceModel: ProductPriceModel = {
      pricetypeid: this.productPriceTypeId,
      productid: this.productid,
      customerid: this.isCreate == true ? this.customerid : undefined,
      price: this.formSelects.value.price
    }
    console.log('productPriceModel', productPriceModel)
    this.productPriceService.CreateProductPrices(productPriceModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage)
        this.filter();
      } else {
        this.toastr.info('No se pudo crer en nuevo precio de producto')
      }
    })
  }
}
