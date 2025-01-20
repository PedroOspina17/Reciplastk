import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { RoleService } from '../../../services/role.service';
import { RoleViewModel } from '../../../models/RoleViewModel';

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
      role: ['',Validators.required]
    })
  }
  formRoles: FormGroup;
  rolesList: RoleViewModel[] = [];
  showCreate: boolean = false;
  ngOnInit(): void {
    this.GetAllRoles();
  }
  GetAllRoles() {
    this.roleService.GetAll().subscribe(r => {
      if (r.wasSuccessful) {
        this.rolesList = r.data;
      } else {
        this.toastr.info(r.statusMessage);
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
      name: this.formRoles.value.role,
    }
    console.log('RoleModel',roleModel)
    this.roleService.Create(roleModel).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage);
        this.formRoles.reset();
        this.showCreate = false;
        this.GetAllRoles();
      } else {
        this.toastr.error(r.statusMessage);
      }
    })
  }
  Delete(roleId: number) {
    this.roleService.Delete(roleId).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage);
        this.GetAllRoles();
      } else {
        this.toastr.error(r.statusMessage);
      }
    })
  }
}
