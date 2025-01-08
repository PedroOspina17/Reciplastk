import { ProductModel } from '../../../../models/ProductModel';
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
  listSubproduct: ProductModel[] = [];

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
      console.log('DATA',result.data)
      if (result.wasSuccessful == true) {
        this.productPriceService.GetProductCurrentBuySellPrices(id).subscribe(r => {
          console.log('DATA2',result.data)

          if (r.wasSuccessful) {
            this.formProduct.controls['shortname'].disable();
            this.formProduct.controls['code'].disable();
            this.formProduct.setValue({
              shortname: result.data.shortname,
              name: result.data.name,
              description: result.data.description,
              code: result.data.code,
              issubtype: result.data.inverseParent.length > 0,
              buyprice: r.data.buy,
              sellprice: r.data.sell,
            });
            console.log('FORM',this.formProduct.value)
          }
        });


        result.data.inverseParent.forEach((element: ProductModel) => {
          this.productPriceService.GetProductCurrentPrice(element.productid!, PriceType.Sell).subscribe(r => {
            if (r.wasSuccessful) {
              const productPrice = r.data;
              const product = {
                ...element,
                sellprice: productPrice
              };
              this.listSubproduct.push(product);
              console.log(this.listSubproduct);
            }
          });
        });


      } else {
        this.toastr.error(result.statusMessage);
      }
    });
  }
  AddandUpdate() {
    const product: ProductModel = {
      shortname: this.formProduct.value.shortname,
      name: this.formProduct.value.name,
      description: this.formProduct.value.description,
      code: this.formProduct.value.code,
      buyprice: this.formProduct.value.buyprice,
      sellprice: this.formProduct.value.sellprice,
      SubtypeProductList: this.listSubproduct,
    };
    product.productid = this.id;
    if (this.id != 0) {
      this.productService.Update(this.id, product).subscribe((result) => {
        if (result.wasSuccessful == true) {
          this.toastr.success(
            `El producto ${product.name} fue actualizado con exito`,
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
            `El producto ${product.name} fue creado Exitosamente`,
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
    console.log('form',this.formProduct.value)
    const subproduct = {
      shortname:
        this.formProduct.value.shortname +
        ' - ' +
        this.formSubproduct.value.nameSubproduct,
      name:
        this.formProduct.value.name +
        ' ' +
        this.formSubproduct.value.nameSubproduct,
      description:
        this.formProduct.value.description +
        ' ' +
        this.formSubproduct.value.nameSubproduct,
      code: this.formProduct.value.code + (this.listSubproduct.length + 1),
      buyprice: this.formProduct.value.buyprice,
      sellprice: this.formSubproduct.value.sellpriceSubproduct,
      issubtype: true,
    };
    this.listSubproduct.push(subproduct);
    console.log(this.listSubproduct);
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
