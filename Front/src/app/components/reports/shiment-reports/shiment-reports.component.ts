import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ShipmentReportParamsModel } from '../../../models/ShipmentReportParamsModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsService } from '../../../services/products.service';
import { ShipmentTypeService } from '../../../services/shipment-type.service';
import { ShipmentReports } from '../../../models/ShipmentReports';
import { ShipmentService } from '../../../services/shipment.service';

@Component({
  selector: 'app-shiment-reports',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
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
    private shipmentTypeService: ShipmentTypeService,
    private shipmentService: ShipmentService
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
  isVisible: boolean = false;
  FormShipment: FormGroup;
  EmployeeList: any[] = [];
  ProductList: any[] = [];
  ShipmentTypeList: any[] = [];
  ShipmentReports: ShipmentReports[] = [];
  Filter() {
    const Model: ShipmentReportParamsModel = {
      startDate: this.FormShipment.value.StartDate,
      endDate: this.FormShipment.value.EndDate,
      employeeId: this.FormShipment.value.EmployeeId,
      productId: this.FormShipment.value.ProductId,
      isPaid: this.FormShipment.value.IsPaid,
      type: this.FormShipment.value.TypeId,
    };
    this.shipmentService.Filter(Model).subscribe((r) => {
      if (r.wasSuccessful) {
        this.ShipmentReports = r.data;
      } else {
        this.toastr.error(
          'No se encontraron los detalles con los filtros aplicado'
        );
      }
    });
    this.isVisible = true;
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
