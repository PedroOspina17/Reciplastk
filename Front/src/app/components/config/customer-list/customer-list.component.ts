import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { CustomerService } from '../../../services/customer.service';
import { CustomerViewModel } from '../../../models/CustomerModel';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css',
  imports: [RouterLink, LoaderComponent, CommonModule],
})
export class CustomerListComponent {
  CustomerList: CustomerViewModel[] = [];
  loader: boolean = false;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private customerService: CustomerService,
    private toastr: ToastrService
  ) {}
  ngOnInit(): void {
    this.ShowAllCustomers();
  }
  ShowAllCustomers() {
    this.loader = true;
    this.customerService.ShowAllCustomers().subscribe((result) => {
      if (result.wasSuccessful == true) {
        this.CustomerList = result.data;
        this.loader = false;
      } else {
        this.toastr.info('No se encontro ningun cliente');
      }
    });
  }

  DeleteCustomer(customerId: number) {
    this.loader = true;
    this.customerService.DeleteCustomer(customerId).subscribe((result) => {
      if (result.wasSuccessful) {
        this.loader = false;
        this.toastr.info(result.statusMessage, 'Cliente eliminado');
      } else {
        this.toastr.error(result.statusMessage, 'error');
      }
      this.ShowAllCustomers();
    });
  }
}
