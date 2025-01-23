import { Component, Input, SimpleChanges } from '@angular/core';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { CustomerService } from '../../../services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ProductPriceModel } from '../../../models/ProductPriceModel';
import { ProductPriceInnerParams } from '../../../models/ProductPriceInnerParams';
import { ProductPriceService } from '../../../services/product-price.service';
import { PriceType } from '../../../models/Enums';


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
  @Input() readOnly: boolean = false;

  filterList: ProductPriceInnerParams[] = [];
  formSelects: FormGroup;
  CustomerList: CustomerViewModel[] = [];
  IsNegative: boolean = false;
  value: any = { checked: false };
  PriceType = PriceType;
  ngOnInit(): void {
    this.filter();
    this.GetCustomers(this.productPriceTypeId);
  }
  ngOnChanges(changes: SimpleChanges) {
    this.onRadioChange(false);    
    this.filter();
  }
  onRadioChange(value: boolean): void {
    if (value != null) {
      this.IsNegative = value;
    };
  }
  OnChecboxChange(event: Event): void {
    this.value = event.target as HTMLInputElement;
    this.filter();
  }
  filter() {
    const productPriceModel: ProductPriceModel = {
      pricetypeid: this.productPriceTypeId,
      productid: this.productid,
      customerid: this.customerid,
      showHistory: this.value?.checked ?? false,
    }
    this.productPriceService.Filter(productPriceModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.filterList = r.data;
      } else {
        this.toastr.info("No se encontraron productos con los filtros aplicados")
      }
    })
  }
  GetCustomers(id: number) {
    if (id == PriceType.Buy) {
      this.customerService.GetAllProviders().subscribe((r) => {
        if (r.wasSuccessful) {
          this.CustomerList = r.data;
        } else {
          this.toastr.info('No se encontro ningun proveedor');
        }
      });
    } else if (id == PriceType.Sell) {
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
    this.filter();
  }
  CreateProductPrice() {
    const productPriceModel: ProductPriceModel = {
      pricetypeid: this.productPriceTypeId,
      productid: this.productid,
      customerid: this.isCreate == true ? this.customerid : undefined,
      price: this.IsNegative && this.isCreate == false ? this.formSelects.value.price * -1 : this.formSelects.value.price
    }
    this.productPriceService.CreateProductPrices(productPriceModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage)
        this.filter();
        this.formSelects.get('price')?.setValue('');
      } else {
        this.toastr.info('No se pudo crer en nuevo precio de producto')
      }
    })
  }
}
