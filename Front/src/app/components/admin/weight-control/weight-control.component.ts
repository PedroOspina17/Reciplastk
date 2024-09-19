import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  NgModel,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsModel } from '../../../models/ProductsModel';
import { ProductsService } from '../../../services/products.service';

@Component({
  selector: 'app-weight-control',
  standalone: true,
  imports: [
    RouterLink,
    LoaderComponent,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
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
  ) {}
  employeeList: any[] = [];
  generalProductList: ProductsModel[] = [];
  ngOnInit(): void {
    this.GetEmployyes();
    this.GetGeneralProducts();
  }
  GetEmployyes() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.employeeList = r.data;
        console.log("Empleados: ",this.employeeList);
      } else {
        this.toastr.info('No se encontro ningun empleado');
      }
    });
  }
  GetGeneralProducts(){
    this.productsService.GetGeneralProducts().subscribe(r=>{
      if (r.wasSuccessful == true) {
        this.generalProductList = r.data
        console.log("Productos generales: ",this.generalProductList)
      } else {
        this.toastr.info('No se encontro ningun producto general');
      }
    })
  }
}
