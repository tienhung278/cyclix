import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Observable} from "rxjs";
import {Service} from "../../models/service.model";
import {Package} from "../../models/package.model";
import {ServiceService} from "../../services/service.service";
import {PackageService} from "../../services/package.service";

@Component({
  selector: 'app-step2',
  templateUrl: './step2.component.html',
  styleUrls: ['./step2.component.css']
})
export class Step2Component implements OnInit {

  @Input()
  serviceId: number = 0;
  @Output()
  onServiceValueChange = new EventEmitter<number>();

  @Input()
  packageIds: number[] = [];
  @Output()
  onPackageValueChange = new EventEmitter<number[]>();

  services$: Observable<Service[]> = new Observable<Service[]>();
  packages$: Observable<Package[]> = new Observable<Package[]>();

  selectedPackageIds: number[] = [];

  constructor(private serviceService: ServiceService,
              private packageService: PackageService) {
  }

  ngOnInit(): void {
    this.services$ = this.serviceService.getServices();
    this.packages$ = this.packageService.getPackages();
  }

  serviceValueChange(serviceSelectedId: number): void {
    this.onServiceValueChange.emit(serviceSelectedId);
  }

  packageValueChange(packageSelectedId: number): void {
    const index = this.selectedPackageIds?.indexOf(packageSelectedId)!;
    if (packageSelectedId && index != -1) {
      this.selectedPackageIds?.splice(index, 1);
    } else {
      this.selectedPackageIds?.push(packageSelectedId);
      this.selectedPackageIds.sort();
    }
    this.onPackageValueChange.emit(this.selectedPackageIds);
  }
}
