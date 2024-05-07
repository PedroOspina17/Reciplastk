import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../../services/products.service';
import { ProductsModel } from '../../../../models/ProductsModel';

@Component({
  selector: 'app-add-edit-products',
  standalone: true,
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, RouterLink ],
  templateUrl: './add-edit-products.component.html',
  styleUrl: './add-edit-products.component.css'
})
export class AddEditProductsComponent {

  formProduct: FormGroup;
  id: number;
  operacion: string = "Agregar";

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
      buyPrice: [null, Validators.required],
      SellPrice: [null, Validators.required],
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
      this.operacion = 'Editar';

    }
  }

  // Metodo para Crear Producto y Modificar Informacion del Producto
  AddandUpdateProduct(): void {
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

   if(this.id != 0){
    // es modificar
    this.productService
    .UpdateProduct(product)
    .subscribe((result)=>{
      this.toastr.info(
        'Producto ${product.name} fue Modificado con exito',
        'Producto Actualizado'
      );
      this.router.navigate(['/listProducts'])
    });
   } else{
    this.productService.CreateProduct(product).subscribe((result) => {
      this.toastr.success(
        'Producto ${product.name} fue creado Exitosamente',
        'Producto Creado'
      );
      this.router.navigate(['/listProducts'])

    });
   }
  }

  // Metodo para Obtener un Producto por Id

  getProduct(id: number): void {
    this.productService.GetProduct(id).subscribe((result: ProductsModel) =>{
      console.log('info de Result: ', result);
      //setiar o llenar el formulario con setValue para todos los valores o parchValue para algunos
      this.formProduct.setValue({
        name: result.name,
        description: result.description,
        code: result.description,
        buyPrice: result.buyprice,
        sellPrice: result.sellprice,
        margin: result.margin
      });
      console.log('info formProduct: ', this.formProduct.value.Name);
    });
  }

}

