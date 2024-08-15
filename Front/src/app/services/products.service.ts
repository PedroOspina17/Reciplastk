import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductsModel } from '../models/ProductsModel';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private htpp: HttpClient) { }

  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Products/`;

  // Metodo para obtener todos los productos
  GetAll(): Observable<HttpResponseModel>{
    return this.htpp.get<HttpResponseModel>(this.ServiceEndpoint+'GetAll');
  }

  // Metodo para obtener un Producto por id
  GetById(id: number): Observable<HttpResponseModel>{
    return this.htpp.get<HttpResponseModel>(this.ServiceEndpoint+'GetById?id='+id)
  }
  // Metodo para obtener un Producto por parentid
  GetByParentId(id: number): Observable<HttpResponseModel>{
    return this.htpp.get<HttpResponseModel>(this.ServiceEndpoint+'GetParentId?id='+id)
  }

  // Metodo para Crear un Producto
  Create(productModel: ProductsModel): Observable<HttpResponseModel>{
    return this.htpp.post<HttpResponseModel>(this.ServiceEndpoint+"Create", productModel)
  }

  // Metodo para modificar un Producto
  Update (productid: number, productModel: ProductsModel): Observable<HttpResponseModel>{
    return this.htpp.put<HttpResponseModel>(this.ServiceEndpoint+'Update', productModel)
  }

  // Metodo para Eliminar un Producto
  Delete(id: number): Observable<HttpResponseModel>{
    return this.htpp.delete<HttpResponseModel>(this.ServiceEndpoint+'Delete?id='+id )
  }
}
