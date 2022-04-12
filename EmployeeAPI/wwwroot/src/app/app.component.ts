import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import CustomStore from 'devextreme/data/custom_store';
import { BASE_URL } from "../constants";
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent
{

  selectedIndex = 0;
  tabs = ["Employee", "Company"];
  isVisible = false;
  type = "";
  message = "Some message";
  errMsg = "There is some problem during rendering. Please retry again!";

  employeeData: any = [];
  companyData: any = [];

  constructor(private http: HttpClient)
  {
    const employeeURL = `${BASE_URL}/employee`;
    const companyURL = `${BASE_URL}/company`;

    this.employeeData = new CustomStore({

      key: 'id',

      load: () =>
      {
        return lastValueFrom(http.get(employeeURL))
          .then((data: any) => ({
            data: data,
            totalCount: data.length
          }))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });
      },

      insert: (values) =>
      {
        return lastValueFrom(http.post(employeeURL, values))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });
      },

      update: (key, values) =>
      {
        return lastValueFrom(http.put(`${employeeURL}/${encodeURIComponent(key)}`, values))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });;
      },

      remove: (key) =>
      {
        return lastValueFrom(http.delete(`${employeeURL}/${encodeURIComponent(key)}`))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          }) as PromiseLike<any>;
      },

      onInserted: () =>
      {
        this.notify("success", "A new employee is added");
      },

      onRemoved: () =>
      {
        this.notify("success", "An employee is removed");
      },

      onUpdated: () =>
      {
        this.notify("success", "The employee info is updated");
      }

    });


    this.companyData = new CustomStore({

      key: 'id',

      load: () =>
      {
        return lastValueFrom(http.get(companyURL))
          .then((data: any) => ({
            data: data,
            totalCount: data.length
          }))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });
      },

      insert: (values) => 
      {
        return lastValueFrom(http.post(companyURL, values))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });
      },

      update: (key, values) =>
      {
        return lastValueFrom(http.put(`${companyURL}/${encodeURIComponent(key)}`, values))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          });
      },

      remove: (key) =>
      {
        return lastValueFrom(http.delete(`${companyURL}/${encodeURIComponent(key)}`))
          .catch((err: any) =>
          {
            this.notify("error", this.errMsg);
            throw err;
          }) as PromiseLike<any>;
      },

      onInserted: () =>
      {
        this.notify("success", "A new company is added");
      },

      onRemoved: () =>
      {
        this.notify("success", "A company is removed");
      },

      onUpdated: () =>
      {
        this.notify("success", "The company info is updated");
      }
    });
  }

  notify(type: string, message: string)
  {
    this.isVisible = true;
    this.type = type;
    this.message = message;
  }
}