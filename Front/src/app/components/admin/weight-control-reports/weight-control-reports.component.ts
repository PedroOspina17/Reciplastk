import { Component } from '@angular/core';
import { WeightControlReportParams } from '../../../models/WeightControlReportParams';
import {
  FormBuilder,
  Validators,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsModel } from '../../../models/ProductsModel';
import { ProductsService } from '../../../services/products.service';
import { WeightCotrolTypeService } from '../../../services/weight-cotrol-type.service';
import { WeightControlReport } from '../../../models/WeightControlReport';

@Component({
  selector: 'app-weight-control-reports',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    LoaderComponent,
  ],
  templateUrl: './weight-control-reports.component.html',
  styleUrl: './weight-control-reports.component.css',
})
export class WeightControlReportsComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private weightControlService: WeightControlService,
    private productsService: ProductsService,
    private weightControloTypeService: WeightCotrolTypeService
  ) {
    this.FormGroupControl = this.fb.group({
      StartDate: [],
      EndDate: [],
      Employeeid: [-1],
      Productsid: [-1],
      Ispaid: [],
      Typeid: [-1],
    });
  }
  FormGroupControl: FormGroup;
  EmployeValue: string = '';
  ProductValue: string = '';
  TypeValue: string = '';
  ShowTable: boolean = false;
  weightControlReport: WeightControlReport[] = [];
  ProductList: ProductsModel[] = [];
  WeightControlTypeList: any[] = [];
  EmployeeList: any[] = [];
  typeList: any[] = [];
  ngOnInit(): void {
    this.GetInfo();
  }
  Filter() {
    const model: WeightControlReportParams = {
      StartDate: this.FormGroupControl.value.StartDate,
      EndDate: this.FormGroupControl.value.EndDate,
      ProductId: this.FormGroupControl.value.Productsid,
      EmployeeId: this.FormGroupControl.value.Employeeid,
      Ispaid: this.FormGroupControl.value.Ispaid,
      Type: this.FormGroupControl.value.Typeid,
    };
    console.log('Model',model); 
    this.weightControlService.Filter(model).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.weightControlReport = r.data
        console.log(r.data)
        console.log(this.weightControlReport)

        this.ShowTable = true;
      } else {
        this.toastr.error('No se encontraron productos con los filtros aplicados')
      }
    });
    
    console.log(this.FormGroupControl);
  }
  GetInfo() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.EmployeeList = r.data;
      } else {
        this.toastr.info('No se encontraron los empleados');
      }
    });
    this.productsService.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.ProductList = r.data;
      } else {
        this.toastr.info('No se encontraron los productos');
      }
    });
    this.weightControloTypeService.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.WeightControlTypeList = r.data;
      } else {
        this.toastr.info('No se encontraron los tipos de envio');
      }
    });
  }
}
