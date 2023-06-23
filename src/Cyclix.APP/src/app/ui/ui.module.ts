import { NgModule } from '@angular/core';
import {MatStepperModule} from "@angular/material/stepper";
import {MatIconModule} from "@angular/material/icon";
import {
  DxButtonModule,
  DxCheckBoxModule,
  DxFormModule,
  DxSelectBoxModule,
  DxTextAreaModule,
  DxTextBoxModule
} from "devextreme-angular";

const UIComponents = [
  MatStepperModule,
  MatIconModule,
  DxSelectBoxModule,
  DxCheckBoxModule,
  DxButtonModule,
  DxTextAreaModule,
  DxTextBoxModule
];

@NgModule({
  imports: [UIComponents],
  exports: [UIComponents]
})
export class UIModule { }
