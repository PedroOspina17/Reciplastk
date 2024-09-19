import { HttpClient } from '@angular/common/http';
import { Injectable, model } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { WeightControlModel } from '../models/WeightControlModel';

@Injectable({
  providedIn: 'root'
})
export class WeightControlService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/WeightControl/`;

  GetAll():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAll');
  }  
  GetById(id: number):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetById?id='+id);
  }
  Create(Model: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Create',Model);
  }
  Update(Model: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Update',Model);
  }
  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/Delete?id='+id);
  }  
  GetEmployee():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/Employee');
  }
}
