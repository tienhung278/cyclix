import {Component, EventEmitter, Input, OnChanges, Output, SimpleChanges} from '@angular/core';
import {Customer} from "../../models/customer.model";

@Component({
  selector: 'app-step5',
  templateUrl: './step5.component.html',
  styleUrls: ['./step5.component.css']
})
export class Step5Component implements OnChanges {

  @Input()
  customer: Customer = {};

  @Output()
  onCustomerValueChange = new EventEmitter<Customer>();

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!this.customer) {
      this.customer = {};
    }
  }
}
