import { Component } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductsRequest } from '../../../models/Requests/ProductsRequest';
import { WeightControlService } from '../../../services/weight-control-service';
import { CommonModule } from '@angular/common';
import { PayrollconfigService } from '../../../services/payrollconfig.service';
import { PayrollConfigRequest } from '../../../models/Requests/PayrollConfigRequest';
import { PayrollConfigParams } from '../../../models/PayrollConfigParams';

@Component({
  selector: 'app-material-processing-prices',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './material-processing-prices.component.html',
  styleUrl: './material-processing-prices.component.css'
})
export class MaterialProcessingPricesComponent {
  constructor(
    private fb: FormBuilder,
    private weightControlService: WeightControlService,
    private toastr: ToastrService,
    private productsService: ProductsService,
    private payrollconfigService: PayrollconfigService
  ) {
    this.formSelect = this.fb.group({
      Employee: [-1],
      Product: [-1],
      price: []
    })
  }
  formSelect: FormGroup;
  SpecificProductsList: ProductsRequest[] = [];
  payrollConfigList: PayrollConfigParams[] = [];
  employeeList: any[] = [];
  employeeId: number = -1;
  productId: number = -1;
  showAll?: boolean;
  ngOnInit(): void {
    this.GetEmployee();
    this.GetProduct();
    this.Filter();
  }
  validation(): boolean {
    if (this.formSelect.value.Employee != -1 && this.formSelect.value.Product != -1 && this.formSelect.value.price != null) {
      return true;
    } else {
      return false;
    }
  }
  OnChecboxChange(event: Event) {
    const checkbox = event.target as HTMLInputElement;
    this.showAll = checkbox.checked;
    this.Filter();
  }
  Filter() {
    const payrollConfig: PayrollConfigRequest = {
      EmployeeId: this.formSelect.value.Employee,
      Id: this.formSelect.value.Product,
      ShowAll: this.showAll
    };
    this.payrollconfigService.Filter(payrollConfig).subscribe(r => {
      if (r.WasSuccessful) {
        this.payrollConfigList = r.Data
      } else {
        this.toastr.info(r.StatusMessage);
      }
    })
  }
  GetProduct() {
    this.productsService.GetSpecificProducts().subscribe(r => {
      if (r.WasSuccessful) {
        this.SpecificProductsList = r.Data;
      } else {
        this.toastr.info(r.StatusMessage);
      }
    })
  }
  GetEmployee() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.employeeList = r.Data;
      } else {
        this.toastr.info('No se encontro ningun empleado');
      }
    });
  }
  saveConfig() {
    const model: PayrollConfigRequest = {
      Id: this.formSelect.value.Product,
      EmployeeId: this.formSelect.value.Employee,
      PricePerKilo: this.formSelect.value.price,
    }
    this.payrollconfigService.Create(model).subscribe(r => {
      if (r.WasSuccessful) {
        this.toastr.success(r.StatusMessage)
        this.Filter()
        this.formSelect.reset({
          Product: -1,
          Employee: -1,
        });
      } else {
        this.toastr.error(r.StatusMessage)
      }
    })
  }

}
