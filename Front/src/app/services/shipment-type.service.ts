import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfig } from '../common/app-config';
import { Observable } from 'rxjs';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { ShipmentTypeRequest } from '../models/Requests/ShipmentTypeRequest';


@Injectable({
  providedIn: 'root'
})
export class ShipmentTypeService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/ShipmentType`;

  GetAll(): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetAll')
  }

  GetById(id: number): Observable<HttpResponseModel>{
    return this.http.get<HttpResponseModel>(this.ServiceEndpoint+'/GetById?shipmentTypeId='+id)
  }

  Create(shipmenTypetModel: ShipmentTypeRequest):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Create', shipmenTypetModel)
  }

  Update(shipmenTypetModel: ShipmentTypeRequest, id: number):Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint+'/Update', shipmenTypetModel)
  }

  Delete(id: number):Observable<HttpResponseModel>{
    return this.http.delete<HttpResponseModel>(this.ServiceEndpoint+'/Delete?shipmentTypeId='+id)
  }

}
