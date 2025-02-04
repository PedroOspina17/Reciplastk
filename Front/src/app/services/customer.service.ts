import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerViewModel } from '../models/ViewModel/CustomerViewModel';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }
  
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Customer`;
  GetAll(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAll')
  }
  GetAllCustomer(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAllCustomer')
  }
  GetAllProviders():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAllProviders')
  }
  GetCustomer(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetCustomer?id='+id)
  }
  GetProvider(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetProvider?id='+id)
  }
  Create(customerModel: CustomerViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Create',customerModel)
  }
  Update(customerModel: CustomerViewModel, customerId: number): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Update',customerModel)
  }
  Delete(id: number): Observable<HttpResponseModel> {
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/Delete?id='+id)
  }
}
