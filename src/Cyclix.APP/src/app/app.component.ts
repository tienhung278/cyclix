import {Component, OnDestroy, OnInit} from '@angular/core';
import {RequestService} from "./services/request.service";
import {RequestWrite} from "./models/request_write.model";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  isSaved = false;
  requestWrite: RequestWrite = {};
  subscriptions: Subscription[] = [];

  constructor(private requestService: RequestService) {
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  ngOnInit() {
    this.subscriptions.push(
      this.requestService.getRequest().subscribe(
        value => {
          this.requestWrite = {
            typeId: value.type?.id,
            brandId: value.brand?.id,
            serviceId: value.service?.id,
            packageIds: value.packages?.map(p => p.id),
            optionIds: value.options?.map(o => o.id),
            anotherOptionIds: value.anotherOptions?.map(ao => ao.id),
            description: value.description,
            note: value.note,
            customer: value.customer
          };
        }
      )
    );
  }

  submit(): void {
    this.subscriptions.push(
      this.requestService.createRequest(this.requestWrite).subscribe(
        value => {
          this.isSaved = true;
          this.reset();
        }
      )
    );
  }

  load(): void {
    this.subscriptions.push(
      this.requestService.getRequest().subscribe(
        value => {
          this.requestWrite = {
            typeId: value.type?.id,
            brandId: value.brand?.id,
            serviceId: value.service?.id,
            packageIds: value.packages?.map(p => p.id),
            optionIds: value.options?.map(o => o.id),
            anotherOptionIds: value.anotherOptions?.map(ao => ao.id),
            description: value.description,
            note: value.note,
            customer: value.customer
          };
          this.isSaved = false;
        }
      )
    );
  }

  private reset(): void {
    this.requestWrite = {
      packageIds: [],
      optionIds: [],
      anotherOptionIds: [],
      customer: {}
    }
  }
}
