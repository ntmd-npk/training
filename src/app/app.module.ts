import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FormatDatePipe } from '../pipe/format.date';
import { FormEmployeeComponent } from './form-employee/form-employee.component';
@NgModule({
  declarations: [
    AppComponent,
    FormatDatePipe,
    FormEmployeeComponent,
  ],
  imports: [
    BrowserModule, FormsModule
  ],
  exports: [FormatDatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
