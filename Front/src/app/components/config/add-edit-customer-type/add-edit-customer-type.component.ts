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
        if (r.wasSuccessful == true) {
          this.toastr.success(r.statusMessage);
          this.router.navigate(['/config/CustomerTypeComponent']);
        } else {
          this.toastr.error(r.statusMessage, 'Error');
        }
      });
    } else {
      customermodel.Id = this.id;
      this.customerTypeService.Update(customermodel, this.id).subscribe((r) => {
        if (r.wasSuccessful == true) {
          this.toastr.success(r.statusMessage);
          this.router.navigate(['/config/CustomerTypeComponent']);
        } else {
          this.toastr.error(r.statusMessage, 'Error');
        }
      });
    }
  }

  GetById(id: number) {
    this.customerTypeService.GetById(id).subscribe((result) => {
      if (result.wasSuccessful == true) {
        this.FormCustomer.setValue({
          name: result.data.name,
          description: result.data.description,
          isactive: result.data.isactive
        });
      } else {
        this.toastr.error(result.data);
      }
    });
  }

}
