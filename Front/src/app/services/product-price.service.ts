import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { ProductPriceModel } from '../models/ProductPriceModel';
import { CopyCustomerPricesViewModel } from '../models/CopyCustomerPricesViewModel';

@Injectable({
  providedIn: 'root'
})
export class ProductPriceService {
  constructor(private http: HttpClient) { }
  
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/ProductPrices/`;
  GetAllPriceTypes(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAllPriceTypes')
  }
  GetAllProductPrices(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAllProductPrices')
  }
  GetPriceTypesById(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetPriceTypesById?id='+id)
  }
  GetProductPricesById(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetProductPricesById?id='+id)
  }
  CreateProductPrices(Model: ProductPriceModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreateProductPrices',Model);
  }
  CreatePriceTypes(Model: ProductPriceModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreatePriceTypes',Model);
  }
  Filter(Model: ProductPriceModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Filter',Model);
  }
  GetCurrentPrice(productid:number, customerid:number, productpricetypeid:number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetCurrentPrice?productid='+productid+'&customerid='+customerid+'&productpricetypeid='+productpricetypeid);
  }
  CopyPrices(Model: CopyCustomerPricesViewModel): Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CopyPrices',Model);
  }
}
