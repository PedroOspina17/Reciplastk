import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { Observable } from 'rxjs/internal/Observable';
import { EmployeeViewModel } from '../models/EmployeeViewModel';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Employee`;
  
  GetAll(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + '/GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + '/GetById?customerTypeId=' + id)
  }

  Create(employeeModel: EmployeeViewModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + '/Create', employeeModel)
  }

  Update(employeeModel: EmployeeViewModel, id: number): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + '/Update', employeeModel)
  }

  Delete(id: number): Observable<HttpResponseModel> {
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint + '/Delete?customerTypeId=' + id)
  }
}
