import { Injectable } from '@angular/core';
import { Rates } from './rates.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RatesService {

  constructor(private http: HttpClient) { }
  ratesModel: Rates = new Rates();
  ratesList: Rates[] = [];
  readonly baseUrl = "https://localhost:44365/api/Rent";


  getRates() {
    return this.http.get(this.baseUrl, { observe: 'response' });
  }
}