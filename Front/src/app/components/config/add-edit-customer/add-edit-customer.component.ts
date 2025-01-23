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
import { CustomerViewModel } from '../../../models/CustomerModel';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { CustomerTypeModel } from '../../../models/CustomerTypeModel';
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
  customertypeList: CustomerTypeModel[] = [];
  //customeTypeEnum = CustomeTypeEnum;
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
      if (r.wasSuccessful == true) {
        this.customertypeList = r.data
      } else {
        this.toastr.info(r.statusMessage)
      }
    })
  }

  GetCustomer(customerId: number) {
    this.customerServises.GetProvider(customerId).subscribe((result) => {
      if (result.wasSuccessful) {
        this.formCustomer.setValue({
          nit: result.data.nit,
          customertypeid: result.data.customertypeid,
          name: result.data.name,
          lastname: result.data.lastname,
          address: result.data.address,
          cell: result.data.cell,
          needspickup: result.data.needspickup,
          clientsince: formatDate(
            result.data.clientsince,
            'yyyy-MM-dd',
            this.locale
          ),
        });
      } else {
        this.customerServises.GetCustomer(customerId).subscribe((result) => {
          if (result.wasSuccessful) {
            this.formCustomer.setValue({
              nit: result.data.nit,
              customertypeid: result.data.customertypeid,
              name: result.data.name,
              lastname: result.data.lastname,
              address: result.data.address,
              cell: result.data.cell,
              needspickup: result.data.needspickup,
              clientsince: formatDate(
                result.data.clientsince,
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
      nit: this.formCustomer.value.nit,
      customertypeid: this.formCustomer.value.customertypeid,
      name: this.formCustomer.value.name,
      lastname: this.formCustomer.value.lastname,
      address: this.formCustomer.value.address,
      cell: this.formCustomer.value.cell,
      needspickup: this.formCustomer.value.needspickup,
      clientsince: this.formCustomer.value.clientsince,
    };
    if (this.id != 0) {
      customer.customerid = this.id;
      this.customerServises
        .Update(customer, this.id)
        .subscribe((result) => {
          if (result.wasSuccessful == true) {
            this.loader = false;
            this.toastr.success(
              `El cliente ${customer.name} fue modificado exitosamente`,
              'Felicitaciones'
            );
            this.router.navigate(['/config/customer']);
          } else {
            this.loader = false;
            this.toastr.error(result.statusMessage, 'Error');
            this.router.navigate(['/config/customer']);
          }
        });
    } else {
      this.customerServises.Create(customer).subscribe((result) => {
        if (result.wasSuccessful) {
          this.loader = false;
          this.toastr.success(result.statusMessage, 'Felicitaciones');
          this.router.navigate(['/config/customer']);
        } else {
          this.loader = false;
          this.toastr.error(result.statusMessage, 'Error');          
        }
      });
    }
  }
}
