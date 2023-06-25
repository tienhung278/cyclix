import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TypeService} from "../../services/type.service";
import {BrandService} from "../../services/brand.service";
import {TranslateService} from "@ngx-translate/core";
import {Observable} from "rxjs";
import {Type} from "../../models/type.model";
import {Brand} from "../../models/brand.model";

@Component({
  selector: 'app-step1',
  templateUrl: './step1.component.html',
  styleUrls: ['./step1.component.css']
})
export class Step1Component implements OnInit {

  @Input()
  typeId = 0;
  @Output()
  onTypeValueChange = new EventEmitter<number>();

  @Input()
  brandId = 0;
  @Output()
  onBrandValueChange = new EventEmitter<number>();

  types$: Observable<Type[]> = new Observable<Type[]>();
  brands$: Observable<Brand[]> = new Observable<Brand[]>();

  constructor(private typeService: TypeService,
              private brandService: BrandService,
              private translate: TranslateService) {
    translate.addLangs(['en', 'vn']);
  }

  ngOnInit(): void {
        this.types$ = this.typeService.getTypes();
        this.brands$ = this.brandService.getBrands();
  }

  switchLanguage(lang: string) {
    this.translate.use(lang);
  }

  typeValueChange(typeSelectedId: number): void {
    this.onTypeValueChange.emit(typeSelectedId);
  }

  brandValueChange(brandSelectedId: number): void {
    this.onBrandValueChange.emit(brandSelectedId);
  }
}
