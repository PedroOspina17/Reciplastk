import { Component } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductModel } from '../../../models/ProductModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { CommonModule } from '@angular/common';
import { PayrollconfigService } from '../../../services/payrollconfig.service';
import { PayrollConfig } from '../../../models/PayrollConfigViewModel';

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
      Employee: [-1, Validators.required],
      Product: [-1, Validators.required],
      price: [, Validators.required],
    })
  }
  formSelect: FormGroup;
  SpecificProductsList: ProductModel[] = [];
  employeeList: any[] = [];
  ngOnInit(): void {
    this.GetEmployee();
    this.GetProduct();
  }
  saveConfig() {
    console.log(this.formSelect.value);
    const model: PayrollConfig = {
      productId: this.formSelect.value.Product,
      employeeId: this.formSelect.value.Employee,
      pricePerKilo: this.formSelect.value.price,
    }
    console.log('Model', model);
    this.payrollconfigService.Create(model).subscribe(r => {
      if (r.wasSuccessful) {
        this.toastr.success(r.statusMessage)
        this.formSelect.reset({
          Product: -1,
          Employee: -1,
        });
      } else {
        this.toastr.error(r.statusMessage)
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
        console.log(this.employeeList)
      } else {
        this.toastr.info('No se encontro ningun empleado');
      }
    });
  }
}
