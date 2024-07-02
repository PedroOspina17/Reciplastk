import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CustomerService } from '../../../services/customer.service';
import { CustomerViewModel } from '../../../models/CustomerViewModel';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { Subscriber } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-customer',
  standalone: true,
  templateUrl: './add-edit-customer.component.html',
  styleUrl: './add-edit-customer.component.css',
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    LoaderComponent,
  ],
})
export class AddEditCustomerComponent {
  formCustomer: FormGroup;
  id: number;
  operacion: string = 'Agregar';
  loader: boolean = false;

  constructor(
    private fb: FormBuilder,
    private customerServises: CustomerService,
    private router: Router,
    private aRoute: ActivatedRoute, //
    private toastr: ToastrService
  ) {
    this.formCustomer = this.fb.group({
      nit: ['', [Validators.required, Validators.maxLength(50)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastname: ['', [Validators.required, Validators.maxLength(50)]],
      address: ['', [Validators.required, Validators.maxLength(50)]],
      cell: ['', [Validators.required, Validators.maxLength(20)]],
      needspickup: [false, Validators.required],
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if (this.id != 0) {
      this.operacion = 'Editar';
      this.GetCustomer(this.id);
    } else {
      this.operacion = 'Agregar';
    }
  }

  GetCustomer(customerId: number) {
    this.customerServises.ShowCustomer(customerId).subscribe((result) => {
      if (result.wasSuccessful) {
        this.formCustomer.setValue({
          nit: result.data.nit,
          name: result.data.name,
          lastname: result.data.lastname,
          address: result.data.address,
          cell: result.data.cell,
          needspickup: result.data.needspickup,
        });
      } else {
        console.log('Informacion incorrecta');
      }
    });
  }

  AddEditCustomer() {
    this.loader = true;
    const customer: CustomerViewModel = {
      nit: this.formCustomer.value.nit,
      name: this.formCustomer.value.name,
      lastname: this.formCustomer.value.lastname,
      address: this.formCustomer.value.address,
      cell: this.formCustomer.value.cell,
      needspickup: this.formCustomer.value.needspickup,
    };
    if (this.id != 0) {
      // Llamar metodo modificar
      debugger;
      customer.customerid = this.id;
      this.customerServises
        .EditCustomer(customer, this.id)
        .subscribe((result) => {
          if (result.wasSuccessful == true) {
            this.loader = false;
            this.toastr.success(
              `El cliente ${customer.name} fue modificado exitosamente`,
              'Felicitaciones'
            );
            this.router.navigate(['/admin/customer']);
          } else {
            this.loader = false;
            this.toastr.error(
              result.statusMessage,
              'Error'
            );
            this.router.navigate(['/admin/customer']);
          }
        });
    } else {
      debugger;
      // Llmar metodo Agregar
      this.customerServises.CreateCustomer(customer).subscribe((result) => {
        if (result.wasSuccessful) {
          this.loader = false;
          this.toastr.success(
            result.statusMessage,
            'Felicitaciones'
          );
          this.router.navigate(['/admin/customer']);
        } else {
          this.loader = false;
          this.toastr.error(
            result.statusMessage,
            'Error'
          );
          this.router.navigate(['/admin/customer']);
        }
      });
    }
  }
}
