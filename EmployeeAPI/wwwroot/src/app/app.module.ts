import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FormatDatePipe } from '../pipe/format.date';
import { HttpClientModule } from '@angular/common/http';
import {
  DxButtonModule,
  DxDataGridModule,
  DxFormModule,
  DxToastModule,
  DxTabsModule,
} from 'devextreme-angular';
import { GridTableComponent } from './grid-table/grid-table.component';
@NgModule({
  declarations: [AppComponent, FormatDatePipe, GridTableComponent],
  imports: [
    BrowserModule,
    FormsModule,
    DxButtonModule,
    DxDataGridModule,
    DxFormModule,
    DxToastModule,
    DxTabsModule,
    HttpClientModule,
  ],
  exports: [FormatDatePipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
