import { CommonModule, formatDate } from '@angular/common';
import { Component, Inject, LOCALE_ID } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CustomerService } from '../../../services/customer.service';
import { CustomerViewModel } from '../../../models/ViewModel/CustomerViewModel';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { CustomerTypeRequest } from '../../../models/Requests/CustomerTypeRequest';
import { CustomerTypeService } from '../../../services/customer-type.service';

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
  customertypeList: CustomerTypeRequest[] = [];
  constructor(
    private fb: FormBuilder,
    private customerServises: CustomerService,
    private customerTypeService: CustomerTypeService,
    private router: Router,
    private aRoute: ActivatedRoute,
    private toastr: ToastrService,
    @Inject(LOCALE_ID) public locale: string
  ) {
    this.formCustomer = this.fb.group({
      nit: ['', [Validators.required, Validators.maxLength(50)]],
      customertypeid: [-1, Validators.required],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      lastname: ['', [Validators.required, Validators.maxLength(50)]],
      address: ['', [Validators.required, Validators.maxLength(50)]],
      cell: ['', [Validators.required, Validators.maxLength(20)]],
      needspickup: [,],
      clientsince: [null, Validators.required],
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }
  ngOnInit(): void {
    this.getCustomerType();
    if (this.id != 0) {
      this.operacion = 'Editar';
      this.GetCustomer(this.id);
    } else {
      this.operacion = 'Agregar';
    }
  }
  getCustomerType() {
    this.customerTypeService.GetAll().subscribe(r => {
      if (r.WasSuccessful == true) {
        this.customertypeList = r.Data
      } else {
        this.toastr.info(r.StatusMessage)
      }
    })
  }

  GetCustomer(customerId: number) {
    this.customerServises.GetProvider(customerId).subscribe((result) => {
      if (result.WasSuccessful) {
        this.formCustomer.setValue({
          nit: result.Data.nit,
          customertypeid: result.Data.customertypeid,
          name: result.Data.name,
          lastname: result.Data.lastname,
          address: result.Data.address,
          cell: result.Data.cell,
          needspickup: result.Data.needspickup,
          clientsince: formatDate(
            result.Data.clientsince,
            'yyyy-MM-dd',
            this.locale
          ),
        });
      } else {
        this.customerServises.GetCustomer(customerId).subscribe((result) => {
          if (result.WasSuccessful) {
            this.formCustomer.setValue({
              nit: result.Data.nit,
              customertypeid: result.Data.customertypeid,
              name: result.Data.name,
              lastname: result.Data.lastname,
              address: result.Data.address,
              cell: result.Data.cell,
              needspickup: result.Data.needspickup,
              clientsince: formatDate(
                result.Data.clientsince,
                'yyyy-MM-dd',
                this.locale
              ),
            });
          } else {
            this.toastr.error("Informacion incorrecta")
          }
        });
      }
    });
  }

  AddEditCustomer() {
    this.loader = true;
    const customer: CustomerViewModel = {
      Nit: this.formCustomer.value.nit,
      CustomerTypeId: this.formCustomer.value.customertypeid,
      Name: this.formCustomer.value.name,
      LastName: this.formCustomer.value.lastname,
      Address: this.formCustomer.value.address,
      Cell: this.formCustomer.value.cell,
      NeedsPickUp: this.formCustomer.value.needspickup,
      ClientSince: this.formCustomer.value.clientsince,
    };
    if (this.id != 0) {
      customer.Id = this.id;
      this.customerServises
        .Update(customer, this.id)
        .subscribe((result) => {
          if (result.WasSuccessful == true) {
            this.loader = false;
            this.toastr.success(
              `El cliente ${customer.Name} fue modificado exitosamente`,
              'Felicitaciones'
            );
            this.router.navigate(['/config/customer']);
          } else {
            this.loader = false;
            this.toastr.error(result.StatusMessage, 'Error');
            this.router.navigate(['/config/customer']);
          }
        });
    } else {
      this.customerServises.Create(customer).subscribe((result) => {
        if (result.WasSuccessful) {
          this.loader = false;
          this.toastr.success(result.StatusMessage, 'Felicitaciones');
          this.router.navigate(['/config/customer']);
        } else {
          this.loader = false;
          this.toastr.error(result.StatusMessage, 'Error');          
        }
      });
    }
  }
}
