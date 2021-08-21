import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Rates } from 'src/app/shared/rates.model';
import { RatesService } from 'src/app/shared/rates.service';
import { RentService } from 'src/app/shared/rent.service';
import { RentDetailService } from 'src/app/shared/rent-detail.service';
import { RentDetail } from 'src/app/shared/rent-detail.model';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from "ngx-spinner";
import swal from "sweetalert2";
import { HttpResponse } from '@angular/common/http';



@Component({
  selector: 'app-rent-form',
  templateUrl: './rent-form.component.html',
  styles: [
  ]
})
export class RentFormComponent implements OnInit {

  constructor(public rentService: RentService,
    public ratesService: RatesService,
    public rentDetailService: RentDetailService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show();

    this.ratesService.getRates().subscribe(
      (res: HttpResponse<any>) => {
        if (res.status == 200) {
          this.ratesService.ratesList = res.body as Rates[];
          this.ratesService.ratesList.forEach(e => {
            this.rentDetailService.rentDetailList.push(new RentDetail(e.id));
          });
          this.spinner.hide();
        }
      },
      err => {
        this.spinner.hide();
        this.spinner.show("primary", {
          zIndex: 1
        });
        swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'There was a system error! Please try again!',
          confirmButtonText: `<a class="text-decoration-none text-white" href="window.location.reload()">Ok</a>`,
        })
      }
    )
  }

  onSubmit(form: NgForm) {
    let details = this.rentDetailService.filterDetails(this.rentDetailService.rentDetailList);
    let isValid = this.rentDetailService.validateRent(details);
    if (isValid) {
      this.rentService.rentModel.rentDetails = details;
      this.rentService.postRent().subscribe(
        (res: HttpResponse<any>) => {
          if (res.status == 200) {
            this.rentService.refreshOrder(res.body as any);
            this.toastr.success("Successfully rented", "Bike Rent");
          }
        },
        err => {
          this.toastr.error("There was a system error", "Bike Rent");
          return;
        })
    } else {
      swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'You must specify the term and the amount of rentals!'
      })
    }
  }
}
