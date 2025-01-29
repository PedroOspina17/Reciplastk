import { ProductsRequest } from '../../../../models/Requests/ProductsRequest';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../../services/products.service';
import { ProgressBarComponent } from '../../../shared/progress/progress-bar/progress-bar.component';
import { ProductPriceService } from '../../../../services/product-price.service';
import { PriceType } from '../../../../models/Enums';
@Component({
  selector: 'app-add-edit-products',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    ProgressBarComponent,
  ],
  templateUrl: './add-edit-products.component.html',
  styleUrl: './add-edit-products.component.css',
})
export class AddEditProductsComponent {
  formProduct: FormGroup;
  formSubproduct: FormGroup;
  id: number;
  operation: string = '';
  loading: boolean = false;
  listSubproduct: ProductsRequest[] = [];

  constructor(
    private fb: FormBuilder,
    private productService: ProductsService,
    private aRoute: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private productPriceService: ProductPriceService
  ) {
    this.formProduct = this.fb.group({
      shortname: ['', [Validators.required, Validators.maxLength(20)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['', [Validators.required, Validators.maxLength(150)]],
      code: ['', [Validators.required, Validators.maxLength(10)]],
      buyprice: [null, Validators.required],
      sellprice: [null, Validators.required],
      issubtype: [false],
    });

    this.formSubproduct = this.fb.group({
      nameSubproduct: ['', [Validators.required, Validators.maxLength(20)]],
      sellpriceSubproduct: [null, Validators.required],
    });
    this.id = Number(aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    if (this.id != 0) {
      this.operation = 'Editar';
      this.GetById(this.id);
      this.loading = false;
    } else {
      this.operation = 'Agregar';
      this.loading = false;
    }
  }

  GetById(id: number): void {
    this.productService.GetById(id).subscribe((result) => {
      if (result.wasSuccessful == true) {
        this.productPriceService.GetProductCurrentBuySellPrices(id).subscribe(r => {

          if (r.wasSuccessful) {
            this.formProduct.controls['shortname'].disable();
            this.formProduct.controls['code'].disable();
            this.formProduct.setValue({
              shortname: result.data.shortname,
              name: result.data.name,
              description: result.data.description,
              code: result.data.code,
              issubtype: result.data.subproducts.length > 0,
              buyprice: r.data.buy,
              sellprice: r.data.sell,
            });
          }
        });


        result.data.subproducts.forEach((element: ProductsRequest) => {
          this.productPriceService.GetProductCurrentPrice(element.Id!, PriceType.Sell).subscribe(r => {
            if (r.wasSuccessful) {
              const productPrice = r.data;
              const product = {
                ...element,
                sellprice: productPrice
              };
              this.listSubproduct.push(product);
            }
          });
        });


      } else {
        this.toastr.error(result.statusMessage);
      }
    });
  }
  AddandUpdate() {
    const product: ProductsRequest = {
      ShortName: this.formProduct.value.shortname,
      Name: this.formProduct.value.name,
      Description: this.formProduct.value.description,
      Code: this.formProduct.value.code,
      BuyPrice: this.formProduct.value.buyprice,
      SellPrice: this.formProduct.value.sellprice,
      SubTypeProductList: this.listSubproduct,
    };
    product.Id = this.id;
    if (this.id != 0) {
      this.productService.Update(this.id, product).subscribe((result) => {
        if (result.wasSuccessful == true) {
          this.toastr.success(
            `El producto ${product.Name} fue actualizado con exito`,
            `Producto Actualizado.`
          );
          this.loading = false;
          this.router.navigate(['/config/products']);
        } else {
          this.toastr.error(`El producto no pudo ser modificado`, `Error.`);
          this.loading = false;
          this.router.navigate(['/config/products']);
        }
      });
    } else {
      this.productService.Create(product).subscribe((result) => {
        if (result.wasSuccessful == true) {
          this.toastr.success(
            `El producto ${product.Name} fue creado Exitosamente`,
            `Producto Creado`
          );
          this.router.navigate(['/config/products']);
        } else {
          this.toastr.error(result.statusMessage, `Error.`);
        }
        this.loading = false;
      });
    }
  }
  AddSubproduct() {
    const subproduct = {
      ShortName:
        this.formProduct.value.shortname +
        ' - ' +
        this.formSubproduct.value.nameSubproduct,
      Name:
        this.formProduct.value.name +
        ' ' +
        this.formSubproduct.value.nameSubproduct,
      Description:
        this.formProduct.value.description +
        ' ' +
        this.formSubproduct.value.nameSubproduct,
      Code: this.formProduct.value.code + (this.listSubproduct.length + 1),
      BuyPrice: this.formProduct.value.buyprice,
      SellPrice: this.formSubproduct.value.sellpriceSubproduct,
      issubtype: true,
    };
    this.listSubproduct.push(subproduct);
    this.formSubproduct.reset();
  }
  DeleteSubproduct(index: number) {
    this.listSubproduct.splice(index, 1);
    this.toastr.info(
      `El producto ${this.listSubproduct[index]} fue eliminado`,
      `Producto Eliminado.`
    );
  }
}
