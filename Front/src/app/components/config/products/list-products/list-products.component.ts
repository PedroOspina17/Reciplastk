import { ToastrService } from 'ngx-toastr';
import { ProductsRequest } from '../../../../models/Requests/ProductsRequest';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsService } from '../../../../services/products.service';
import { ProductPriceInnerComponent } from "../../../admin/product-price-inner/product-price-inner.component";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-list-products',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink, ProductPriceInnerComponent],
  templateUrl: './list-products.component.html',
  styleUrl: './list-products.component.css'
})
export class ListProductsComponent {
  listProducts: ProductsRequest[] = [];
  subProductsList: ProductsRequest[] = [];
  loading: boolean = false;
  expandedArea: boolean = true;
  id: number;
  producttochangeprice: number = -1;
  DeletePopUp: boolean = false;
  constructor(
    private productService: ProductsService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
  ) {
    this.id = Number(aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(id: number) {
    this.GetMain();
  };
  ChangePrice(productid: number) {
    this.producttochangeprice = productid
  }
  GetMain() {
    this.loading = true;
    this.productService.GetAll().subscribe(result => {
      if (result.WasSuccessful == true) {
        this.listProducts = result.Data;
        this.loading = false;
      } else {
      }
    })
  };

  GetByParentid(id: number) {
    this.loading
    this.productService.GetByParentId(id).subscribe(result => {
      if (result.WasSuccessful == true) {
        this.subProductsList = result.Data;
      }
    })
  }

  Delete(id: number) {
    this.DeletePopUp = true
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'Esto borrara todos los datos previamente almacenados en la tabla.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FFA500 ',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Sí, Eliminar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.loading = true;
        this.productService.Delete(id).subscribe(result => {
          if (result.WasSuccessful == true) {
            this.toastr.info(`El producto ${result.Data.name} fue eliminado con exito`, `Producto Eliminado.`)
          } else {
            this.toastr.error('El producto no fue eliminado.', 'Error.');
          }
          this.GetMain();
        })
      } else {
        this.DeletePopUp = false;
      }
    });




  }

  ExpandArea(id: number) {
    this.loading = true;


    this.productService.GetByParentId(id).subscribe(result => {
      if (result.WasSuccessful == true) {
        this.expandedArea = true;
        this.subProductsList = result.Data;
      }
    })
  }
}
