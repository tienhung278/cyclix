import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-step4',
  templateUrl: './step4.component.html',
  styleUrls: ['./step4.component.css']
})
export class Step4Component {

  @Input()
  description: string = "";
  @Output()
  onDescriptionValueChange = new EventEmitter<string>();

  @Input()
  note: string = "";
  @Output()
  onNoteValueChange = new EventEmitter<string>();

  descriptionValueChange(text: string) {
    this.onDescriptionValueChange.emit(text);
  }

  noteValueChange(text: string) {
    this.onNoteValueChange.emit(text);
  }
}
