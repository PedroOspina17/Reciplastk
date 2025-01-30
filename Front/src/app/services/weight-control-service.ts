import { HttpClient } from '@angular/common/http';
import { Injectable, model } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { WeightControlSeparationRequest } from '../models/Requests/WeightControlSeparationRequest';
import { WeightControlGrindingRequest } from '../models/Requests/WeightControlGrindingRequest';
import { WeightControlReportRequest } from '../models/Requests/WeightControlReportRequest';
import {PaymentReceiptRequest } from '../models/Requests/PaymentReceiptRequest';

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
  CreateSeparation(Model: WeightControlSeparationRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreateSeparation',Model);
  }
  CreateGrinding(Model: WeightControlGrindingRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'CreateGrinding',Model);
  }
  Update(Model: WeightControlSeparationRequest):Observable<HttpResponseModel>{
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
  Filter(Model: WeightControlReportRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Filter',Model);
  }
  Remainings(viewAll: boolean):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'Remainings?ViewAll='+viewAll)
  }
  WeightControlForPayments(Model: WeightControlReportRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'Filter',Model);
  }
  PayAndSave(Model: PaymentReceiptRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'PayAndSave',Model);
  }
  GetAllReceipt():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetAllReceipt');
  } 
  GetReceipt(id: number):Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'GetReceipt?id='+id);
  }
}
