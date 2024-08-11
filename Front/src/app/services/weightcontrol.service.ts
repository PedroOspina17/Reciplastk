import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { HttpClient } from '@angular/common/http';
import { WeightControlModel } from '../models/WeightControlModel';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';

@Injectable({
  providedIn: 'root'
})
export class WeightcontrolService {

  constructor(private http:HttpClient) { }
  serviceEndpoint: string = `${AppConfig.API_URL}/api/WeightControl`;

  ShowById(request: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(`${this.serviceEndpoint}/ShowById`+ request)
  }

  ShowAll():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(`${this.serviceEndpoint}/ShowAll`)
  }

  Create(request: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(`${this.serviceEndpoint}/Create`,request)
  }
  Update(request: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.put<HttpResponseModel>(`${this.serviceEndpoint}/Update`,request)
  }

  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(`${this.serviceEndpoint}/Delete/${id}`)
  }




}
