import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ShipmentReportRequest } from '../../../models/Requests/ShipmentReportRequest';
import { WeightControlService } from '../../../services/weight-control-service';
import { ProductsService } from '../../../services/products.service';
import { ShipmentTypeService } from '../../../services/shipment-type.service';
import { ShipmentReportViewModel } from '../../../models/ViewModel/ShipmentReportViewModel';
import { ShipmentService } from '../../../services/shipment.service';
import { EmployeeService } from '../../../services/employee.service';
import { EmployeeParams } from '../../../models/EmployeeParams';

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
    private shipmentService: ShipmentService,
    private employeeService: EmployeeService,

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
  EmployeeList: EmployeeParams[] = [];
  ProductList: any[] = [];
  ShipmentTypeList: any[] = [];
  ShipmentReports: ShipmentReportViewModel[] = [];
  Filter() {
    const Model: ShipmentReportRequest = {
      StartDate: this.FormShipment.value.StartDate,
      EndDate: this.FormShipment.value.EndDate,
      EmployeeId: this.FormShipment.value.EmployeeId,
      ProductId: this.FormShipment.value.ProductId,
      IsPaid: this.FormShipment.value.IsPaid,
      Type: this.FormShipment.value.TypeId,
    };
    this.shipmentService.Filter(Model).subscribe((r) => {
      if (r.WasSuccessful) {
        this.ShipmentReports = r.Data;
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
    this.employeeService.GetAll().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.EmployeeList = r.Data;
      } else {
        this.toastr.error('No se encontro ningun empleado');
      }
    });
    this.productService.GetAll().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.ProductList = r.Data;
      } else {
        this.toastr.error('No se encontro ningun Producto');
      }
    });
    this.shipmentTypeService.GetAll().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.ShipmentTypeList = r.Data;
      } else {
        this.toastr.error('No se encontro ningun tipo de cargamento');
      }
    });
  }
}
