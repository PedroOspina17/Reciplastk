import { Component } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductModel } from '../../../models/ProductModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { CommonModule } from '@angular/common';
import { PayrollconfigService } from '../../../services/payrollconfig.service';
import { PayrollConfig } from '../../../models/PayrollConfigViewModel';
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
  SpecificProductsList: ProductModel[] = [];
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
    const payrollConfig: PayrollConfig = {
      employeeId: this.formSelect.value.Employee,
      productId: this.formSelect.value.Product,
      showAll: this.showAll
    };
    this.payrollconfigService.Filter(payrollConfig).subscribe(r => {
      if (r.wasSuccessful) {
        this.payrollConfigList = r.data
      } else {
        this.toastr.info(r.statusMessage);
      }
    })
  }
  GetProduct() {
    this.productsService.GetSpecificProducts().subscribe(r => {
      if (r.wasSuccessful) {
        this.SpecificProductsList = r.data;
      } else {
        this.toastr.info(r.statusMessage);
      }
    })
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
  saveConfig() {
    const model: PayrollConfig = {
      productId: this.formSelect.value.Product,
      employeeId: this.formSelect.value.Employee,
      pricePerKilo: this.formSelect.value.price,
    }
    this.payrollconfigService.Create(model).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage)
        this.Filter()
        this.formSelect.reset({
          Product: -1,
          Employee: -1,
        });
      } else {
        this.toastr.error(r.statusMessage)
      }
    })
  }

}
