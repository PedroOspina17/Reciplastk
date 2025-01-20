import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from '../../../services/employee.service';
import { EmployeeParams } from '../../../models/EmployeeParams';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule, RouterLink],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  constructor(
    private toastr: ToastrService,
    private aRoute: ActivatedRoute,
    private employeeService: EmployeeService,
  ) { }
  employeeList: EmployeeParams[] = [];
  GetAll() {
    this.employeeService.GetAll().subscribe(r => {
      if (r.wasSuccessful) {
        this.employeeList = r.data;
      } else {
        this.toastr.error(r.statusMessage);
      }
    })
  }
  Delete(employeeid: number){
    this.employeeService.Delete(employeeid).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage);
      } else {
        this.toastr.error(r.statusMessage);
      }
    })
  }
}
