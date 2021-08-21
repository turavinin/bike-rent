import { Component, OnInit } from '@angular/core';
import { RentService } from 'src/app/shared/rent.service';

@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styles: [
  ]
})
export class RentComponent implements OnInit {

  constructor(public rentService: RentService) { }

  ngOnInit(): void {
  }

}
