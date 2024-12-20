import { HttpClient } from '@angular/common/http';
import { Injectable, model } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { WeightControlModel } from '../models/WeightControlModel';
import { WeightControlGrindingModel } from '../models/WeightControlGrindingModel';
import { WeightControlReportParams } from '../models/WeightControlReportParams';
import {PaymentReceipt } from '../models/PaymentReceipt';

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
  CreateSeparation(Model: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreateSeparation',Model);
  }
  CreateGrinding(Model: WeightControlGrindingModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreateGrinding',Model);
  }
  Update(Model: WeightControlModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Update',Model);
  }
  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'Delete?id='+id);
  }  
  GetEmployee():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/Employee');
  }
  GetGroundProducts():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetGroundProducts');
  }
  Filter(Model: WeightControlReportParams):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Filter',Model);
  }
  Remainings(viewAll: boolean):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'Remainings?ViewAll='+viewAll)
  }
  WeightControlForPayments(Model: WeightControlReportParams):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Filter',Model);
  }
  PayAndSave(Model: PaymentReceipt):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'PayAndSave',Model);
  }
  GetAllReceipt():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAllReceipt');
  } 
  GetReceipt(id: number):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetReceipt?id='+id);
  }
}
