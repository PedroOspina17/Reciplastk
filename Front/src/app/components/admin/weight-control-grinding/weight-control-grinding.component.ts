import { Component } from '@angular/core';
import { WeightControlService } from '../../../services/weight-control-service';
import { WeightControlGrindingModel } from '../../../models/WeightControlGrindingModel';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import {  } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { ProductsService } from '../../../services/products.service';
import { ProductsModel } from '../../../models/ProductsModel';


@Component({
  selector: 'app-weight-control-grinding',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './weight-control-grinding.component.html',
  styleUrl: './weight-control-grinding.component.css',
  providers: [DatePipe],
})
export class WeightControlGrindingComponent {
    constructor(
      private weightControlService: WeightControlService,
      private fb: FormBuilder,
      private toastr: ToastrService,
      private datePipe: DatePipe,
      private products: ProductsService
    ) {
    this.FormSelection = this.fb.group({
      ProductSelection: ['-1', Validators.required],
      ColorSelection: [{ value: '-1', disabled: true }, Validators.required],
    });
    this.FormRemaining = this.fb.group({
      Package: ['', Validators.required],
      Spare: ['', Validators.required],
    });
    const today = new Date();
    this.formattedDate = this.datePipe.transform(today, 'MMMM/d/y');
  }
  weightControlId: number = -1;
  totalweight: number = 0;
  productid: number = -1;
  productName: string = '';
  specificproductid: number = -1;
  showRemaining: boolean = false;
  isVisible: boolean = false;
  FormSelection: FormGroup;
  FormRemaining: FormGroup;
  todaysProductList: any[] = [];
  generalProductList: ProductsModel[] = [];
  specificProductList: ProductsModel[] = [];
  filterProductList: ProductsModel[] = [];
  formattedDate: string | null = '';
  ngOnInit(): void {
    this.getProducts();
    this.GetTodaysDetails();
  }
  onProductChange(value: any) {
    const selectElement = value.target;
    this.productid = selectElement.value;
    this.filterProductList = this.specificProductList.filter(
      (p) => p.pid == this.productid
    );
    this.FormSelection.get('ColorSelection')?.enable();
  }
  onColorChange(value: any) {
    const selectElement = value.target;
    this.specificproductid = selectElement.value;
    this.productName = selectElement.options[selectElement.selectedIndex].text;
    this.isVisible = false;
    if (this.specificproductid != -1) {
      this.isVisible = true;
    }
  }
  SaveRemainig() {
    const remainingModel: WeightControlGrindingModel = {
      ProductId: this.specificproductid,
      PackageCount: this.FormRemaining.value.Package,
      Remainig: this.FormRemaining.value.Spare,
    };
    this.weightControlService.CreateGrinding(remainingModel).subscribe((p) => {
      if (p.wasSuccessful == true) {
        this.toastr.success(p.statusMessage);
        this.ClearForm();
        this.GetTodaysDetails();
        console.log('Productos:', this.todaysProductList);
      } else {
        this.toastr.error('No se puedo crear el producto');
      }
      this.isVisible = false;
    });
  }
  ClearForm() {
    this.isVisible = false;
    this.FormSelection = this.fb.group({
      ProductSelection: ['-1', Validators.required],
      ColorSelection: [{ value: '-1', disabled: true }, Validators.required],
    });
    this.FormRemaining.reset();
  }
  getProducts() {
    this.products.GetGeneralProducts().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.generalProductList = r.data;
      } else {
        this.toastr.info('No se encontro ningun producto general');
      }
    });
    this.products.GetSpecificProducts().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.specificProductList = r.data;
      } else {
        this.toastr.info('No se encontro ningun producto general');
      }
    });
  }
  GetTodaysDetails() {
    this.totalweight = 0;
    this.weightControlService.GetGroundProducts().subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.todaysProductList = r.data;
        this.todaysProductList.forEach((element) => {
          this.totalweight += element.weight;
        });
      } else {
        this.toastr.error(r.statusMessage);
      }
    });
  }
  DeleteRemaining(id: number) {
    console.log('id: ', id);
    this.weightControlService.Delete(id).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.toastr.info('Elemento eliminado con exito');
        this.GetTodaysDetails();
      } else {
        this.toastr.info(r.statusMessage);
      }
    });
  }
}
