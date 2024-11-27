import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { ShipmentModel } from '../models/ShipmentModel';
import { ShipmentReportParamsModel } from '../models/ShipmentReportParamsModel';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Shipment`;

  GetAll(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetById?shipmentid='+id)
  }

  Create(shipmentModel: ShipmentModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Create', shipmentModel)
  }
  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/Delete?shipmentid='+id)
  }
  Filter(model: ShipmentReportParamsModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Filter', model)
  }
  GetShipmentForPayments(id:number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetShipmentForPayments?id='+id);
  }
  GetReceivableReceiptInfo(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetReceivableReceiptInfo?id='+id);
  }
  ProductBuyPrice(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/ProductBuyPrice')
  }
  ProductSellPrice(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/ProductSellPrice')
  }
}
