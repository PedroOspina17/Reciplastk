import { Injectable } from '@angular/core';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../common/app-config';
import { ProductsModel } from '../models/ProductsModel';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }
  //ServiceEndpoint: string = `${AppConfig.API_URL}`;

  GetGeneralProducts():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/GeneralProduct')
  }
  GetByIdGeneralProducts(id: number):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/GeneralProduct')
  }
  CreateGeneralProducts(products: ProductsModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>('http://localhost:8765/GeneralProduct',products)
  }
  UpdateGeneralProducts(products: ProductsModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>('http://localhost:8765/GeneralProduct',products)
  }
  DeleteGeneralProducts():Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>('http://localhost:8765/GeneralProduct')
  }

  GetSpecificProducts():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/SpecificProduct')
  }
  GetByIdSpecificProducts(id: number):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/SpecificProduct')
  }
  CreateSpecificProducts(products: ProductsModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>('http://localhost:8765/SpecificProduct', products)
  }
  UpdateSpecificProducts(products: ProductsModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>('http://localhost:8765/SpecificProduct', products)
  }
  DeleteSpecificProducts(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>('http://localhost:8765/SpecificProduct')
  }
}
