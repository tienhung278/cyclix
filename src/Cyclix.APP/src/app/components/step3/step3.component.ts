import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Observable} from "rxjs";
import {Option} from "../../models/option.model";
import {OptionService} from "../../services/option.service";
import {AnotherOptionService} from "../../services/another-option.service";
import {AnotherOption} from "../../models/another-option.model";

@Component({
  selector: 'app-step3',
  templateUrl: './step3.component.html',
  styleUrls: ['./step3.component.css']
})
export class Step3Component implements OnInit {

  @Input()
  optionIds: number[] = [];
  @Output()
  onOptionValueChange = new EventEmitter<number[]>();

  @Input()
  anotherOptionIds: number[] = [];
  @Output()
  onAnotherOptionValueChange = new EventEmitter<number[]>();

  options$: Observable<Option[]> = new Observable<Option[]>();
  anotherOptions$: Observable<AnotherOption[]> = new Observable<AnotherOption[]>();

  constructor(private optionService: OptionService,
              private anotherOptionService: AnotherOptionService) {
  }

  ngOnInit(): void {
    this.options$ = this.optionService.getOptions();
    this.anotherOptions$ = this.anotherOptionService.getAnotherOptions();
  }

  optionValueChange(optionSelectedId: number): void {
    const index = this.optionIds?.indexOf(optionSelectedId)!;
    if (optionSelectedId && index != -1) {
      this.optionIds?.splice(index, 1);
    } else {
      this.optionIds?.push(optionSelectedId);
    }

    this.onOptionValueChange.emit(this.optionIds);
  }

  anotherOptionValueChange(anotherOptionSelectedId: number): void {
    const index = this.anotherOptionIds?.indexOf(anotherOptionSelectedId)!;
    if (anotherOptionSelectedId && index != -1) {
      this.anotherOptionIds?.splice(index, 1);
    } else {
      this.anotherOptionIds?.push(anotherOptionSelectedId);
    }

    this.onAnotherOptionValueChange.emit(this.anotherOptionIds);
  }
}
