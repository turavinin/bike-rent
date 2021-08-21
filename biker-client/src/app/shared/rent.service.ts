import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Rent } from './rent.model';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  constructor(private http: HttpClient) { }
  rentModel: Rent = new Rent();
  rentList: Rent[] = [];
  readonly baseUrl = "https://localhost:44365/api/Rent";

  postRent() {
    return this.http.post(this.baseUrl, this.rentModel, { observe: 'response' });
  }

  refreshOrder(model: Rent) {
    this.rentModel = model;
  }


}
