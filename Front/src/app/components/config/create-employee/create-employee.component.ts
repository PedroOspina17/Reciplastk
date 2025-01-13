import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from '../../../services/role.service';
import { RoleParams } from '../../../models/RoleParams';
import { EmployeeViewModel } from '../../../models/EmployeeViewModel';
import { EmployeeService } from '../../../services/employee.service';

@Component({
  selector: 'app-create-employee',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  templateUrl: './create-employee.component.html',
  styleUrl: './create-employee.component.css'
})
export class CreateEmployeeComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService,
    private roleService: RoleService,
    private employeeService: EmployeeService
  ) {
    this.formEmployee = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      userName: ['', [Validators.required, Validators.maxLength(50)]],
      password: ['', [Validators.required, Validators.maxLength(50)]],
      role: ['', Validators.required]
    })
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  formEmployee: FormGroup;
  roleList: RoleParams[] = [];
  isCreate: string = "";
  id: number;
  ngOnInit(): void {
    if (this.id != 0) {
      this.isCreate = 'Editar';
    } else {
      this.isCreate = 'Agregar';
    }
  }
  GetAllRoles() {
    this.roleService.GetAll().subscribe(r => {
      if (r.wasSuccessful) {
        this.roleList = r.data;
      } else {
        this.toastr.error(r.statusMessage);
      }
    })
  }
  CreateOrEdit() {
    const model: EmployeeViewModel = {
      roleid: this.formEmployee.value.role,
      name: this.formEmployee.value.name,
      lastName: this.formEmployee.value.lastName,
      userName: this.formEmployee.value.userName,
      password: this.formEmployee.value.password,
    };
    if (this.id == null) {
      this.employeeService.Create(model).subscribe(r => {
        if (r.wasSuccessful) {
          this.toastr.success(r.statusMessage);
          this.router.navigate(['/comfig/employee']);
        } else {
          this.toastr.success(r.statusMessage);
        }
      })
    } else {
      model.employeeId = this.id;
      this.employeeService.Update(model).subscribe(r => {
        if (r.wasSuccessful) {
          this.toastr.success(r.statusMessage);
          this.router.navigate(['/comfig/employee']);
        } else {
          this.toastr.success(r.statusMessage);
        }
      })
    }
  }
}
