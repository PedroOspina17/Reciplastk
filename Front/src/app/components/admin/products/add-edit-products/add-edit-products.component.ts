import { ProductModel } from './../../../../models/ProductModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../../services/products.service';
import { ProgressBarComponent } from '../../../shared/progress/progress-bar/progress-bar.component';

@Component({
  selector: 'app-add-edit-products',
  standalone: true,
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, RouterLink, ProgressBarComponent ],
  templateUrl: './add-edit-products.component.html',
  styleUrl: './add-edit-products.component.css'
})
export class AddEditProductsComponent {

  formProduct: FormGroup;
  formSubproduct: FormGroup;
  id: number;
  operacion: string = "";
  loading: boolean = false;
  listSubproduct: ProductModel[] = [];
  // subproduct:  = {};

  constructor(
    private fb: FormBuilder,
    private productService: ProductsService,
    private aRoute: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ){
    this.formProduct = this.fb.group({
      shortname: ['', [Validators.required, Validators.maxLength(20)]],
      name: ['', [Validators.required, Validators.maxLength(20)]],
      description: ['', [Validators.required, Validators.maxLength(20)]],
      code: ['', [Validators.required, Validators.maxLength(20)]],
      buyprice: [null, Validators.required],
      sellprice: [null, Validators.required],
      margin: [null, Validators.required],
      issubtype: [false]
    });

    this.formSubproduct = this.fb.group({
      nameSubproduct: ['', [Validators.required, Validators.maxLength(20)]],
      sellpriceSubproduct: [null, Validators.required],
    })
    // Obtener el id de la URL - inyecta la dependencia ActiveRoute y luego lo llama con snapshot.paramMap
    this.id = Number(aRoute.snapshot.paramMap.get('id')); // Se parsea para que no salga error Number( lo que se quire cambiar)
  }

  ngOnInit(){
    if (this.id != 0){
      // Es editar
      this.operacion = 'Editar';
      this.GetById(this.id)
      this.loading = false;
    }else{
      // es Agregar
      console.log("info id ngOnInit: ", this.id);
      this.operacion = 'Agregar';
      this.loading = false;
    };

  }

  GetById(id: number): void {
    this.productService.GetById(id).subscribe(result =>{
      console.log("result GetProduct: ", result);
      if (result.wasSuccessful == true) {
        //setiar o llenar el formulario con setValue para todos los valores o parchValue para algunos
        this.formProduct.setValue({
          shortname: result.data.shortname,
          name: result.data.name,
          description: result.data.description,
          code: result.data.code,
          buyprice: result.data.buyprice,
          sellprice: result.data.sellprice,
          margin: result.data.margin,
          issubtype: result.data.issubtype,
          nameSubproduct: result.data.name,
          sellpriceSubproduct: result.data.sellprice,
          marginSubproduct: result.data.margin
        });
        console.log('info formProduct: ', this.formProduct.value.name);
        console.log('info formProduct: ', this.formProduct.value.name);
      } else {
        console.log("informacion incorrecta");
      }
    });
  }

    AddandUpdate() {

   const product: ProductModel = {
    shortname: this.formProduct.value.shortname,
    name: this.formProduct.value.name,
    description: this.formProduct.value.description,
    code: this.formProduct.value.code,
    issubtype: this.formProduct.value.issubtype,
    SubtypeProductList: this.listSubproduct
   };
   console.log(" info product AddUpdte", product);

   product.productid = this.id;
   this.loading = true;

   if(this.id != 0){
    // es editar

    this.productService.Update(this.id, product).subscribe(result =>{

      if (result.wasSuccessful == true) {
        this.toastr.success(`El producto ${product.name} fue actualizado con exito`, `Producto Actualizado.`);
        this.loading = false;
        this.router.navigate(['/admin/products'])
      } else {
        this.toastr.error(`El producto no pudo ser modificado`, `Error.`)
        this.loading = false;
        this.router.navigate(['/admin/products'])
      }
    });
   } else{
    // Es agregar
    this.productService.Create(product).subscribe(result => {
      console.log("result CreateProducts: ", result);
      debugger;
      if (result.wasSuccessful == true) {
        console.log("informacion de product en agregar: ", product);
        this.toastr.success(`El producto ${product.name} fue creado Exitosamente`, `Producto Creado`);
        this.loading = false;
        this.router.navigate(['/admin/products'])
      } else {
        this.toastr.error(`El producto ${product.name}`,`Error.`);
        this.loading = false;
        this.router.navigate(['/admin/products'])
      }
    });
   }
  }
  AddSubproduct(){
    const subproduct =
      {
        shortname: this.formProduct.value.shortname + " " + this.formSubproduct.value.nameSubproduct,
        name: this.formProduct.value.name + " " + this.formSubproduct.value.nameSubproduct,
        description: this.formProduct.value.description + " " + this.formSubproduct.value.nameSubproduct,
        code: this.formProduct.value.code,
        issubtype: false,
      }
      console.log("subproducto: ", subproduct);
      this.listSubproduct.push(subproduct);
      console.log("lista de subp: ", this.listSubproduct);
      this.formSubproduct.value.shorname = "";
      this.formSubproduct.value.sellprice = "";
  }

  DeleteSubproduct(index: number){
    this.listSubproduct.splice(index,1);
    this.toastr.info(`El producto ${this.listSubproduct[index]} fue eliminado`, `Producto Eliminado.`)
  }

}

