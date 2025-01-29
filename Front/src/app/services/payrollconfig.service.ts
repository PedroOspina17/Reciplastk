import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { PayrollConfigRequest } from '../models/Requests/PayrollConfigRequest';

@Injectable({
  providedIn: 'root'
})
export class PayrollconfigService {

  constructor(private http: HttpClient) { }
    ServiceEndpoint: string = `${AppConfig.API_URL}/api/PayrollConfig/`;
  
    GetAll(): Observable<HttpResponseModel> {
      return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetAll')
    }
  
    GetById(id: number): Observable<HttpResponseModel> {
      return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetById?Id=' + id)
    }
  
    Create(payrollConfig:PayrollConfigRequest): Observable<HttpResponseModel> {
      return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Create', payrollConfig)
    }

    Filter(payrollConfig:PayrollConfigRequest): Observable<HttpResponseModel> {
      return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Filter', payrollConfig)
    }

    Update(payrollConfig:PayrollConfigRequest): Observable<HttpResponseModel> {
      return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Update', payrollConfig)
    }
  
    Delete(id: number): Observable<HttpResponseModel> {
      return this.http.delete<HttpResponseModel>(this.ServiceEndpoint + 'Delete?Id=' + id)
    }
}
