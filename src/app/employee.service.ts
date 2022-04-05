import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { Employee } from './employee';
import { EMPLOYEES } from './employee-data';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  employee: Employee = {
    id: 0,
    name: '',
    birth: '',
    address: '',
    phone: '',
  };
  employees: Employee[] = EMPLOYEES
  employees$: BehaviorSubject<Employee[]> = new BehaviorSubject<Employee[]>(EMPLOYEES);
  store$: Observable<any> = this.employees$.asObservable();


  constructor() { }

  get() {
    return this.employees$;
  }

  delete(id: number) {
    this.employees = this.employees.filter(_ => _.id !== id);
    this.employees$.next(this.employees);
  }

  add(newEmployee: Employee) {

    const id = this.employees.slice(-1)[0].id + 1;
    const newOne: Employee = {
      id,
      name: newEmployee.name,
      birth: newEmployee.birth,
      address: newEmployee.address,
      phone: newEmployee.phone
    }
    this.employees.push(newOne)
    this.employees$.next(this.employees);
  }


  edit(employee: Employee) {
    const editEmployee = this.employees.find(_ => _.id === employee.id);
    if (editEmployee) {
      editEmployee.id = employee.id
      editEmployee.name = employee.name
      editEmployee.address = employee.address
      editEmployee.birth = employee.birth
      editEmployee.phone = employee.phone
    }
    this.employees$.next(this.employees);
  }
}
