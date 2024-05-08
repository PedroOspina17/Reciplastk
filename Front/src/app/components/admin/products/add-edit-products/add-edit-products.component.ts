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
  operacion: string = "Agregar ";
  loading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router,
    private productService: ProductsService,
    private aRoute: ActivatedRoute
  ){
    this.formProduct = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(20)]],
      description: ['', [Validators.required, Validators.maxLength(20)]],
      code: ['', [Validators.required, Validators.maxLength(20)]],
      buyprice: [null, Validators.required],
      sellprice: [null, Validators.required],
      margin: [null, Validators.required],
    });
    // Obtener el id de la URL - inyecta la dependencia ActiveRoute y luego lo llama con snapshot.paramMap
    this.id = Number(aRoute.snapshot.paramMap.get('id')); // Se parsea para que no salga error Number( lo que se quire cambiar)
    console.log('info id: ', this.id)
  }

  // Metodo para cargar los productos al momento de ingresar al componente
  ngOnInit(): void {

    if (this.id != 0){
      // Es editar
      this.operacion = 'Editar ';
      this.GetProduct(this.id)
      this.loading = false;
    }
  }

  // Metodo para Crear Producto y Modificar Informacion del Producto
  AddandUpdateProduct() {
    /* OBTENER EL VALOR DE LAS PROPIEDADES
      console.log(this.formProduct.value.name)
      console.log(this.formProduct.get('name')?.value)
    */
   const product: ProductsModel = {
    name: this.formProduct.value.name,
    description: this.formProduct.value.description,
    code: this.formProduct.value.code,
    buyprice: this.formProduct.value.buyprice,
    sellprice: this.formProduct.value.sellprice,
    margin: this.formProduct.value.margin
   };

   product.id = this.id;
   this.loading = true;
   if(this.id !== 0){

    // es editar
    product.id = this.id;
    this.productService.UpdateProduct(this.id, product).subscribe(()=>{
      console.log('informacion product.name: ', product.name);
      this.toastr.success(
        'El producto ${product.name} fue actualizado con exito',
        'Producto Actualizado'
      );
      this.loading = false;
      this.router.navigate(['/welcom'])
    });
   } else{
    // Es agregar

    this.productService.CreateProduct(product).subscribe(() => {

      console.log(product.name);

      this.toastr.success(
        'El producto ${product.name} fue creado Exitosamente',
        'Producto Creado'
      );
      this.loading = false;
      this.router.navigate(['/welcom'])
    });
   }
  }

  // Metodo para Obtener un Producto por Id

  GetProduct(id: number): void {
    this.productService.GetProduct(id).subscribe((result: ProductsModel) =>{

      //setiar o llenar el formulario con setValue para todos los valores o parchValue para algunos
      this.formProduct.setValue({
        name: result.name,
        description: result.description,
        code: result.code,
        buyprice: result.buyprice,
        sellprice: result.sellprice,
        margin: result.margin
      });
      console.log('info formProduct: ', this.formProduct.value.Name);
    });
  }

}

