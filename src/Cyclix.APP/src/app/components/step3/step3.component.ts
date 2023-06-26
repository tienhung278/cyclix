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

  selectedOptionIds: number[] = [];
  selectedAnotherOptionIds: number[] = [];

  constructor(private optionService: OptionService,
              private anotherOptionService: AnotherOptionService) {
  }

  ngOnInit(): void {
    this.options$ = this.optionService.getOptions();
    this.anotherOptions$ = this.anotherOptionService.getAnotherOptions();
  }

  optionValueChanged(event: any, optionSelectedId: number): void {
    const index = this.selectedOptionIds?.indexOf(optionSelectedId)!;
    if (event && index == -1) {
      this.selectedOptionIds?.push(optionSelectedId);
      this.selectedOptionIds.sort();
    } else if (index != -1) {
      this.selectedOptionIds?.splice(index, 1);
    }
    this.onOptionValueChange.emit(this.selectedOptionIds);
  }

  anotherOptionValueChanged(event: any, anotherOptionSelectedId: number): void {
    const index = this.selectedAnotherOptionIds?.indexOf(anotherOptionSelectedId)!;
    if (event && index == -1) {
      this.selectedAnotherOptionIds?.push(anotherOptionSelectedId);
      this.selectedAnotherOptionIds.sort();
    } else if (index != -1) {
      this.selectedAnotherOptionIds?.splice(index, 1);
    }

    this.onAnotherOptionValueChange.emit(this.selectedAnotherOptionIds);
  }
}
