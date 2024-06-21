import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../../services/products.service';
import { ProductsModel } from '../../../../models/ProductsModel';
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
  id: number;
  operacion: string = "";
  loading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private productService: ProductsService,
    private aRoute: ActivatedRoute
  ){
    this.formProduct = this.fb.group({
      shortname: ['', [Validators.required, Validators.maxLength(20)]],
      name: ['', [Validators.required, Validators.maxLength(20)]],
      description: ['', [Validators.required, Validators.maxLength(20)]],
      code: ['', [Validators.required, Validators.maxLength(20)]],
      buyprice: [null, Validators.required],
      sellprice: [null, Validators.required],
      margin: [null, Validators.required],
    });
    // Obtener el id de la URL - inyecta la dependencia ActiveRoute y luego lo llama con snapshot.paramMap
    this.id = Number(aRoute.snapshot.paramMap.get('id')); // Se parsea para que no salga error Number( lo que se quire cambiar)

  }

  // Metodo para cargar los productos al momento de ingresar al componente
  ngOnInit(): void {

    if (this.id != 0){
      // Es editar
      this.operacion = 'Editar';
      this.GetProduct(this.id)
      this.loading = false;
    }else{
      // es Agregar
      console.log("info id ngOnInit: ", this.id);
      this.operacion = 'Agregar';
      this.loading = false;
    }
  }

  // Metodo para Obtener un Producto por Id

  GetProduct(productid: number): void {
    this.productService.GetProduct(productid).subscribe(result =>{
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
          margin: result.data.margin
        });
        console.log('info formProduct: ', this.formProduct.value.name);
      } else {
        console.log("informacion incorrecta");
      }
    });
  }

  // Metodo para Crear Producto y Modificar Informacion del Producto
  AddandUpdateProduct() {

   const product: ProductsModel = {
    shortname: this.formProduct.value.shortname,
    name: this.formProduct.value.name,
    description: this.formProduct.value.description,
    code: this.formProduct.value.code,
    buyprice: this.formProduct.value.buyprice,
    sellprice: this.formProduct.value.sellprice,
    margin: this.formProduct.value.margin
   };

   product.productid = this.id;
   this.loading = true;
   if(this.id != 0){

    // es editar
    product.productid = this.id;
    console.log("info product.productid metodo addedit: ", product.productid);
    console.log("info id en addedit: ", this.id);

    this.productService.UpdateProduct(this.id, product).subscribe(result =>{
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
    console.log("info product.productid metodo addedit: ", product.productid);
    console.log("info id en addedit: ", this.id);

    this.productService.CreateProduct(product).subscribe(result => {
      console.log("result CreateProducts: ", result);
      if (result.wasSuccessful == true) {
        this.toastr.success(`El producto ${product.name} fue creado Exitosamente`, `Producto Creado`);
        this.loading = false;
        this.router.navigate(['/admin/dashboard/products'])
      } else {
        this.toastr.error(`El producto ${product.name}`,`Error.`);
        this.loading = false;
        this.router.navigate(['/admin/dashboard/products'])
      }
    });
   }
  }
}

