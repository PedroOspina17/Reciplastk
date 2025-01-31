import { ToastrService } from 'ngx-toastr';
import { ProductModel } from '../../../../models/ProductModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink} from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsService } from '../../../../services/products.service';
import { ProductPriceInnerComponent } from "../../../admin/product-price-inner/product-price-inner.component";

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, ProductPriceInnerComponent],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent {
  listProducts: ProductModel[] = [];
  subProductsList: ProductModel [] =[];
  loading: boolean = false;
  expandedArea: boolean = true;
  id: number;
  producttochangeprice: number = -1;
  constructor(
    private productService: ProductsService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
  ) {
    this.id = Number(aRoute.snapshot.paramMap.get('id'));
   }

  ngOnInit(id: number){
    this.GetMain();
  };
  ChangePrice(productid: number) {
    this.producttochangeprice = productid
  }
  GetMain() {
    this.loading = true;
    this.productService.GetAll().subscribe(result =>{
      if (result.wasSuccessful == true) {
        this.listProducts = result.data;
        this.loading= false;
      } else {
      }
    })
  };

  GetByParentid(id: number){
    this.loading
    this.productService.GetByParentId(id).subscribe(result=> {
      if(result.wasSuccessful == true){
        this.subProductsList = result.data;
      }
    })
  }

  Delete(id: number){
    this.loading = true;
    this.productService.Delete(id).subscribe(result  => {
      if(result.wasSuccessful == true){
        this.toastr.info(`El producto ${result.data.name} fue eliminado con exito`, `Producto Eliminado.`)
      }else {
        this.toastr.error('El producto no fue eliminado.', 'Error.');
      }
    this.GetMain();
   })
  }

  ExpandArea(id: number){
    this.loading = true;


    this.productService.GetByParentId(id).subscribe(result =>{
      if(result.wasSuccessful == true){
        this.expandedArea = true;
        this.subProductsList = result.data;
      }
    })
  }
}
