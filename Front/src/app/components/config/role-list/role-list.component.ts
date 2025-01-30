import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from '../../../services/role.service';
import { RoleViewModel } from '../../../models/RoleViewModel';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-role-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './role-list.component.html',
  styleUrl: './role-list.component.css'
})
export class RoleListComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private roleService: RoleService,
  ) {
    this.formRoles = this.fb.group({
      role: ['', Validators.required]
    })
  }
  formRoles: FormGroup;
  rolesList: RoleViewModel[] = [];
  showCreate: boolean = false;
  DeletePopUp: boolean = false;
  ngOnInit(): void {
    this.GetAllRoles();
  }
  GetAllRoles() {
    this.roleService.GetAll().subscribe(r => {
      if (r.WasSuccessful) {
        this.rolesList = r.Data;
      } else {
        this.toastr.info(r.StatusMessage);
      }
    })
  }
  ShowRole() {
    this.showCreate = true;
  }
  CancelRole() {
    this.showCreate = false;
    this.formRoles.reset();
  }
  SaveRole() {
    const roleModel: RoleViewModel = {
      Name: this.formRoles.value.role,
    }
    this.roleService.Create(roleModel).subscribe(r => {
      if (r.WasSuccessful) {
        this.toastr.success(r.StatusMessage);
        this.formRoles.reset();
        this.showCreate = false;
        this.GetAllRoles();
      } else {
        this.toastr.error(r.StatusMessage);
      }
    })
  }
  Delete(roleId: number) {

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
        this.roleService.Delete(roleId).subscribe(r => {
          if (r.WasSuccessful) {
            this.toastr.success(r.StatusMessage);
            this.GetAllRoles();
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
