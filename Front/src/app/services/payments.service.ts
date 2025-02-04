import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfig } from '../common/app-config';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { PaymentReceiptRequest } from '../models/Requests/PaymentReceiptRequest';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Payments/`;

  PayAndSave(Model: PaymentReceiptRequest): Observable<HttpResponseModel> {
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint + 'PayAndSave', Model);
  }
  GetAllReceipt(): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetAllReceipt');
  }
  GetReceipt(id: number): Observable<HttpResponseModel> {
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint + 'GetReceipt?id=' + id);
  }
}
