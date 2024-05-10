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

  ServiceEndpoint: string = `${AppConfig.API_URL}`;

  // Metodo para obtener todos los productos
  GetProducts(): Observable<HttpResponseModel>{
    return this.htpp.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Products/GetProducts');
  }

  // Metodo para obtener un Producto por id
  GetProduct(id: number): Observable<HttpResponseModel>{
    return this.htpp.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Products/getProductId?id='+id)
  }

  // Metodo para Crear un Producto
  CreateProduct(infoProduct: ProductsModel): Observable<HttpResponseModel>{
    return this.htpp.post<HttpResponseModel>(this.ServiceEndpoint+"/api/Products/createProduct", infoProduct)
  }

  // Metodo para modificar un Producto
  UpdateProduct (id: number, infoProduct: ProductsModel): Observable<HttpResponseModel>{
    return this.htpp.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Products/updateProduct', infoProduct)
  }

  // Metodo para Eliminar un Producto
  DeleteProduct(id: number): Observable<HttpResponseModel>{
    return this.htpp.delete<HttpResponseModel>(this.ServiceEndpoint+'/api/Products/deleteProduct?id='+id )
  }
}
