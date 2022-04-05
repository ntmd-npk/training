import { Component } from '@angular/core';
import { Employee } from './employee';
import { EmployeeService } from './employee.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})

export class AppComponent {

  title = 'Employee List';
  employee: Employee = {
    id: 0,
    name: '',
    birth: '',
    address: '',
    phone: ''
  };
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployeeList();
  }

  getEmployeeList() {
    this.employeeService.get().subscribe((employees) => {
      this.employees = employees;
    });
  }

  deleteEmployee(id: number) {
    let isDetele = confirm('Do you really want to delete this employee?');
    if (isDetele) this.employeeService.delete(id);
  }

  editEmployee(id: number) {
    const editEmployee = this.employees.find(_ => _.id === id)
    if (editEmployee) {
      this.employee = { ...editEmployee }
    }
  }

  employeeChange() {
    this.employeeService.edit(this.employee)
  }

  ngOnDestroy(): void {
    // this.employeeService.get().unsubscribe();
  }
}
