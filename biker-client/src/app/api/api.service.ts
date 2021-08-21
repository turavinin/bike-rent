import { Injectable } from '@angular/core';
import { Api } from "./api.model"
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  api: Api = new Api();
}
