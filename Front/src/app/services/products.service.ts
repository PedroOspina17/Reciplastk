import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductModel } from '../models/ProductModel';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Products/`;

  GetAll(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAll');
  }
  GetMain(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetMainProducts');
  }
  GetSpecificProducts(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetSpecificProducts');
  }
  GetById(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetById?id='+id)
  }
  GetByParentId(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetParentId?id='+id)
  }

  Create(productModel: ProductModel): Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+"Create", productModel)
  }

  Update (productid: number, productModel: ProductModel): Observable<HttpResponseModel>{
    return this.http.put<HttpResponseModel>(this.ServiceEndpoint+'Update', productModel)
  }

  Delete(id: number): Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'Delete?id='+id )
  }

}
