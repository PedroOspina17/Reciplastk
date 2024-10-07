import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomerService } from '../../../services/customer.service';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { QuerisWeightControlModel } from '../../../models/QuerisWeightControlModel';

@Component({
  selector: 'app-querie-weight-control',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    LoaderComponent,
  ],
  templateUrl: './querie-weight-control.component.html',
  styleUrl: './querie-weight-control.component.css',
})
export class QuerieWeightControlComponent {
  constructor(
    private fb: FormBuilder,
    private customerServises: CustomerService,
    private router: Router,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService
  ) {
    this.FormGroupControl = this.fb.group({
      StartDate: ['', Validators.required],
      EndtDate: ['', Validators.required],
      EmployeeList: ['-1', Validators.required],
      ProductsList: ['-1', Validators.required],
      ispaid: [false, Validators.required],
      type: ['-1', Validators.required],
    });
  }
  EmployeList: any[] = [];
  ProductList: any[] = [];
  typeList: any[] = [];
  FormGroupControl: FormGroup;
  ShowTable: boolean = false;
  ShowList() {
    const model: QuerisWeightControlModel = {
      StartDate: this.FormGroupControl.value.StartDate,
      EndtDate: this.FormGroupControl.value.EndtDate,
      EmployeeList: this.FormGroupControl.value.EmployeeList,
      ProductsList: this.FormGroupControl.value.ProductsList,
      ispaid: this.FormGroupControl.value.ispaid,
      type: this.FormGroupControl.value.type,
    };
    console.log(model);
    this.ShowTable = true;
    console.log(this.FormGroupControl);
  }
  findName() {}
}
