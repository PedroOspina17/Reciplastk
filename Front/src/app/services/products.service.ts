import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductsModel } from '../models/ProductsModel';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private htpp: HttpClient) { }

  // Metodo para obtener todos los productos
  GetProducts(): Observable<Array<ProductsModel>>{
    return this.htpp.get<Array<ProductsModel>>('https://localhost:7131/api/Products/GetProducts');
  }

  // Metodo para obtener un Procto por id
  GetProduct(id: number): Observable<ProductsModel>{
    return this.htpp.get<ProductsModel>('https://localhost:7131/api/Products/getProductId?id='+id)
  }
}
