import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { RoleViewModel } from '../models/ViewModel/RoleViewModel';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Role/`;

  GetAll(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetById?id=' + id)
  }

  Create(roleViewModel: RoleViewModel): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'Create', roleViewModel)
  }

  Update(roleViewModel: RoleViewModel): Observable<HttpResponseModel> {
    return this.http.put<HttpResponseModel>(this.ServiceEndpoint + 'Update', roleViewModel)
  }

  Delete(id: number): Observable<HttpResponseModel> {
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint + 'Delete?Id=' + id)
  }
}
