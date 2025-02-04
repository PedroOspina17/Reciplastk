import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { ProductPriceInnerComponent } from "../product-price-inner/product-price-inner.component";
import { ProductPriceService } from '../../../services/product-price.service';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../services/products.service';
import { ProductsRequest } from '../../../models/Requests/ProductsRequest';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../../../services/customer.service';
import { ProductPriceViewModel } from '../../../models/ViewModel/ProductPriceViewModel';
import { PriceType } from '../../../models/Enums';
import { PriceTypeViewModel } from '../../../models/ViewModel/PriceTypeViewModel';

@Component({
  selector: 'app-product-price',
  standalone: true,
  imports: [ProductPriceInnerComponent, ReactiveFormsModule, CommonModule],
  templateUrl: './product-price.component.html',
  styleUrl: './product-price.component.css'
})
export class ProductPriceComponent {
  constructor(private fb: FormBuilder, private customerService: CustomerService, private productPriceService: ProductPriceService, private toastr: ToastrService, private productsService: ProductsService) {
    this.formSelects = this.fb.group({
      tipeid: [-1],
      productid: [{ value: -1, disabled: true }],
      isCreate: [{ value: false, disabled: true }]
    })
  }
  formSelects: FormGroup;
  PriceTypesList: PriceTypeViewModel[] = []
  ProductsList: ProductsRequest[] = [];
  productPriceTypeId = -1;
  priceType = PriceType;
  @ViewChild(ProductPriceInnerComponent) child!: ProductPriceInnerComponent;
  ngOnInit(): void {
    this.GetAllPriceTypes();
  }
  PriceTypeChange(value: any) {
    this.formSelects.get('isCreate')?.disable();
    this.productPriceTypeId = value.target.value
    if (value.target.value == -1) {
      this.formSelects.get('productid')?.disable();
    } else {
      this.GetProduct(value.target.value);
      this.formSelects.get('productid')?.enable();
    }
  }
  ProductChange(value: any) {
    if (value.target.value == -1) {
      this.formSelects.get('isCreate')?.disable();
    } else {
      this.formSelects.get('isCreate')?.enable();
      this.child.filter();
    }
  }
  IsCreateChange(value: any) {
    const isCreateValue = value.target.id;
  }

  GetAllPriceTypes() {
    this.productPriceService.GetAllPriceTypes().subscribe(r => {
      if (r.WasSuccessful) {
        this.PriceTypesList = r.Data;
        console.log(this.PriceTypesList)
      } else {
        this.toastr.error(r.StatusMessage)
      }
    });
  }
  GetProduct(id: number) {
    if (id == this.priceType.Buy) {
      this.productsService.GetMain().subscribe(r => {
        if (r.WasSuccessful) {
          this.ProductsList = r.Data;
        } else {
          this.toastr.error(r.StatusMessage);
        }
      })
    } else {
      this.productsService.GetAll().subscribe(r => {
        if (r.WasSuccessful) {
          this.ProductsList = r.Data;
        } else {
          this.toastr.error(r.StatusMessage);
        }
      })
    }
  }
}
