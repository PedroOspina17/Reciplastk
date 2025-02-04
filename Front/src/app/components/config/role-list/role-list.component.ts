import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from '../../../services/role.service';
import { RoleViewModel } from '../../../models/ViewModel/RoleViewModel';
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
    this.FormRoles = this.fb.group({
      role: ['', Validators.required]
    })
  }
  FormRoles: FormGroup;
  RolesList: RoleViewModel[] = [];
  ShowCreate: boolean = false;
  UpdateRole: boolean = false;
  DeletePopUp: boolean = false;
  Id: number = -1;
  ngOnInit(): void {
    this.GetAllRoles();
  }
  GetAllRoles() {
    this.roleService.GetAll().subscribe(r => {
      if (r.WasSuccessful) {
        this.RolesList = r.Data;
      } else {
        this.toastr.info(r.StatusMessage);
      }
    })
  }
  ShowRole() {
    this.ShowCreate = true;
  }
  CancelRole() {
    this.ShowCreate = false;
    this.FormRoles.reset();
  }
  SaveRole() {
    const RoleModel: RoleViewModel = {
      Name: this.FormRoles.value.role,
    }
    if (this.UpdateRole) {
      RoleModel.Id = this.Id;
      this.roleService.Update(RoleModel).subscribe(r => {
        if (r.WasSuccessful) {
          this.toastr.success(r.StatusMessage);
          this.GetAllRoles();
          this.CancelRole();
        } else {
          this.toastr.success(r.StatusMessage)
        }
      })
    } else {
      this.roleService.Create(RoleModel).subscribe(r => {
        if (r.WasSuccessful) {
          this.toastr.success(r.StatusMessage);
          this.FormRoles.reset();
          this.ShowCreate = false;
          this.GetAllRoles();
        } else {
          this.toastr.error(r.StatusMessage);
        }
      })
    }
  }
  Update(Id: number) {
    this.UpdateRole = true;
    this.ShowRole();
    this.Id = Id;
    this.roleService.GetById(Id).subscribe(r => {
      if (r.WasSuccessful) {
        const role = r.Data;
        this.FormRoles.patchValue({
          role: role.Name,
        });
      } else {
        this.toastr.error("No se encontro el rol seleccionado en la base de datos")
      }
    })
  }
  Delete(Id: number) {

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
        this.roleService.Delete(Id).subscribe(r => {
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
