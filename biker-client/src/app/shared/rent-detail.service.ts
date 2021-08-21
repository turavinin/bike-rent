import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RentDetail } from './rent-detail.model';

@Injectable({
  providedIn: 'root'
})
export class RentDetailService {

  constructor(private http: HttpClient) { }
  rentDetailModel: RentDetail = new RentDetail(0);
  rentDetailList: RentDetail[] = [];


  filterDetails(rentList: RentDetail[]) {
    return this.rentDetailList.filter((x) => {
      let rent;
      if (x.amountTerm != 0 || x.totalRents != 0) {
        rent = x;
      }
      return rent;
    })
  }
  validateRent(details: RentDetail[]) {
    let output = true;
    if (details.length == 0)
      output = false;

    details.forEach((e) => {
      if (e.amountTerm == 0 || e.totalRents == 0) {
        output = false;
      }
    })
    return output;
  }
}