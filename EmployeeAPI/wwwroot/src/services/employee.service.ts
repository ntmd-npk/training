import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Employee } from '../mock/employee';
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class EmployeeService
{

  url = 'https://localhost:7053/api/employee';


  constructor(private http: HttpClient) { }

  get(): Observable<any>
  {
    return this.http.get<Employee[]>(this.url);
  }

  delete(id: number): Observable<any>
  {
    return this.http.delete(`${this.url}/${id}`).pipe(catchError(this.handleError));
  }

  add(employee: any): Observable<number>
  {
    return this.http.post<number>(this.url, employee);
  }

  edit(id: number, data: any): Observable<any>
  {
    return this.http.put(`${this.url}/${id}`, data).pipe(catchError(this.handleError));
  }

  handleError(err: any)
  {
    return throwError(err);
  }
}
