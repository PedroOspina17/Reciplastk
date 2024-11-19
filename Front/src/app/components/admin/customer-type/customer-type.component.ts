import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CustomerTypeModel } from '../../../models/CustomerTypeModel';
import { CustomerTypeService } from '../../../services/customer-type.service';

@Component({
  selector: 'app-customer-type',
  standalone: true,
  imports: [RouterLink, LoaderComponent, CommonModule],
  templateUrl: './customer-type.component.html',
  styleUrl: './customer-type.component.css',
})
export class CustomerTypeComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private customerTypeService: CustomerTypeService,
    private toastr: ToastrService
  ) {}
  customertypelist: CustomerTypeModel[] = [];
  ngOnInit(): void {
    this.GetAll();
  }
  GetAll() {
    this.customerTypeService.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.customertypelist = r.data;
      } else {
        this.toastr.info(r.statusMessage);
      }
    });
  }
  Delete(id: number) {
    this.customerTypeService.Delete(id).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.toastr.info(r.statusMessage);
      } else {
        this.toastr.error(r.statusMessage, 'Error');
      }
      this.GetAll();
    });
  }
}
