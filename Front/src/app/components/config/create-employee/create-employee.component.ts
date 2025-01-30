import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from '../../../services/role.service';
import { EmployeeRequest } from '../../../models/Requests/EmployeeRequest';
import { EmployeeService } from '../../../services/employee.service';
import { RoleViewModel } from '../../../models/RoleViewModel';

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
      role: ['', Validators.required],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      documentNumber: ['', [Validators.required, Validators.maxLength(15)]],
      userName: ['', [Validators.required, Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.maxLength(20)]],
      repPassword: ['', [Validators.required, Validators.maxLength(20)]],
      dateOfBirth: [, Validators.required],
      dateOfJoin: [, Validators.required],
      createdBy: [, Validators.required]
    },
      { validators: this.passwordsMatchValidator }
    )
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  passwordsMatchValidator: ValidatorFn = (group: AbstractControl): { [key: string]: boolean } | null => {
    const password = group.get('password')?.value;
    const repPassword = group.get('repPassword')?.value;

    return password === repPassword ? null : { passwordsMismatch: true };
  };
  formEmployee: FormGroup;
  roleList: RoleViewModel[] = [];
  isCreate: string = "";
  id: number;
  ngOnInit(): void {
    this.GetAllRoles();
    if (this.id != 0) {
      this.isCreate = 'Editar';
    } else {
      this.isCreate = 'Agregar';
    }
  }
  GetAllRoles() {
    this.roleService.GetAll().subscribe(r => {
      if (r.WasSuccessful) {
        this.roleList = r.Data;
      } else {
        this.toastr.error("No se encontraron roles disponibles");
      }
    })
  }
  CreateOrEdit() {
    const model: EmployeeRequest = {
      RoleId: this.formEmployee.value.role,
      Name: this.formEmployee.value.name,
      LastName: this.formEmployee.value.lastName,
      DocumentNumber: this.formEmployee.value.documentNumber,
      UserName: this.formEmployee.value.userName,
      Password: this.formEmployee.value.password,
      DateOfBirth: this.formEmployee.value.dateOfBirth,
      DateOfJoin: this.formEmployee.value.dateOfJoin,
      CreatedBy: this.formEmployee.value.createdBy,
    };
    if (this.id == null) {
      this.employeeService.Create(model).subscribe(r => {
        if (r.WasSuccessful) {
          this.toastr.success(r.StatusMessage);
          this.router.navigate(['/comfig/employee']);
        } else {
          this.toastr.success(r.StatusMessage);
        }
      })
    } else {
      model.Id = this.id;
      this.employeeService.Update(model).subscribe(r => {
        if (r.WasSuccessful) {
          this.toastr.success(r.StatusMessage);
          this.router.navigate(['/comfig/employee']);
        } else {
          this.toastr.success(r.StatusMessage);
        }
      })
    }
  }
}
