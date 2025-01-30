import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from '../../../services/employee.service';
import { EmployeeParams } from '../../../models/EmployeeParams';
import Swal from 'sweetalert2';

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
  DeletePopUp: boolean = false;
  GetAll() {
    this.employeeService.GetAll().subscribe(r => {
      if (r.WasSuccessful) {
        this.employeeList = r.Data;
      } else {
        this.toastr.error(r.StatusMessage);
      }
    })
  }
  Delete(employeeid: number) {

    this.DeletePopUp = true
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'Esto borrara todos los datos previamente almacenados en la tabla.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FFA500 ',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Sí, Eliminar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.employeeService.Delete(employeeid).subscribe(r => {
          if (r.WasSuccessful) {
            this.toastr.success(r.StatusMessage);
          } else {
            this.toastr.error(r.StatusMessage);
          }
        })
      } else {
        this.DeletePopUp = false;
      }
    });
  }
}
