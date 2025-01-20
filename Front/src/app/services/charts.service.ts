import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { Observable } from 'rxjs';
import { AppConfig } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class ChartsService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Charts`;

  GetEmployeeComparisonInfo(isYearlyChart: boolean, year:number, month: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+`/GetEmployeeComparisonInfo?yearlyChart=${isYearlyChart}&year=${year}&month=${month}`)
  }
}
