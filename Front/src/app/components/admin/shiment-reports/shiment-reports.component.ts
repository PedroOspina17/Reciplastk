import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ShipmentReportParamsModel } from '../../../models/ShipmentReportParamsModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsService } from '../../../services/products.service';
import { ShipmentTypeService } from '../../../services/shipment-type.service';
import { ShipmentReports } from '../../../models/ShipmentReports';

@Component({
  selector: 'app-shiment-reports',
  standalone: true,
  imports: [
    RouterLink,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    LoaderComponent,
  ],
  templateUrl: './shiment-reports.component.html',
  styleUrl: './shiment-reports.component.css',
})
export class ShimentReportsComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private weightControlService: WeightControlService,
    private productService: ProductsService,
    private shipmentTypeService: ShipmentTypeService
  ) {
    this.FormShipment = this.fb.group({
      StartDate: [],
      EndDate: [],
      EmployeeId: [-1],
      ProductId: [-1],
      IsPaid: [],
      TypeId: [-1],
    });
  }
  FormShipment: FormGroup;
  EmployeeList: any[] = [];
  ProductList: any[] = [];
  ShipmentTypeList: any[] = [];
  ShipmentReports: ShipmentReports[] = [];
  Filter() {
    const Model: ShipmentReportParamsModel = {
      StartDate: this.FormShipment.value.StartDate,
      EndDate: this.FormShipment.value.EndDate,
      EmployeeId: this.FormShipment.value.EmployeeId,
      ProductId: this.FormShipment.value.ProductId,
      IsPaid: this.FormShipment.value.IsPaid,
      Type: this.FormShipment.value.TypeId,
    };
    console.log(Model);
  }
  ngOnInit(): void {
    this.GetInfo();
  }
  GetInfo() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.EmployeeList = r.data;
      } else {
        this.toastr.error('No se encontro ningun empleado');
      }
    });
    this.productService.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.ProductList = r.data;
      } else {
        this.toastr.error('No se encontro ningun Producto');
      }
    });
    this.shipmentTypeService.GetAll().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.ShipmentTypeList = r.data;
      } else {
        this.toastr.error('No se encontro ningun tipo de cargamento');
      }
    });
  }
}
