import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeViewModel } from '../../../models/EmployeeViewModel';

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
  ) { }
  employeeList: EmployeeViewModel[] = [];
  
}
