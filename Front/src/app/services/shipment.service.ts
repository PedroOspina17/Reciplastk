import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { ShipmentViewModel } from '../models/shipmentViewModel';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Shipment`;

  ShowAllShipment(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/ShowAllShipment')
  }

  ShowShipment(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/ShowShipment?shipmentid='+id)
  }

  CreateShipment(shipmentModel: ShipmentViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/CreateShipment', shipmentModel)
  }

  EditShipment(shipmentModel: ShipmentViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/EditShipment', shipmentModel)
  }

  DeleteShipment(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/DeleteShipment?shipmentid='+id)
  }

}
