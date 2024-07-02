import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerViewModel } from '../models/CustomerViewModel';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }
  
  ServiceEndpoint: string = `${AppConfig.API_URL}`;

  ShowAllCustomers(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Customer/ShowAllCustomers')
  }

  ShowCustomer(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Customer/Find?id='+id)
  }

  CreateCustomer(customerModel: CustomerViewModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Customer/Create', customerModel)
  }

  EditCustomer(customerModel: CustomerViewModel, customerId: number): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Customer/Edit',customerModel)
  }

  DeleteCustomer(id: number): Observable<HttpResponseModel> {
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/api/Customer/Delete?id='+id)
  }

}
