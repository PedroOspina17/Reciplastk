import { ToastrService } from 'ngx-toastr';
import { ProductsModel } from './../../../../models/ProductsModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink} from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsService } from '../../../../services/products.service';
import { ProgressBarComponent } from '../../../shared/progress/progress-bar/progress-bar.component';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, ProgressBarComponent],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent {
  listProducts: ProductsModel[] = [];
  loading: boolean = false;

  constructor(
    private productService: ProductsService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void{
    this.GetProducts();
  };

  GetProducts() {
    this.loading = true;
    this.productService.GetProducts().subscribe(result =>{
      if (result.wasSuccessful == true) {
        this.listProducts = result.data;
        this.loading= false;
      } else {
        console.log("informacion incorrecta");
      }
    })
  };

  DeleteProduct(id: number){
    this.loading = true;
    console.log("id product: ", id);
    this.productService.DeleteProduct(id).subscribe(result  => {
      if(result.wasSuccessful == true){
        this.toastr.info(`El producto ${result.data.name} fue eliminado con exito`, `Producto Eliminado.`)
      }else {
        this.toastr.error('El producto no fue eliminado.', 'Error.');
      }
    this.GetProducts();
   })

  }

}
