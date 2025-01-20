import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { ProductPriceInnerComponent } from "../product-price-inner/product-price-inner.component";
import { ProductPriceService } from '../../../services/product-price.service';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../services/products.service';
import { ProductModel } from '../../../models/ProductModel';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CustomerService } from '../../../services/customer.service';
import { ProductPriceInnerParams } from '../../../models/ProductPriceInnerParams';

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
  PriceTypesList: any[] = []
  ProductsList: ProductModel[] = [];
  productPriceTypeId = -1;
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
      if (r.wasSuccessful) {
        this.PriceTypesList = r.data;
      } else {
        this.toastr.error(r.statusMessage)
      }
    });
  }
  GetProduct(id: number) {
    if (id == 1) {
      this.productsService.GetMain().subscribe(r => {
        if (r.wasSuccessful) {
          this.ProductsList = r.data;
        } else {
          this.toastr.error(r.statusMessage);
        }
      })
    } else {
      this.productsService.GetAll().subscribe(r => {
        if (r.wasSuccessful) {
          this.ProductsList = r.data;
        } else {
          this.toastr.error(r.statusMessage);
        }
      })
    }
  }
}
