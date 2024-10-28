import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { CustomerTypeModel } from '../models/CustomerTypeModel';


@Injectable({
  providedIn: 'root'
})
export class CustomerTypeService {
  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/CustomerType`;

  GetAll(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetById?customerTypeId='+id)
  }

  Create(customerModel: CustomerTypeModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Create', customerModel)
  }

  Update(customerModel: CustomerTypeModel, id: number):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Update', customerModel)
  }

  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/Delete?customerTypeId='+id)
  }
}
