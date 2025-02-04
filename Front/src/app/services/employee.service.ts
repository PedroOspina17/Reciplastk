import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { Observable } from 'rxjs/internal/Observable';
import { EmployeeRequest } from '../models/Requests/EmployeeRequest';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Employee/`;
  
  GetAll(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetById?Id=' + id)
  }

  Create(Model: EmployeeRequest): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Create', Model)
  }

  Update(Model: EmployeeRequest): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Update', Model)
  }

  Delete(id: number): Observable<HttpResponseModel> {
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint + 'Delete?Id=' + id)
  }
}
