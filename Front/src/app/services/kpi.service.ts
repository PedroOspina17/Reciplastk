import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KpiService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Kpi`;

  GetSeparationSummary(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetSeparationSummary?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }
  GetGrindingSummary(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetGrindingSummary?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }
  GetShippingSummary(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetShippingSummary?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }
  GetBillingSummary(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetBillingSummary?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }
  GetShipmentGoal(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetShipmentGoal?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }
  GetBillingGoal(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetBillingGoal?isYearly=${isYearlyChart}&year=${year}&month=${month}`)
  }

}
