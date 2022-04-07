import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FormatDatePipe } from '../pipe/format.date';
import { FormEmployeeComponent } from './form-employee/form-employee.component';
import { HttpClientModule } from '@angular/common/http';
import {
  DxButtonModule,
  DxDataGridModule,
  DxFormModule,
} from 'devextreme-angular';
@NgModule({
  declarations: [AppComponent, FormatDatePipe, FormEmployeeComponent],
  imports: [
    BrowserModule,
    FormsModule,
    DxButtonModule,
    DxDataGridModule,
    DxFormModule,
    HttpClientModule
  ],
  exports: [FormatDatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
