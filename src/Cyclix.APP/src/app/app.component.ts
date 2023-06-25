import {Component, OnInit} from '@angular/core';
import {Type} from "./models/type.model";
import {RequestService} from "./services/request.service";
import {TranslateService} from "@ngx-translate/core";
import {RequestRead} from "./models/request_read.model";
import {Customer} from "./models/customer.model";
import {RequestWrite} from "./models/request_write.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  items: Type[] = [];
  types: Type[] = [];
  brands: Type[] = [];
  services: Type[] = [];
  options: Type[] = [];
  packages: Type[] = [];
  anotherOptions: Type[] = [];
  bike: RequestRead = {};
  customer: Customer = {};
  isPackageMapped = false;
  totalPackageItem = -1
  isOptionMapped = false;
  totalOptionItem = -1
  isAnotherOptionMapped = false;
  totalAnotherOption = -1
  isSaved = false;

  requestWrite: RequestWrite = {};

  constructor(
    private bikeService: RequestService,
    private translate: TranslateService) {
    translate.addLangs(['en', 'vn']);
  }

  ngOnInit() {
  }

  onPackageChanged($event: null | undefined | boolean, item: Type) {
    // if (this.isPackageMapped) {
    //   const index = this.bike.packageId?.indexOf(item.id)!;
    //   if (!$event && index != -1) {
    //     this.bike.packageId?.splice(index, 1);
    //   } else {
    //     this.bike.packageId?.push(item.id);
    //   }
    // }
    //
    // if (--this.totalPackageItem == 0) {
    //   this.isPackageMapped = true;
    // }
  }

  onOptionChanged($event: null | undefined | boolean, item: Type) {
    // if (this.isOptionMapped) {
    //   const index = this.bike.optionId?.indexOf(item.id)!;
    //   if (!$event && index != -1) {
    //     this.bike.optionId?.splice(index, 1);
    //   } else {
    //     this.bike.optionId?.push(item.id);
    //   }
    // }
    //
    // if (--this.totalOptionItem == 0) {
    //   this.isOptionMapped = true;
    // }
  }

  onAnotherOptionChanged($event: null | undefined | boolean, item: Type) {
    // if (this.isAnotherOptionMapped) {
    //   const index = this.bike.anotherOptionId?.indexOf(item.id)!;
    //   if (!$event && index != -1) {
    //     this.bike.anotherOptionId?.splice(index, 1);
    //   } else {
    //     this.bike.anotherOptionId?.push(item.id);
    //   }
    // }
    //
    // if (--this.totalAnotherOption == 0) {
    //   this.isAnotherOptionMapped = true;
    // }
  }

  submit() {
    // this.bike.customer = this.customer;
    // this.bikeService.createBike(this.bike).subscribe(
    //   data => this.isSaved = true
    // );
  }
}
