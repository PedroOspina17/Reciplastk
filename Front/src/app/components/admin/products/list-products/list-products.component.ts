import { ToastrService } from 'ngx-toastr';
import { ProductsModel } from './../../../../models/ProductsModel';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink} from '@angular/router';
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
  subProductsList: ProductsModel [] =[];
  loading: boolean = false;
  expandedArea: boolean = true;
  id: number;

  constructor(
    private productService: ProductsService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
  ) {
    this.id = Number(aRoute.snapshot.paramMap.get('id'));
   }

  ngOnInit(id: number){
    this.GetAll();
  };

  GetAll() {
    this.loading = true;
    this.productService.GetAll().subscribe(result =>{
      if (result.wasSuccessful == true) {
        this.listProducts = result.data;
        this.loading= false;
      } else {
        console.log("informacion incorrecta");
      }
    })
  };

  GetByParentid(id: number){
    this.loading
    this.productService.GetByParentId(id).subscribe(result=> {
      if(result.wasSuccessful == true){
        this.subProductsList = result.data;
        console.log("getByparentid:", this.subProductsList);
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
    this.GetAll();
   })
  }

  ExpandArea(id: number){
    this.loading = true;

   
    this.productService.GetByParentId(id).subscribe(result =>{
      if(result.wasSuccessful == true){
        this.expandedArea = true;
        this.subProductsList = result.data;
        console.log("data product expandArea: ", this.subProductsList);
      }
    })

  }

}
