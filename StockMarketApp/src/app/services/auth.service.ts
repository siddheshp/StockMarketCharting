import { LoginModel } from './../models/login-model';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = "https://localhost:44392/authservice";
  constructor(private client: HttpClient) { }

  login(username: string, password: string): Observable<LoginModel> {
    //https://localhost:44392/authservice?username=<>&password=<>
    let url = this.baseUrl + '?username=' + username + '&password=' + password;
    return this.client.get<LoginModel>(url);
  }
}
