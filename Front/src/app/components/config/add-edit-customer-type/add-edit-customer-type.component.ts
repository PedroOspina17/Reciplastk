import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { RouterLink, Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomerTypeRequest } from '../../../models/Requests/CustomerTypeRequest';
import { CustomerTypeService } from '../../../services/customer-type.service';

@Component({
  selector: 'app-add-edit-customer-type',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './add-edit-customer-type.component.html',
  styleUrl: './add-edit-customer-type.component.css',
})
export class AddEditCustomerTypeComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private customerTypeService: CustomerTypeService,
    private toastr: ToastrService,
    private aRoute: ActivatedRoute
  ) {
    this.FormCustomer = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(50)]],
      description: ['', Validators.maxLength(100)],
      isactive: [true],
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  edit: string = 'Editar';
  id: number;
  FormCustomer: FormGroup;
  ngOnInit(): void {
    if (this.id == 0) {
      this.edit = 'Agregar';
    } else {
      this.edit = 'Editar';
      this.GetById(this.id);
    }
  }
  AddEditCustomer() {
    const customermodel: CustomerTypeRequest = {
      Name: this.FormCustomer.value.name,
      Description: this.FormCustomer.value.description,
      IsActive: this.FormCustomer.value.isactive,
    };
    if (this.id == 0) {
      this.customerTypeService.Create(customermodel).subscribe((r) => {
        if (r.WasSuccessful == true) {
          this.toastr.success(r.StatusMessage);
          this.router.navigate(['/config/CustomerTypeComponent']);
        } else {
          this.toastr.error(r.StatusMessage, 'Error');
        }
      });
    } else {
      customermodel.Id = this.id;
      this.customerTypeService.Update(customermodel, this.id).subscribe((r) => {
        if (r.WasSuccessful == true) {
          this.toastr.success(r.StatusMessage);
          this.router.navigate(['/config/CustomerTypeComponent']);
        } else {
          this.toastr.error(r.StatusMessage, 'Error');
        }
      });
    }
  }

  GetById(id: number) {
    this.customerTypeService.GetById(id).subscribe((result) => {
      if (result.WasSuccessful == true) {
        this.FormCustomer.setValue({
          name: result.Data.name,
          description: result.Data.description,
          isactive: result.Data.isactive
        });
      } else {
        this.toastr.error(result.Data);
      }
    });
  }

}
