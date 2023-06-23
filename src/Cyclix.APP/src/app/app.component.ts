import {AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild, ViewChildren} from '@angular/core';
import {Item} from "./models/item.model";
import {BikeService} from "./services/bike.service";
import {TranslateService} from "@ngx-translate/core";
import {Bike} from "./models/bike.model";
import DevExpress from "devextreme";
import {Customer} from "./models/customer.model";
import {DxCheckBoxComponent} from "devextreme-angular";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  items: Item[] = [];
  types: Item[] = [];
  brands: Item[] = [];
  services: Item[] = [];
  options: Item[] = [];
  packages: Item[] = [];
  anotherOptions: Item[] = [];
  bike: Bike = {};
  customer: Customer = {};
  isPackageMapped = false;
  totalPackageItem = -1
  isOptionMapped = false;
  totalOptionItem = -1
  isAnotherOptionMapped = false;
  totalAnotherOption = -1
  isSaved = false;

  constructor(
    private bikeService: BikeService,
    private translate: TranslateService) {
    translate.addLangs(['en', 'vn']);
  }

  ngOnInit() {
    this.bikeService.getItems().subscribe(
      data => {
        this.items = data;
        this.getTypes();
        this.getBrand();
        this.getService();
        this.getOption();
        this.getPackage();
        this.getAnotherOption();

        this.totalPackageItem = this.packages.length;
        this.totalOptionItem = this.options.length;
        this.totalAnotherOption = this.anotherOptions.length;
      });

    this.bikeService.getBike().subscribe(
      data => {
        this.bike = data;
      });
  }

  switchLanguage(lang: string) {
    this.translate.use(lang);
  }

  getTypes() {
    this.types = this.items.filter(i => i.category === 'type');
  }

  getBrand() {
    this.brands = this.items.filter(i => i.category === 'brand');
  }

  getService() {
    this.services = this.items.filter(i => i.category === 'service');
  }

  getOption() {
    this.options = this.items.filter(i => i.category === 'option');
  }

  getPackage() {
    this.packages = this.items.filter(i => i.category === 'package');
  }

  getAnotherOption() {
    this.anotherOptions = this.items.filter(i => i.category === 'another_option');
  }

  onPackageChanged($event: null | undefined | boolean, item: Item) {
    if (this.isPackageMapped) {
      const index = this.bike.packageId?.indexOf(item.id)!;
      if (!$event && index != -1) {
        this.bike.packageId?.splice(index, 1);
      } else {
        this.bike.packageId?.push(item.id);
      }
    }

    if (--this.totalPackageItem == 0) {
      this.isPackageMapped = true;
    }
  }

  onOptionChanged($event: null | undefined | boolean, item: Item) {
    if (this.isOptionMapped) {
      const index = this.bike.optionId?.indexOf(item.id)!;
      if (!$event && index != -1) {
        this.bike.optionId?.splice(index, 1);
      } else {
        this.bike.optionId?.push(item.id);
      }
    }

    if (--this.totalOptionItem == 0) {
      this.isOptionMapped = true;
    }
  }

  onAnotherOptionChanged($event: null | undefined | boolean, item: Item) {
    if (this.isAnotherOptionMapped) {
      const index = this.bike.anotherOptionId?.indexOf(item.id)!;
      if (!$event && index != -1) {
        this.bike.anotherOptionId?.splice(index, 1);
      } else {
        this.bike.anotherOptionId?.push(item.id);
      }
    }

    if (--this.totalAnotherOption == 0) {
      this.isAnotherOptionMapped = true;
    }
  }

  submit() {
    this.bike.customer = this.customer;
    this.bikeService.createBike(this.bike).subscribe(
      data => this.isSaved = true
    );
  }
}
