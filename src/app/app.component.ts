import { Component } from '@angular/core';
import { lastValueFrom, of, Subscription, throwError } from 'rxjs';
import { Employee } from '../mock/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent
{
  title = 'Employee List';
  employees: Employee[] = [];
  subsTemp$: Subscription = new Subscription;
  subs: Subscription[] = [];
  newId = -3;

  constructor(private employeeService: EmployeeService) { }

  // Get employee list
  ngOnInit(): void
  {
    this.getEmployeeList();
  }

  getEmployeeList()
  {
    this.subs.push(this.employeeService.get().subscribe((employees) => this.employees = employees));
  }

  // Add a new employee
  async onRowInserting(e: any)
  {
    const newId = await lastValueFrom(this.employeeService.add(e.data)).catch(() =>
    {
      this.employees.pop();
    });
    this.newId = newId;
  }

  onRowInserted(e: any)
  {
    e.data.id = this.newId;
    e.component.navigateToRow(e.key);
  }

  // Delete a new employee
  onRowRemoving(e: any)
  {
    let index = this.employees.findIndex((_) => _.id === e.data.id);
    let oldData = { ...e.data };
    this.employeeService.delete(e.data.id).subscribe(({
      error: () =>
      {
        this.employees.splice(index, 0, oldData);
      }
    }));
  }

  // Edit a new employee
  onRowUpdating(e: any)
  {
    let oldData = { ...e.oldData };
    this.subsTemp$.add(this.employeeService.edit(e.key, e.newData).subscribe({
      error: () =>
      {
        let editItem = this.employees.find((_) => _.id === e.key);
        if (editItem)
        {
          for (const key in e.newData)
          {
            if (editItem.hasOwnProperty(key))
            {
              editItem[key] = oldData[key];
            }
          }
        }
      }
    }));
  }

  ngOnDestroy(): void
  {
    this.subs.forEach(element => element.unsubscribe());
  }

}