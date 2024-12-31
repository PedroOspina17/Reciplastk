import { Component } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductModel } from '../../../models/ProductModel';
import { WeightControlService } from '../../../services/weight-control-service';
import { CommonModule } from '@angular/common';

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
    private productsService: ProductsService) { 
      this.formSelect = this.fb.group({
        Employee: [-1],
        Product: [-1],
        price:[],
      })
    }

  formSelect: FormGroup;
  SpecificProductsList: ProductModel[] = [];
  employeeList: any[] = [];

  ngOnInit(): void {
    this.GetEmployee();
    this.GetProduct();
  }
  seeform(){
    console.log(this.formSelect.value);
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
