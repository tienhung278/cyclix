import {Component, OnInit} from '@angular/core';
import {RequestService} from "./services/request.service";
import {Customer} from "./models/customer.model";
import {RequestWrite} from "./models/request_write.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  customer: Customer = {};
  isSaved = false;
  requestWrite: RequestWrite = {};

  constructor(private bikeService: RequestService) {
  }

  ngOnInit() {
  }

  submit() {
    console.log(this.requestWrite);
  }
}
