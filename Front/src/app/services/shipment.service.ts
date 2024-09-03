import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { ShipmentViewModel } from '../models/ShipmentModel';
import { ShipmentDetail } from '../models/ShipmentDetail';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}`;

  ShowAllShipment(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/ShowAllShipment')
  }

  ShowShipment(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/ShowShipment?shipmentid='+id)
  }

  CreateShipment(shipmentModel: ShipmentViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/CreateShipment', shipmentModel)
  }

  CreateShipmentDetail(shipmentModel: ShipmentViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/CreateShipment', ShipmentDetail)
  }

  EditShipment(shipmentModel: ShipmentViewModel):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/EditShipment', shipmentModel)
  }

  DeleteShipment(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/api/Shipment/DeleteShipment?shipmentid='+id)
  }
  ShowAllProviders():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/Providers')
  }
  ShowGeneralProducts():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/GeneralProduct')
  }
  ShowSpesificProducts():Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>('http://localhost:8765/SpesificProduct')
  }

}
