import {Component, EventEmitter, Input, Output} from '@angular/core';
import {Customer} from "../../models/customer.model";

@Component({
  selector: 'app-step5',
  templateUrl: './step5.component.html',
  styleUrls: ['./step5.component.css']
})
export class Step5Component {

  @Input()
  customer: Customer = {};
  @Output()
  onCustomerValueChange = new EventEmitter<Customer>();
}
