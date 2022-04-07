import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../../mock/employee';
import { EmployeeService } from '../../services/employee.service';
@Component({
  selector: 'app-form-employee',
  templateUrl: './form-employee.component.html',
  styleUrls: ['./form-employee.component.scss']
})
export class FormEmployeeComponent implements OnInit {

  isEdit?: Boolean

  @Input() employee: Employee = {
    id: 0,
    name: '',
    birth: '',
    address: '',
    phone: ''
  }

  @Output() employeeChange = new EventEmitter<Employee>()

  constructor(private employeeService: EmployeeService) { }

  ngOnChanges() {
    this.isEdit = !!this.employee.id
  }

  ngOnInit(): void {
    this.resetEmployee()
  }

  resetEmployee() {
    this.employee.id = 0;
    this.employee.name = '';
    this.employee.birth = '';
    this.employee.address = '';
    this.employee.phone = '';
  }

  validEmployee() {
    return this.employee.name &&
      this.employee.birth &&
      this.employee.address &&
      this.employee.phone
  }

  addEmployee() {
    if (this.validEmployee()) {
      // this.employeeService.add(this.employee);
      this.resetEmployee();
    } else {
      alert('Please fill out all fields!!!');
    }
  }

  saveEmployee() {
    if (this.validEmployee()) {
      this.employeeChange.emit(this.employee)
      this.isEdit = false;
      this.resetEmployee();
    } else {
      alert('Please fill out all fields!!!');
    }
  }
}
