import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsService } from '../../../services/products.service';
import { WeightControlDetailComponent } from '../weight-control-detail/weight-control-detail.component';
import Swal from 'sweetalert2';
import { ProductsRequest } from '../../../models/Requests/ProductsRequest';

@Component({
  selector: 'app-weight-control',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    WeightControlDetailComponent,
  ],
  templateUrl: './weight-control.component.html',
  styleUrl: './weight-control.component.css',
})
export class WeightControlComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private toastr: ToastrService,
    private weightControlService: WeightControlService,
    private productsService: ProductsService
  ) { }
  disable: boolean = true;
  employeeList: any[] = [];
  generalProductList: ProductsRequest[] = [];
  employeeid: number = -1;
  employeename: string = '';
  productid: number = -1;
  productname: string = '';
  showDetail: boolean = false;
  edit: boolean = false;
  ngOnInit(): void {
    this.GetEmployee();
    this.GetGeneralProducts();
  }
  GetEmployee() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.employeeList = r.data;
      } else {
        this.toastr.info('No se encontro ningun empleado');
      }
    });
  }
  GetGeneralProducts() {
    this.productsService.GetMain().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.generalProductList = r.data;
      } else {
        this.toastr.info('No se encontro ningun producto general');
      }
    });
  }
  onEmployeChange(value: any) {
    const selectElement = value.target as HTMLSelectElement;
    this.employeeid = value.target.value;
    this.employeename = selectElement.options[selectElement.selectedIndex].text;
  }
  onProductChange(value: any) {
    const selectElement = value.target as HTMLSelectElement;
    this.productid = value.target.value;
    this.productname = selectElement.options[selectElement.selectedIndex].text;
    if (this.productid != -1) {
      this.showDetail = true;
    } else {
      this.showDetail = true;
    }
  }
  edittype() {
    this.edit = true;
    Swal.fire({
      title: '¿Estás seguro?',
      text: 'Esto borrara todos los datos previamente almacenados en la tabla.',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#FFA500 ',
      cancelButtonColor: '#6c757d',
      confirmButtonText: 'Sí, habilitar',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.edit = true;
        this.Clear();
      } else {
        this.edit = false;
      }
    });
  }
  Clear() {
    this.employeeid = -1;
    this.productid = -1;
    this.showDetail = false;
  }
}
