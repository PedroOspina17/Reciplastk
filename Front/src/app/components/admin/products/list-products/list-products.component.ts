import { ProductsModel } from './../../../../models/ProductsModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavbarProductsComponent } from '../navbar-products/navbar-products.component';
import { RouterLink } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsService } from '../../../../services/products.service';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, NavbarProductsComponent ],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent {
  listProducts: ProductsModel[] = [];

  constructor(private productService: ProductsService) { }

  ngOnInit(): void{
    this.GetProducts();
  };

  GetProducts(): void{

    this.productService.GetProducts().subscribe(result =>{
      this.listProducts = result;
    // console.log('info listProducts: ', this.listProducts);
     console.log("informacion de result: ", result);
    })
  };

}
