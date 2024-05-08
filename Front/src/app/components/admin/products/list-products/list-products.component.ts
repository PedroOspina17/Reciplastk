import { ProductsModel } from './../../../../models/ProductsModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavbarProductsComponent } from '../navbar-products/navbar-products.component';
import { RouterLink } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsService } from '../../../../services/products.service';
import { ProgressBarComponent } from '../../../shared/progress/progress-bar/progress-bar.component';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, ProgressBarComponent ],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent {
  listProducts: ProductsModel[] = [];
  loading: boolean = false;

  constructor(private productService: ProductsService) { }

  ngOnInit(): void{
    this.GetProducts();
  };

  GetProducts() {
    this.loading = true;
    this.productService.GetProducts().subscribe(result =>{
      this.listProducts = result;
      this.loading= false;
      console.log('info listProducts: ', this.listProducts);
    })
  };

  DeleteProduct(id: number){
    this.loading = true;
    this.productService.DeleteProduct(id).subscribe(()  => {
    this.GetProducts();
   })

  }

}
