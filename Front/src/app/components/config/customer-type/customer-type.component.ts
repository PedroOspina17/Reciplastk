import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { RouterLink, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomerTypeModel } from '../../../models/CustomerTypeModel';
import { CustomerTypeService } from '../../../services/customer-type.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-customer-type',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './customer-type.component.html',
  styleUrl: './customer-type.component.css',
})
export class CustomerTypeComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private customerTypeService: CustomerTypeService,
    private toastr: ToastrService
  ) { }
  customertypelist: CustomerTypeModel[] = [];
  DeletePopUp: boolean = false;
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
        this.customerTypeService.Delete(id).subscribe((r) => {
          if (r.wasSuccessful == true) {
            this.toastr.info(r.statusMessage);
          } else {
            this.toastr.error(r.statusMessage, 'Error');
          }
          this.GetAll();
        });
      } else {
        this.DeletePopUp = false;
      }
    });
  }
}
