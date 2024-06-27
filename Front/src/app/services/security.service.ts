import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/LoginModel';
import { HttpResponseModel } from '../models/HttpResponseModel';
import { AppConfig  } from '../common/app-config';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  constructor(private http: HttpClient) { }
  ServiceEndpoint: string = `${AppConfig.API_URL}/api/Security/Login`;

  LogIn(loginInfo: LoginModel): Observable<HttpResponseModel>{
    return this.http.post<HttpResponseModel>(this.ServiceEndpoint,loginInfo);
  }
}
